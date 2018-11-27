using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Character : UWEBase {
    /*Base Character Class*/

    //What interaction mode are we in and various ranges
    public static int InteractionMode;

    public const int InteractionModeWalk = 6;
    public const int InteractionModeOptions = 0;
    public const int InteractionModeTalk = 1;
    public const int InteractionModePickup = 2;
    public const int InteractionModeLook = 3;
    public const int InteractionModeAttack = 4;
    public const int InteractionModeUse = 5;
    public const int InteractionModeInConversation = 7; //For trading purposes.
    public static int DefaultInteractionMode = InteractionModeUse;

    /// <summary>
    /// At what distance from the player is the AI awake for processing.
    /// </summary>
    public const float BaseAIWakeRange = 8.0f;

    /// <summary>
    /// The base detection range for hostile AI who are not currently targetting the player.
    /// </summary>
    public const float BaseDetectionRange = 6.0f;

    /// <summary>
    /// The minimum detection range a player can achieve
    /// </summary>
    public const float MinDetectionRange = 0.2f;


    //The storage location for container items.
    //public static GameObject GameWorldController.instance.InventoryMarker;

    //Reference to a C# version of the standard character controller.

    [Header("Controllers")]
    public CharacterMotorC playerMotor;
    public CharacterController playerController;
    public AudioSource aud;
    public AudioSource footsteps;
    public bool step = true;

    [Header("Health")]
    [SerializeField]
    private int _MaxVit;
    /// <summary>
    /// Get or Set Player vitality.
    /// </summary>
    public int MaxVIT
    {
        get
        {
            return _MaxVit;
        }
        set
        {
            _MaxVit = value;
            UWHUD.instance.FlaskHealth.UpdateFlaskDisplay();     
        }
    }
    [SerializeField]
    private int _CurVit;
    public int CurVIT
    {
        get
        {
            return _CurVit;
        }
        set
        {
            _CurVit = value;
            UWHUD.instance.FlaskHealth.UpdateFlaskDisplay();
        }
    }

	[Header("Interaction Ranges")]	
	public float pickupRange=2.5f;
	public float useRange=2.0f;
	public float talkRange=20.0f;
	public float lookRange=25.0f;
	/// <summary>
	/// The calculated detection range for when NPCs can first become aware of the PC.
	/// </summary>
	public float DetectionRange=6.0f;


	/// <summary>
	/// The base engagement range.
	/// How close do you need to be to an npc for them to want to track you down
	/// </summary>
	public float BaseEngagementRange = 8;

	public static bool Invincible;
    public static bool AutoKeyUse;

	//For controlling switching between mouse look and interaction
	[Header("Mouselook")]	
	public MouseLook XAxis;
	public MouseLook YAxis;
	public bool MouseLookEnabled;

	[Header("Character")]	
	//The player's name
	public string CharName;

	//Heading values for compass displays
	[Header("Compass and Position")]	
	public int currentHeading;
	protected int[] CompassHeadings={0,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0};
	//Camera direction for billboarding
	public Vector3 dir;
	public Vector3 dirForNPC; 

		[Header("Camera")]
	//The camera attached to this gameobject
	public Camera playerCam;
	public Vector3 CameraPos;

	//Object for picking up quantities
	protected ObjectInteraction QuantityObj=null;



	[Header("AI")]
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
		/// <summary>
		/// The room index the player is in
		/// </summary>
	//public int room;



	public void ApplyDamage(int damage)
	{
		if (!Invincible)
		{
			CurVIT=CurVIT-damage;	
		}
		else
		{
			//Debug.Log("Invincible character damage is " + damage );
		}
        //Applies damage to the player.

        //TODO:Check the players armour and apply damage on a crit			
        //CameraShake.instance.shakeDuration = 0.2f;
        CameraShake.instance.ShakeCombat(0.2f);
    }

	//Damage from a known source
	public void ApplyDamage(int damage, GameObject src)
	{
		ApplyDamage(damage);
		HelpMeMyFriends=true;
		LastEnemyToHitMe=src;			
	}

	// Use this for initialization
	public virtual void Begin () {
		if (_RES==GAME_SHOCK)
		{
			InteractionMode=UWCharacter.InteractionModePickup;
			UWCharacter.Instance.playerCam.rect= new Rect(0.0f,0.0f,1.0f,1.0f);
		}
	}


	public virtual void Update()
	{
		//Get the current compass heading
		currentHeading = CompassHeadings[ (int)Mathf.Round((  (this.gameObject.transform.eulerAngles.y % 360) / 22.5f)) ];
		dir = Camera.main.transform.forward;//Billboarding
		dirForNPC=dir;
		dirForNPC.y=0.0f;
				//dir.y = 0.0f;
		CameraPos=Camera.main.transform.position;

				if (transform.position.y <-10f)
				{
						if (CurrentTileMap()!=null)
						{
								this.transform.position = CurrentTileMap().getTileVector(TileMap.visitedTileX,TileMap.visitedTileY);			
						}					
				}
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
				else if (hit.transform.parent==GameWorldController.instance.LevelModel.transform)
				{
					if (EditorMode)	
					{
						string[] tilenamePortions = hit.transform.name.Split('_');
						int tileX=int.Parse(tilenamePortions[1]);
						int tileY=int.Parse(tilenamePortions[2]);
						if (IngameEditor.FollowMeMode)	
						{
							IngameEditor.UpdateFollowMeMode(tileX,tileY);	
						}
						else
						{
							IngameEditor.instance.SelectTile(tileX,tileY);
						}
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
		if (pInv.ObjectInHand==null)//Player is not holding anything.
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
						if (objPicked.isUsable)
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

        //FIELD PICKUP objPicked.PickedUp=true;
        if (objPicked.GetComponent<Container>()!=null)
		{
			Container.SetPickedUpFlag(objPicked.GetComponent<Container>(),true);
			Container.SetItemsParent(objPicked.GetComponent<Container>(),GameWorldController.instance.InventoryMarker.transform);
			Container.SetItemsPosition (objPicked.GetComponent<Container>(),GameWorldController.instance.InventoryMarker.transform.position);
		}
		//UWHUD.instance.CursorIcon=objPicked.GetInventoryDisplay().texture;
		pInv.ObjectInHand=objPicked;
		if (objPicked.GetComponent<Rigidbody>() !=null)
		{								
			FreezeMovement(objPicked.gameObject);
		}

		objPicked.transform.position=GameWorldController.instance.InventoryMarker.transform.position;
		objPicked.transform.parent=GameWorldController.instance.InventoryMarker.transform;
		GameWorldController.MoveToInventory(objPicked);
		pInv.ObjectInHand=objPicked;
		objPicked.Pickup();
		return objPicked;

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

	public override Vector3 GetImpactPoint ()
	{
		return TargetPoint.transform.position;
	}
}