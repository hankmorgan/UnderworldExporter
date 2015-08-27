using UnityEngine;
using System.Collections;

/*
The basic character. Stats and interaction.
 */ 
public class UWCharacter : MonoBehaviour {
	public int game;
	//What mode are we in and various ranges
	public static int InteractionMode;
	public float weaponRange=1.0f;
	public float pickupRange=3.0f;
	public float useRange=3.0f;
	public float talkRange=20.0f;
	public float lookRange=25.0f;
	//public float InteractionDistance;

	//The cursor to display on the gui
	public Texture2D CursorIcon;
	public Texture2D CursorIconDefault;
	public Texture2D CursorIconBlank;
	public string CurrObjectSprite;
	private int cursorSizeX =64;
	private int cursorSizeY =64;

	//For controlling switching between mouse look and interaction
	private MouseLook XAxis;
	private MouseLook YAxis;
	private bool MouseLookEnabled;
	private GameObject MainCam;
	public bool CursorInMainWindow;

	public StringController StringControl;

	//Combat variables
	public int AttackCharging;
	public float Charge;
	public float chargeRate=33.0f;

	//Magic spell to be cast on next click in window
	public string ReadiedSpell;
	//Runes that the character has picked up and is currently using
	public bool[] Runes=new bool[24];
	public int[] ActiveRunes=new int[3];

	//Character related info
	public bool isFemale;
	public bool isLefty;

	//The storage location for container items.
	public static GameObject InvMarker;

	//The message log on the main screen.
	private UILabel MessageLog;

	// Use this for initialization
	void Start () {
		StringControl=new StringController();
		StringControl.InitStringController("c:\\uw1_strings.txt");
		//Initialise some basic references on other objects.
		ObjectInteraction.player=this.gameObject;//Set the player controller for all interaction scripts.
		ObjectInteraction.SC=StringControl;
		a_text_string_trap.SC=StringControl;
		ButtonHandler.SC=StringControl;
		//ObjectInteraction.SC = GameObject.Find ("StringController").GetComponent<StringController>();
		ButtonHandler.player=this.gameObject;
		InventorySlot.player=this.gameObject;
		InventorySlot.playerUW=this.GetComponent<UWCharacter>();
		ActiveRuneSlot.playerUW=this.GetComponent<UWCharacter>();
		RuneSlot.playerUW=this.GetComponent<UWCharacter>();
		WindowDetect.playerUW=this.GetComponent<UWCharacter>();
		Readable.SC=StringControl;

		XAxis = GetComponent<MouseLook>();
		YAxis =	transform.FindChild ("Main Camera").GetComponent<MouseLook>();
		Screen.lockCursor=true;

		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();

		//Debug.Log ("Setting player to " + this.gameObject);
		//Cursor.SetCursor (CursorIcon,Vector2.zero, CursorMode.ForceSoftware);
		//ObjectInteraction.player=this.gameObject;//Set the player controller for all interaction scripts.
		//InventorySlot.player=this.gameObject;
		//InventorySlot.playerUW=this.GetComponent<UWCharacter>();
		//CursorIcon=(Texture2D)Resources.Load("Assets/HUD/cursors/cursors_0000.tga",typeof(Texture2D));
		//Debug.Log ("the player is " + ObjectInteraction.player.name);
		Cursor.SetCursor (CursorIconBlank,Vector2.zero, CursorMode.ForceSoftware);
		//Rect Position = new Rect(Event.current.mousePosition.x-cursorSizeX/2,Event.current.mousePosition.y-cursorSizeY/2,cursorSizeX,cursorSizeY);
		//GUI.DrawTexture (Position,CursorIcon);
		if (game==2)
			{
			InteractionMode=2;
			}
	}

