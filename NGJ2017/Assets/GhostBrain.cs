using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBrain : MonoBehaviour
{

	public Helpers.Colors myColor;

	public bool isAlive = true;

	void Start ()
	{
		
	}

	void Update()
	{
		if (isAlive == false) {
			KillGhost();
		}
	}

	void OnTriggerEnter2D (Collider2D what)
	{
		GameObject who = what.gameObject;
		Obstacle pillar = who.GetComponent<Obstacle> ();
		if (who.tag == "Enemy") {
			if (myColor != pillar.myColor) {
				isAlive = false;
			}
		}
			
	}

	void KillGhost ()
	{
		//do here animations, sounds etc; and then ->
		this.gameObject.SetActive(false);
	}

}
