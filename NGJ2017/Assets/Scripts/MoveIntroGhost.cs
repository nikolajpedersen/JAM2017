using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIntroGhost : MonoBehaviour {

	public float moveSpeedContinuous = 0.005f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 position = this.transform.position;
		position.x += moveSpeedContinuous;
		this.transform.position = position;
	}
}
