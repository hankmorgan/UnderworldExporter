using UnityEngine;
using System.Collections;

/*
The basic character. Stats and interaction.
 */ 
public class UWCharacter : MonoBehaviour {
	public int game;
	//What mode are we in and various ranges
	public static int InteractionMode;


	public const int InteractionModeOptions=0;
	public const int InteractionModeTalk=1;
	public const int InteractionModePickup=2;
	public const int InteractionModeLook=3;
	public const int InteractionModeAttack=4;
	public const int InteractionModeUse=5;
	public static int DefaultInteractionMode=UWCharacter.InteractionModeUse;

	public const int SkillAttack =0;
	public const int SkillDefense =1;
	public const int SkillUnarmed =2;
	public const int SkillSword =3;
	public const int SkillAxe =4;
	public const int SkillMace =5;
	public const int SkillMissile =6;
	public const int SkillMana =7;
	public const int SkillLore =8;
	public const int SkillCasting =9;
	public const int SkillTraps =10;
	public const int SkillSearch =11;
	public const int SkillTrack =12;
	public const int SkillSneak =13;
	public const int SkillRepair =14;
	public const int SkillCharm =15;
	public const int SkillPicklock =16;
	public const int SkillAcrobat =17;
	public const int SkillAppraise =18;
	public const int SkillSwimming =19;

	private string[] Skillnames = {"ATTACK","DEFENSE","UNARMED","SWORD","AXE","MACE","MISSILE",
		"MANA","LORE","CASTING","TRAPS","SEARCH","TRACK","SNEAK","REPAIR",
		"CHARM","PICKLOCK","ACROBAT","APPRAISE","SWIMMING"};


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
	private int cursorSizeX =32;
	private int cursorSizeY =32;

	//For controlling switching between mouse look and interaction
	private MouseLook XYAxis;
	//private MouseLook YAxis;
	private bool MouseLookEnabled;
	private GameObject MainCam;
	public bool CursorInMainWindow;

	public StringController StringControl;
	//The message log on the main screen.
	private UILabel MessageLog;

	//Combat variables
	public bool AttackCharging;
	public bool AttackExecuting;
	public float Charge;
	public float chargeRate=33.0f;

	//Magic spell to be cast on next click in window
	public string ReadiedSpell;
	//Runes that the character has picked up and is currently using
	public bool[] Runes=new bool[24];
	public int[] ActiveRunes=new int[3];

	public SpellEffect[] ActiveSpell=new SpellEffect[3]; //What magic spells are currently active on the player. (max 3)

	public int Body;//Which body/portrait this character has

	//The storage location for container items.
	public static GameObject InvMarker;

	//Character related info
	//Character Details
	public string CharName;
	public string CharClass;
	public int CharLevel;
	public bool isFemale;
	public bool isLefty;
	public bool isSwimming;

	//Character Status
	public int FoodLevel;
	public int Fatigue;
	public bool Poisoned;

	//Character Stats
	public int STR;
	public int DEX;
	public int INT;
	public int MaxVIT;
	public int CurVIT;
	public int MaxMana;
	public int CurMana;
	public int EXP;

	//Character skills
	public int Attack;
	public int Defense;
	public int Unarmed;
	public int Sword;
	public int Axe;
	public int Mace;
	public int Missile;
	public int ManaSkill;
	public int Lore;
	public int Casting;
	public int Traps;
	public int Search;
	public int Track;
	public int Sneak;
	public int Repair;
	public int Charm;
	public int PickLock;
	public int Acrobat;
	public int Appraise;
	public int Swimming;


	public int currentHeading;

	private int[] CompassHeadings={0,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0};

	public WeaponAnimation wpa;

	// Use this for initialization
	void Start () {

		//Cursor.visible = false;
		StringControl=new StringController();
	//	StringControl.InitStringController("c:\\uw1_strings.txt");
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
		SpellEffectsDisplay.playerUW=this.GetComponent<UWCharacter>();
		RuneSlot.playerUW=this.GetComponent<UWCharacter>();
		WindowDetect.playerUW=this.GetComponent<UWCharacter>();
		TileMap.gronk=this.gameObject;
		HealthFlask.playerUW=this.gameObject.GetComponent<UWCharacter>();
		Compass.playerUW=this.gameObject.GetComponent<UWCharacter>();
		//Readable.SC=StringControl;
		StatsDisplay.playerUW=this.gameObject.GetComponent<UWCharacter>();
		DoorControl.playerUW=this.gameObject.GetComponent<UWCharacter>();
		Conversation.playerUW = this.gameObject.GetComponent<UWCharacter>();
		Conversation.SC=ObjectInteraction.SC;
		NPC.playerUW=this.GetComponent<UWCharacter>();
		GoblinAI.player=this.gameObject;



		XYAxis = GetComponent<MouseLook>();
		//YAxis =	transform.FindChild ("Main Camera").GetComponent<MouseLook>();
		//Screen.lockCursor=true;
		Cursor.lockState=CursorLockMode.None;

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
			InteractionMode=UWCharacter.InteractionModePickup;
			}
		else
			{
			InteractionMode=UWCharacter.DefaultInteractionMode;
			}
		StringControl.InitStringController(Application.dataPath + "//..//uw1_strings.txt");

