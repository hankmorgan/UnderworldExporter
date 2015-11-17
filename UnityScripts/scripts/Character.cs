using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public int game;
	//What mode are we in and various ranges
	public static int InteractionMode;

	public const int InteractionModeWalk=6;
	public const int InteractionModeOptions=0;
	public const int InteractionModeTalk=1;
	public const int InteractionModePickup=2;
	public const int InteractionModeLook=3;
	public const int InteractionModeAttack=4;
	public const int InteractionModeUse=5;
	public const int InteractionModeInConversation=7; //For trading purposes.
	public static int DefaultInteractionMode=UWCharacter.InteractionModeUse;

	//The storage location for container items.
	public static GameObject InvMarker;

	public UITexture MouseLookCursor;
	//The cursor to display on the gui
	public Texture2D CursorIcon;
	public Texture2D CursorIconDefault;
	public Texture2D CursorIconBlank;
	//public string CurrObjectSprite;

	public CharacterMotorC playerMotor;

	//Character Stats
	public int MaxVIT;
	public int CurVIT;

	public float pickupRange=2.5f;
	public float useRange=2.0f;
	public float talkRange=20.0f;
	public float lookRange=25.0f;


	//For controlling switching between mouse look and interaction
	public MouseLook XAxis;
	public MouseLook YAxis;
	public bool MouseLookEnabled;
	//public bool CursorInMainWindow;


	public string CharName;


	public int currentHeading;
	protected int[] CompassHeadings={0,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0};

	public Camera playerCam;


	public StringController StringControl;
	//The message log on the main screen.
	protected  UILabel MessageLog;


	public MusicController mus;

	protected ObjectInteraction QuantityObj=null;

	public UILabel GetMessageLog()
	{
		if (MessageLog==null)
		{
			MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		}
		return MessageLog;
	}


	public void ApplyDamage(int damage)
	{
		CurVIT=CurVIT-5;
	}

	// Use this for initialization
	public virtual void Start () {

		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();

		//Common stuff
		//ObjectInteraction.player=this.gameObject;
		//ObjectInteraction.SC=StringControl;
		//WindowDetect.playerUW=this.GetComponent<UWCharacter>();
		//ButtonHandler.SC=StringControl;
		//ButtonHandler.player=this.gameObject;
		//InventorySlot.player=this.gameObject;
		InventorySlot.playerUW=this.GetComponent<UWCharacter>();
		TileMap.gronk=this.gameObject;
		DoorControl.playerUW=this.gameObject.GetComponent<UWCharacter>();


		
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
			ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		}
		else
		{
			//ray= Camera.main.ViewportPointToRay(Input.mousePosition);
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
	{
		return pickupRange;
	}

	public void PickupMode()
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
				//ray= Camera.main.ViewportPointToRay(Input.mousePosition);
				ray= Camera.main.ScreenPointToRay(Input.mousePosition);
			}
			
			//= Camera.main.ScreenPointToRay(Input.mousePosition);
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
							//right click check for quant.
							//Pickup if either not a quantity or is a quantity of one.
							if ((objPicked.isQuant ==false) || ((objPicked.isQuant)&&(objPicked.Link==1)) || (objPicked.isEnchanted))
							{
								Pickup(objPicked,pInv);
							}
							else
							{
								Debug.Log("attempting to pick up a quantity");
								UIInput inputctrl =MessageLog.gameObject.GetComponent<UIInput>();
								inputctrl.eventReceiver=this.gameObject;
								inputctrl.type=UIInput.KeyboardType.NumberPad;
								inputctrl.selected=true;
								QuantityObj=objPicked;	
								Time.timeScale=0.0f;
								WindowDetect.WaitingForInput=true;
							}		
						}
						else
						{//Left click. Pick them all up.
								Pickup(objPicked,pInv);	
						}
						
					}
				}
			}
		}
	}




	public virtual void Pickup(ObjectInteraction objPicked, PlayerInventory  pInv)
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
		objPicked.transform.position = InvMarker.transform.position;
		objPicked.transform.parent=InvMarker.transform;

		objPicked.Pickup();//Call pickup event for this object.
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