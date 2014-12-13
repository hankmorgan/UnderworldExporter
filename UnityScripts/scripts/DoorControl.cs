using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {
	public bool locked;
	public int KeyIndex;
	private bool state;
	public bool isPortcullis;
	public bool DoorBusy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate()
	{
		Debug.Log (this.name + " touched");
		if (locked==false)
		{//Toggle Open and closed
			if (state==false)
				{//Door is closed
				OpenDoor ();
				}
			else
				{//Door is open
				CloseDoor ();
				}
		}
		else
		{
			Debug.Log(this.name + " is locked");
		}
	}

	public void OpenDoor()
	{
		if(!DoorBusy)
		{
			Debug.Log ("Move door to open position");
			if (isPortcullis==false)
			{
				StartCoroutine(RotateDoor (this.transform,Vector3.up * 90,1.0f));
			}
			else
			{
				StartCoroutine(RaiseDoor (this.transform,new Vector3(0f,0.85f,0f),1.0f));
			}
			state=true;
		}
	}

	public void CloseDoor()
	{
		if(!DoorBusy)
		{
			Debug.Log ("Move door to closed position");
			if (isPortcullis==false)
			{
				StartCoroutine(RotateDoor (this.transform,Vector3.up * -90,1.0f));
			}
			else
			{
				StartCoroutine(RaiseDoor (this.transform,new Vector3(0f,-0.85f,0f),1.0f));
			}
			state=false;
		}
	}

	public void LockDoor()
	{
		Debug.Log ("Locking door");
		locked=false;
	}

	public void UnlockDoor()
	{
		Debug.Log ("Locking door");
		locked=true;
	}

	public void ToggleLock()
	{
		if (locked==false)
		{
			locked=true;	
		}
		else
		{
			locked=false;	
		}
	}

	public void ToggleDoor()
	{
		if (state==false)//Closed
		{
			UnlockDoor();
			OpenDoor();	
		}
		else
		{
			CloseDoor ();
			LockDoor();
		}
	}


	IEnumerator RotateDoor(Transform door, Vector3 turningAngle, float traveltime)
	{
		Quaternion StartAngle = door.rotation;
		Quaternion EndAngle = Quaternion.Euler (door.eulerAngles+turningAngle);
		DoorBusy=true;
		for (float t = 0.0f; t<traveltime; t+=Time.deltaTime/traveltime)
		{
			door.rotation=Quaternion.Lerp (StartAngle,EndAngle,t);
			yield return null;
		}
		DoorBusy=false;
	}
	
	IEnumerator RaiseDoor(Transform door, Vector3 TransformDir, float traveltime)
	{
		float rate = 1.0f/traveltime;
		float index = 0.0f;
		Vector3 StartPos = door.position;
		Vector3 EndPos = StartPos + TransformDir;
		DoorBusy=true;
		while (index <traveltime)
		{
			door.position = Vector3.Lerp (StartPos,EndPos,index);
			index += rate * Time.deltaTime;
			yield return new WaitForSeconds(0.01f);
		}
		DoorBusy=false;
		door.position = EndPos;
	}


}
