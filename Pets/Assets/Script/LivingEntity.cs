using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PetState
{
    Hungry,
    Loo,
    Action
}

public abstract class LivingEntity : MonoBehaviour
{
    [SerializeField]
    protected GameObject HungryspeechBubble;
    [SerializeField]
    protected GameObject poop;
    [SerializeField]
    Transform[] poopSpawnLocations;

    public PetState petState;

    private void Start()
    {
        
    }

    public void Feed()
    {
        HungryspeechBubble.SetActive(true);
    }

    public void Shit()
    {
        int temp = Random.Range(0, poopSpawnLocations.Length + 1);
        Instantiate(poop, poopSpawnLocations[temp].position, Quaternion.identity);
    }

    public abstract void Action();

    public void SetRandomState(ref PetState currentstate)
    {
        int temp = Random.Range(1, 4);

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
