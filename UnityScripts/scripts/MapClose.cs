using UnityEngine;
using System.Collections;

public class MapClose : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick()
	{
		GameObject map = GameObject.Find ("Automap");
		
		//Turn on the camera
		foreach(Transform child in map.transform)
		{
			if (child.name == "Camera")
			{
				child.gameObject.SetActive(false);
			}
		}
		//Turn off the main hud
		GameObject UWHud =GameObject.Find ("UW_HUD");
		foreach(Transform child in UWHud.transform)
		{
			if ((child.name == "Anchor")||(child.name == "Camera"))
			{
				child.gameObject.SetActive(true);
			}
		}
	}
}
