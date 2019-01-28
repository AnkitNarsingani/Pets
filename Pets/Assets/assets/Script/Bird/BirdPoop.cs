using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPoop : Poop {

	public Bird bird;
	void Start()
	{
		bird = FindObjectOfType<Bird>();
		bird.display.UpdateReferences(bird.petState);
        bird.display.GetComponent<Timer>().timer = 10;
        bird.display.GetComponent<Timer>().StartTimer();
    }

	new void Update()
	{
		if(base.Update())
		{

            bird.display.GetComponent<Timer>().timer = 10;
            bird.display.GetComponent<Timer>().StartTimer();
            bird.GetNewAction();
			bird.display.UpdateReferences(bird.petState);
			Destroy(gameObject);
		}
	}

	IEnumerator StartAction()
	{
		yield return new WaitForSeconds(2);
	}
}
