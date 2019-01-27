
using System.Collections.Generic;
using UnityEngine;

public class FishFeed : Feed
{
	Fish fish;

	void Start () 
	{
		
	}

	void Update () 
	{
		if (base.Update ()) 
		{
			enabled = false;
			fish.speechBubble.SetActive (false);
			fish.GetNewAction ();
			fish.display.UpdateReferences (fish.petState);
		}
	}
}
