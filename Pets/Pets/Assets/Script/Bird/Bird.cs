using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class Bird : LivingEntity
{
	
    AudioSource audioSource;
	Animator anim;

	public Display display;
    void Start()
    {
		display = GameObject.Find("Bird").GetComponent<Display>();
        GetNewAction();
		anim = GetComponent<Animator> ();



		//InvokeRepeating ("Hide",0, 0.25f);

    }
    void Update()
    {
        



    }
	public override void Feed()
	{
		GetComponent<BirdFeed> ().enabled = true;
	}

	public override void Action()
	{
		GetComponent<BirdFly>().enabled = true;
	}


   

 
    
    public void GetNewAction()
    {
        SetRandomState(ref petState);
        switch (petState)
        {
		case PetState.Action:
			Action ();
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
