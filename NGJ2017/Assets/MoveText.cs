using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour {

	public float moveSpeedContinuous = 1.0f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(!(this.transform.position.y > 226.0f)) {
			Vector3 position = this.transform.position;
			position.y += moveSpeedContinuous;
			this.transform.position = position;
		}
	}
}
