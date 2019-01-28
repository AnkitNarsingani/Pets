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
    }

    new void Update()
    {
        if(base.Update())
        {
			cat.GetNewAction();
			cat.display.UpdateReferences(cat.petState);
            Destroy(gameObject);
        }
    }

	IEnumerator StartAction()
	{
		yield return new WaitForSeconds(2);
	}
}
