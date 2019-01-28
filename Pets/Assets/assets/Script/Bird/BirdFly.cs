using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour 
{

	Bird bird;
	bool facingRight = true;
	Vector3 pos, localScale;
	[SerializeField]
	public Vector3  spawn;
	[SerializeField]
	float moveSpeed = 5f;

	[SerializeField]
	float frequency = 20f;

	[SerializeField]
	float magnitude = 0.5f;
	void Start () {
		bird = GetComponent<Bird> ();
        pos = new Vector3(-0.83f, 1.97f, -0.04003906f);
        transform.position = pos;
        localScale = transform.localScale;
    
        bird.display.GetComponent<Timer>().timer = 10;
        bird.display.GetComponent<Timer>().StartTimer();
    }
	
	// Update is called once per frame
	void Update () 
	{
		Fly ();
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.name.Equals(gameObject.name))
			{
                pos = new Vector3(-0.83f, 1.97f, -0.04003906f);
                transform.position = pos;
                bird.display.GetComponent<Timer>().timer = 10;
                bird.display.GetComponent<Timer>().StartTimer();
                bird.GetNewAction();
				enabled = false;
				bird.display.UpdateReferences(bird.petState);
				GetComponent<BirdFly>().enabled = false;
			}
		}

	}
	void Fly()
	{ 	
		CheckWhereToFace ();

		if (facingRight)
			MoveRight ();
		else
			MoveLeft ();


	}
	void CheckWhereToFace()
	{
		if (pos.x < -5.4f)
			facingRight = true;

		else if (pos.x > 7.6f)
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
