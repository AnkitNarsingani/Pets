using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPoop : Poop {

	Fish fish;

	void Start () 
	{
		fish = FindObjectOfType<Fish>();
		fish.display.UpdateReferences(fish.petState);
	}
	
	// Update is called once per frame
	new void Update () 
	{
		if (base.Update ()) 
		{
			fish.GetNewAction();
			fish.display.UpdateReferences(fish.petState);
			Destroy(gameObject);
		}
	}
}
