using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings: MonoBehaviour {

	public Helpers.GameMode gameMode;
	public bool isPaused = false;
	public bool levelOver = false;
	public int totalGhosts;
	public int score = 0;

	GameObject [] ghosts;

	void Start()
	{
		ghosts = GameObject.FindGameObjectsWithTag ("Ghost");
		totalGhosts = ghosts.Length;
	}

	void Update ()
	{
		if (totalGhosts == 0) {
			levelOver = true;
		}
	}

}
