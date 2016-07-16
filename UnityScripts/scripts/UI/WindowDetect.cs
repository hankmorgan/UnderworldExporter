using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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

	public Rect CursorPosition;
	
		//UI Positioning
	public RectTransform[] UIsToStore = new RectTransform[1];
	public Vector3[] UIPositionsWindowed = new Vector3[1];
	public Vector3[] UIPositionsFullScreen= new Vector3[1];


	public virtual void Start()
	{
		//anchor=this.GetComponent<UIAnchor>();
		//stretch=this.GetComponent<UIStretch>();
		CursorPosition = new Rect(
			0.0f,
			0.0f,
			cursorSizeX,
			cursorSizeY);
			if (this.FullScreen==false)
			{
					for (int i = 0; i<=UIsToStore.GetUpperBound(0);i++)
					{
						UIPositionsWindowed[i]= UIsToStore[i].position;
							if (UIPositionsFullScreen[i] == Vector3.zero)
							{
								UIPositionsFullScreen[i]= UIsToStore[i].position;
							}
					}
			}
	}
	
	// Update is called once per frame
	protected virtual void Update () {

				//	BlockingCollider.SetActive(WaitingForInput || InMap  );

	}

	public void updatePositions()
	{//stores the positions of ui elements in fullscreenmode
		for (int i = 0; i<=UIsToStore.GetUpperBound(0);i++)
		{
			UIPositionsFullScreen[i]= UIsToStore[i].position;
		}
	}

	public void setPositions()
	{
		if (this.FullScreen==true)
			{//put ui elements in fullscreen positions
				for (int i = 0; i<=UIsToStore.GetUpperBound(0);i++)
				{
					UIsToStore[i].position= UIPositionsFullScreen[i];
				}
			}
		else
			{//put ui elements in windowed positions.
				for (int i = 0; i<=UIsToStore.GetUpperBound(0);i++)
				{
					UIsToStore[i].position= UIPositionsWindowed[i];
				}	
			}
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