using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    Display display;
    private float timer = 0;
    bool canTime = false;

    void Start()
    {
        display = GetComponent<Display>();
    }

    void Update()
    {
        if(canTime)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                //GameOver
            }
        }
    }

    void StartTimer()
    {
        float.TryParse(display.timer.text, out timer);

        if(timer > 0)
        {
            canTime = true;
        }
    }
}
