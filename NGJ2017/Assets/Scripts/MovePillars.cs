using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePillars : MonoBehaviour {

	public bool start = true;
	public float moveSpeedTetrisTick = 1f;
	public float moveSpeedFluid = 10f;
	public float moveSpeedRobotic = 1f;
	public float moveSpeedFluidTick = 2f;
	public float moveSpeedContinuous = 0.1f;
	public float _time = 0f;


	private Helpers.GameMode gameMode;

	private static Vector3 direction = new Vector3(0f,-1f,0f);
	private bool hasTarget = false;
	public Vector3 moveTo;
	public Vector3 infinityDown = new Vector3(0f,float.MaxValue, 0f);

	void Awake()
	{
		gameMode = this.GetComponent<GameSettings> ().gameMode;
		moveTo = transform.position;
	}


	void FixedUpdate ()
	{
		if (gameMode == Helpers.GameMode.tetris) {
			_time = _time + Time.deltaTime;
			if (_time > moveSpeedTetrisTick) {
				gameObject.transform.position = gameObject.transform.position + direction;
				_time = 0f;
			}
		}
		if (gameMode == Helpers.GameMode.fluid) {
			if (!hasTarget) {
				moveTo = transform.position + direction;
				hasTarget = true;
			}
			_time = _time + Time.deltaTime;
			if (_time < moveSpeedFluidTick) {
				float step = moveSpeedFluid * Time.deltaTime;
				transform.position = Vector3.Lerp (transform.position, moveTo, step);
			} else {
				moveTo = moveTo + direction;
				_time = 0f;
			}
		}
		if (gameMode == Helpers.GameMode.robotic) {
			if (!hasTarget) {
				moveTo = transform.position + direction;
				hasTarget = true;
			}
			_time = _time + Time.deltaTime;
			if (_time < moveSpeedFluidTick) {
				float step = moveSpeedRobotic * Time.deltaTime;
				transform.position = Vector3.MoveTowards (transform.position, moveTo, step);
			} else {
				moveTo = moveTo + direction;
				_time = 0f;
			}
		}

		if (gameMode == Helpers.GameMode.continous) {
			Vector3 position = this.transform.position;
			position.y = position.y - moveSpeedContinuous;
			this.transform.position = position;
		}
	}
}
