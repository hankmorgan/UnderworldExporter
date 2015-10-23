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
	public static UWCharacter playerUW;
	PlayerInventory pInv;
	private bool MouseHeldDown=false;

	public static bool WaitingForInput=false;
	public GameObject BlockingCollider;
	//public bool ThrowArea;

	// Use this for initialization
	void Start () {
		//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		playerUW=GameObject.Find ("Gronk").GetComponent <UWCharacter>();
		pInv=GameObject.Find ("Gronk").GetComponent <PlayerInventory>();

	}

	
	// Update is called once per frame
	void Update () {

		BlockingCollider.SetActive(WaitingForInput);
		switch (UWCharacter.InteractionMode)
		{
		case UWCharacter.InteractionModeAttack:
			{
			if (playerUW.AttackExecuting==true)
			{//No attacks can be started will executing the last one.
				return;
			}
			if (MouseHeldDown==true)
				{
					if(playerUW.AttackCharging==false)
					{//Begin the attack
						playerUW.MeleeBegin();
					}
					if ((playerUW.AttackCharging==true) && (playerUW.Charge<100))
					{//While still charging increase the charge by the charge rate.
						playerUW.MeleeCharging ();
					}
				return;
				}
			else if (playerUW.AttackCharging==true)
				{
				//Player has been building an attack up and has released it.
				playerUW.MeleeExecute();
				}
			break;
			}
		default:
			{//TODO:Fix this drag object behaviour.
			/*if ((MouseHeldDown) && (pInv.ObjectInHand==""))
				{
				OnClick();
				}
			else if ((playerUW.CursorInMainWindow) && (pInv.ObjectInHand!="") && (MouseHeldDown==false) && (UWCharacter.InteractionMode==UWCharacter.InteractionModePickup))
				{//Drop the object in hand.
				ThrowObjectInHand();
				}*/
			break;
			}
		}


	

		return;
		if ((UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack) && (MouseHeldDown==true))
		{
			if(playerUW.AttackCharging==false)
			{//Begin the attack
				playerUW.MeleeBegin();
			}
			if ((playerUW.AttackCharging==true) && (playerUW.Charge<100))
			{//While still charging increase the charge by the charge rate.
				playerUW.MeleeCharging ();
			}
			return;
		}
		if ((UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack) && (MouseHeldDown==false) && (playerUW.AttackCharging==true))
		{//Player has been building an attack up and has released it.
			playerUW.MeleeExecute();
		}
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
			playerUW.AttackCharging=false;
			playerUW.Charge=0;
			playerUW.CursorInMainWindow=false;
			if (UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack)
			{
				playerUW.wpa.SetAnimation= playerUW.GetWeapon () +"_Ready_" + playerUW.GetRace () + "_" + playerUW.GetHand();
			}
			else
			{
				playerUW.wpa.SetAnimation= "WeaponPutAway";
			}
			//MessageLog.text="unHover window";
		}
	}

	void OnClick()
	{
		//Debug.Log (UICamera.currentTouchID);
		/*
		 * Cursor Click on main view area
		// */
		//Debug.Log("WindowDetect : interaction is " + UWCharacter.InteractionMode);
		if (playerUW.ReadiedSpell!="" )
		{
			Debug.Log("player has a spell to cast");
			return;
		}

		switch (UWCharacter.InteractionMode)
		{
		case UWCharacter.InteractionModeOptions://Options mode
			return;//do nothing
			break;
		case UWCharacter.InteractionModeTalk://Talk
			playerUW.TalkMode();
			break;
		case UWCharacter.InteractionModePickup://Pickup
			if (playerUW.gameObject.GetComponent<PlayerInventory>().ObjectInHand!="")
				{
				ThrowObjectInHand();
				}
			else
				{
				playerUW.PickupMode();
				}

			break;
		case UWCharacter.InteractionModeLook://look
			playerUW.LookMode();//do nothing
			break;
		case UWCharacter.InteractionModeAttack:	//attack
			playerUW.AttackModeMelee() ;//do nothing
			break;
		case UWCharacter.InteractionModeUse://Use
			if (playerUW.gameObject.GetComponent<PlayerInventory>().ObjectInHand!="")
				{
				UseObjectInHand ();
				}
			else
				{
				playerUW.UseMode();
				}
			break;
		}
	}

