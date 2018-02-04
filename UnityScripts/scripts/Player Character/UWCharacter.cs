using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;

/*
The basic character. Stats and interaction.
 */ 
public class UWCharacter : Character {
		/// <summary>
		/// The xor encryption key for the save file
		/// </summary>
		public int XorKey=0xD9;

		public bool onIce;
		public bool onIcePrev;
		public Vector3 IceVelocity=Vector3.zero;

		public bool decode=true;//decodes a save file
		public bool recode=true;//recodes a save file at indextochange with newvalue
		public bool recode_cheat=true;//recodes a save file into an all 30s character
		public int IndexToRecode=0;
		public int ValueToRecode=0;
		public int game_time;

		public const int CharClassFighter=0;
		public const int CharClassMage=1;
		public const int CharClassBard=2;
		public const int CharClassTinker=3;
		public const int CharClassDruid=4;
		public const int CharClassPaladin=5;
		public const int CharClassRanger=6;
		public const int CharClassShepard=7;


	//What magic spells are currently active on (and cast by) the player. (max 3)
	//These are the ones that the player can see on the hud.
	public static UWCharacter Instance;

	public SpellEffect[] ActiveSpell=new SpellEffect[3]; 

	//What effects and enchantments (eg from items are equipped on the player)
	public SpellEffect[] PassiveSpell=new SpellEffect[10];

	public int Body;//Which body/portrait this character has 

	public int room;

	//Character related info
	//Character Details

	public int CharClass;
	public int CharLevel;
	public int EXP;
	public int TrainingPoints;
	public bool isFemale;
	public bool isLefty;
	public bool isSwimming;
	public bool isFlying;
	public bool isRoaming;
	public float flySpeed;
	public float walkSpeed;
	public float speedMultiplier=1.0f;
	public float swimSpeedMultiplier=1.0f;//Is set to a fractional value when swimming.
	public float SwimTimer =0.0f;	//How long has the player been swimming. Used to determine when to start applying damage.
	public float SwimDamageTimer; //For timing out drowning damage.
	public bool isFloating;
	public bool isWaterWalking;
	//public bool onGround;//Not currently used.
	public bool isTelekinetic;
	public bool isLeaping;
	public int StealthLevel; //The level of stealth the character has.
	
	public int Resistance; //DR from spells.
	public bool FireProof;//Takes no damage from lava
	
	//Character Status
	public int FoodLevel; //0-255 range.
	public int Fatigue;   //0-29 range
	//public bool Poisoned;
	public short play_poison;
	public bool Paralyzed;

	//Character skills
	public Skills PlayerSkills;

	//Magic system
	public Magic PlayerMagic;

	//Inventory System
	public PlayerInventory playerInventory;
	
	//Combat System
	public UWCombat PlayerCombat;

	public long summonCount=0;//How many stacks I have split so far. To keep them uniquely named.

	public short ResurrectLevel;
	public Vector3 ResurrectPosition=Vector3.zero;//TODO change this to a search.

	public Vector3 MoonGatePosition=Vector3.zero;
	public short MoonGateLevel = 2;//Domain of the mountainmen

	public float lavaDamageTimer;//How long before applying lava damage
	//public string currRegion;
	private bool InventoryReady=false;
	public bool JustTeleported=false;
	public Vector3 TeleportPosition;
	public float teleportedTimer=0f;

		/// <summary>
		/// The dream return position when you are dreaming in the void.
		/// </summary>
	public short DreamReturnTileX=0;
	public short DreamReturnTileY=0;

		/// <summary>
		/// The dream return level when you are dreaming in the void.
		/// </summary>
	public short DreamReturnLevel=0;

	public float DreamWorldTimer=30f;//Not sure what values controls the time spent in dream world
	public void Awake()
	{
		Instance=this;
		//DontDestroyOnLoad(this);
	}

	public void Start()
	{
		//UWCharacter.Instance=this;
		XAxis.enabled=false;
		YAxis.enabled=false;
		MouseLookEnabled=false;
	}

	public override void Begin ()
	{

		base.Begin ();
		if (_RES==GAME_SHOCK){return;}
		InventoryReady=false;
		//UWCharacter.Instance=this;
		XAxis.enabled=false;
		YAxis.enabled=false;
		MouseLookEnabled=false;
		Cursor.SetCursor (UWHUD.instance.CursorIconBlank,Vector2.zero, CursorMode.ForceSoftware);
		InteractionMode=UWCharacter.DefaultInteractionMode;


		//Tells other objects about this component;

		RuneSlot.playerUW=this.GetComponent<UWCharacter>();
		Magic.playerUW=this.GetComponent<UWCharacter>();
		SpellProp.playerUW = this.gameObject.GetComponent<UWCharacter>();

		UWHUD.instance.InputControl.text="";
		UWHUD.instance.MessageScroll.Clear ();

		switch (UWCharacter.Instance.Body)
		{
		case 0:
		case 2 :
		case 3:
		case 4:
				GameWorldController.instance.weapongr=new WeaponsLoader(0);break;
		default:
				GameWorldController.instance.weapongr=new WeaponsLoader(1);break;
		}

		
	}

