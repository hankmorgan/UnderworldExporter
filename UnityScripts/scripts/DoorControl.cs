using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {
	public bool locked;
	public int KeyIndex;
	private bool state;
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
			StartCoroutine(RotateDoor (this.transform,Vector3.up * 90,1.0f));
			state=true;
		}
	}

	public void CloseDoor()
	{
		if(!DoorBusy)
		{
			Debug.Log ("Move door to closed position");
			StartCoroutine(RotateDoor (this.transform,Vector3.up * -90,1.0f));
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

}
