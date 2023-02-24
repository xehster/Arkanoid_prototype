using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private ObstacleView objectPrefab;
    private int obstacleCount = 10;
    private int minX, maxX, minZ, maxZ;
    private int collisionCount = 0;
    [SerializeField] private TMP_Text scoreCounter;

    void Start()
    {
        ObstacleGenerator();
        SetScoreText(collisionCount);
    }

    private void ObstacleGenerator() //создаю в рандомных местах кубики 
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            int x = Random.Range(-4, 4);
            int z = Random.Range(7, 14);

            Collider[] colliders = Physics.OverlapBox(new Vector3(x, 1, z), Vector3.one * 0.5f);
            if (colliders.Length == 0)
            {
                ObstacleView newObstacle = Instantiate(objectPrefab, new Vector3(x, 0, z), Quaternion.identity);
                newObstacle.ObstacleHitAction += ObstacleHitAction; //подписываюсь на инфу о коллизиях с шариком
            }
            else
            {
                i--;
            }
        }
    }

    private void ObstacleHitAction()
    {
        collisionCount += 1;
        SetScoreText(collisionCount);
    }

    private void SetScoreText(int count)
    {
        scoreCounter.text = "Score " + count;
    }
}
