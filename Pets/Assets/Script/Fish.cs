using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : LivingEntity
{

    void Start()
    {
        SetRandomState(ref petState);
    }

    void Update()
    {
        Debug.Log("Fish = " + petState.ToString());
    }

    public override void Action()
    {

    }

}
