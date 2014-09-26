using UnityEngine;
using System.Collections;

public class MouseLocker : MonoBehaviour {
	private MouseLook XAxis;
	private MouseLook YAxis;
	private bool MouseLookEnabled;
	private GameObject MainCam;
	// Use this for initialization
	void Start () {
		//MainCam=GameObject.Find("Main Camera");
		XAxis = GetComponent<MouseLook>();
		YAxis =	transform.FindChild ("Main Camera").GetComponent<MouseLook>();
		Screen.lockCursor=true;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.E))
		{
			if (MouseLookEnabled==true)
			{

				Screen.lockCursor = true;
				XAxis.enabled=true;
				YAxis.enabled=true;
				MouseLookEnabled=false;
			}
			else
			{
				Screen.lockCursor = false;
				XAxis.enabled=false;
				YAxis.enabled=false;
				MouseLookEnabled=true;
			}

		}
			
	}
}
