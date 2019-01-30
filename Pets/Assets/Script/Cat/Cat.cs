using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cat : LivingEntity 
{

    AudioSource audioSource;
	[HideInInspector]
	public Display display;
    [SerializeField]
    private float catMoveSpeed = 5f;

    bool escaping = false, canMove = false;
    Vector3 originalPos;
    SpriteRenderer spriteRenderer;

    void Start () 
	{
        spriteRenderer = GetComponent<SpriteRenderer>();
		display = GameObject.Find("Cat").GetComponent<Display>();
        audioSource = Camera.main.GetComponent<AudioSource>();
        speechBubbleText = speechBubble.GetComponentInChildren<Text>();
        originalPos = transform.localPosition;
        GetNewAction();
        display.UpdateReferences(petState);
        display.GetComponent<Timer>().StartTimer();
    }
	

	new void Update () 
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
                    escaping = false;
                    spriteRenderer.flipX = true;
                    GetNewAction();
                    display.UpdateReferences(petState);
                    display.GetComponent<Timer>().StartTimer();
                    AudioManager.Instance.Stop("Bark");
                    break;
            }
        }
        if(canMove)
        {
            if (escaping)
            {
                Move(Vector3.left);
            }
            else
            {
                Move(Vector3.right);
                if (transform.localPosition.x == originalPos.x || transform.localPosition.x > originalPos.x)
                {
                    escaping = false;
                    canMove = false;
                    spriteRenderer.flipX = false;
                }
            }
                
        }
        
    }

    public override void Action()
    {
        escaping = true;
        canMove = true;
    }

    void Move(Vector3 dir)
    {
        transform.position += dir * catMoveSpeed * Time.deltaTime;
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
