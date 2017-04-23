using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour {


	GameSettings gameSettings;
	int currentScore = 0;
	float _seconds = 0.2f;

	Text _text;
	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
		gameSettings = GameObject.Find ("Level").GetComponent<GameSettings> ();

		
	}


	
	// Update is called once per frame
	void LateUpdate ()
	{

		if (currentScore < gameSettings.score) {
			currentScore = gameSettings.score;
			_text.text = gameSettings.score.ToString ();
			ChangeColor (true);
		}
		if (currentScore > gameSettings.score) {
			currentScore = gameSettings.score;
			_text.text = gameSettings.score.ToString () + " :(";
			ChangeColor (false);
		}
		if (currentScore < 0) {
			currentScore = gameSettings.score;
			_text.text = gameSettings.score.ToString () + " :)";
			_text.color = Color.red;
			StartCoroutine (ResetColor (_seconds));

		}
	}

	void ChangeColor(bool win)
	{
		if (win) {
			_text.color = Color.green;
		} else {
			_text.color = Color.red;
		}
		StartCoroutine (ResetColor (_seconds));
	}
	IEnumerator ResetColor(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		_text.color = Color.white;
	}
}
