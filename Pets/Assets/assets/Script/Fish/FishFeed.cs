
using System.Collections;
using UnityEngine;

public class FishFeed : Feed
{
	Fish fish;

	void Start () 
	{
		fish = GetComponent<Fish> ();
	}

	void Update () 
	{
		if (base.Update ()) 
		{
			enabled = false;
			fish.speechBubble.SetActive (false);
			fish.display.timer.text = "";
			StartCoroutine (getAction ());
		}
	}

	IEnumerator getAction()
	{
		int temp = Random.Range (3, 8);
		yield return new WaitForSeconds (temp);
		fish.GetNewAction ();
		fish.display.UpdateReferences (fish.petState);
		fish.display.GetComponent<Timer> ().StartTimer ();
	}
}
