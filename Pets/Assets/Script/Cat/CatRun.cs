using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRun : MonoBehaviour
{
	Cat cat;
	public float catSpeed;

	Vector3 originalPos;

	bool goingLeft = false;
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

    void Start()
    {
		cat = GetComponent<Cat> ();
		originalPos = transform.localPosition;
		pos = transform.position;
		localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
		Fly ();
		//if (goingLeft) 
	//	{
	//		Move (Vector3.left);
	//		if (transform.localPosition.x == originalPos.x || transform.localPosition.x < originalPos.x) 
	//		{
	//			goingLeft = false;
	//			enabled = false;
		//	}
				
	//	}	
	//	else
	//		Move (Vector3.right);


		if (Input.GetMouseButtonDown(0))
		{
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.name.Equals (gameObject.name)) 
			{
				cat.speechBubble.SetActive(false);

				cat.display.UpdateReferences(cat.petState);
				goingLeft = true;
				cat.GetNewAction();
			}

		}
	}

	void Move(Vector3 dir)
	{
		transform.position += dir * catSpeed * Time.deltaTime;
	}
	void Fly()
	{ 	
		CheckWhereToFace ();

		if (!facingRight)
			MoveRight ();
		else
			MoveLeft ();


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
