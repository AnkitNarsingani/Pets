using System.Collections.Generic;
using UnityEngine;

public class Cat : LivingEntity 
{

    AudioSource audioSource;
    Animator anim;

    void Start () 
	{
        audioSource = Camera.main.GetComponent<AudioSource>();
        GetNewAction();
    }
	

	void Update () 
	{
		
	}

    public override void Action()
    {
        
    }

    public void GetNewAction()
    {
        SetRandomState(ref petState);
        switch (petState)
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