void OnPress(bool isDown)
	{
		MouseHeldDown=isDown;
	}

void UseObjectInHand()
	{//TODO:Investigate Camera.Main.Viewport to Ray
		if (pInv.ObjectInHand!="")
		{//The player is holding something
			//Determine what is directly in front of the player via a raycast
			//If something is in the way then cancel the drop
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Ray ray ;
			if (playerUW.MouseLookEnabled==true)
			{
				ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			}
			else
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				//ray= Camera.main.ViewportPointToRay(Input.mousePosition);
				//ray= Camera.main.ScreenPointToRay(Input.mousePosition);
			}

			RaycastHit hit = new RaycastHit(); 

			if (Physics.Raycast(ray,out hit,playerUW.useRange))
			{
//				Debug.Log ("Use Object In Hand :" + pInv.ObjectInHand + " on " + hit.transform.gameObject.name);
				//pInv.InteractTwoObjects(pInv.ObjectInHand,hit.transform.gameObject.name,-1);
				if (hit.transform.gameObject.GetComponent<ObjectInteraction>()!=null)
				{
					hit.transform.gameObject.GetComponent<ObjectInteraction>().Use();
				}
				else
				{
					playerUW.CursorIcon= playerUW.CursorIconDefault;
					pInv.ObjectInHand="";
				}
			}
		}
	}


void ThrowObjectInHand()
	{//Obviously throws the object in the players hand along a vector in the 3d view.
		//Bugged at the moment the vector does not match the mouse position.
		if (pInv.ObjectInHand!="")
		{//The player is holding something
			if (pInv.JustPickedup==false)//To prevent the click event dropping an object immediately after pickup
			{
				//Determine what is directly in front of the player via a raycast
				//If something is in the way then cancel the drop
				//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				Ray ray ;
				if (playerUW.MouseLookEnabled==true)
				{
					ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
				}
				else
				{
					ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					//ray= Camera.main.ViewportPointToRay(Input.mousePosition);
					//ray= Camera.main.ScreenPointToRay(Input.mousePosition);
				}


				RaycastHit hit = new RaycastHit(); 
				float dropRange=0.5f;
				if (!Physics.Raycast(ray,out hit,dropRange))
				{//No object interferes with the drop
					//Calculate the force based on how high the mouse is
					float force = Input.mousePosition.y/Camera.main.pixelHeight *200;
					//float force = Camera.main.ViewportToWorldPoint(Input.mousePosition).y/Camera.main.pixelHeight *200;

					//Get the object being dropped and moved towards the end of the ray
					GameObject droppedItem = GameObject.Find(pInv.ObjectInHand);
					droppedItem.transform.parent=null;
					droppedItem.GetComponent<ObjectInteraction>().PickedUp=false;	//Back in the real world
					GameObject InvMarker = GameObject.Find ("InventoryMarker");
					if (droppedItem.GetComponent<Container>()!=null)
						{
						Container.SetPickedUpFlag(droppedItem.GetComponent<Container>(),false);
						Container.SetItemsParent(droppedItem.GetComponent<Container>(),null);
						Container.SetItemsPosition (droppedItem.GetComponent<Container>(),InvMarker.transform.position);
						}
					droppedItem.transform.position=ray.GetPoint(dropRange-0.1f);//playerUW.transform.position;
					WindowDetect.UnFreezeMovement(droppedItem);
					if (Camera.main.ScreenToViewportPoint (Input.mousePosition).y>0.4f)
					{//throw if above a certain point in the view port.
						Vector3 ThrowDir = ray.GetPoint(dropRange) - pInv.transform.position;
						//Apply the force along the direction.
						droppedItem.GetComponent<Rigidbody>().AddForce(ThrowDir*force);
					}

					//Clear the object and reset the cursor
					playerUW.CursorIcon= playerUW.CursorIconDefault;
					//playerUW.CurrObjectSprite = "";
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