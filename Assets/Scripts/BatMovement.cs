using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Vector3 = UnityEngine.Vector3;

public class BatMovement : MonoBehaviour
{
    public int contactsCounter = 0;
    public TMP_Text batCounter;
    [SerializeField] Camera mainCamera;
    private float batInitialY;
    private float batInitialZ;
    private float distance;
    private float minMaxBound = 3.5f;
    private float timer;
    private float delayTimer = 0.2f;
    

    void Start()
    {
        InitialDistance();
        InitialBatPosition();
    }
    void Update()
    {
        timer -= Time.deltaTime;
        BatMove();
    }

    private void UpdateCounterText(int count)
    {
        batCounter.text = count.ToString();
    }

    private void InitialDistance()
    {
        distance = Vector3.Distance(mainCamera.transform.position, transform.position);
    }

    private void InitialBatPosition()
    {
        batInitialY = transform.position.y;
        batInitialZ = transform.position.z;
    }
    private void BatMove()
    {
        float mousePositionX = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, distance)).x;
        this.transform.position = new Vector3(mousePositionX, batInitialY, batInitialZ);
        if (transform.position.x > minMaxBound)
        {
            transform.position = new Vector3(minMaxBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -minMaxBound)
        {
            transform.position = new Vector3(-minMaxBound, transform.position.y, transform.position.z); 
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ball") && timer <= 0f)
        {
            timer = delayTimer;
            contactsCounter += 1;
            UpdateCounterText(contactsCounter);
        }
    }
}
