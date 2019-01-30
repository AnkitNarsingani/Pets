using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPoop : RayCastHit {

	public Bird bird;
	void Start()
	{
		bird = FindObjectOfType<Bird>();
    }

	new void Update()
	{
		if(base.Update())
		{
			bird.GetNewAction();
			bird.display.UpdateReferences(bird.petState);
            bird.display.GetComponent<Timer>().StartTimer();
            Destroy(gameObject);
		}
	}

	IEnumerator StartAction()
	{
		yield return new WaitForSeconds(2);
	}
}
