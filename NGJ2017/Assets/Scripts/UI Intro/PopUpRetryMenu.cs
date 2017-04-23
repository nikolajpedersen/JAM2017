using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpRetryMenu : MonoBehaviour {


	public GameObject mainMenuBtn;
	public GameObject retryBtn;
	public GameObject skipBtn;

	GameSettings gameSettings;

	void Start()
	{
		mainMenuBtn = transform.FindChild ("MainMenu").gameObject;
		retryBtn = transform.FindChild ("Retry").gameObject;

		try {
			skipBtn = transform.FindChild ("Move on").gameObject;
		} catch {}

		gameSettings = GameObject.Find ("Level").GetComponent<GameSettings> ();
	}

	void Update()
	{
		try {
			if (gameSettings.levelOver) {
				mainMenuBtn.SetActive (true);
				retryBtn.SetActive (true);
				skipBtn.SetActive(true);
			}
		} catch {
		}  
	}
}
