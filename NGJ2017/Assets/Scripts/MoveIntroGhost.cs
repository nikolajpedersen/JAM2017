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

		if (this.transform.position.x > 6.0f) {
			Vector3 newPosition = new Vector3(
				-6.5f,
				this.transform.position.y,
				this.transform.position.z
			);
			this.transform.position = newPosition;
		}
	}
}
