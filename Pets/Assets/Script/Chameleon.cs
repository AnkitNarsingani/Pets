using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class Chameleon : LivingEntity
{
	
    AudioSource audioSource;
	Animator anim;
	bool facingRight = true;
	Vector3 pos, localScale;
	[SerializeField]
	float moveSpeed = 5f;

	[SerializeField]
	float frequency = 20f;

	[SerializeField]
	float magnitude = 0.5f;
    void Start()
    {
        GetNewAction();
		anim = GetComponent<Animator> ();
		pos = transform.position;

		localScale = transform.localScale;


		//InvokeRepeating ("Hide",0, 0.25f);

    }
    void Update()
    {
        



    }
	IEnumerator Hide()
	{
		yield return new WaitForSeconds (1);
		anim.Play ("Hide");
	}
		
    public override void Action()
    {
        //anim.SetBool("Barking", true);
        //AudioManager.Instance.Play("Bark");

	//StartCoroutine (Hide ());

		InvokeRepeating ("Fly", 0, 0.01f);
    }
	void Fly()
	{ 	
		CheckWhereToFace ();

		if (facingRight)
			MoveRight ();
		else
			MoveLeft ();


	}

 
    
    public void GetNewAction()
    {
        SetRandomState(ref petState);
        switch (petState)
        {
		case PetState.Action:
			Action ();
			Debug.Log ("Action");
                break;
            case PetState.Hungry:
                Feed();
			Debug.Log ("Hungry");
                break;
            case PetState.Loo:
                Shit();
			Debug.Log ("Loo");
                break;
        }
    }
	void CheckWhereToFace()
	{
		if (pos.x < -7f)
			facingRight = true;

		else if (pos.x > 7f)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;

	}

	void MoveRight()
	{
		pos += transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

	void MoveLeft()
	{
		pos -= transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}
}
