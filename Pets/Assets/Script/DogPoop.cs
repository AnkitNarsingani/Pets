using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPoop : Poop
{
    Dog dog;
    Display display;

	void Start ()
    {
        dog = GameObject.Find("Dog").GetComponent<Dog>();
	}

	new void Update ()
    {
        if(base.Update())
        {
            Destroy(gameObject);
            display.UpdateReferences();
            StopCoroutine("StartAction");
        }
	}

    IEnumerator StartAction()
    {
        yield return new WaitForSeconds(2);
        dog.GetNewAction();
    }
}
