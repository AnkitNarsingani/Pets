using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fish : LivingEntity
{
	[HideInInspector]
	public Display display;

    void Start()
    {
		display = GameObject.Find("Fish").GetComponent<Display>();
        speechBubbleText = speechBubble.GetComponentInChildren<Text>();
        GetNewAction ();
        display.UpdateReferences(petState);
        display.GetComponent<Timer>().StartTimer();
    }

    new void Update()
    {
		if(base.Update())
        {
            speechBubble.SetActive(false);
            display.GetComponent<Timer>().StopTimer();
            display.timer.text = "";
            StartCoroutine(GetDelayedAction());
        }
    }

	public override void Feed()
	{
		base.Feed ();
		speechBubbleText.text = "Feed me";
    }

    public override void Action()
    {
		
    }

    IEnumerator GetDelayedAction()
    {
        int temp = Random.Range(3, 8);
        yield return new WaitForSeconds(temp);
        GetNewAction();
        display.UpdateReferences(petState);
        display.GetComponent<Timer>().StartTimer();
    }

    public void GetNewAction()
	{
		SetRandomState(ref petState);
		switch(petState)
		{
		case PetState.Action:
			GetNewAction ();
			break;
		case PetState.Hungry:
			Feed();
			break;
		case PetState.Loo:
			GetNewAction ();
			break;
		}
	}

}
