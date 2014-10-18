using UnityEngine;
using System.Collections;

public class PersistObject : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Debug.Log ("Setting don't destroy on " + name);
		DontDestroyOnLoad(gameObject);
		Debug.Log ("Set don't destroy on " + name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
