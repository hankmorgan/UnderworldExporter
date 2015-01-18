using UnityEngine;
using System.Collections;

public class DoorControlShock : MonoBehaviour {
	public bool locked;
	public int KeyIndex;
	private bool state;
	public bool DoorBusy;
	public int DoorSpriteIndex;
	public int NoOfFrames;
	private SpriteRenderer sc;
	// Use this for initialization
	void Start () {
		sc=this.GetComponentInChildren<SpriteRenderer>();
		if (sc!=null)
		{
			if (state==false)//Closed
			{
				setSprite (0);
			}
			else
			{
				setSprite (NoOfFrames-1);
			}
		}
	}

	void setSprite(int index)
	{
		Sprite Image=new Sprite();
		Image=Resources.Load <Sprite> ("Doors/" + DoorSpriteIndex + "/" + DoorSpriteIndex + "_" + index.ToString ("D4"));
		sc.sprite=Image;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Activate()
	{
		//Debug.Log (this.name + " touched");
			if (state==false)
			{//Door is closed
				OpenDoor ();
			}
			else
			{//Door is open
				CloseDoor ();
			}
		}

	public void PlayerTouch()
	{
		//Debug.Log (this.name + " touched");
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
			//StartCoroutine(AnimateDoor (this.transform,Vector3.up * 90,1.0f));
			setSprite (NoOfFrames-1);
			state=true;
		}
	}
	
	public void CloseDoor()
	{
		if(!DoorBusy)
		{
			Debug.Log ("Move door to closed position");
			setSprite (0);
			//StartCoroutine(AnimateDoor (this.transform,Vector3.up * -90,1.0f));
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
	
	
/*	IEnumerator AnimateDoor(Transform door, Vector3 turningAngle, float traveltime)
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
	}*/
}
