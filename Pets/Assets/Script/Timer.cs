using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

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
        if (canTime)
        {
            timer -= Time.deltaTime;
            int Inttext = (int)Math.Ceiling(timer);
            GetComponentInChildren<Text>().text = Inttext.ToString();
            if (timer <= 0)
            {
                //GameOver
                canTime = false;
            }
        }
    }

    public void StartTimer()
    {
        float.TryParse(display.timer.text, out timer);

        if (timer > 0)
        {
            canTime = true;
        }
    }

    public void StopTimer()
    {
        canTime = false;
        timer = 0;
    }
}
