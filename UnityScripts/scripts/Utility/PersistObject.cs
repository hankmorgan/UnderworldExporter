using UnityEngine;
using System.Collections;

public class PersistObject : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		//if (Application.loadedLevelName=="0")
		//{
		//Debug.Log ("Setting don't destroy on " + name);
		DontDestroyOnLoad(gameObject);				
		//}
		
		//Debug.Log ("Set don't destroy on " + name);
		
	}
	
}
