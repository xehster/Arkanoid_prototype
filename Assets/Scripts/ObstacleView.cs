using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleView : MonoBehaviour
{
    public Action ObstacleHitAction; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ObstacleHitAction?.Invoke();
            Destroy(gameObject);
            Debug.Log("collision happened");
        }
    }
}
