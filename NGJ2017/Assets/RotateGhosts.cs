using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGhosts : MonoBehaviour {

	public GameObject dialObject;

	// Use this for initialization
	void Start () {
		dialObject = GameObject.Find ("Dial");
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion dialRotation = dialObject.transform.rotation;
		transform.rotation = dialRotation;
	}
}
