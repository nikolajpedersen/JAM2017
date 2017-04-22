using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpRetryMenu : MonoBehaviour {


	public GameObject mainMenuBtn;
	public GameObject retryBtn;

	GameSettings gameSettings;

	void Start()
	{
		mainMenuBtn = GameObject.Find ("Main Menu");
		retryBtn = GameObject.Find ("Retry");
		gameSettings = GameObject.Find ("Level").GetComponent<GameSettings> ();
	}

	void Update()
	{
		if (gameSettings.levelOver) {
			mainMenuBtn.SetActive (true);
			retryBtn.SetActive (true);
		}
	}
}
