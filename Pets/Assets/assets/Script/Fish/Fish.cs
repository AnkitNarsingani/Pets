using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fish : LivingEntity
{
    [HideInInspector]
    public Display display;
    public GameObject go;
    new void Start()
    {
        base.Start();
        display = GameObject.Find("Fish").GetComponent<Display>();
        display.GetComponent<Timer>().timer = 10;
        display.GetComponent<Timer>().StartTimer();
        Feed();
        go = GameObject.FindGameObjectWithTag("Finish");



    }

    void Update()
    {


    }

    public override void Feed()
    {

        base.Feed();
        speechBubbleText.text = "Feed me";
        // display.GetComponent<Timer>().timer = 10;
        // display.GetComponent<Timer>().StartTimer();
        GetComponent<FishFeed>().enabled = true;

    }

    public override void Action()
    {


    }



}
