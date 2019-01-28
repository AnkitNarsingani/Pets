using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class ActionHolder : ScriptableObject
{
    public string animal;
    public Sprite Image;
    public Sprite[] actions;
}