	void PlayerDeath()
	{//CHeck if the player has planted the seed and if so send them to that position.
	//mus.Death=true;
				//TODO:Turn of the player camera
		//UWCharacter.Instance.playerCam.cullingMask=31;
		GameWorldController.instance.getMus().Death=true;
		UWCharacter.InteractionMode=InteractionModeUse;
		UWHUD.instance.wpa.SetAnimation=-1;
		if ( UWHUD.instance.CutScenesSmall!=null)
		{
			if (ResurrectLevel!=0)
			{
				UWHUD.instance.CutScenesSmall.anim.SetAnimation="cs402.n01";//="Death_With_Sapling";
				//this.transform.position=ResurrectPosition;
			}
			else
			{
				UWHUD.instance.CutScenesSmall.anim.SetAnimation="cs403.n01";
			}
		}

		//Cancel the spell
		if (PlayerMagic.ReadiedSpell!="")
		{
			PlayerMagic.ReadiedSpell="";
			UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
		}
	}

	public override float GetUseRange ()
	{
		if (isTelekinetic==true)
		{
			return useRange*8.0f;
		}
		else
		{

			if (playerInventory.GetObjectInHand() =="")
			{
				return useRange;
			}
			else
			{//Test if this is a pole. If so extend the use range by a small amount.
				ObjectInteraction objIntInHand = playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>();
				if (objIntInHand!=null)
				{
					switch (objIntInHand.GetItemType())
					{
						case ObjectInteraction.POLE:
							return useRange *2;
					}
				}
				return useRange;
			}
		}
	}


	public override float GetPickupRange ()
	{
		if (isTelekinetic==true)
		{
			return pickupRange*8.0f;
		}
		else
		{
			return pickupRange;
		}
	}

	void FlyingMode ()
	{
		playerMotor.movement.maxFallSpeed = 0.0f;
		playerMotor.movement.maxForwardSpeed = flySpeed * speedMultiplier;
		playerMotor.movement.maxSidewaysSpeed=playerMotor.movement.maxForwardSpeed*2/3;
		playerMotor.movement.maxBackwardsSpeed=playerMotor.movement.maxForwardSpeed/3;
		//if (((Input.GetKeyDown (KeyCode.R)) || (Input.GetKey (KeyCode.R))) && (WindowDetectUW.WaitingForInput == false)) {
		if (((Input.GetKeyDown (KeyBindings.instance.FlyUp)) || (Input.GetKey (KeyBindings.instance.FlyUp))) && (WindowDetectUW.WaitingForInput == false)) {
			//Fly up
			this.GetComponent<CharacterController> ().Move (new Vector3 (0, 0.2f * Time.deltaTime* speedMultiplier, 0));
		}
		else
			if (((Input.GetKeyDown (KeyBindings.instance.FlyDown)) || (Input.GetKey (KeyBindings.instance.FlyDown))) && (WindowDetectUW.WaitingForInput == false)) {
				//Fly down
			this.GetComponent<CharacterController> ().Move (new Vector3 (0, -0.2f * Time.deltaTime* speedMultiplier, 0));
			}
	}

	void SwimmingMode ()
	{
		playerCam.transform.localPosition = new Vector3 (playerCam.transform.localPosition.x, -0.8f, playerCam.transform.localPosition.z);
		swimSpeedMultiplier = Mathf.Max ((float)(PlayerSkills.Swimming / 30.0f), 0.3f);//TODO:redo me
		SwimTimer = SwimTimer + Time.deltaTime;
		//Not sure of what UW does here but for the moment 45seconds of damage gree swimming then 15s per skill point
		if (SwimTimer >= 05.0f + PlayerSkills.Swimming * 15.0f) {
			SwimDamageTimer += Time.deltaTime;
			if (SwimDamageTimer >= 10.0f)//Take Damage every 10 seconds.
			 {
				ApplyDamage (1);
				SwimDamageTimer = 0.0f;
			}
		}
		else {
			SwimDamageTimer = 0.0f;
		}
		if (ObjectInteraction.PlaySoundEffects) {
			if (!aud.isPlaying) {
				switch (Random.Range (1, 3)) {
				case 1:
					aud.clip = GameWorldController.instance.getMus ().SoundEffects [MusicController.SOUND_EFFECT_SPLASH_1];
					break;
				case 2:
				default:
					aud.clip = GameWorldController.instance.getMus ().SoundEffects [MusicController.SOUND_EFFECT_SPLASH_2];
					break;
				}
				aud.Play ();
			}
		}
	}

