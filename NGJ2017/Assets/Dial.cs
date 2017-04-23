using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dial : MonoBehaviour {

	//private int finId1 = -1; //id finger for cancel touch event
	//private int finId2 = -1;

	// rotation speed
	float rotationSpeed = 1.0f;

	// store the first position the user presses
	private float lastYPosition = 0;
	// the dampener value on the swipe spinning pr. second
	private float swipeDetectThreshold = 0.04f;

	//  note if the wheel is spinning due to swipe
	private bool isSwipeSpin = false;
	// the force the wheel is swiping around currently
	private float currentSwipeSpinForce = 0.0f;
	// the intial force for activating swipe spinning
	private float swipeSpinForce = 0.2f;
	// the dampener value on the swipe spinning pr. second
	private float swipeSpinDampener = 2.0f;

	// mouse dragging bool
	private bool isMouseDragging = false;

	// a queu to track the last 4 Y touch position to deterine swipe and force
	float floatCacheXPos1 = 9999999999;
	float floatCacheXPos2 = 9999999999;


	// sound tracking
	float lastDialTickRotation = 9999;
	float tickThreshold = 0.05f;
	float lastTimePlayed = 0;
	float playThresholdSeconds = 0.1f;
	float ownTime = 0;

	AudioSource tick;


	// Use this for initialization
	void Start () {
		//Input.multiTouchEnabled = true; //enabled Multitouch
		tick = GetComponent<AudioSource>();
	}


	// Update is called once per frame
	void Update () {
		ownTime += Time.deltaTime;

		// sound
		// store last rotation
		float current_rotation = transform.rotation.z;

		if (lastDialTickRotation != 9999) {
			float difference = Mathf.Abs(lastDialTickRotation) - (Mathf.Abs(current_rotation));


			if (Mathf.Abs(difference) > tickThreshold && (ownTime-lastTimePlayed) > playThresholdSeconds ) {
				lastDialTickRotation =  Mathf.Abs(current_rotation);
				lastTimePlayed = ownTime;
				tick.Play();
			}
		} else {
			lastDialTickRotation = current_rotation;
		}

		// rotation
		float posY = 0;
		//float posX = 0;

		string clickStatus = "";

		// determine if mouse or touch
		if(Input.touchCount == 1)
		{
			// stop swipe if going on
			isSwipeSpin = false;

			Debug.Log("touched");
			Touch touchObject = Input.GetTouch(0);
			//posX = touchObject.position.x;
			posY = touchObject.position.y;

			if(touchObject.phase == TouchPhase.Began) {
				clickStatus = "began";
			} else if (touchObject.phase == TouchPhase.Ended) {
				clickStatus = "ended";
			} else if (touchObject.phase == TouchPhase.Moved) {
				clickStatus = "moved";
			}
		} else if (Input.GetMouseButtonDown(0)) {
			//posX = Input.mousePosition.x;
			posY= Input.mousePosition.y;
			isMouseDragging = true;
			clickStatus = "began";
			// stop swipe if going on
			isSwipeSpin = false;
		} else if (Input.GetMouseButtonUp(0)) {
			//posX = Input.mousePosition.x;
			posY= Input.mousePosition.y;

			clickStatus = "ended";
			isMouseDragging = false;
			// stop swipe if going on
			isSwipeSpin = false;
		} else if (isMouseDragging == true) {
			//posX = Input.mousePosition.x;
			posY= Input.mousePosition.y;

			clickStatus = "moved";
			// stop swipe if going on
			isSwipeSpin = false;
		}
			
		// perform actions based on status
		if (clickStatus == "began") {
			//Debug.Log("start drag");

			// store last Y pos
			lastYPosition = posY;

			// stop swipe turning if on
			isSwipeSpin = false;
			currentSwipeSpinForce = 0;

			SetCachePos(posY);
		} else if (clickStatus == "moved") {
			//Debug.Log("moved drag");
			// is a position tracked after the initial

			// calculate percent the user moved with touch in relation to screen height
			float screenAreaChange = (float)(posY - lastYPosition) / (float)Screen.height;

			// store last Y pos
			lastYPosition = posY;

			// change in the angle for the dial
			float dialRotationChange =  screenAreaChange * 180 * rotationSpeed;

			// do rotate
			transform.Rotate(0,0,dialRotationChange * -1f);
	
			SetCachePos(posY);
		} else if (clickStatus == "ended") {
			//Debug.Log("drag ended");

			// calculate percent the user moved with touch in relation to screen height
			float screenAreaChange = (float)(posY - lastYPosition) / (float)Screen.height;

			// change in the angle for the dial
			float dialRotationChange =  screenAreaChange * 180 * rotationSpeed;

			// do rotate
			transform.Rotate(0,0,dialRotationChange * -1f);

			// determine if the wheel should spin after swipe
			float endPosition = posY;

			// get all from queue and determine the distance moved in the last positions (can be negative or positive)
			float lengthTravelled = 0;

		
			if (floatCacheXPos2 != 9999999999) {
				lengthTravelled +=  endPosition - floatCacheXPos2;	
			} else if (floatCacheXPos1 != 9999999999) {
				lengthTravelled +=  endPosition - floatCacheXPos1;	
			}

			// reset
			floatCacheXPos1 = 9999999999;
			floatCacheXPos2 = 9999999999;

			// length by screen height
			float swipeDetectedValue = lengthTravelled / Screen.height;

			//Debug.Log("swipeDetectThreshold:");
			//Debug.Log(swipeDetectThreshold);

			//Debug.Log("swipeDetectedValue:");
			//Debug.Log(Mathf.Abs(swipeDetectedValue));

			if (Mathf.Abs(swipeDetectedValue) > swipeDetectThreshold) {
				//Debug.Log("swipe detected");
				float spinForce = swipeSpinForce * swipeDetectedValue * 180;
				// enable swipe
				isSwipeSpin = true;
				currentSwipeSpinForce = Mathf.Clamp(spinForce,-3, 3);

				//Debug.Log("currentSwipeSpinForce");
				//Debug.Log(currentSwipeSpinForce);
			}	
		} else {
			// see if we are spinning
			if (isSwipeSpin) {
				//Debug.Log(currentSwipeSpinForce);

				if (Mathf.Abs(currentSwipeSpinForce) < 0.001f) {
					currentSwipeSpinForce = 0;
					isSwipeSpin = false;
					//Debug.Log("end spin");
					return;
				}

				// reduce the force by dampener per second
				float dampenerValue = swipeSpinDampener * Time.deltaTime;

				if (currentSwipeSpinForce < 0) {
					currentSwipeSpinForce = currentSwipeSpinForce + dampenerValue;
					if (currentSwipeSpinForce > 0) {
						currentSwipeSpinForce = 0;
					}
				} else {
					currentSwipeSpinForce = currentSwipeSpinForce - dampenerValue;
					if (currentSwipeSpinForce < 0) {
						currentSwipeSpinForce = 0;
					}
				}
					
				// calculate the force applied in this tick FPS independent
				float dialRotationChange = currentSwipeSpinForce * Time.deltaTime * 180;

				transform.Rotate(0,0,dialRotationChange * -1f);
			}
		}
	}

	private void SetCachePos(float cachePosX) {

		if (floatCacheXPos1 != 9999999999) {
			floatCacheXPos2 = floatCacheXPos1;	
		}
		floatCacheXPos1 = cachePosX;
	}

	public void RotateTest() {
		
	}

}