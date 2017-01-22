using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Character : UWEBase {
	/*Base Character Class*/

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

	//Reference to a C# version of the standard character controller.
	public CharacterMotorC playerMotor;

	public CharacterController playerController;

	//Character Stats
	public int MaxVIT;
	public int CurVIT;

	protected float pickupRange=2.5f;
	protected float useRange=2.0f;
	protected float talkRange=20.0f;
	protected float lookRange=25.0f;

	/// <summary>
	/// The calculated detection range for when NPCs can first become aware of the PC.
	/// </summary>
	public float DetectionRange=6.0f;

	/// <summary>
	/// At what distance from the player is the AI awake for processing.
	/// </summary>
	public const float BaseAIWakeRange=8.0f;

	/// <summary>
	/// The base detection range for hostile AI who are not currently targetting the player.
	/// </summary>
	public const float BaseDetectionRange=6.0f;

	/// <summary>
	/// The minimum detection range a player can achieve
	/// </summary>
	public const float MinDetectionRange=0.2f;


	//For controlling switching between mouse look and interaction
	public MouseLook XAxis;
	public MouseLook YAxis;
	public bool MouseLookEnabled;

	//The player's name
	public string CharName;

	//Heading values for compass displays
	public int currentHeading;
	protected int[] CompassHeadings={0,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0};

		//Camera direction for billboarding
		public Vector3 dir; 

	//The camera attached to this gameobject
	public Camera playerCam;

	public Vector3 CameraPos;

	//Object for picking up quantities
	protected ObjectInteraction QuantityObj=null;

		/// <summary>
		/// Tracks the last enemy character to hit th eplayer.
		/// </summary>
	public GameObject LastEnemyToHitMe;

		/// <summary>
		/// Signals allied creatures to come help the player.
		/// </summary>
		public bool HelpMeMyFriends;

	/// <summary>
	/// The player has an active lightsource in use.
	/// </summary>
	public bool LightActive;

	/// <summary>
	/// The point enemies will aim at when trying to hit the player.
	/// </summary>
	public GameObject TargetPoint;

	public void ApplyDamage(int damage)
	{
		//Applies damage to the player.
		CurVIT=CurVIT-damage;
		//TODO:Check the players armour and apply damage on a crit			
	}

	//Damage from a known source
	public void ApplyDamage(int damage, GameObject src)
	{
		ApplyDamage(damage);
		HelpMeMyFriends=true;
		LastEnemyToHitMe=src;			
	}

	// Use this for initialization
	public virtual void Start () {
		if (GameWorldController.instance.game=="SS1")
		{
			InteractionMode=UWCharacter.InteractionModePickup;
		}
	}


	public virtual void Update()
	{
		//Get the current compass heading
		currentHeading = CompassHeadings[ (int)Mathf.Round((  (this.gameObject.transform.eulerAngles.y % 360) / 22.5f)) ];
				dir = Camera.main.transform.forward;//Billboarding
				dir.y = 0.0f;
				CameraPos=Camera.main.transform.position;
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
						UWHUD.instance.window.UWWindowWait (1.0f);
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

	public virtual void PickupMode (int ptrId)
	{//Picks up the clicked object in the view.
		PlayerInventory pInv = this.GetComponent<PlayerInventory>();
		if (InvMarker==null)
		{
			InvMarker=GameWorldController.instance.InventoryMarker;//GameObject.Find ("InventoryMarker");
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
						if (ptrId==-2)
						{
						objPicked=Pickup(objPicked,pInv);
						}
					}
					else
					{//Object cannot be picked up. Try and use it instead
						if (objPicked.CanBeUsed)
						{
							UseMode();
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
		UWHUD.instance.CursorIcon=objPicked.GetInventoryDisplay().texture;
		pInv.ObjectInHand=objPicked.transform.name;
		if (objPicked.GetComponent<Rigidbody>() !=null)
		{								
			GameWorldController.FreezeMovement(objPicked.gameObject);
		}
		//Clone the object into the inventory
		if (WindowDetectUW.UsingRoomManager==true)
		{
			GameObject objClone = Instantiate(objPicked.gameObject);
			objClone.name=objPicked.name;
			objPicked.name=objPicked.name+ "_destroyed";
			//objPicked.transform.DestroyChildren();
			DestroyImmediate(objPicked.gameObject);

			objClone.transform.position = InvMarker.transform.position;
			objClone.transform.parent=InvMarker.transform;
			objClone.GetComponent<ObjectInteraction>().Pickup();
			/*
			UniqueIdentifier uid=objClone.GetComponent<UniqueIdentifier>();
			if (uid!=null)
			{
					//uid.Id=uid.GetInstanceID().ToString();		
			}
			*/
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