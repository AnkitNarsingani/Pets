using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour {

    public ActionHolder animal;
    public Image img;
    public Text timer;
    public Text action;
    public Image actions;
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        int value = (int)animal.currState;
        img.sprite = animal.Image;
        timer.text = animal.timer.ToString();
        action.text = animal.currState.ToString();
        actions.sprite = animal.actions[value];
       // print(animal.actions[value]);

    }
}
