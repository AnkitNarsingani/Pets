using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : LivingEntity
{
    AudioSource audioSource;
    Animator anim;

    void Start()
    {
        SetRandomState(ref petState);
        audioSource = Camera.main.GetComponent<AudioSource>();
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
}
