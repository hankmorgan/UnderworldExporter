using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	/*Base Character Class*/

	public int game;

	//What interaction mode are we in and various ranges
	public static int InteractionMode;

	public const int InteractionModeWalk=6;
	public const int InteractionModeOptions=0;
	public const int InteractionModeTalk=1;
	public const int InteractionModePickup=2;
	public const int InteractionModeLook=3;
	public const int InteractionModeAttack=4;
	public const int InteractionModeUse=5;
	public const int InteractionModeInConversation=7; //For trading purposes.
	public static int DefaultInteractionMode=InteractionModeUse;

	//The storage location for container items.
	public static GameObject InvMarker;


	//The cursor to display on the gui
	public UITexture MouseLookCursor;
	public Texture2D CursorIcon;
	public Texture2D CursorIconDefault;
	public Texture2D CursorIconBlank;
	public Texture2D CursorIconTarget; //Default Cursor for ranged spells and combat.

	//Reference to a C# version of the standard character controller.
	public CharacterMotorC playerMotor;

	//Character Stats
	public int MaxVIT;
	public int CurVIT;

	protected float pickupRange=2.5f;
	protected float useRange=2.0f;
	protected float talkRange=20.0f;
	protected float lookRange=25.0f;


	//For controlling switching between mouse look and interaction
	public MouseLook XAxis;
	public MouseLook YAxis;
	public bool MouseLookEnabled;

	//The player's name
	public string CharName;

	//Heading values for compass displays
	public int currentHeading;
	protected int[] CompassHeadings={0,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0};

	//The camera attached to this gameobject
	public Camera playerCam;

	//For requesting strings for the message logs.
	public StringController StringControl;

	//The message log on the main screen.
	//protected  UILabel MessageLog;

	//The music system
	public MusicController mus;

	//Object for picking up quantities
	protected ObjectInteraction QuantityObj=null;

	//public UILabel GetMessageLog()
	//{
		/*Returns the message log for various functions*/
	//	if (MessageLog==null)
	//	{
	//		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
	//	}
	//	return MessageLog;
	//}



	public void ApplyDamage(int damage)
	{
		//Applies damage to the player.
		CurVIT=CurVIT-damage;
	}

	// Use this for initialization
	public virtual void Start () {

	//	MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();

		//tell other objects about this object.
		TileMap.gronk=this.gameObject;
		NPC.player=this.gameObject;

		if (game==2)
		{
			InteractionMode=UWCharacter.InteractionModePickup;
		}

	}


	public virtual void Update()
	{
		//Get the current compass heading
		currentHeading = CompassHeadings[ (int)Mathf.Round((  (this.gameObject.transform.eulerAngles.y % 360) / 22.5f)) ];
	}

	public void UseMode()
	{//Uses the object on right click
		Ray ray ;
		if (MouseLookEnabled==true)
		{
			ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));//This is a vector to the center of the window
		}
		else
		{
			ray= Camera.main.ScreenPointToRay(Input.mousePosition);
		}
		RaycastHit hit = new RaycastHit(); 
		if (Physics.Raycast(ray,out hit,GetUseRange()))
		{
			ObjectInteraction objPicked;
			objPicked=hit.transform.GetComponent<ObjectInteraction>();
			
			if (objPicked!=null)
			{
				objPicked.Use();
			}
			else
			{//Special case for portcullises
				if (hit.transform.GetComponent<PortcullisInteraction>()!=null)
				{
					objPicked = hit.transform.GetComponent<PortcullisInteraction>().getParentObjectInteraction();
					if (objPicked!=null)
					{
						objPicked.Use ();
					}
				}
			}
		}
	}

	public virtual float GetUseRange()
	{//Returns the use range of the character
		return useRange;
	}

	public virtual float GetPickupRange()
	{//Returns the pickup range of the character
		return pickupRange;
	}

	public virtual void PickupMode()
	{//Picks up the clicked object in the view.
		PlayerInventory pInv = this.GetComponent<PlayerInventory>();
		if (InvMarker==null)
		{
			InvMarker=GameObject.Find ("InventoryMarker");
		}
		if (pInv.ObjectInHand=="")//Player is not holding anything.
		{//Find the object within the pickup range.
			Ray ray ;
			if (MouseLookEnabled==true)
			{
				ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			}
			else
			{
				ray= Camera.main.ScreenPointToRay(Input.mousePosition);
			}
			RaycastHit hit = new RaycastHit(); 
			if (Physics.Raycast(ray,out hit,GetPickupRange()))
			{
				ObjectInteraction objPicked;
				objPicked=hit.transform.GetComponent<ObjectInteraction>();
				if (objPicked!=null)//Only objects with ObjectInteraction can be picked.
				{
					if (objPicked.CanBePickedUp==true)
					{
						if (UICamera.currentTouchID==-2)
						{
						objPicked=Pickup(objPicked,pInv);
						}
					}
				}
			}
		}
	}

	public virtual ObjectInteraction Pickup(ObjectInteraction objPicked, PlayerInventory  pInv)
	{//completes the pickup.

		objPicked.PickedUp=true;
		if (objPicked.GetComponent<Container>()!=null)
		{
			Container.SetPickedUpFlag(objPicked.GetComponent<Container>(),true);
			Container.SetItemsParent(objPicked.GetComponent<Container>(),InvMarker.transform);
			Container.SetItemsPosition (objPicked.GetComponent<Container>(),InvMarker.transform.position);
		}
		CursorIcon=objPicked.GetInventoryDisplay().texture;
		pInv.ObjectInHand=objPicked.transform.name;
		//////pInv.JustPickedup=true;//To stop me throwing it away immediately.
		if (objPicked.GetComponent<Rigidbody>() !=null)
		{								
			WindowDetect.FreezeMovement(objPicked.gameObject);
		}
		//Clone the object into the inventory
				if (WindowDetectUW.UsingRoomManager==true)
				{
						GameObject objClone = Instantiate(objPicked.gameObject);
						objClone.name=objPicked.name;
						objPicked.name=objPicked.name+ "_destroyed";
						objPicked.transform.DestroyChildren();
						DestroyImmediate(objPicked.gameObject);

						objClone.transform.position = InvMarker.transform.position;
						objClone.transform.parent=InvMarker.transform;
						objClone.GetComponent<ObjectInteraction>().Pickup();
						UniqueIdentifier uid=objClone.GetComponent<UniqueIdentifier>();
						if (uid!=null)
						{
								//uid.Id=uid.GetInstanceID().ToString();		
						}
						objClone.GetComponent<ObjectInteraction>().Pickup();
						return objClone.GetComponent<ObjectInteraction>();	
				}
				else
				{
						objPicked.transform.position=InvMarker.transform.position;
						objPicked.transform.parent=InvMarker.transform;
						objPicked.Pickup();
						return objPicked;
				}

		//objPicked.transform.position = InvMarker.transform.position;
		//objPicked.transform.parent=InvMarker.transform;

		//objPicked.Pickup();//Call pickup event for this object.
	}


	public virtual void LookMode()
	{//Look at the clicked item.
		Ray ray ;
		if (MouseLookEnabled==true)
		{
			ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		}
		else
		{
			ray= Camera.main.ScreenPointToRay(Input.mousePosition);
		}

		RaycastHit hit = new RaycastHit(); 
		if (Physics.Raycast(ray,out hit,lookRange))
		{
			//Debug.Log ("Hit made" + hit.transform.name);
			ObjectInteraction objInt = hit.transform.GetComponent<ObjectInteraction>();
			if (objInt != null)
			{
				objInt.LookDescription();
				return;
			}
		}
	}
}