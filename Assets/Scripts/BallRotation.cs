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
        if (gameStarted)
        {
            BallRotate(); 
        }
    }

    private void BallRotate()
    {
        transform.Rotate(Vector3.right, rotationSpeed);
        RotationSpeedController();
    }

    private void RotationSpeedController()
    {
        rotationSpeed = BallMovement.ballSpeed;
    }
}

