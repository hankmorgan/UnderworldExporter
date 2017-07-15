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

		public bool decode=true;//decodes a save file
		//public bool recode=true;//recodes a save file at indextochange with newvalue
		public int game_time;
		//public 	int heading;
		//public float testvalue=0.4f;
		//public int indextochange;
		//public int newvalue;
		//public int newvaluesize=8;
	//What magic spells are currently active on (and cast by) the player. (max 3)
	//These are the ones that the player can see on the hud.
	public static UWCharacter Instance;

	public SpellEffect[] ActiveSpell=new SpellEffect[3]; 

	//What effects and enchantments (eg from items are equipped on the player)
	public SpellEffect[] PassiveSpell=new SpellEffect[10];

	public int Body;//Which body/portrait this character has 



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
	public int FoodLevel; //0-35 range.
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
	public string currRegion;
	private bool InventoryReady=false;
	public bool JustTeleported=false;
	public float teleportedTimer=0f;



	public void Awake()
	{
		Instance=this;
		//DontDestroyOnLoad(this);
	}

	public override void Start ()
	{

		base.Start ();
				if (_RES==GAME_SHOCK){return;}
				InventoryReady=false;
		GameWorldController.instance.playerUW=this;
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

		switch (GameWorldController.instance.playerUW.Body)
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
		//GameWorldController.instance.playerUW.playerCam.cullingMask=31;
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


	// Update is called once per frame
	public override void Update () {
				if (_RES==GAME_SHOCK){return;}
		base.Update ();
		if (JustTeleported)
		{
			teleportedTimer+=Time.deltaTime;
			if (teleportedTimer>=2f)
			{
				JustTeleported=false;
			}
		}
		if (InventoryReady==false)
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
				playerCam.transform.localPosition=new Vector3(playerCam.transform.localPosition.x,-0.8f,playerCam.transform.localPosition.z);
				swimSpeedMultiplier= Mathf.Max((float)(PlayerSkills.Swimming/30.0f),0.1f);
				SwimTimer = SwimTimer + Time.deltaTime;
				//Not sure of what UW does here but for the moment 45seconds of damage gree swimming then 15s per skill point
				if (SwimTimer>=05.0f + PlayerSkills.Swimming*15.0f)
				{
					SwimDamageTimer+=Time.deltaTime;
					if (SwimDamageTimer>=10.0f)//Take Damage every 10 seconds.
					{
						ApplyDamage (1);
						SwimDamageTimer=0.0f;
					}
				}
				else
				{
					SwimDamageTimer=0.0f;
				}
				if (ObjectInteraction.PlaySoundEffects)
				{
					if (!aud.isPlaying)
					{
						switch (Random.Range(1,3))
						{
						case 1:
							aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_SPLASH_1];break;
						case 2:
						default:
							aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_SPLASH_2];break;
						}
						aud.Play();
					}		
				}

			}
			else
			{//0.9198418f
				playerCam.transform.localPosition=new Vector3(playerCam.transform.localPosition.x,1.0f,playerCam.transform.localPosition.z);
				swimSpeedMultiplier=1.0f;
				SwimTimer=0.0f;
			}
		}
		playerMotor.enabled=((!Paralyzed) && (!GameWorldController.instance.AtMainMenu) && (!Conversation.InConversation));
		

		if (isFlying)
		{//Flying spell
			playerMotor.movement.maxFallSpeed=0.0f;
			playerMotor.movement.maxForwardSpeed=flySpeed*speedMultiplier;
			if (((Input.GetKeyDown(KeyCode.R)) || (Input.GetKey(KeyCode.R))) && (WindowDetectUW.WaitingForInput==false))
			{//Fly up
					this.GetComponent<CharacterController>().Move(new Vector3(0,0.2f * Time.deltaTime,0));
			}
			else if (((Input.GetKeyDown(KeyCode.V)) || (Input.GetKey(KeyCode.V))) && (WindowDetectUW.WaitingForInput==false))
			{//Fly down
				this.GetComponent<CharacterController>().Move(new Vector3(0,-0.2f * Time.deltaTime,0));
			}
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
				GameObject Split = Instantiate(QuantityObj.gameObject);//What we are picking up.
				Split.GetComponent<ObjectInteraction>().link =quant;
				Split.name = Split.name+"_"+summonCount++;
				QuantityObj.link=QuantityObj.link-quant;
				Pickup (Split.GetComponent<ObjectInteraction>(), playerInventory);
				ObjectInteraction.Split (Split.GetComponent<ObjectInteraction>(),QuantityObj.GetComponent<ObjectInteraction>());
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
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,171));
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
							UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,95));
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
							UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,96));									
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
			//Do stuff with acrobat here. In the mean time a flat skill check.
			if ( ! PlayerSkills.TrySkill(Skills.SkillAcrobat, (int)fallSpeed))
			{
				ApplyDamage(Random.Range (1,5));//TODO:As a function of the acrobat skill versus fall.
			}
			aud.clip=GameWorldController.instance.getMus().SoundEffects[0];
			aud.Play();
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
				return StringController.instance.GetString (1,104+FoodLevelString);

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
		return StringController.instance.GetString (1,113+((Fatigue)/5));
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
		if (GameWorldController.instance.playerUW.CharLevel<level)
		{
			//000~001~147~You have attained experience level
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,147));
			TrainingPoints+=3;
			GameWorldController.instance.playerUW.MaxVIT=GameWorldController.instance.playerUW.PlayerSkills.STR*3;
			switch (_RES)
			{
			case GAME_UW1:
				if ((GameWorldController.instance.LevelNo==6) && ( !GameWorldController.instance.playerUW.quest().isOrbDestroyed ))
				{
					GameWorldController.instance.playerUW.PlayerMagic.TrueMaxMana=GameWorldController.instance.playerUW.PlayerSkills.ManaSkill*3;;								
				}
				else
				{
					GameWorldController.instance.playerUW.PlayerMagic.MaxMana= GameWorldController.instance.playerUW.PlayerSkills.ManaSkill*3;
					GameWorldController.instance.playerUW.PlayerMagic.CurMana=GameWorldController.instance.playerUW.PlayerMagic.MaxMana;
					GameWorldController.instance.playerUW.PlayerMagic.TrueMaxMana=GameWorldController.instance.playerUW.PlayerMagic.MaxMana;											
				}
				break;
			default:
				GameWorldController.instance.playerUW.PlayerMagic.MaxMana= GameWorldController.instance.playerUW.PlayerSkills.ManaSkill*3;
				GameWorldController.instance.playerUW.PlayerMagic.CurMana=GameWorldController.instance.playerUW.PlayerMagic.MaxMana;
				GameWorldController.instance.playerUW.PlayerMagic.TrueMaxMana=GameWorldController.instance.playerUW.PlayerMagic.MaxMana;
				break;
			}


		}
		GameWorldController.instance.playerUW.CharLevel=level;
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
}
