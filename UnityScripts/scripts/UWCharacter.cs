using UnityEngine;
using System.Collections;

public class UWCharacter : MonoBehaviour {
	public static int InteractionMode;
	public Texture2D CursorIcon;
	public Texture2D CursorIconDefault;
	public Texture2D CursorIconBlank;
	private int cursorSizeX =64;
	private int cursorSizeY =64;
	//
	private MouseLook XAxis;
	private MouseLook YAxis;
	private bool MouseLookEnabled;
	private GameObject MainCam;

	public int AttackCharging;
	public float Charge;
	public float chargeRate=33.0f;

	public float weaponRange=1.0f;
	public float pickupRange=3.0f;
	public float useRange=3.0f;
	public float talkRange=20.0f;
	public string CurrObjectSprite;

	public bool isFemale;
	public bool isLefty;
	public bool CursorInMainWindow;

	public float InteractionDistance;
	public static GameObject InvMarker;

	private UILabel MessageLog;

	public bool[] Runes=new bool[24];
	public int[] ActiveRunes=new int[3];

	// Use this for initialization
	void Start () {

		ObjectInteraction.player=this.gameObject;//Set the player controller for all interaction scripts.
		ButtonHandler.player=this.gameObject;
		InventorySlot.player=this.gameObject;
		InventorySlot.playerUW=this.GetComponent<UWCharacter>();
		ActiveRuneSlot.playerUW=this.GetComponent<UWCharacter>();
		RuneSlot.playerUW=this.GetComponent<UWCharacter>();
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
	}
	
	// Update is called once per frame
	void Update () {
		if (CursorInMainWindow==false)
			{//Stop items outside the viewport from being triggered.
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


	void UseMode()
	{
		if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
			{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit(); 
			if (Physics.Raycast(ray,out hit,pickupRange))
			{
				ObjectInteraction objPicked;
				objPicked=hit.transform.GetComponent<ObjectInteraction>();
				if (objPicked!=null)
				{
					MessageLog.text = "You use a " + hit.transform.name;
				}
				ButtonHandler objButton = hit.transform.GetComponent<ButtonHandler>();
				if (objButton!=null)
				{
					objButton.Activate();
				}
			}
		}
	}


	void PickupMode()
	{
		if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
			{
			PlayerInventory pInv = this.GetComponent<PlayerInventory>();
			if (InvMarker==null)
			{
				InvMarker=GameObject.Find ("InventoryMarker");
			}
			if (pInv.ObjectInHand=="")
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit(); 
				if (Physics.Raycast(ray,out hit,pickupRange))
				{
					ObjectInteraction objPicked;
					objPicked=hit.transform.GetComponent<ObjectInteraction>();
					if (objPicked!=null)
					{
						MessageLog.text = "You pick up a " + hit.transform.name;
						CursorIcon=objPicked.InventoryIcon.texture;
						CurrObjectSprite=objPicked.InventoryString;
						pInv.ObjectInHand=hit.transform.name;
						pInv.JustPickedup=true;//To stop me throwing it away immediately.
						objPicked.transform.position = InvMarker.transform.position;
					}
				}
			}
		}
	}

	void LookMode()
	{
		if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit(); 
			if (Physics.Raycast(ray,out hit,talkRange))
			{
				MessageLog.text = "You see " + hit.transform.name;
			}
			else
			{
				MessageLog.text = "You see nothing";
			}
		}
	}

	void TalkMode()
	{
		if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit(); 
			if (Physics.Raycast(ray,out hit,talkRange))
			{
				MessageLog.text = "Talking to " + hit.transform.name;
			}
			else
			{
				MessageLog.text = "Talking to yourself? ";
			}
		}
	}

	void AttackModeMelee()
	{//Code to handle melee Combat
		if(Input.GetMouseButton(1) && (CursorInMainWindow==true) && (AttackCharging==0))
		{
			AttackCharging=1;
			Charge=0;
			Debug.Log ("attack charging begun");
		}
		if ((AttackCharging==1) && (Charge<100))
		{
			Charge=(Charge+(chargeRate*Time.deltaTime));
			Debug.Log ("Charging is " + Charge);
			if (Charge>100)
			{
				Charge=100;
			}
		}
		if (Input.GetMouseButtonUp (1) && (CursorInMainWindow==true) && (AttackCharging==1))
		{
			Debug.Log ("Attack released with charge of " + Charge +"%");
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

	}


	void OnGUI()
	{
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
