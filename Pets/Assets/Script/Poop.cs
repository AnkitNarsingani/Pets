using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    Camera mainCamera;

	void Start ()
    {
        mainCamera = Camera.main;
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider.gameObject.name.Contains("Poop"))
            {
                Destroy(gameObject);
            }
        }
    }
}
