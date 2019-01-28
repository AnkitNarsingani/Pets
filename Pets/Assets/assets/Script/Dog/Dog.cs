using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dog : LivingEntity
{
    AudioSource audioSource;
    Animator anim;
	[HideInInspector]
	public Display display;

    new void Start()
    {

        audioSource = Camera.main.GetComponent<AudioSource>();
		display = GameObject.Find("Dog").GetComponent<Display>();
		speechBubbleText =  speechBubble.GetComponentInChildren<Text> ();
        display.GetComponent<Timer>().StartTimer();
        GetNewAction();
    }

    void Update()
    {

    }

	public override void Feed()
	{
		base.Feed ();
		GetComponent<DogFeed> ().enabled = true;
	}

    public override void Action()
    {
        //anim.SetBool("Barking", true);
        GetComponent<DogBark>().enabled = true;
        AudioManager.Instance.Play("Bark");
		speechBubble.SetActive (true);
		speechBubbleText.text = "*woof woof*";
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
