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
		base.Start ();
		display = GameObject.Find("Fish").GetComponent<Display>();
		GetNewAction ();
		//speechBubbleText =  speechBubble.GetComponentInChildren<Text> ();
    }

    void Update()
    {
		
    }

	public override void Feed()
	{
		base.Feed ();
		speechBubbleText.text = "Feed me";
		GetComponent<FishFeed> ().enabled = true;
	}

    public override void Action()
    {
		
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
