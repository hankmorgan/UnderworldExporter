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
	public BoxCollider bc;
	// Use this for initialization
	void Start () {
		sc=this.GetComponentInChildren<SpriteRenderer>();
		if (sc!=null)
		{
			if (state==false)//Closed
			{
				setSprite (0);
				AddDoorCollision();
			}
			else
			{
				setSprite (NoOfFrames-1);
			}
		}
		locked=false;
	}

	void setSprite(int index)
	{
		//Sprite Image=new Sprite();
		//Image=Resources.Load <Sprite> ("Doors/" + DoorSpriteIndex + "/" + DoorSpriteIndex + "_" + index.ToString ("D4"));
		//sc.sprite=Image;
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

	void OnMouseDown()
	{
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
			RemoveDoorCollision();
			StartCoroutine(AnimateDoorOpen (1.0f));
			//setSprite (NoOfFrames-1);
			state=true;
		}
	}
	
	public void CloseDoor()
	{
		if(!DoorBusy)
		{
			Debug.Log ("Move door to closed position");
			AddDoorCollision();
			//setSprite (0);
			StartCoroutine(AnimateDoorClose (1.0f));
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

	IEnumerator AnimateDoorOpen(float traveltime)
	{
		float animationFrameTime= traveltime/ NoOfFrames;
		int currentFrame=0;
		float nextFrameTime=animationFrameTime;
		setSprite(currentFrame++);
		for (float t = 0.0f; t<traveltime; t+=Time.deltaTime/traveltime)
		{
			if(t>=nextFrameTime)
				{
				setSprite(currentFrame++);
				nextFrameTime+=animationFrameTime;
				}
			yield return null;
		}
	}

	IEnumerator AnimateDoorClose(float traveltime)
	{
		float animationFrameTime= traveltime/ NoOfFrames;
		int currentFrame=NoOfFrames-1;
		float nextFrameTime=animationFrameTime;
		setSprite(currentFrame--);
		for (float t = 0.0f; t<traveltime; t+=Time.deltaTime/traveltime)
		{
			if(t>=nextFrameTime)
			{
				setSprite(currentFrame--);
				nextFrameTime+=animationFrameTime;
			}
			yield return null;
		}
	}

	private void AddDoorCollision()
	{
		if (bc==null)
		{
			bc = this.gameObject.AddComponent<BoxCollider>();
			bc.center=new Vector3(0.0f,0.317f,0.0f);
			bc.size=new Vector3(0.64f, 0.64f, 0.01f);
		}
	}

	private void RemoveDoorCollision()
	{
		if (bc!=null)
		{
			Destroy (bc);
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
