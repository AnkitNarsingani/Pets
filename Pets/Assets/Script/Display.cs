using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour {

    public ActionHolder animal;
    public Image img;
    void Start ()
    {
        img.sprite = animal.Image;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
