using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBark : MonoBehaviour
{
    Dog dog;

    void Start()
    {
        dog = GetComponent<Dog>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.name.Equals(gameObject.name))
            {
                dog.speechBubble.SetActive(false);
                dog.GetNewAction();
                dog.display.UpdateReferences(dog.petState);
                enabled = false;
                AudioManager.Instance.Stop("Bark");
            }
        }
    }
}
