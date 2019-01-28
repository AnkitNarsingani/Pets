using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fish : LivingEntity
{
    [HideInInspector]
    public Display display;

    new void Start()
    {
        base.Start();
        display = GameObject.Find("Fish").GetComponent<Display>();
        display.GetComponent<Timer>().StartTimer();
        GetNewAction();
       
    }

    void Update()
    {
        

    }

    public override void Feed()
    {
        base.Feed();
        speechBubbleText.text = "Feed me";
        display.GetComponent<Timer>().timer = 10;
        display.GetComponent<Timer>().StartTimer();
        GetComponent<FishFeed>().enabled = true;
    }

    public override void Action()
    {
        display.timer.text = "";
      
    }


    public void GetNewAction()
    {
        display.GetComponent<Timer>().timer = 10;
        display.GetComponent<Timer>().StartTimer();

        SetRandomState(ref petState);
        switch (petState)
        {
            case PetState.Action:
                Action();
                break;
            case PetState.Hungry:
                Feed();
                break;
            case PetState.Loo:
                GetNewAction();
                break;
        }
    }

}
