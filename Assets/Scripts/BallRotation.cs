using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    private float rotationSpeed;
    public GameManager GameManager;
    public BallMovement BallMovement;
    public bool gameStarted;

    void Update()
    {
        gameStarted = GameManager.gameStarted;
        BallRotate();
    }

    private void BallRotate()
    {
        if (gameStarted)
        {
            transform.Rotate(Vector3.right, rotationSpeed);
            RotationSpeedController();
        }
    }

    private void RotationSpeedController()
    {
        rotationSpeed = BallMovement.speedCoef;
    }
}

