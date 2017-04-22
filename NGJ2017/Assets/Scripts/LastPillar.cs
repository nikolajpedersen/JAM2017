using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPillar : MonoBehaviour {

	GameObject mainMenuBtn;
	GameObject retryBtn;

	GameObject[] ghosts;

	Transform oneGhost;
	GameSettings gameSettings;

	public float difference = float.MaxValue;
	// Use this for initialization
	void Start () {

		try{
		mainMenuBtn = GameObject.Find ("Main Menu");
		mainMenuBtn.SetActive (false);

		retryBtn = GameObject.Find ("Retry");
		retryBtn.SetActive (false);
		}
		catch{
		}

		gameSettings = GameObject.Find ("Level").GetComponent<GameSettings> ();

		ghosts = GameObject.FindGameObjectsWithTag ("Ghost");
		if (ghosts.Length > 0) {
			oneGhost = ghosts [0].transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		difference = transform.position.y - oneGhost.position.y;
		if (difference < -1f ) {
			gameSettings.levelOver = true;
		}
		
	}
}
