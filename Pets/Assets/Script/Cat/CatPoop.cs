using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPoop : Poop
{
	Cat cat;
	Display display;
    void Start()
    {
		cat = FindObjectOfType<Cat>();
		display = GameObject.Find("Cat").GetComponent<Display>();
		display.UpdateReferences(cat.petState);
    }

    new void Update()
    {
        if(base.Update())
        {
            StartCoroutine(StartAction());
            Destroy(gameObject, 3);
        }
    }

	IEnumerator StartAction()
	{
		yield return new WaitForSeconds(2);
		cat.GetNewAction();
		display.UpdateReferences(cat.petState);
	}
}
