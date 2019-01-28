using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPoop : Poop
{
	Cat cat;
    void Start()
    {
		cat = FindObjectOfType<Cat>();
		cat.display.UpdateReferences(cat.petState);
        cat.display.GetComponent<Timer>().timer = 10;
        cat.display.GetComponent<Timer>().StartTimer();
    }

    new void Update()
    {
        if(base.Update())
        {
			cat.GetNewAction();
			cat.display.UpdateReferences(cat.petState);
            cat.display.GetComponent<Timer>().timer = 10;
            cat.display.GetComponent<Timer>().StartTimer();
            Destroy(gameObject);
        }
    }

	IEnumerator StartAction()
	{
		yield return new WaitForSeconds(2);
	}
}
