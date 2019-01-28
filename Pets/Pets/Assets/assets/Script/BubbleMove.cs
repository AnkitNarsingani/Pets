using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour {

	RectTransform rt;
	public GameObject obj;
	bool isEnabled=false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnEnable()
	{
		rt = GetComponent<RectTransform> ();
		rt.localPosition += obj.transform.position;

	}
	void OnDisable()
	{
		isEnabled = false;
	}

}
