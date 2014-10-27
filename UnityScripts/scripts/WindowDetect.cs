using UnityEngine;
using System.Collections;
/*
WindowDetect.cs
Functions dealing with the following
1) Detecting if the mouse cursor is within the bounds of the main player view. (and related effects)
2) Dropping and throwing objects in the 3d view
 */

public class WindowDetect : MonoBehaviour {
	//private UILabel MessageLog;
	//public int InteractionMode;
	UWCharacter playerUW;
	PlayerInventory pInv;
	//public bool ThrowArea;
	// Use this for initialization
	void Start () {
		//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		playerUW=GameObject.Find ("Gronk").GetComponent <UWCharacter>();
		pInv=GameObject.Find ("Gronk").GetComponent <PlayerInventory>();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnHover( bool isOver )
	{//Detect if the mouse cursor is in the main window view
		if( isOver )
		{
			playerUW.CursorInMainWindow=true;
			//MessageLog.text=name + "over window";
		}
		else
		{
			playerUW.AttackCharging=0;
			playerUW.Charge=0;
			playerUW.CursorInMainWindow=false;
			//MessageLog.text="unHover window";
		}
	}

	void OnClick()
	{
		/*
		 * Cursor Click on main view area
		 */
		if (pInv.ObjectInHand!="")
			{//The player is holding something
			if (pInv.JustPickedup==false)//To prevent the click event dropping an object immediately after pickup
				{
				//Determine what is directly in front of the player via a raycast
				//If something is in the way then cancel the drop
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit(); 
				float dropRange=0.5f;
				if (!Physics.Raycast(ray,out hit,dropRange))
					{//No object interferes with the drop
						//Calculate the force based on how high the mouse is
						float force = Input.mousePosition.x/Camera.main.pixelHeight *200;
						Debug.Log ("throw force is " + force);
						//Get the object being dropped and moved towards the end of the ray
						GameObject droppedItem = GameObject.Find(pInv.ObjectInHand);
						droppedItem.transform.parent=null;
						droppedItem.transform.position=ray.GetPoint(dropRange-1.0f);//playerUW.transform.position;
						Vector3 ThrowDir = ray.GetPoint(dropRange) - pInv.transform.position;
						//Apply the force along the direction.
						droppedItem.rigidbody.AddForce(ThrowDir*force);
						//Clear the object and reset the cursor
						playerUW.CursorIcon= playerUW.CursorIconDefault;
						playerUW.CurrObjectSprite = "";
						pInv.ObjectInHand="";
					}
				}
			else
			{

				pInv.JustPickedup=false;//The next click event will allow dropping.
			}
				//try and drop the item in the world

			}
	}
}
