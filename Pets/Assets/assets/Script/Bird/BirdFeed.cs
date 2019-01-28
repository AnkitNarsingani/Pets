using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFeed : Feed {

	Bird bird;

	void Start () 
	{
		bird = GetComponent<Bird> ();
        bird.display.GetComponent<Timer>().timer = 10;
        bird.display.GetComponent<Timer>().StartTimer();
    }
	
	// Update is called once per frame
	new void Update () {
		if (base.Update()) 
		{
			bird.speechBubble.SetActive (false);
			bird.GetNewAction ();
			bird.display.UpdateReferences (bird.petState);
			enabled = false;
		}
	}
}
