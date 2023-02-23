using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool firstStart;
    public void OnMouseDown()
    {
        gameStarted = true;
        firstStart = true;
    }

    public void OnMouseUp()
    {
        firstStart = false;
    }
}
