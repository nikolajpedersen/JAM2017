using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour {

	public GameObject dial;
	public Dial myDial;

	// Use this for initialization
	void Start () {
		dial = GameObject.Find ("Dial");
		myDial = dial.GetComponent<Dial> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
