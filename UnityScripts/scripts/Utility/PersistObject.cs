using UnityEngine;
using System.Collections;

/// <summary>
/// Makes sure the object persists.
/// </summary>
public class PersistObject : UWEBase {
	void Awake () {
		DontDestroyOnLoad(gameObject);	
	}	
}