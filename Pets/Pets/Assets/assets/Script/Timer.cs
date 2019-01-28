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
    public int counter;
    

    void Start()
    {
        display = GetComponent<Display>();
        counter = 0;
        
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
                counter++;
              
                if (counter > 3)
                {
                    
                    canTime = false;
                }
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
}
