using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public Helpers.Colors myColor;

	void Start()
	{
		ColorME (myColor);

	}

	void ColorME(Helpers.Colors _color)
	{
		switch (_color) {
		case Helpers.Colors.cyan:
			this.GetComponent<Renderer> ().material.color = Color.cyan;
			break;
		case Helpers.Colors.purple:
			this.GetComponent<Renderer> ().material.color = Color.magenta;
			break;
		case Helpers.Colors.red:
			this.GetComponent<Renderer> ().material.color = Color.red;
			break;
		case Helpers.Colors.yellow:
			this.GetComponent<Renderer> ().material.color = Color.yellow;
			break;
		}
	}
	

}
