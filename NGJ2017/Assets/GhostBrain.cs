using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBrain : MonoBehaviour
{

	public Helpers.Colors myColor;

	public bool isAlive = true;
	public float dyingSpeed = 0.1f;

	private GameSettings gameSettings;

	private AudioSource beep;
	private AudioSource flopp;


	void Start ()
	{
		beep = GameObject.Find ("beep").GetComponent<AudioSource>();
		flopp = GameObject.Find ("flopp").GetComponent<AudioSource>();

		try{
		gameSettings = GameObject.Find ("Level").GetComponent<GameSettings> ();
		}
		catch{
		}
	}

	void Update()
	{
		if (isAlive == false) {
			transform.localScale -= Vector3.one * dyingSpeed;
			if (transform.localScale.x < 0.15f) {
				KillGhost ();
			}
		}
	}

	void OnTriggerEnter2D (Collider2D what)
	{
		GameObject who = what.gameObject;
		Obstacle pillar = who.GetComponent<Obstacle> ();
		if (who.tag == "Enemy") {
			if (myColor != pillar.myColor) {
				beep.Play ();
				gameSettings.score--;
				pillar.isAlive = false;

			} else {
				flopp.Play ();
				gameSettings.score++;
				pillar.isAlive = false;
			}
		}
			
	}

	void KillGhost ()
	{
		//do here animations, sounds etc; and then ->
		gameSettings.totalGhosts--;
		this.gameObject.SetActive(false);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 1);
	}
}
