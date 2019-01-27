using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : LivingEntity
{
	[HideInInspector]
	public Display display;

    void Start()
    {
		GetNewAction ();
    }

    void Update()
    {
		
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
