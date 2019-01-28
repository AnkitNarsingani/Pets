using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PetState
{
    Hungry,
    Loo,
    Action
}

public abstract class LivingEntity : MonoBehaviour
{
    [SerializeField]
	public GameObject speechBubble;

	protected Text speechBubbleText;

    [SerializeField]
    protected GameObject poop;
    [SerializeField]
    Transform[] poopSpawnLocations;

    public PetState petState;

    public virtual void Start()
    {
		speechBubbleText =  speechBubble.GetComponentInChildren<Text> ();
    }

    public virtual void Feed()
    {
        speechBubble.SetActive(true);
		speechBubbleText.text = "Feed me please!";
    }

    public void Shit()
    {
        int temp = UnityEngine.Random.Range(0, poopSpawnLocations.Length);
		Instantiate(poop, poopSpawnLocations[temp].position, Quaternion.identity);
    }

    public abstract void Action();

    protected void SetRandomState(ref PetState currentstate)
    {
        int temp = UnityEngine.Random.Range(1, 4);

        switch(temp)
        {
            case 1:
                if (currentstate != PetState.Hungry)
                    currentstate = PetState.Hungry;
                else
                    SetRandomState(ref currentstate);
                break;
            case 2:
                if (currentstate != PetState.Loo)
                    currentstate = PetState.Loo;
                else
                    SetRandomState(ref currentstate);
                break;
            case 3:
                if (currentstate != PetState.Action)
                    currentstate = PetState.Action;
                else
                    SetRandomState(ref currentstate);
                break;
        }
    }
}
