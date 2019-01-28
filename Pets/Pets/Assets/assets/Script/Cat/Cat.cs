using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Cat : LivingEntity
{

    AudioSource audioSource;
    Animator anim;
    [HideInInspector]
    public Display display;
    Camera cam;
   // public GameObject catObj;



    new void Start()
    {
        display = GameObject.Find("Cat").GetComponent<Display>();
        audioSource = Camera.main.GetComponent<AudioSource>();
        GetNewAction();

        cam = Camera.main;
    }


    void Update()
    {
        if (this.petState != PetState.Action)
            transform.position = new Vector3(2.46f, -2.19f, -0.04882813f);
     }

    public override void Feed()
    {
        speechBubble.SetActive(true);
        speechBubble.transform.position= cam.WorldToScreenPoint(gameObject.transform.position);

        GetComponent<CatFeed>().enabled = true;

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
