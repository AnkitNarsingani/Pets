using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFeed : Feed
{
	Cat cat;

    void Start()
    {
		cat = GetComponent<Cat> ();
        cat.display.GetComponent<Timer>().timer = 10;
        cat.display.GetComponent<Timer>().StartTimer();

    }

    new void Update()
    {
		if (base.Update ()) 
		{
			enabled = false;
			cat.speechBubble.SetActive (false);

			cat.GetNewAction ();
			cat.display.UpdateReferences (cat.petState);

		}
    }
}
