using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFeed : Feed
{
	Cat cat;

    void Start()
    {
		cat = GetComponent<Cat> ();
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
