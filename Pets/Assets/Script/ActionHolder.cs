﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class ActionHolder : ScriptableObject
{
    public string animal;
   
    public int timer;
    public bool isDone;
    public Sprite Image;
    public Sprite[] actions;
    
    public enum ActionState{ Action=0,Feed,Shit,Done }
    public ActionState currState;

}