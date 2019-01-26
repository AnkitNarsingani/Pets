using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : LivingEntity
{
    AudioSource audioSource;
    Animator anim;

    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        GetNewAction();
    }

    void Update()
    {
        Debug.Log("Dog = " + petState.ToString());
    }

    public override void Action()
    {
        anim.SetBool("Barking", true);
        AudioManager.Instance.Play("Bark");
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
