using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPoop : Poop
{
    public Dog dog;
    public Display display;

    void Start()
    {
        dog = FindObjectOfType<Dog>();
        display = GameObject.Find("Dog").GetComponent<Display>();
    }

    new void Update()
    {
        if (base.Update())
        {
            StartCoroutine(StartAction());
            Destroy(gameObject, 3);
        }

    }

    IEnumerator StartAction()
    {
        yield return new WaitForSeconds(2);
        dog.GetNewAction();
        display.UpdateReferences(dog.petState);
    }
}
