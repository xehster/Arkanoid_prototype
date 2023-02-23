using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BallMovement : MonoBehaviour
{
    public GameManager GameManager;
    public bool firstStart;
    public float speedCoef = 5f;
    [SerializeField] private float randomDirectionZ;
    [SerializeField] private float randomDirectionX;
    private Vector3 moveDirection;
    private Vector3 previousPosition;
    private float speedAcceleration = 0.1f;
    private float maxSpeed = 7f;
    private float rotateDirection;
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    private void Drop () {
        rigidBody.velocity = moveDirection;
    }
    
    private void Update()
    {
        firstStart = GameManager.firstStart;
        
        if (firstStart)
        {
            InitialBallMove(); 
        }
        BallMove();
    }

    private void FixedUpdate()
    {
        previousPosition = transform.position;
        AngleRandomizer();
    }
    
    
    private void InitialBallMove()
    {
        moveDirection = new Vector3(randomDirectionX, 0f, randomDirectionZ).normalized * speedCoef;
        Drop();
    }

    private void SpeedAcceleration()
    {
        if (speedCoef < maxSpeed)
        {
            speedCoef += speedAcceleration * Time.deltaTime;
        }
    }

    private void AngleRandomizer()
    {
        randomDirectionZ = Random.Range(1, 10);
        randomDirectionX = Random.Range(-3, 3);
    }
    

    [SerializeField] private float maxAngle = 45f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bat"))
        {
            float distance = transform.position.x - other.transform.position.x;
            float maxDistance = other.transform.localScale.x / 2;
            float reflectionAngle = Mathf.Clamp(distance / maxDistance, -1f, 1f) * maxAngle;

            Vector3 reflectionAxis = other.transform.up;
            moveDirection = Vector3.Reflect(moveDirection, reflectionAxis);
            Quaternion rotation = Quaternion.AngleAxis(reflectionAngle, Vector3.up);
            moveDirection = rotation * moveDirection;

            moveDirection = moveDirection.normalized * speedCoef;
            Drop();
        }
    }
    
    private void BallMove()
    {
        Vector3 direction = transform.position - previousPosition;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
        SpeedAcceleration();
                
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.blue);
    }
}
