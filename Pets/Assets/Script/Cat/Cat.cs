using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Cat : LivingEntity 
{

    AudioSource audioSource;
    Animator anim;
	public Transform catPlace;
	[HideInInspector]
	public Display display;


    void Start () 
	{
		display = GameObject.Find("Cat").GetComponent<Display>();
        audioSource = Camera.main.GetComponent<AudioSource>();
        GetNewAction();
    }
	

	void Update () 
	{
		
	}

	public override void Feed()
	{
		GetComponent<CatFeed> ().enabled = true;
	}

    public override void Action()
    {
		GetComponent<CatRun>().enabled = true;
    }

    public void GetNewAction()
    {
        SetRandomState(ref petState);
        switch (petState)
        {
			case PetState.Hungry:
				Feed();
				break;
			case PetState.Action:
                Action();
                break;
            
            case PetState.Loo:
                Shit();
                break;
        }
    }
}
