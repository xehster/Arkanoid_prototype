using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool firstStart;
    
    public void MouseClicked()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            gameStarted = true;
            firstStart = true;
        }
    }
    
    
    public void MouseUnclicked()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            firstStart = false; //не добавляю gameStarted = false для удобства дебага чтобы всегда можно было заново запустить шарик кликом мыши
        }
    }

    private void Update()
    {
        MouseClicked();
        MouseUnclicked();
    }
}