		wpa = GameObject.Find ("HudAnimations").GetComponentInChildren<WeaponAnimation>();
	}

	// Update is called once per frame
	void Update () {
		if (CurVIT<=0)
		{
			//Debug.Log ("You have died!. Queue the laughing skulls.");
			return;
		}
		if (ReadiedSpell!="")
		{//Player has a spell thats about to be cast. All other activity is ignored.
			SpellMode ();
			return;
		}
		if ((AttackCharging==false) && (AttackExecuting==false))
		{
			if ((InteractionMode==UWCharacter.InteractionModeAttack))
			{
				wpa.SetAnimation= GetWeapon () +"_Ready_" + GetRace () + "_" + GetHand();
			}
			else
			{
			//	Debug.Log ("setting ready");
				wpa.SetAnimation= "WeaponPutAway";
			}
		}
	
		//Get the current compass heading
		currentHeading = CompassHeadings[ (int)Mathf.Round((  (this.gameObject.transform.eulerAngles.y % 360) / 22.5f)) ];
	}

	public void SpellMode()
	{//Casts a spell on right click.
		if(Input.GetMouseButtonDown(1) && (CursorInMainWindow==true))
		{
			//Debug.Log(ReadiedSpell + " is cast in main wind");

			this.GetComponent<Magic>().castSpell(this.gameObject, ReadiedSpell,false);
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
					//Debug.Log("USE MODE:Activating objectinteraction "+ hit.transform.name);
					objPicked.Use();
					//ObjectInteraction.Activate (objPicked);
					//MessageLog.text = "You use a " + hit.transform.name;
				}
				else
				{//Special case for portcullises
				if (hit.transform.GetComponent<PortcullisInteraction>())
					{
					objPicked = hit.transform.GetComponent<PortcullisInteraction>().getParentObjectInteraction();
					if (objPicked!=null)
						{
						objPicked.Use ();
						}
					}
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
						if (objPicked.CanBePickedUp==true)
							{
							objPicked.PickedUp=true;
							if (objPicked.GetComponent<Container>()!=null)
								{
								Container.SetPickedUpFlag(objPicked.GetComponent<Container>(),true);
								Container.SetItemsParent(objPicked.GetComponent<Container>(),InvMarker.transform);
								Container.SetItemsPosition (objPicked.GetComponent<Container>(),InvMarker.transform.position);
								}
							//MessageLog.text = "You pick up a " + hit.transform.name;
							CursorIcon=objPicked.GetInventoryDisplay().texture;
							//CurrObjectSprite=objPicked.InventoryString;
							pInv.ObjectInHand=hit.transform.name;
							pInv.JustPickedup=true;//To stop me throwing it away immediately.
							if (objPicked.GetComponent<Rigidbody>() !=null)
								{								
								//objPicked.rigidbody.useGravity=false;
								WindowDetect.FreezeMovement(objPicked.gameObject);
								}
							objPicked.transform.position = InvMarker.transform.position;
							objPicked.transform.parent=InvMarker.transform;
							}
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
				if (hit.transform.gameObject.GetComponent<ObjectInteraction>()!=null)
					{
					if (hit.transform.gameObject.GetComponent<ObjectInteraction>().ItemType==ObjectInteraction.NPC_TYPE)
						{
						hit.transform.gameObject.GetComponent<ObjectInteraction>().TalkTo();
						}
					}
			}
			else
			{
				MessageLog.text = "Talking to yourself?";
			}
		//}
	}

	public void MeleeBegin()
	{//Begins to charge and attack. 

		//wpa.SetAnimation= "Mace_Slash_White_Right_Charge";
		//Debug.Log (GetWeapon () +"_Slash_" + GetRace () + "_" + GetHand() + "_Charge");
		wpa.SetAnimation= GetWeapon () +"_Slash_" + GetRace () + "_" + GetHand() + "_Charge";
		AttackCharging=true;
		Charge=0;
		//Debug.Log ("attack charging begun");
	}

	public void MeleeCharging()	
	{//While still charging increase the charge by the charge rate.
		Charge=(Charge+(chargeRate*Time.deltaTime));
		//Debug.Log ("Charging up ");
		if (Charge>100)
		{
			Charge=100;
		}
	}

	IEnumerator ExecuteMelee()
	{

		float localCharge=Charge;
		Charge=0.0f;
		AttackCharging=false;

		yield return new WaitForSeconds(0.6f);

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
				ObjectInteraction objInt = hit.transform.gameObject.GetComponent<ObjectInteraction>();
				//Debug.Log ("you've hit " + hit.transform.name);
				if (objInt!=null)
				{
					hit.transform.gameObject.GetComponent<ObjectInteraction>().Attack(5);
					//Create a blood splatter at this point
					GameObject hitimpact = new GameObject(hit.transform.name + "_impact");
					hitimpact.transform.position=hit.point;//ray.GetPoint(weaponRange/0.7f);
					Impact imp= hitimpact.AddComponent<Impact>();
					imp.FrameNo=objInt.GetHitFrameStart();
					imp.EndFrame=objInt.GetHitFrameEnd();
					StartCoroutine(imp.Animate());				
				}
				else
				{
					//do a miss impact 
					GameObject hitimpact = new GameObject(hit.transform.name + "_impact");
					hitimpact.transform.position=hit.point;//ray.GetPoint(weaponRange/0.7f);
					Impact imp= hitimpact.AddComponent<Impact>();
					imp.FrameNo=46;
					imp.EndFrame=50;
					StartCoroutine( imp.Animate());
				}
				//hit.transform.SendMessage("ApplyDamage");
				//Destroy(hit.collider.gameObject);
			}
		}
		else
		{
			Debug.Log ("MISS");
		}

		AttackExecuting=false;

	}

	public void MeleeExecute()
	{
		//Debug.Log ("Attack released");//with charge of " + Charge +"%");
		//wpa.SetAnimation= "Mace_Slash_White_Right_Execute";
//TODO:Figure out how to have the attack actually hit in time with the animation.
		wpa.SetAnimation= GetWeapon () + "_Slash_" + GetRace () + "_" + GetHand() + "_Execute";
		AttackExecuting=true;
		StartCoroutine(ExecuteMelee());
	}

	public void AttackModeMelee()
	{//Code to handle melee Combat
		return;
		//Begins to charge and attack. 
		//As long as the cursor is in the main window the attack will continue to build up.
		if(Input.GetMouseButton(1) && (CursorInMainWindow==true) && (AttackCharging==false))
		{//Begin the attack.
			MeleeBegin();
		}
		if ((AttackCharging==true) && (Charge<100))
		{//While still charging increase the charge by the charge rate.
			MeleeCharging ();
		}
		if (Input.GetMouseButtonUp (1) && (CursorInMainWindow==true) && (AttackCharging==true))
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
				//Screen.lockCursor = true;
				//TODO:Position cursor to middle of screen.
				XYAxis.enabled=true;
				//YAxis.enabled=true;
				MouseLookEnabled=true;
				Cursor.lockState = CursorLockMode.Locked;
				//Cursor.visible=false;
			}
			else
			{
				//Debug.Log("Turning off mouselook");
				//Screen.lockCursor = false;
				XYAxis.enabled=false;
				//YAxis.enabled=false;
				MouseLookEnabled=false;
				Cursor.lockState = CursorLockMode.None;
				//Cursor.visible=false;
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

	public int GetSkill(int SkillNo)
	{//Gets the value for the requested skill

		switch (SkillNo)
		{
		case SkillAttack : return Attack;break;
		case SkillDefense : return Defense;break;
		case SkillUnarmed :return Unarmed;break;
		case SkillSword : return Sword;break;
		case SkillAxe :return Axe;break;
		case SkillMace : return Mace;break;
		case SkillMissile :return Missile;break;
		case SkillMana :return ManaSkill;break;
		case SkillLore :return Lore;break;
		case SkillCasting :return Casting;break;
		case SkillTraps :return Traps;break;
		case SkillSearch :return Search;break;
		case SkillTrack :return Track;break;
		case SkillSneak :return Sneak;break;
		case SkillRepair :return Repair;break;
		case SkillCharm :return Charm;break;
		case SkillPicklock :return PickLock;break;
		case SkillAcrobat :return Acrobat;break;
		case SkillAppraise :return Appraise;break;
		case SkillSwimming : return Swimming;break;
		default: return -1;break;
		}
	}

	public bool TrySkill(int SkillToUse, int CheckValue)
	{//Prototype skill check code
		Debug.Log ("Skill check Skill :" + Skillnames[SkillToUse] + " (" +GetSkill(SkillToUse) +") vs " + CheckValue);
		return (CheckValue<GetSkill(SkillToUse));
	}

	public void ApplyDamage(int damage)
	{
		//Debug.Log ("applying damage");
		CurVIT=CurVIT-5;
	}

	public string GetWeapon()
	{
		PlayerInventory pInv = this.GetComponent<PlayerInventory>();
		string ObjInWeaponHand;
		if (isLefty)
		{
			ObjInWeaponHand= pInv.sLeftHand;
		}
		else
		{
			ObjInWeaponHand= pInv.sRightHand;
		}


		if (ObjInWeaponHand=="")
		{
			return "Fist";
		}
		else
		{
			GameObject handobj = GameObject.Find (ObjInWeaponHand);
			Weapon weap = handobj.GetComponent<Weapon>();
			if(weap!=null)
			{
			switch (weap.Skill)
				{
				case 3:
					return "Sword";break;
				case 4:
					return "Axe";break;
				case 5:
					return "Mace";break;
				default:
					return "Fist";break;
				}
			}
			else
			{
				return "Fist";
			}
		}
	}

	public string GetRace()
	{
		//It does'nt matter if you're black or white.

		//Except here where I need to the right skin tone for weapon animations
	 switch (Body)
		{
		case 1:
		case 3:
		case 4:
		case 5:
			return "White";break;
		default:
			return "Black";break;
		}
	}

	public string GetHand()
	{
		if (isLefty)
		{
			return "Left";
		}
		else
		{
			return "Right";
		}
	}
}
