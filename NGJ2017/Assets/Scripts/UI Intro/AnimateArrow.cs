using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateArrow : MonoBehaviour {

	public float speed = 10f;
	public float length = 5f;

	float x,y = 0f;

	void Start()
	{
		x = transform.position.x;
		y = transform.position.y;
		///
	}

	// Use this for initialization
	void Update() {
		transform.position = new Vector3(Mathf.PingPong(Time.time * speed, length) + x, Mathf.PingPong(Time.time * speed, length + 2) + y, transform.position.z);
	}
}
