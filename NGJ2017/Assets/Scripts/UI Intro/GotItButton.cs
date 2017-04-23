using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GotItButton : MonoBehaviour {

	private GameObject level;
	private Button btn;
	private Color _color;

	private GameObject arrow;
	private GameObject skip;

	void Start()
	{
		arrow = GameObject.Find ("arrow_yellow");
		btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		level = GameObject.Find ("Level");
		skip = GameObject.Find ("Move on");
	}

	void TaskOnClick()
	{
		level.GetComponent<GameSettings> ().isPaused = false;
		transform.parent.gameObject.SetActive (false);
		arrow.SetActive (false);
		skip.SetActive(false);
	}

	void Update()
	{

	}
}
