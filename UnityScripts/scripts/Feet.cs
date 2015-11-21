using UnityEngine;
using System.Collections;

public class Feet : MonoBehaviour {
	//For a game object attached to the player. Detects if the player is in contact with the ground.

	public TileMap tm;

	void OnTriggerStay(Collider other) {
		TileMap.OnGround=true;  
	}

	void OnTriggerExit(Collider other) {
		//Debug.Log ("Exit");
		TileMap.OnGround=false;
		tm.PositionDetect();
	}
}
