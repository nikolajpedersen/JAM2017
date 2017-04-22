using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public Helpers.Lanes lane;

	public Helpers.Lanes myLane()
	{
		return lane;
	}

	public void setMyLane(Helpers.Lanes theLane)
	{
		lane = theLane;
	}
	

}
