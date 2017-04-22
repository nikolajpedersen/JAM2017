using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpRetryMenu : MonoBehaviour {


	public GameObject mainMenuBtn;
	public GameObject retryBtn;

	GameSettings gameSettings;

	void Start()
	{
		mainMenuBtn = transform.FindChild ("MainMenu").gameObject;
		retryBtn = transform.FindChild ("Retry").gameObject;
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
