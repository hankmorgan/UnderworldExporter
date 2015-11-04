using UnityEngine;
using System.Collections;

public class ShockCharacter : MonoBehaviour {
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
	//public string CurrObjectSprite;
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
		//ObjectInteraction.player=this.gameObject;//Set the player controller for all interaction scripts.
		ObjectInteraction.SC=StringControl;
		//a_text_string_trap.SC=StringControl;
	//	ButtonHandler.SC=StringControl;
		//ObjectInteraction.SC = GameObject.Find ("StringController").GetComponent<StringController>();
		//ButtonHandler.player=this.gameObject;
		//InventorySlot.player=this.gameObject;
		InventorySlot.playerUW=this.GetComponent<UWCharacter>();
		ActiveRuneSlot.playerUW=this.GetComponent<UWCharacter>();
		RuneSlot.playerUW=this.GetComponent<UWCharacter>();
	
	//TODO:Shock character
		//WindowDetect.playerUW=this.GetComponent<UWCharacter>();
		
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
	

		
	
	public void PickupMode()
	{//Picks up the clicked object in the view.
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
					//MessageLog.text = "You pick up a " + hit.transform.name;
					CursorIcon=objPicked.GetInventoryDisplay().texture;
					//CurrObjectSprite=objPicked.InventoryString;
					pInv.ObjectInHand=hit.transform.name;
					pInv.JustPickedup=true;//To stop me throwing it away immediately.
					objPicked.transform.position = InvMarker.transform.position;
				}
			}
		}
		//}
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
