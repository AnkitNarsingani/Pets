using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class ActionHolder : ScriptableObject
{
    public string animalName;
    public Sprite[] actions;
}