	// Update is called once per frame
	void Update () {
		if (ReadiedSpell!="")
		{//Player has a spell thats about to be cast. All other activity is ignored.
			SpellMode ();
			return;
		}
		return;
		//Performs actions depending on the interaction mode.
		if (CursorInMainWindow==false)
			{//Stop items outside the viewport from being triggered.
			return;
			}
		if (ReadiedSpell!="")
		{//Player has a spell thats about to be cast. All other activity is ignored.
			SpellMode ();
			return;
		}
		switch (UWCharacter.InteractionMode)
		{
		case 0://Options mode
			break;
		case 1://Talk
			TalkMode ();
			break;
		case 2://Pickup
			PickupMode();
			break;
		case 4://look
			LookMode();
			break;
		case 8:	//attack
			AttackModeMelee ();
			break;
		case 16://Use
			UseMode ();
			break;
		}

	}

	public void SpellMode()
	{//Casts a spell on right click.
		if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
		{
			Debug.Log(ReadiedSpell + " is cast in main wind");
			Magic.castSpell(this.gameObject, ReadiedSpell,false);
			//ReadiedSpell="";
		}
	}

	public void UseMode()
	{//Uses the object on right click
		//if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
			//{
		//Debug.Log("USERMODE " + hit.transform.name);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit(); 
			if (Physics.Raycast(ray,out hit,useRange))
			{
				ObjectInteraction objPicked;
				objPicked=hit.transform.GetComponent<ObjectInteraction>();
				
				if (objPicked!=null)
				{
					Debug.Log("USERMODE:Activating objectinteraction "+ hit.transform.name);
					objPicked.Activate();
					//ObjectInteraction.Activate (objPicked);
					//MessageLog.text = "You use a " + hit.transform.name;
				}
		//		//Activates switches.
		//		ButtonHandler objButton = hit.transform.GetComponent<ButtonHandler>();
		//		if (objButton!=null)
		//		{
		//		Debug.Log("USERMODE:Activating buttonhandler "+ hit.transform.name);
		//			objButton.Activate();
		//			return;
		//		}
				//Activates door.
				//DoorControl objDoor = hit.transform.GetComponent<DoorControl>();
				//if (objDoor!=null)
				//{
				//	objDoor.Activate();
				//	return;
				//}
			}
	//	}
	}


	public void PickupMode()
	{//Picks up the clicked object in the view.
		//Debug.Log (Input.GetMouseButtonDown(1))
		//if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
		//	{
			PlayerInventory pInv = this.GetComponent<PlayerInventory>();
			if (InvMarker==null)
				{
				InvMarker=GameObject.Find ("InventoryMarker");
				}
			if (pInv.ObjectInHand=="")//Player is not holding anything.
			{//Find the object within the pickup range.
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit(); 
				if (Physics.Raycast(ray,out hit,pickupRange))
				{
					ObjectInteraction objPicked;
					objPicked=hit.transform.GetComponent<ObjectInteraction>();
					if (objPicked!=null)//Only objects with ObjectInteraction can be picked.
					{
						objPicked.PickedUp=true;	
						//MessageLog.text = "You pick up a " + hit.transform.name;
						CursorIcon=objPicked.InventoryIcon.texture;
						CurrObjectSprite=objPicked.InventoryString;
						pInv.ObjectInHand=hit.transform.name;
						pInv.JustPickedup=true;//To stop me throwing it away immediately.
						if (objPicked.rigidbody !=null)
							{
								objPicked.rigidbody.useGravity=false;
							}
						objPicked.transform.position = InvMarker.transform.position;
					}
				}
			}
		//}
	}

	public void LookMode()
	{//Look at the clicked item.
		//if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
		//{
		//Debug.Log ("Look");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit(); 
			if (Physics.Raycast(ray,out hit,lookRange))
			{
				Debug.Log ("Hit made" + hit.transform.name);
				//MessageLog.text = "You see " + hit.transform.name + " UWCharacter.LookMode()";
				ObjectInteraction objInt = hit.transform.GetComponent<ObjectInteraction>();
				if (objInt != null)
					{
					objInt.LookDescription();//+ "( " + hit.transform.name + " in UWCharacter.LookMode() )";
					//Debug.Log ("lookmode:" + hit.normal + " " + objInt.LookDescription());
					return;
					}
			//ButtonHandler objButton = hit.transform.GetComponent<ButtonHandler>();
			//if (objButton!=null)
			//{
			//	MessageLog.text = "You see " + objButton.LookDescription() + "( " + hit.transform.name + " in UWCharacter.LookMode() )";
				//Debug.Log ("lookmode:" + hit.normal + " " + objInt.LookDescription());
			//	return;
			//}
			}
			//else
			//{
			//	MessageLog.text = "You see nothing  UWCharacter.LookMode()";
			//}
		//}
	}

