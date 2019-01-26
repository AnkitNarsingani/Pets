using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPoop : Poop
{
    public Dog dog;
    

    void Start()
    {
        dog = FindObjectOfType<Dog>();
        dog.display.UpdateReferences(dog.petState);
    }

    new void Update()
    {
        if (base.Update())
        {
            dog.GetNewAction();
            dog.display.UpdateReferences(dog.petState);
            Destroy(gameObject);
        }

    }

    IEnumerator StartAction()
    {
        yield return new WaitForSeconds(2);
    }
}
