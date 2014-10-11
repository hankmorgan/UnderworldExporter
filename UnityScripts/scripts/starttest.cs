using UnityEngine;
using System.Collections;

public class starttest : MonoBehaviour {


	void Awake () {
		GameObject player =GameObject.Find ("Gronk");
		Debug.Log ("Moving " + player.name);
		player.transform.position=new Vector3(38.72f,4.152f,3.244f);

		//CreateObj();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
