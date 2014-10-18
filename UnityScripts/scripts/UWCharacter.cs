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

	public float weaponRange=0.5f;

	public string CurrObjectSprite;
	//
	public bool isFemale;
	public bool isLefty;
	public bool CursorInMainWindow;

	public float InteractionDistance;

	// Use this for initialization
	void Start () {

		ObjectInteraction.player=this.gameObject;//Set the player controller for all interaction scripts.
		ButtonHandler.player=this.gameObject;
		InventorySlot.player=this.gameObject;
		InventorySlot.playerUW=this.GetComponent<UWCharacter>();
		XAxis = GetComponent<MouseLook>();
		YAxis =	transform.FindChild ("Main Camera").GetComponent<MouseLook>();
		Screen.lockCursor=true;

		
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
		if(Input.GetMouseButton(1) && (CursorInMainWindow==true) && (UWCharacter.InteractionMode==8) && (AttackCharging==0))
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