	public void TalkMode()
	{//Talk to the object clicked on.
		//if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
		//{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit(); 
			if (Physics.Raycast(ray,out hit,talkRange))
			{
				MessageLog.text = "Talking to " + hit.transform.name;
			}
			else
			{
				MessageLog.text = "Talking to yourself?";
			}
		//}
	}

	public void MeleeBegin()
	{//Begins to charge and attack. 
		AttackCharging=1;
		Charge=0;
		Debug.Log ("attack charging begun");
	}

	public void MeleeCharging()	
	{//While still charging increase the charge by the charge rate.
		Charge=(Charge+(chargeRate*Time.deltaTime));
		Debug.Log ("Charging up ");
		if (Charge>100)
		{
			Charge=100;
		}
	}


	public void MeleeExecute()
	{
		Debug.Log ("Attack released");//with charge of " + Charge +"%");
		AttackCharging=0;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit(); 
		if (Physics.Raycast(ray,out hit,weaponRange))
			//if (Physics.Raycast (transform.position,transform.TransformDirection(Vector3.forward),out hit))
		{
			if (hit.transform.Equals(this.transform))
			{
				Debug.Log ("you've hit yourself ? " + hit.transform.name);
			}
			else
			{
				Debug.Log ("you've hit " + hit.transform.name);
				hit.transform.SendMessage("ApplyDamage");
				//Destroy(hit.collider.gameObject);
			}
		}
		else
		{
			Debug.Log ("MISS");
		}
	}

	public void AttackModeMelee()
	{//Code to handle melee Combat
		return;
		//Begins to charge and attack. 
		//As long as the cursor is in the main window the attack will continue to build up.
		if(Input.GetMouseButton(1) && (CursorInMainWindow==true) && (AttackCharging==0))
		{//Begin the attack.
			MeleeBegin();
		}
		if ((AttackCharging==1) && (Charge<100))
		{//While still charging increase the charge by the charge rate.
			MeleeCharging ();
		}
		if (Input.GetMouseButtonUp (1) && (CursorInMainWindow==true) && (AttackCharging==1))
		{//On right click find out what is at the mouse cursor and execute the attack along the raycast
			MeleeExecute ();
		}

	}


	void OnGUI()
	{//Controls switching between Mouselook and interaction.
		if (Event.current.Equals(Event.KeyboardEvent("e")))
		{
			
			if (MouseLookEnabled==false)
			{
				//Debug.Log("Turning on mouselook");
				Screen.lockCursor = true;
				XAxis.enabled=true;
				YAxis.enabled=true;
				MouseLookEnabled=true;
			}
			else
			{
				//Debug.Log("Turning off mouselook");
				Screen.lockCursor = false;
				XAxis.enabled=false;
				YAxis.enabled=false;
				MouseLookEnabled=false;
			}
		}
		//Cursor.SetCursor (CursorIcon,Vector2.zero, CursorMode.ForceSoftware);
		//Debug.Log ("ongui");
		if (MouseLookEnabled == true)
		{
			Rect Position = new Rect((Screen.width/2) - (cursorSizeX/2),(Screen.height/2) - (cursorSizeY/2),cursorSizeX,cursorSizeY);
			//GUI.DrawTexture (Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), CursorIcon);
			GUI.DrawTexture (Position,CursorIcon);
		}
		else
		{
			Rect Position = new Rect(Event.current.mousePosition.x-cursorSizeX/2,Event.current.mousePosition.y-cursorSizeY/2,cursorSizeX,cursorSizeY);
			//GUI.DrawTexture (Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), CursorIcon);
			GUI.DrawTexture (Position,CursorIcon);
		}
		
	}
}
