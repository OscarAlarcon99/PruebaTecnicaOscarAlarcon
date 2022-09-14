using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public Text ui;
    public bool timerActive;

    
    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime + Time.deltaTime;
            
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            ui.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
    }

    public void RestaurarTiempo(float tiempo)
    {
        currentTime -= tiempo;
    }

    public void StartTimer()
    {
        currentTime = 0;
        timerActive = true;
    }
}
