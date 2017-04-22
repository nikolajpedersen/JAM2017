using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public Helpers.Colors myColor;

	public bool isAlive = true;

	//private Vector3 currentScale;
	public float dyingSpeed = 0.1f;

	void Start()
	{
		ColorME (myColor);

	}

	void ColorME(Helpers.Colors _color)
	{
		switch (_color) {
		case Helpers.Colors.green:
			this.GetComponent<Renderer> ().material.color = Color.green;
			break;
		case Helpers.Colors.blue:
			this.GetComponent<Renderer> ().material.color = Color.blue;
			break;
		case Helpers.Colors.red:
			this.GetComponent<Renderer> ().material.color = Color.red;
			break;
		case Helpers.Colors.yellow:
			this.GetComponent<Renderer> ().material.color = Color.yellow;
			break;
		}
	}

	void FixedUpdate()
	{
		if (!isAlive) {
			transform.localScale -= Vector3.one * dyingSpeed;
		
		}
		if (transform.localScale.x < 0.15f) {
			gameObject.SetActive (false);
		}
	}
}
