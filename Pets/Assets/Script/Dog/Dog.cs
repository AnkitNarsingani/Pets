using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dog : LivingEntity
{
    AudioSource audioSource;
	[HideInInspector]
	public Display display;

    private void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
		display = GameObject.Find("Dog").GetComponent<Display>();
        speechBubbleText = speechBubble.GetComponentInChildren<Text>();
        GetNewAction();
        display.UpdateReferences(petState);
        display.GetComponent<Timer>().StartTimer();
    }

    new void Update()
    {
        if(base.Update())
        {
            switch(petState)
            {
                case PetState.Action:
                    speechBubble.SetActive(false);
                    GetNewAction();
                    display.UpdateReferences(petState);
                    display.GetComponent<Timer>().StartTimer();
                    AudioManager.Instance.Stop("Bark");
                    break;

                case PetState.Hungry:
                    speechBubble.SetActive(false);
                    GetNewAction();
                    display.UpdateReferences(petState);
                    display.GetComponent<Timer>().StartTimer();
                    break;
            }
        }
    }

    public override void Action()
    {
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
