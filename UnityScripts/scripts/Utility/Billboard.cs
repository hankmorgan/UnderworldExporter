﻿using UnityEngine;

public class Billboard : MonoBehaviour
{
	public float adjustment=0.0f;//0.8f;

	//private Quaternion dir;
	void Update()
	{
		if (Camera.main!=null)
		{

			transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
			//dir =Quaternion.LookRotation(transform.position - (Camera.main.transform.position - (Vector3.up*adjustment)));
			////////transform.rotation=Quaternion.LookRotation(transform.position - (Camera.main.transform.position - (Vector3.up*adjustment)));
				//dir;
			//transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
			//transform.rotation = new Quaternion(dir.x,dir.y,0.0f,dir.w);

		}
		//transform.LookAt(Camera.main.transform.position, Vector3.up);
	}
}