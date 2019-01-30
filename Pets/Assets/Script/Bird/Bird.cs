using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : LivingEntity
{
	
    AudioSource audioSource;

	public Display display;
    void Start()
    {
		display = GameObject.Find("Bird").GetComponent<Display>();
        speechBubbleText = speechBubble.GetComponentInChildren<Text>();
        GetNewAction();
        display.UpdateReferences(petState);
        display.GetComponent<Timer>().StartTimer();
    }
    new void Update()
    {
        if (base.Update())
        {
            switch (petState)
            {
                case PetState.Hungry:
                    speechBubble.SetActive(false);
                    GetNewAction();
                    display.UpdateReferences(petState);
                    display.GetComponent<Timer>().StartTimer();
                    break;

                case PetState.Action:
                    GetNewAction();
                    transform.position = new Vector3(-0.83f, 1.97f, -0.04003906f);
                    GetComponent<BirdFly>().enabled = false;
                    display.UpdateReferences(petState);
                    display.GetComponent<Timer>().StartTimer();
                    AudioManager.Instance.Stop("Bark");
                    break;
            }
        }

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
