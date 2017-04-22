using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GotItButton : MonoBehaviour {

	private GameObject level;
	private Button btn;
	private Color _color;

	void Start()
	{
		btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		level = GameObject.Find ("Level");
	}

	void TaskOnClick()
	{
		level.GetComponent<GameSettings> ().isPaused = false;
		transform.parent.gameObject.SetActive (false);
	}

	void Update()
	{

	}
}
