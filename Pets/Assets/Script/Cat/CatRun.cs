using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRun : MonoBehaviour
{
	Cat cat;
	public float catSpeed;

	Vector3 originalPos;

	bool goingLeft = false;

    void Start()
    {
		cat = GetComponent<Cat> ();
		originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
		if (goingLeft) 
		{
			Move (Vector3.left);
			if (transform.localPosition.x == originalPos.x || transform.localPosition.x < originalPos.x) 
			{
				goingLeft = false;
				enabled = false;
			}
				
		}	
		else
			Move (Vector3.right);

		if (Input.GetMouseButtonDown(0))
		{
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.name.Equals (gameObject.name)) 
			{
				cat.speechBubble.SetActive(false);
				cat.GetNewAction();
				cat.display.UpdateReferences(cat.petState);
				goingLeft = true;
			}

		}
	}

	void Move(Vector3 dir)
	{
		transform.position += dir * catSpeed * Time.deltaTime;
	}
}
