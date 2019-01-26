using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPoop : Poop
{
    Dog dog;
    public Display disp;

	void Start ()
    {
        dog = GameObject.Find("Dog").GetComponent<Dog>();
        disp = GameObject.Find("Dog").GetComponent<Display>();
        disp.animal.currState = ActionHolder.ActionState.Shit;
    }

	new void Update ()
    {
        if(base.Update())
        {
            Destroy(gameObject);
            
            StopCoroutine("StartAction");
         
            disp.animal.currState = ActionHolder.ActionState.Done;
          
        }
       
    }

    IEnumerator StartAction()
    {
        yield return new WaitForSeconds(2);
        dog.GetNewAction();
        disp.UpdateReferences();
    }
}