	// Update is called once per frame
	public override void Update () {
		if ((_RES==GAME_SHOCK) || (_RES==GAME_TNOVA))
		{	
			if (isFlying)
			{
				flySpeed=10f;
				FlyingMode();
			}
			return;
		}

		if (onIce)
		{		
			//if (onIcePrev==false)
			//{
			//	IceVelocity = playerMotor.movement.velocity.normalized * 2f;
			//}
			//playerMotor.movement.velocity=IceVelocity;//playerMotor.movement.velocity.normalized;
		}
		onIcePrev = onIce;

		base.Update ();
		if (EditorMode)
		{
			CurVIT=MaxVIT;	
		}

		if ((JustTeleported))
		{
			teleportedTimer+=Time.deltaTime;
			if (teleportedTimer>=0.1f)
			{
				JustTeleported=false;
			}
			else
			{
				this.transform.position= new Vector3(TeleportPosition.x, this.transform.position.y, TeleportPosition.z);
			}				
		}
		if( (PlayerInventory.Ready==true) && (InventoryReady=false))
		{						
			//if (!LevelSerializer.IsDeserializing)
			//{
				if ((playerInventory!=null))
				{
					if (playerInventory.GetCurrentContainer()!=null)
					{
							playerInventory.Refresh();
							InventoryReady=true;				
					}
				}	
			//}
		}
		if ((WindowDetectUW.WaitingForInput==true) && (Instrument.PlayingInstrument==false))//TODO:Make this cleaner!!
		{//TODO: This should be in window detect
			//UWHUD.instance.MessageScroll.gameObject.GetComponent<UIInput>().selected=true;
			//UWHUD.instance.MessageScroll.gameObject.GetComponent<UIInput>().selected=true;
			//UWHUD.instance.InputControl.selected=true;
			UWHUD.instance.InputControl.Select();
		}
		if ((CurVIT<=0) && (GameWorldController.instance.getMus().Death==false))
		{
			PlayerDeath();
			return;
		}
		if(GameWorldController.instance.getMus().Death==true)
		{
			//Still processing death.
			return;
		}
		if (playerCam.enabled==true)
		{
			if (isSwimming==true)
			{
				playerMotor.jumping.enabled=false;				
				SwimmingMode ();
			}
			else
			{//0.9198418f
				playerMotor.jumping.enabled=((!Paralyzed) && (!GameWorldController.instance.AtMainMenu) && (!ConversationVM.InConversation) && (!WindowDetectUW.InMap) );
				playerCam.transform.localPosition=new Vector3(playerCam.transform.localPosition.x,1.0f,playerCam.transform.localPosition.z);
				swimSpeedMultiplier=1.0f;
				SwimTimer=0.0f;
			}
		}
		playerMotor.enabled=((!Paralyzed) && (!GameWorldController.instance.AtMainMenu) && (!ConversationVM.InConversation) );
		
		if(Quest.instance.InDreamWorld)
		{
			isFlying=true;
			DreamWorldTimer -=Time.deltaTime;
			if(DreamWorldTimer<0)
			{
				DreamTravelFromVoid ();
			}
		}

		if (isFlying)
		{//Flying spell
			FlyingMode ();
		}
		else
		{
			if (isFloating)
			{
				playerMotor.movement.maxFallSpeed=0.1f;//Default
			}
			else
			{
				playerMotor.movement.maxFallSpeed=20.0f;//Default
				playerMotor.movement.maxForwardSpeed=walkSpeed*speedMultiplier*swimSpeedMultiplier;
				playerMotor.movement.maxSidewaysSpeed=playerMotor.movement.maxForwardSpeed*2/3;
				playerMotor.movement.maxBackwardsSpeed=playerMotor.movement.maxForwardSpeed/3;
			}
		}
		
		if (isLeaping)
		{//Jump spell
			playerMotor.jumping.baseHeight=1.2f;
		}
		else
		{
			playerMotor.jumping.baseHeight=0.6f;
		}
		
		if (isRoaming)
		{
			playerMotor.movement.maxFallSpeed=0.0f;	
		}

		GameWorldController.instance.getMus().WeaponDrawn=(InteractionMode==UWCharacter.InteractionModeAttack);

		if (PlayerMagic.ReadiedSpell!="")
		{//Player has a spell thats about to be cast. All other activity is ignored.	
			SpellMode ();
			return;
		}

		if (UWHUD.instance.window.JustClicked==false)
		{
			if(Paralyzed==false)
			{
					PlayerCombat.PlayerCombatIdle();					
			}			
		}


		if (TileMap.OnLava==true)
		{
			if(!FireProof)
			{
				lavaDamageTimer+=Time.deltaTime;
				if (lavaDamageTimer>=1.0f)//Take Damage every 1 second.
				{
					ApplyDamage (10);
					lavaDamageTimer=0.0f;
				}
			}
			if (_RES==GAME_UW2)
			{//Stepped in Lava after covering in basilisk oil.
				if (Quest.instance.x_clocks[3]==3)
				{
					Quest.instance.x_clocks[3]=4;	
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,334));
				}
			}
		}
		else
		{
			lavaDamageTimer=0;
		}
	
		//Calculate how visible the player is.
		if (LightActive)//The player has a light and is therefore visible at max range.
				{
					DetectionRange=BaseDetectionRange;
				}
				else
				{//=MinRange+( (MaxRange-MinRange) * ((30-B4)/30))
					DetectionRange= MinDetectionRange+ ( ( BaseDetectionRange-MinDetectionRange) * ((30.0f - (GetBaseStealthLevel()+StealthLevel))/30.0f));
				}
	}

	public void SpellMode()
	{//Casts a spell on right click.
		if(
			(Input.GetMouseButtonDown(1)) 
			&& ((WindowDetectUW.CursorInMainWindow==true) || (MouseLookEnabled==true))
			 && (UWHUD.instance.window.JustClicked==false)
			&& ((PlayerCombat.AttackCharging==false)&&(PlayerCombat.AttackExecuting==false))
		 )
		{
			PlayerMagic.castSpell(this.gameObject, PlayerMagic.ReadiedSpell,false);
			PlayerMagic.SpellCost=0;
			UWHUD.instance.window.UWWindowWait (1.0f);
		}
	}


	public void OnSubmitPickup(int quant)
	{

		InputField inputctrl =UWHUD.instance.InputControl;//UWHUD.instance.MessageScroll.gameObject.GetComponent<UIInput>();

		Time.timeScale=1.0f;
		inputctrl.gameObject.SetActive(false);
		WindowDetectUW.WaitingForInput=false;
		inputctrl.text="";
		inputctrl.text="";
		UWHUD.instance.MessageScroll.Clear ();
		//int quant= int.Parse(inputctrl.text);
		if (quant==0)
		{//cancel
			QuantityObj=null;
		}
		if (QuantityObj!=null)
			{
			if (quant >= QuantityObj.link)
				{
				Pickup(QuantityObj,playerInventory);
				}
			else
				{
				//split the obj.


				ObjectLoaderInfo newobjt= ObjectLoader.newObject(QuantityObj.item_id,QuantityObj.quality,QuantityObj.owner,quant,256);
				newobjt.is_quant=QuantityObj.isquant;
				newobjt.flags=QuantityObj.flags;
				newobjt.enchantment=QuantityObj.enchantment;
				newobjt.doordir=QuantityObj.doordir;
				newobjt.invis=QuantityObj.invis;
				ObjectInteraction Split =ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject,QuantityObj.transform.position);
				newobjt.InUseFlag=1;
				QuantityObj.link-=quant;

				//GameObject Split = Instantiate(QuantityObj.gameObject);//What we are picking up.
				//Split.GetComponent<ObjectInteraction>().link =quant;
				//Split.name = Split.name+"_"+summonCount++;
				//QuantityObj.link=QuantityObj.link-quant;
				Pickup (Split, playerInventory);
				ObjectInteraction.Split (Split,QuantityObj);
				QuantityObj=null;//Clear out to avoid weirdness.
				}
			}
	}

	public void TalkMode()
	{//Talk to the object clicked on.
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
		if (Physics.Raycast(ray,out hit,talkRange))
		{
			if (hit.transform.gameObject.GetComponent<ObjectInteraction>()!=null)
				{
				hit.transform.gameObject.GetComponent<ObjectInteraction>().TalkTo();
				}
		}
		else
		{
			UWHUD.instance.MessageScroll.Add ("Talking to yourself?");
		}
	}

	public override void LookMode ()
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
					if (EditorMode)
					{//Select this object in the editor pane
						IngameEditor.instance.ObjectSelect.value= objInt.objectloaderinfo.index;
					}
					objInt.LookDescription();
					return;
				}
				else
				{
				int len = hit.transform.name.Length;
				if (len >4){len=4;}
					switch(hit.transform.name.Substring(0,len).ToUpper())
					{
					case "CEIL":
						UWHUD.instance.MessageScroll.Add ("You see the ceiling");
						//GetMessageLog().text = "You see the ceiling";
						break;	
					case "PILL":
						//GetMessageLog().text = 
						UWHUD.instance.MessageScroll.Add("You see a pillar");
						break;	
					case "BRID":
						//000~001~171~You see a bridge.
						//GetMessageLog().text= 
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_you_see_a_bridge_));
						break;
					case "WALL":
					case "TILE":
					default:
						if (hit.transform.GetComponent<PortcullisInteraction>()!=null)
							{
								ObjectInteraction objPicked = hit.transform.GetComponent<PortcullisInteraction>().getParentObjectInteraction();
								if (objPicked!=null)
								{
									objPicked.LookDescription ();
								}
								return;
							}
					//Taken from
					//http://forum.unity3d.com/threads/get-material-from-raycast.53123/
					Renderer rend = hit.collider.GetComponent<Renderer>();
					if (rend ==null)
					{
						return;
					}
					MeshCollider meshCollider = (MeshCollider)hit.collider;
					int materialIndex = -1;
					Mesh mesh = meshCollider.sharedMesh;
					int triangleIdx = hit.triangleIndex;
					int lookupIdx1 = mesh.triangles[triangleIdx*3];
					int lookupIdx2 = mesh.triangles[triangleIdx*3+1];
					int lookupIdx3 = mesh.triangles[triangleIdx*3+2];
					int submeshNr = mesh.subMeshCount;

					for (int i = 0; i< submeshNr; i++)
					{
						int[] tr = mesh.GetTriangles(i);
						for (int j = 0; j<tr.Length; j+=3)
						{
							if ((tr[j] == lookupIdx1) && (tr[j+1]== lookupIdx2) && (tr[j+2])== lookupIdx3)
							{
								materialIndex=i;
								break;
							}
						}
						if (materialIndex!=-1)
						{
							break;
						}
					}
					if (materialIndex!=-1)
					{
						if (rend.materials[materialIndex].name.Length>=7)
						{
							int textureIndex =0;
							if (int.TryParse(rend.materials[materialIndex].name.Substring(4,3),out textureIndex))//int.Parse(rend.materials[materialIndex].name.Substring(4,3));
							{
								//GetMessageLog ().text =
								if ((textureIndex==142) && (_RES!=GAME_UW2))
								{//This is a window into the abyss.
									UWHUD.instance.CutScenesSmall.anim.SetAnimation="VolcanoWindow_" + GameWorldController.instance.LevelNo;
								}
								UWHUD.instance.MessageScroll.Add("You see " + StringController.instance.GetTextureName(textureIndex));
							}
						}
					//	GetMessageLog().text=rend.materials[materialIndex].name;

						//Debug.Log (rend.materials[materialIndex].name.Substring(4,3));
					}
					break;

					}
				}
			}
		}


	public override void PickupMode (int ptrId)
	{
		//Picks up the clicked object in the view.
		PlayerInventory pInv = this.GetComponent<PlayerInventory>();
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
				if (objPicked.CanBePickedUp()==true)
					{
						//check for weight
						if (objPicked.GetWeight() > playerInventory.getEncumberance())
						{//000~001~095~That is too heavy for you to pick up.
							UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_that_is_too_heavy_for_you_to_pick_up_));
							return;
						}
						if (ptrId==-2)
						{
							//right click check for quant.
							//Pickup if either not a quantity or is a quantity of one.
							if ((objPicked.isQuant() ==false) || ((objPicked.isQuant())&&(objPicked.link==1)) || (objPicked.isEnchanted()))
							{
								objPicked=Pickup(objPicked,pInv);
							}
							else
							{
								//Debug.Log("attempting to pick up a quantity");

								UWHUD.instance.MessageScroll.Set ("Move how many?");
								InputField inputctrl =UWHUD.instance.InputControl;//UWHUD.instance.MessageScroll.GetComponent<UIInput>();
								inputctrl.gameObject.SetActive(true);
								//inputctrl.GetComponent<GuiBase>().SetAnchorX(0.3f);
								inputctrl.gameObject.GetComponent<InputHandler>().target=this.gameObject;
								inputctrl.gameObject.GetComponent<InputHandler>().currentInputMode=InputHandler.InputCharacterQty;


								//TODO: Fix me inputctrl.eventReceiver=this.gameObject;
																//TODO: Fix me inputctrl.type=UIInput.KeyboardType.NumberPad;
								inputctrl.text="1";
																//TODO: Fix me inputctrl.label.text="1";
																//TODO: Fix me inputctrl.selected=true;
								inputctrl.Select();
								QuantityObj=objPicked;	
								Time.timeScale=0.0f;
								WindowDetect.WaitingForInput=true;
							}		
						}
						else
						{//Left click. Pick them all up.
							objPicked=Pickup(objPicked,pInv);	
						}						
					}
					else
					{//000~001~096~You cannot pick that up.
						//Object cannot be picked up. Try and use it instead
						if (objPicked.CanBeUsed)
						{
							UseMode();
							UWHUD.instance.window.UWWindowWait (1.0f);
						}	
						else
						{
							UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_you_cannot_pick_that_up_));									
						}					
					}
				}
			}
		}
	}

	public Quest quest()
	{
		return this.GetComponent<Quest>();
	}

	public void onLanding(float fallSpeed)
	{
		if (isSwimming==false)
		{
			float fallspeedAdjusted = fallSpeed-((float)PlayerSkills.GetSkill(Skills.SkillAcrobat) * 0.13f);
			//Do stuff with acrobat here. In the mean time a flat skill check.
			if ( fallspeedAdjusted>=5f)
			{
				//Debug.Log("Fallspeed = " + fallSpeed + " adjusted down to " + fallspeedAdjusted) ;
				ApplyDamage(Random.Range (1,5));//TODO:As a function of the acrobat skill versus fall.
			}
			if (ObjectInteraction.PlaySoundEffects)
			{
					aud.clip=GameWorldController.instance.getMus().SoundEffects[0];
					aud.Play();								
			}
		}
	}

	public void UpdateHungerAndFatigue()
	{//Called by the gameclock on the hour.
		Fatigue--;
		if (Fatigue<0)
		{
			Fatigue=0;
			//Do what everhappens when the player stays awake non-stop. 
		}
		FoodLevel--;
		if (FoodLevel<0)
		{
			FoodLevel=0;
		}
		if (FoodLevel<3)
		{
			ApplyDamage(1);//Starving damage.
		}
	}

	
	public string GetFedStatus()
	{//Returns the string representing the players hunger.
		/*
		000~001~104~starving
		000~001~105~famished
		000~001~106~very hungry
		000~001~107~hungry
		000~001~108~peckish
		000~001~109~fed
		000~001~110~well fed
		000~001~111~full
		000~001~112~satiated
		*/
				int FoodLevelString = 0;//in 0x1e steps
				if (FoodLevel< 0x1E)//starving
				{
						FoodLevelString=0;	
				}
				else if (FoodLevel< 0x3c)//Famished
				{
						FoodLevelString=1;
				}
				else if (FoodLevel< 0x5a)//Very hungry
				{
						FoodLevelString=2;
				}
				else if (FoodLevel< 0x78)//hungry
				{
						FoodLevelString=3;
				}
				else if (FoodLevel< 0x96)//peckish
				{
						FoodLevelString=4;
				}
				else if (FoodLevel< 0xB4)// fed
				{
						FoodLevelString=5;
				}
				else if (FoodLevel< 0xD2)//well fed
				{
						FoodLevelString=6;
				}
				else if (FoodLevel< 0xF0)//full
				{
						FoodLevelString=7;
				}
				else //satiated
				{
						FoodLevelString=8;	
				}

		//return StringController.instance.GetString (1,104+((FoodLevel)/8));
		return StringController.instance.GetString (1,StringController.str_starving+FoodLevelString);

	}

	public string GetFatiqueStatus()
	{
		/*
		000~001~113~fatigued
		000~001~114~very tired
		000~001~115~drowsy
		000~001~116~awake
		000~001~117~rested
		000~001~118~wide awake	
		*/
		return StringController.instance.GetString (1,StringController.str_fatigued+((Fatigue)/5));
	}

	public void RegenMana()
	{//Natural Regeneration of mana over time;
		PlayerMagic.CurMana += Random.Range (1,6);
		if (PlayerMagic.CurMana>PlayerMagic.MaxMana)
		{
			PlayerMagic.CurMana=PlayerMagic.MaxMana;
		}
	}

	public void SetCharLevel(int level)
	{
		if (UWCharacter.Instance.CharLevel<level)
		{
			//000~001~147~You have attained experience level
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_you_have_attained_experience_level_));
			TrainingPoints+=3;
			UWCharacter.Instance.MaxVIT=UWCharacter.Instance.PlayerSkills.STR*3;
			switch (_RES)
			{
			case GAME_UW1:
				if ((GameWorldController.instance.LevelNo==6) && ( !Quest.instance.isOrbDestroyed ))
				{
					UWCharacter.Instance.PlayerMagic.TrueMaxMana=UWCharacter.Instance.PlayerSkills.ManaSkill*3;;								
				}
				else
				{
					UWCharacter.Instance.PlayerMagic.MaxMana= UWCharacter.Instance.PlayerSkills.ManaSkill*3;
					UWCharacter.Instance.PlayerMagic.CurMana=UWCharacter.Instance.PlayerMagic.MaxMana;
					UWCharacter.Instance.PlayerMagic.TrueMaxMana=UWCharacter.Instance.PlayerMagic.MaxMana;											
				}
				break;
			default:
				UWCharacter.Instance.PlayerMagic.MaxMana= UWCharacter.Instance.PlayerSkills.ManaSkill*3;
				UWCharacter.Instance.PlayerMagic.CurMana=UWCharacter.Instance.PlayerMagic.MaxMana;
				UWCharacter.Instance.PlayerMagic.TrueMaxMana=UWCharacter.Instance.PlayerMagic.MaxMana;
				break;
			}


		}
		UWCharacter.Instance.CharLevel=level;
	}

		/// <summary>
		/// Adds an XP reward to the character.
		/// </summary>
		/// <param name="xp">Xp.</param>
		public void AddXP(int xp)
		{
				EXP+=xp;
				if (EXP<=600)				
				{//1
						SetCharLevel(1);
				}
				else if(EXP<=1200)
				{//2
						SetCharLevel(2);
				}
				else if(EXP<=1800)
				{//3
						SetCharLevel(3);
				}
				else if(EXP<=2400)
				{//4
						SetCharLevel(4);
				}
				else if(EXP<=3000)
				{//5
						SetCharLevel(5);
				}
				else if (EXP<=3600)				
				{//6
						SetCharLevel(6);
				}
				else if(EXP<=4200)
				{//7
						SetCharLevel(7);
				}
				else if(EXP<=4800)
				{//8
						SetCharLevel(8);
				}
				else if(EXP<=5400)
				{//9
						SetCharLevel(9);
				}
				else if(EXP<=6000)
				{//10
						SetCharLevel(10);
				}
				else if (EXP<=6600)
				{//11
						SetCharLevel(11);	
				}
				else if (EXP<=7200)
				{//12
						SetCharLevel(12);
				}
				else if (EXP<=7800)
				{//13
						SetCharLevel(13);
				}
				else if (EXP<=8400)
				{//14
						SetCharLevel(14);
				}
				else if (EXP<=9000)
				{//15
						SetCharLevel(15);
				}
				else if (EXP<=9600)
				{
						SetCharLevel(16);
				}
				else
				{
					EXP=9600;
					SetCharLevel(16);
				}
		}


		public int GetBaseStealthLevel()
		{
			return PlayerSkills.GetSkill(Skills.SkillSneak);
		}


		public void Sleep()
		{
			switch(_RES)
			{
			case GAME_UW2:
					SleepUW2();break;
			default:
					SleepUW1();break;
			}
		}


		/// <summary>
		/// The player goes to sleep in UW2
		/// </summary>
		public void SleepUW2()
		{
				if (!CheckForMonsters())
				{
						
						if (Quest.instance.DreamPlantEaten)
						{
								DreamTravelToVoid ();
						}
						else
						{	
								if (UWCharacter.Instance.FoodLevel>=3)					
								{
										if (IsGaramonTime())
										{//PLay a garamon dream
												//PlayGaramonDream(Quest.instance.GaramonDream++);	
												UWHUD.instance.MessageScroll.Add("You dream of the guardian");
										}
										else
										{//Regular sleep with a fade to black
												StartCoroutine(SleepDelay());
										}	
								}					
						}
						SleepRegen ();
				}
				else
				{
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,14));
				}	
		}

		/// <summary>
		/// The player goes to sleep in UW1
		/// </summary>
		public void SleepUW1()
		{
				//Rules to implement for sleeping
				//Only sleep if there are no hostile monsters nearby.
				//If a normal sleep do a fade to black in the small cutscene window.
				//If hungry then it is an uneasy sleep.
				//There is a small chance of a monster spawning.
				//If a dream/vision use the full screen.
				//Do a incense dream before a garamon dream. Turn the incense into ashes afterwards
				//Do one Garamon dream per game day.
				//When tybal is dead. Jump to the bury the bones dream
				//Restore an amount of health or mana after a sleep.
				//Track the state of the garamon/cup of wonder dreams in Quest.

				/*
			  000~001~014~There are hostile creatures near!
			  000~001~015~You make camp.
			  000~001~016~You go to sleep.
			  000~001~017~You are starving.
			  000~001~018~You feel rested.
			  000~001~019~Your sleep is uneasy.
			  000~001~020~You can't go to sleep here!
			  000~001~021~Your sleep is interrupted!
			*/

				if (!CheckForMonsters())
				{
						ObjectInteraction incense =UWCharacter.Instance.playerInventory.findObjInteractionByID(277); 
						if (incense!=null)
						{
								IncenseDream (incense);
						}
						else
						{	
								if (UWCharacter.Instance.FoodLevel>=3)					
								{
										if (IsGaramonTime())
										{//PLay a garamon dream
												PlayGaramonDream(Quest.instance.GaramonDream++);								
										}
										else
										{//Regular sleep with a fade to black
												StartCoroutine(SleepDelay());
										}	
								}					
						}
						SleepRegen ();
				}
				else
				{
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,14));
				}	
		}

	void IncenseDream (ObjectInteraction incense)
	{
		UWHUD.instance.EnableDisableControl (UWHUD.instance.CutsceneFullPanel.gameObject, true);
		//UWHUD.instance.CutScenesFull.SetAnimationFile="FadeToBlackSleep";
		incense.consumeObject ();
		switch (Quest.instance.getIncenseDream ()) {
		case 0:
			UWHUD.instance.CutScenesFull.SetAnimationFile = "cs013_n01";
			break;
		case 1:
			UWHUD.instance.CutScenesFull.SetAnimationFile = "cs014_n01";
			break;
		case 2:
			UWHUD.instance.CutScenesFull.SetAnimationFile = "cs015_n01";
			break;
		}
	}

	void DreamTravelToVoid()
	{
		//Record the players position.	
		Quest.instance.DreamPlantEaten=false;
		DreamReturnTileX=TileMap.visitTileX;
		DreamReturnTileY=TileMap.visitTileY;
		DreamReturnLevel = GameWorldController.instance.LevelNo;
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,24));
		GameWorldController.instance.SwitchLevel(68,32,27);//TODO:implement other destinations.
		Quest.instance.InDreamWorld=true;
		DreamWorldTimer=30f;
		Quest.instance.QuestVariables[48]=1;		
	}

	void DreamTravelFromVoid ()
	{
		Quest.instance.InDreamWorld = false;
		isFlying=false;
		GameWorldController.instance.SwitchLevel (DreamReturnLevel,DreamReturnTileX,DreamReturnTileY);
		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1, 25));
	}

	void SleepRegen ()
	{
		for (int i = UWCharacter.Instance.Fatigue; i < 29; i = i + 3)//Sleep restores at a rate of 3 points per hour
		 {
			if (UWCharacter.Instance.FoodLevel >= 3) {
				GameClock.Advance ();
				//Move time forward.
			}
			else {
				//Too hungry to sleep.
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1, 17));
				UWHUD.instance.EnableDisableControl (UWHUD.instance.CutsceneFullPanel, false);
				UWCharacter.Instance.Fatigue += i;
				return;
				// true;
			}
		}
		UWCharacter.Instance.Fatigue = 29;
		//Fully rested
		if (UWCharacter.Instance.CurVIT < UWCharacter.Instance.MaxVIT) {
			//Random regen of an amount of health
			UWCharacter.Instance.CurVIT += Random.Range (1, UWCharacter.Instance.MaxVIT - UWCharacter.Instance.CurVIT + 1);
		}
		if (UWCharacter.Instance.PlayerMagic.CurMana < UWCharacter.Instance.PlayerMagic.MaxMana) {
			//Random regen of an amount of mana
			UWCharacter.Instance.PlayerMagic.CurMana += Random.Range (1, UWCharacter.Instance.PlayerMagic.MaxMana - UWCharacter.Instance.PlayerMagic.CurMana + 1);
		}
	}

		private bool CheckForMonsters()
		{//Finds monsters in the area.
				return false;
		}

		private bool IsGaramonTime()
		{//Is it time for a garamon dream
				//if (Quest.instance.isTybalDead)
				//{
				if (Quest.instance.GaramonDream==6)
				{
						return true;//All done.
				}
				if (Quest.instance.GaramonDream==7)
				{
						return true;//Tybal is dead. Time to play a dream.
				}	
				//}
				//else
				//{
				//	if (Quest.instance.GaramonDream>7)
				//	{
				//		return false;//All done until tybal is dead.
				//	}	
				//}

				if (GameClock.day()>=Quest.instance.DayGaramonDream)
				{
						return true;
				}
				else
				{
						return false;
				}		
		}

		void PlayGaramonDream(int dreamIndex)
		{
				int DaysToWait=0;
				switch (dreamIndex)
				{
				case 0:
						Cutscene_Dream_1 d1 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_1>();
						UWHUD.instance.CutScenesFull.cs=d1;
						UWHUD.instance.CutScenesFull.Begin();
						DaysToWait=1;
						break;
				case 1:
						Cutscene_Dream_2 d2 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_2>();
						UWHUD.instance.CutScenesFull.cs=d2;
						UWHUD.instance.CutScenesFull.Begin();
						DaysToWait=1;
						break;
				case 2:
						Cutscene_Dream_3 d3 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_3>();
						UWHUD.instance.CutScenesFull.cs=d3;
						UWHUD.instance.CutScenesFull.Begin();
						DaysToWait=1;
						break;
				case 3:
						Cutscene_Dream_4 d4 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_4>();
						UWHUD.instance.CutScenesFull.cs=d4;
						UWHUD.instance.CutScenesFull.Begin();
						DaysToWait=1;
						break;
				case 4:
						Cutscene_Dream_5 d5 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_5>();
						UWHUD.instance.CutScenesFull.cs=d5;
						UWHUD.instance.CutScenesFull.Begin();
						DaysToWait=1;
						break;
				case 5:
						Cutscene_Dream_6 d6 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_6>();
						UWHUD.instance.CutScenesFull.cs=d6;
						UWHUD.instance.CutScenesFull.Begin();
						DaysToWait=1;
						break;
				case 6:
						Cutscene_Dream_7 d7 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_7>();
						UWHUD.instance.CutScenesFull.cs=d7;
						UWHUD.instance.CutScenesFull.Begin();
						DaysToWait=1;
						break;
				case 7: // Tybal is dead.
						Cutscene_Dream_7 d8 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_7>();
						UWHUD.instance.CutScenesFull.cs=d8;
						UWHUD.instance.CutScenesFull.Begin();
						Quest.instance.GaramonDream=3;//Move back in the sequence
						DaysToWait=1;
						break;
				case 8:
						Cutscene_Dream_9 d9 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_9>();
						UWHUD.instance.CutScenesFull.cs=d9;
						UWHUD.instance.CutScenesFull.Begin();
						DaysToWait=1;
						break;
				case 9:
						Cutscene_Dream_10 d10 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_10>();
						UWHUD.instance.CutScenesFull.cs=d10;
						UWHUD.instance.CutScenesFull.Begin();
						DaysToWait=1;
						break;		
				}

				Quest.instance.DayGaramonDream=GameClock.day()+DaysToWait;
		}

		static void RestoreHealthMana(UWCharacter sunshine)
		{
				sunshine.CurVIT += Random.Range(1,40);
				if (sunshine.CurVIT>sunshine.MaxVIT)
				{
						sunshine.CurVIT=sunshine.MaxVIT;
				}

				sunshine.PlayerMagic.CurMana += Random.Range(1,40);
				if (sunshine.PlayerMagic.CurMana>sunshine.PlayerMagic.MaxMana)
				{
						sunshine.PlayerMagic.CurMana=sunshine.PlayerMagic.MaxMana;
				}
		}

		public static void WakeUp(UWCharacter sunshine)
		{//Todo: Test the quality of the sleep and check for monster interuption.
				RestoreHealthMana(sunshine);
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,18));
		}

		IEnumerator SleepDelay()
		{
				UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel.gameObject,true);
				UWHUD.instance.CutScenesFull.SetAnimationFile="FadeToBlackSleep";
				yield return new WaitForSeconds(3f);
				UWHUD.instance.CutScenesFull.SetAnimationFile="Anim_Base";
				UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel.gameObject,false);
		}

}
