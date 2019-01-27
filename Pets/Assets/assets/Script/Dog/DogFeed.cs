using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFeed : Feed 
{
	Dog dog;

	void Start()
	{
		dog = GetComponent<Dog> ();
	}

	new void Update () 
	{
		if (base.Update ()) 
		{
			enabled = false;
			dog.speechBubble.SetActive (false);
			dog.GetNewAction ();
			dog.display.UpdateReferences (dog.petState);
			dog.display.GetComponent<Timer> ().StartTimer ();
		}
	}
}
