using UnityEngine;
using System.Collections;
/*
WindowDetect.cs
Functions dealing with the following
1) Detecting if the mouse cursor is within the bounds of the main player view. (and related effects)
2) Dropping and throwing objects in the 3d view
 */

public class WindowDetect : MonoBehaviour {

	protected  int cursorSizeX =64;
	protected  int cursorSizeY =64;

	//public static UWCharacter playerUW;
	public bool MouseHeldDown=false;
	public bool FullScreen;

	public static bool WaitingForInput=false;
	public static bool InMap=false;
	public GameObject BlockingCollider;

	static public bool CursorInMainWindow;
	//protected UIAnchor anchor;
	//protected UIStretch stretch;

	protected Rect CursorPosition;

	public virtual void Start()
	{
		//anchor=this.GetComponent<UIAnchor>();
		//stretch=this.GetComponent<UIStretch>();
		CursorPosition = new Rect(
			0.0f,
			0.0f,
			cursorSizeX,
			cursorSizeY);
	}
	
	// Update is called once per frame
	protected virtual void Update () {

				//	BlockingCollider.SetActive(WaitingForInput || InMap  );

	}

	protected virtual void OnHover( bool isOver )
	{//Detect if the mouse cursor is in the main window view
		CursorInMainWindow=isOver;
	}



	protected virtual void OnPress(bool isDown,int ptrID)
		{
	
			MouseHeldDown=isDown;
		}

	protected virtual void UseObjectInHand()
		{
			return;
		}


	protected virtual void ThrowObjectInHand()
	{//Obviously throws the object in the players hand along a vector in the 3d view.
		return;
	}

	public static void FreezeMovement(GameObject myObj)
	{//Stop objects which can move in the 3d world from moving when they are in the inventory or containers.
		Rigidbody rg = myObj.GetComponent<Rigidbody>();
		if (rg!=null)
		{
			rg.useGravity=false;
			rg.constraints = 
					  RigidbodyConstraints.FreezeRotationX 
					| RigidbodyConstraints.FreezeRotationY 
					| RigidbodyConstraints.FreezeRotationZ 
					| RigidbodyConstraints.FreezePositionX 
					| RigidbodyConstraints.FreezePositionY 
					| RigidbodyConstraints.FreezePositionZ;
		}
	}

	public static void UnFreezeMovement(GameObject myObj)
	{//Allow objects which can move in the 3d world to moving when they are released.
		Rigidbody rg = myObj.GetComponent<Rigidbody>();
		if (rg!=null)
		{
			rg.useGravity=true;
			rg.constraints = 
				RigidbodyConstraints.FreezeRotationX 
					| RigidbodyConstraints.FreezeRotationY 
					| RigidbodyConstraints.FreezeRotationZ;

		}
	}
}