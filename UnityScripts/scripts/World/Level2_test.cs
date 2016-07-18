using UnityEngine;
using System.Collections;

public class Level2_test : MonoBehaviour {
	//bool PlayerMoved;
	// Use this for initialization
	void OnRoomWasLoaded () {
		GameObject player =GameObject.Find ("Gronk");
		Debug.Log ("Moving " + player.name);
		player.transform.position=new Vector3(0,0,0);
		player.transform.position= transform.position;
	}
	

}
