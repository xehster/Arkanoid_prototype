using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DeadZoneController : MonoBehaviour
{
    public int deadZoneContactCounter = 0;
    public TMP_Text counterDeadZone;
    private float delayTimer = 0.2f;
    private float timer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && timer <= 0f)
        {
            timer = delayTimer;
            deadZoneContactCounter += 1;        
        }
    }

    private void Update()
    {
        counterDeadZone.text = deadZoneContactCounter.ToString();
        timer -= Time.deltaTime;
    }
}
