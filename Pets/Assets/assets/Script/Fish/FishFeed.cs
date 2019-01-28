
using System.Collections;
using UnityEngine;

public class FishFeed : Feed
{
	Fish fish;

	void Start () 
	{
		fish = GetComponent<Fish> ();
       
    }
    private void OnEnable()
    {
        fish = GetComponent<Fish>();
        fish.display.GetComponent<Timer>().timer = 10;
        fish.display.GetComponent<Timer>().StartTimer();
    }
    private void OnDisable()
    {

       
        fish.display.timer.text = "";

    }

    new void Update () 
	{
		if (base.Update ()) 
		{
            fish.display.timer.text = "";
            this.enabled = false;
            fish.speechBubble.SetActive (false);
           
            StartCoroutine (getAction ());
		}
	}

	IEnumerator getAction()
	{
		int temp = Random.Range (3, 8);
      
        yield return new WaitForSeconds (temp);
        fish.GetNewAction ();

		fish.display.UpdateReferences (fish.petState);
       

    }
}
