using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : LivingEntity
{

    void Start()
    {
		GetNewAction ();
    }

    void Update()
    {
        Debug.Log("Fish = " + petState.ToString());
    }

    public override void Action()
    {

    }

	public void GetNewAction()
	{
		SetRandomState(ref petState);
		switch(petState)
		{
		case PetState.Action:
			Action();
			break;
		case PetState.Hungry:
			Feed();
			break;
		case PetState.Loo:
			Shit();
			break;
		}
	}

}
