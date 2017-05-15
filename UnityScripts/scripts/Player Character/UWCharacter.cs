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
		public int XorKey=206;
		public bool decode=true;//decodes a save file
		public bool recode=true;//recodes a save file at indextochange with newvalue
		public int game_time;
		//public 	int heading;
		public float testvalue=0.4f;
		public int indextochange;
		public int newvalue;
		public int newvaluesize=8;
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
		public int play_poison;
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

	public int ResurrectLevel;
	public Vector3 ResurrectPosition=Vector3.zero;

	public Vector3 MoonGatePosition=Vector3.zero;
	public int MoonGateLevel = 2;//Domain of the mountainmen

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
		GameWorldController.instance.getMus().Death=true;
		if ( UWHUD.instance.CutScenesSmall!=null)
		{
			if (ResurrectLevel!=0)
			{
				UWHUD.instance.CutScenesSmall.SetAnimation="Death_With_Sapling";
				//this.transform.position=ResurrectPosition;
			}
			else
			{
				UWHUD.instance.CutScenesSmall.SetAnimation="Death";
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
			}
			else
			{
				playerCam.transform.localPosition=new Vector3(playerCam.transform.localPosition.x,0.9198418f,playerCam.transform.localPosition.z);
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
									UWHUD.instance.CutScenesSmall.SetAnimation="VolcanoWindow_" + GameWorldController.instance.LevelNo;
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
				ApplyDamage(5);//TODO:As a function of the acrobat skill versus fall.
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
			ApplyDamage(2);//Starving damage.
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
		return StringController.instance.GetString (1,104+((FoodLevel)/4));
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


		/// <summary>
		/// Loads the player dat file into the current character
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
		public void LoadPlayerDat(int slotNo)
		{
				CharName="";
				char[] buffer;
				int x_position=0;
				int y_position=0;
				int z_position=0;
			
				playerInventory.currentContainer="_Gronk";
				if (DataLoader.ReadStreamFile(Loader.BasePath + "save" + slotNo + "\\player.dat", out buffer))
				{

						TileMap.OnWater=false;
						int xOrValue= (int)buffer[0];
						XorKey=xOrValue;
						int incrnum = 3;

						for(int i=1; i<220; i++)
						{
								if (i==81) 
								{
										incrnum = 3;
								}
								buffer[i] ^= (char)((xOrValue+incrnum) & 0xFF);
								incrnum += 3;
						}

						//string Result="";
						int runeOffset=0;
						for (int i=1; i<=221;i++)
						{
								if (i<14)
								{
										CharName +=buffer[i];
								}
								else
								{
										switch(i)//UWformats doesn't take the first byte into account when describing offsets! I have incremented plus one
										{
										case 0x1F ://Strength
												PlayerSkills.STR=(int)buffer[i];break;
										case 0x20 ://Dex
												PlayerSkills.DEX=(int)buffer[i];break;
										case 0x21 : ///    Intelligence
												PlayerSkills.INT=(int)buffer[i];break;
										case 0x22 : ///    Attack
												PlayerSkills.Attack=(int)buffer[i];break;
										case 0x23 : ///    Defense
												PlayerSkills.Defense=(int)buffer[i];break;
										case 0x24 : ///    Unarmed
												PlayerSkills.Unarmed=(int)buffer[i];break;
										case 0x25  : ///    Sword
												PlayerSkills.Sword=(int)buffer[i];break;
										case 0x26  : ///    Axe
												PlayerSkills.Axe=(int)buffer[i];break;
										case 0x27 : ///    Mace
												PlayerSkills.Mace=(int)buffer[i];break;
										case 0x28   : ///    Missile
												PlayerSkills.Missile=(int)buffer[i];break;
										case 0x29  : ///    Mana
												PlayerSkills.ManaSkill=(int)buffer[i];break;
										case 0x2A : ///    Lore
												PlayerSkills.Lore=(int)buffer[i];break;
										case 0x2B  : ///    Casting
												PlayerSkills.Casting=(int)buffer[i];break;
										case 0x2C  : ///    Traps
												PlayerSkills.Traps=(int)buffer[i];break;
										case 0x2D  : ///    Search
												PlayerSkills.Search=(int)buffer[i];break;
										case 0x2E : ///    Track
												PlayerSkills.Track=(int)buffer[i];break;
										case 0x2F  : ///    Sneak
												PlayerSkills.Sneak=(int)buffer[i];break;
										case 0x30  : ///    Repair
												PlayerSkills.Repair=(int)buffer[i];break;
										case 0x31 : ///    Charm
												PlayerSkills.Charm=(int)buffer[i];break;
										case 0x32 : ///    Picklock
												PlayerSkills.PickLock=(int)buffer[i];break;
										case 0x33  : ///    Acrobat
												PlayerSkills.Acrobat=(int)buffer[i];break;
										case 0x34  : ///    Appraise
												PlayerSkills.Appraise=(int)buffer[i];break;
										case 0x35  : ///    Swimming
												PlayerSkills.Swimming=(int)buffer[i];break;
										case 0x36://Curvit
												CurVIT=(int)buffer[i];break;
										case 0x37 : ///    max. vitality
												MaxVIT=(int)buffer[i];break;
										case 0x38 : ///    current mana, (play_mana)
												PlayerMagic.CurMana=(int)buffer[i];break;
										case 0x39  : ///    max. mana
												PlayerMagic.MaxMana=(int)buffer[i];break;
										case 0x3A : ///    hunger, play_hunger
												FoodLevel=(int)buffer[i];break;		
										case 0x3B:
												//Unknown. Observed values 0 and 64?//Fatigue???
												break;
										//case 0x3C:
										//		testvalue=(int)buffer[i];break;	

										case 0x3E : ///    character level (play_level)
												CharLevel=(int)buffer[i];break;
										case 0x3F:
										case 0x41:
										case 0x43://Active spell effect
												GetActiveSpellID((int)buffer[i]);break;

										case 0x45://Runebits
										case 0x46://Runebits
										case 0x47://Runebits
												for (int r =7; r>=0; r--)
												{
														if (((buffer[i]>>r) & 0x1 )== 1)
														{
															PlayerMagic.PlayerRunes[7-r+runeOffset]=true;
														}
														else
														{
															PlayerMagic.PlayerRunes[7-r+runeOffset]=false;
														}
												}
												runeOffset+=8;
												break;
										case 0x48:
												SetActiveRuneSlots(0, (int)buffer[i]);
												break;
										case 0x49:
												SetActiveRuneSlots(1, (int)buffer[i]);
												break;
										case 0x4A:
												SetActiveRuneSlots(2, (int)buffer[i]);
												break;
											
										case 0x4D : ///   weight in 0.1 stones
												//Or STR * 2; safe to ignore?
												//testvalue=(int)DataLoader.getValAtAddress(buffer,i,16);break;
												break;
										case 0x4F  : ///   experience in 0.1 points
												EXP=(int)DataLoader.getValAtAddress(buffer,i,32);break;
										case 0x53: // skillpoints available to spend
												TrainingPoints=(int)buffer[i];break;
										case 0x55 : ///   x-position in level
												x_position= (int)DataLoader.getValAtAddress(buffer,i,16);break;
										case 0x57  : ///   y-position
												y_position=(int)DataLoader.getValAtAddress(buffer,i,16);break;
										case 0x59 : ///   z-position
												z_position=(int)DataLoader.getValAtAddress(buffer,i,16);break;
										case 0x5C : ///   heading
												{
													float heading=(float)DataLoader.getValAtAddress(buffer,i,8);	

														//heading=255f-heading;//reversed
														//playerCam.transform.rotation=Vector3.zero;

														//this.transform.Rotate(0f,heading*(255f/360f),0f,Space.World);
														this.transform.eulerAngles=new Vector3(0f,heading*(360f/255f),0f);
														//playerCam.transform.localRotation.eulerAngles=Vector3.zero;
														playerCam.transform.localRotation=Quaternion.identity;
														break;
												}


										case 0x5D  : ///   dungeon level
												GameWorldController.instance.startLevel=(int)DataLoader.getValAtAddress(buffer,i,16) - 1;break;
										case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
												//Low nibble is moongate level + 1
												ResurrectLevel=((int)buffer[i]>>4) & 0xf;
												MoonGateLevel=((int)buffer[i]) & 0xf;
												break;
										case 0x60  : ///    bits 2..5: play_poison
												play_poison=(int)((buffer[i]>>2) & 0x7 );break;

										case 0x65: // hand, Gender & body, and class
												{
													//bit 1 = hand left/right
													//bit 2-5 = gender & body
													//bit 6-8 = class

													GRLoader chrBdy = new GRLoader(GRLoader.BODIES_GR);
													isLefty = (((int)buffer[i] & 0x1) == 0);
													int bodyval= ((int)buffer[i]>>1) & 0xf;
														if (bodyval % 2 == 0)
														{//male 0,2,4,6,8
															isFemale=false;
															//Body
															GameWorldController.instance.playerUW.Body=bodyval/2;
															UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(0+(bodyval/2));
														}
														else
														{//female=1,3,5,7,9
															isFemale=true;
															GameWorldController.instance.playerUW.Body=(bodyval-1)/2;
															UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(5+((bodyval-1)/2));
														}
														//class
														CharClass= buffer[i]>>5;

													break;
												}
										case 0x66://Quest flags
												{
													int val = (int)DataLoader.getValAtAddress(buffer,i,32);
													for (int b=31; b>=0;b--)
													{//Check order here
														if (((val<<b) & 0x1) == 1)
														{
															quest().QuestVariables[32-b]=1;
														}
														else
														{
															quest().QuestVariables[32-b]=0;	
														}
													}
												break;
												}
										case 0x6A:
												quest().QuestVariables[32]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6B:
												quest().QuestVariables[33]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6C:
												quest().QuestVariables[34]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6D:
												quest().QuestVariables[35]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6F://Garamon dream related?
												quest().GaramonDream=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x71://Game variables
										case 0x72:
										case 0x73:
										case 0x74:
										case 0x75:
										case 0x76:
										case 0x77:
										case 0x78:
										case 0x79:
										case 0x7A:
										case 0x7B:
										case 0x7C:
										case 0x7D:
										case 0x7E:
										case 0x7F:
										case 0x80:
										case 0x81:
										case 0x82:
										case 0x83:
										case 0x84:
										case 0x85:
										case 0x86:
										case 0x87:
										case 0x88:
										case 0x89:
										case 0x8A:
										case 0x8B:
										case 0x8C:
										case 0x8D:
										case 0x8E:
										case 0x8F:
										case 0x90:
												{
													GameWorldController.instance.variables[i-0x71]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
													break;
												}

										case 0xCF  : ///   game time
												game_time=(int)DataLoader.getValAtAddress(buffer,i,32);break;
										case 0xDD  : ///    current vitality
												CurVIT=(int)buffer[i];break;
										}
								}
						}

						//float Ratio=GameWorldController.instance.testUVadjust;//213 needs to be tested more.
						float Ratio=213f;
						float VertAdjust = 0.3543672f;
						GameWorldController.instance.StartPos=new Vector3((float)x_position/Ratio, (float)z_position/Ratio +VertAdjust ,(float)y_position/Ratio);

						//Read in the inventory
						//Stored in much the same way as an linked object list is.
						//Inventory list
						int NoOfItems = (buffer.GetUpperBound(0)-312)/8;
						ObjectLoader objLoader = new ObjectLoader();
						objLoader.objInfo = new ObjectLoaderInfo[NoOfItems+2];
						//ObjectLoaderInfo[] objList = new ObjectLoaderInfo[NoOfItems+2];
						int x=1;
						//Debug.Log ("remaining space " + ((int)buffer.GetUpperBound(0)-222));
						if (buffer.GetUpperBound(0)>=312)
						{
								int i = 312;
								while (i < buffer.GetUpperBound(0))
								{
										objLoader.objInfo[x] = new ObjectLoaderInfo();
										objLoader.objInfo[x].parentList=objLoader;
										objLoader.objInfo[x].tileX=99;
										objLoader.objInfo[x].tileY=99;
										objLoader.objInfo[x].InUseFlag=1;
										objLoader.objInfo[x].item_id = (int)(DataLoader.getValAtAddress(buffer,i+0,16)) & 0x1FF;
										objLoader.objInfo[x].flags  = (int)((DataLoader.getValAtAddress(buffer,i+0,16))>> 9) & 0x0F;
										objLoader.objInfo[x].enchantment = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 12) & 0x01);
										objLoader.objInfo[x].doordir  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 13) & 0x01);
										objLoader.objInfo[x].invis  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 14 )& 0x01);
										objLoader.objInfo[x].is_quant = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 15) & 0x01);
										//position at +2
										objLoader.objInfo[x].zpos = (int)(DataLoader.getValAtAddress(buffer,i+2,16)) & 0x7F;	//bits 0-6 
										//objList[x].heading =  45 * (int)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9
										objLoader.objInfo[x].heading = (int)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9

										objLoader.objInfo[x].y = (int)((DataLoader.getValAtAddress(buffer,i+2,16)) >> 10) & 0x07;	//bits 10-12
										objLoader.objInfo[x].x = (int)((DataLoader.getValAtAddress(buffer,i+2,16)) >> 13) & 0x07;	//bits 13-15

										//+4
										objLoader.objInfo[x].quality =(int)((DataLoader.getValAtAddress(buffer,i+4,16)) & 0x3F);
										objLoader.objInfo[x].next = ((DataLoader.getValAtAddress(buffer,i+4,16)>>6) & 0x3FF);

										//+6

										objLoader.objInfo[x].owner = (int)(DataLoader.getValAtAddress(buffer,i+6,16) & 0x3F) ;//bits 0-5

										objLoader.objInfo[x].link = (int)(DataLoader.getValAtAddress(buffer, i + 6, 16) >> 6 & 0x3FF); //bits 6-15
										i=i+8;
										x++;

								}
								//Create the inventory objects
								ObjectLoader.RenderObjectList(objLoader,GameWorldController.instance.currentTileMap(),GameWorldController.instance.InventoryMarker);
								for (int j=248; j<286; j=j+2)
								{//Apply objects to slots
									int index = ((int)DataLoader.getValAtAddress(buffer,j,16) >>6);
									string item_name;
									if (index!=0)
									{
										item_name=ObjectLoader.UniqueObjectName(objLoader.objInfo[index]);
									}
									else
									{
										item_name="";	
									}
										switch(j)
										{//Q? does handeness effect these???
										case 248://Helm
												playerInventory.sHelm=item_name;break;
										case 250://Chest
												playerInventory.sChest=item_name;break;
										case 252: //gloves
												playerInventory.sGloves=item_name;break;
										case 254://Leggings
												playerInventory.sLegs=item_name;break;
										case 256://boots
												playerInventory.sBoots=item_name;break;
										case 258://  is the top right shoulder.
												playerInventory.sRightShoulder=item_name;break;
										case 260:// is the top left shoulder.
												playerInventory.sLeftShoulder=item_name;break;
										case 262://  is the right hand.
												playerInventory.sRightHand=item_name;break;
										case 264://  is the left hand.
												playerInventory.sLeftHand=item_name;break;
										case 266://  is the left ring (assumption.
												playerInventory.sLeftRing=item_name;break;
										case 268://  is the right ring (assumption.
												playerInventory.sRightRing=item_name;break;
										case 270://  is the backpack slots 1.
												playerInventory.playerContainer.items[0]=item_name;break;
										case 272://  is the backpack slots 2.
												playerInventory.playerContainer.items[1]=item_name;break;
										case 274://  is the backpack slots 3.
												playerInventory.playerContainer.items[2]=item_name;break;
										case 276://  is the backpack slots 4.
												playerInventory.playerContainer.items[3]=item_name;break;
										case 278://  is the backpack slots 5.
												playerInventory.playerContainer.items[4]=item_name;break;
										case 280://  is the backpack slots 6.
												playerInventory.playerContainer.items[5]=item_name;break;
										case 282://  is the backpack slots 7.
												playerInventory.playerContainer.items[6]=item_name;break;
										case 284://  is the backpack slots 8.
												playerInventory.playerContainer.items[7]=item_name;break;
										}
								}
								playerInventory.Refresh();

						}


						if (decode)
						{
								//write out decrypted file for analysis
								byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
								for (long i=0; i<=buffer.GetUpperBound(0);i++)
								{
										dataToWrite[i] = (byte)buffer[i];
								}
								File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\decoded.dat", dataToWrite);
						}

						if (recode)//Rewrite the file with test value changes.
						{
								xOrValue= (int)buffer[0];
								incrnum = 3;
								if (indextochange!=0)
								{
										buffer[indextochange]=(char)newvalue;										
								}

								for(int i=1; i<220; i++)
								{
										if (i==81) 
										{
												incrnum = 3;
										}
										buffer[i] ^= (char)((xOrValue+incrnum) & 0xFF);
										incrnum += 3;
								}
								//write back reencrypted file to test c
								byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
								for (long i=0; i<=buffer.GetUpperBound(0);i++)
								{
										dataToWrite[i] = (byte)buffer[i];
								}
								File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\recoded.dat", dataToWrite);
						}


				}


		}

		/// <summary>
		/// Calcs the active spell effect id in a player.dat file
		/// </summary>
		/// <param name="val">Value.</param>
		void GetActiveSpellID(int val)
		{
				{//active spell 1
						if (val!=0)
						{
								//int val=(int)buffer[i];
								int effectID= ((val & 0xf)<<4) | ((val & 0xf0) >> 4);
								Debug.Log (StringController.instance.GetString(6,effectID));
						}
				}	
		}

		/// <summary>
		/// Sets the active rune slots.
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
		/// <param name="rune">Rune.</param>
		void SetActiveRuneSlots(int slotNo, int rune)
		{
				if (rune<24)
				{
						PlayerMagic.ActiveRunes[slotNo]=rune;		
				}
				else
				{
						PlayerMagic.ActiveRunes[slotNo]=-1;
				}
				ActiveRuneSlot.UpdateRuneSlots();	
		}

		/// <summary>
		/// Writes the player dat file based on the current character
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
		public void WritePlayerDat(int slotNo)
		{
				float Ratio=213f;
				float VertAdjust = 0.3543672f;

				//****Hardcoded values
				int[] hardcoded = {
						16,	16,	16,	16,	16,	240,	240,	240,	240,	240,	240,	16,	16,	16,	16,	16,	48,	48,	48,	48,	48,	37,	24,	16,	16,	16,	16,	143,	112,	112,	112,	112,	16,	16,	16,	16,	16,	48,	48,	48,	48,	48,	48,	16,	16,	16,	50,	33,	251,	241,	118,	122,	2,	160,	227,	22,	137,	140,	143,	0,	34,	0,	0,	0,	48,	0,	0,	0,	0,	0,	0,	0,	0,	44,	32,	128,	0,	0,	253,	0,	0,	0,	0,	0,	0,	0,	0
				};

				//*****
				FileStream file = File.Open(Loader.BasePath + "save" + slotNo + "\\playertmp.dat",FileMode.Create);
				BinaryWriter writer= new BinaryWriter(file);
				int ActiveEffectIndex=0;
				int runeOffset=0;

				//update inventory linking
				string[] inventoryObjects= ObjectLoader.UpdateInventoryObjectList();


				//Write the XOR Key
				DataLoader.WriteInt8(writer,XorKey);
				//I'm lazy. I'm going to write a temp file and then re-encode using the key.
				for (int i=1; i<312;i++)
				{//non inventory data 

						if (i<14)
						{
								if (i-1 <= CharName.Length)	
								{
									char alpha = CharName.ToCharArray()[i-1];
									DataLoader.WriteInt8(writer,(int)alpha);
								}
								else
								{
									DataLoader.WriteInt8(writer,0);
								}
						}
						else
						{
								switch(i)
								{
								case 0x1F ://Strength
										DataLoader.WriteInt8(writer,PlayerSkills.STR);break;
								case 0x20 ://Dex
										DataLoader.WriteInt8(writer,PlayerSkills.DEX);break;
								case 0x21 : ///    Intelligence
										DataLoader.WriteInt8(writer,PlayerSkills.INT);break;
								case 0x22 : ///    Attack
										DataLoader.WriteInt8(writer,PlayerSkills.Attack);break;
								case 0x23 : ///    Defense
										DataLoader.WriteInt8(writer,PlayerSkills.Defense);break;
								case 0x24 : ///    Unarmed
										DataLoader.WriteInt8(writer,PlayerSkills.Unarmed);break;
								case 0x25  : ///    Sword
										DataLoader.WriteInt8(writer,PlayerSkills.Sword);break;
								case 0x26  : ///    Axe
										DataLoader.WriteInt8(writer,PlayerSkills.Axe);break;
								case 0x27 : ///    Mace
										DataLoader.WriteInt8(writer,PlayerSkills.Mace);break;
								case 0x28   : ///    Missile
										DataLoader.WriteInt8(writer,PlayerSkills.Missile);break;
								case 0x29  : ///    Mana
										DataLoader.WriteInt8(writer,PlayerSkills.ManaSkill);break;
								case 0x2A : ///    Lore
										DataLoader.WriteInt8(writer,PlayerSkills.Lore);break;
								case 0x2B  : ///    Casting
										DataLoader.WriteInt8(writer,PlayerSkills.Casting);break;
								case 0x2C  : ///    Traps
										DataLoader.WriteInt8(writer,PlayerSkills.Traps);break;
								case 0x2D  : ///    Search
										DataLoader.WriteInt8(writer,PlayerSkills.Search);break;
								case 0x2E : ///    Track
										DataLoader.WriteInt8(writer,PlayerSkills.Track);break;
								case 0x2F  : ///    Sneak
										DataLoader.WriteInt8(writer,PlayerSkills.Sneak);break;
								case 0x30  : ///    Repair
										DataLoader.WriteInt8(writer,PlayerSkills.Repair);break;
								case 0x31 : ///    Charm
										DataLoader.WriteInt8(writer,PlayerSkills.Charm);break;
								case 0x32 : ///    Picklock
										DataLoader.WriteInt8(writer,PlayerSkills.PickLock);break;
								case 0x33  : ///    Acrobat
										DataLoader.WriteInt8(writer,PlayerSkills.Acrobat);break;
								case 0x34  : ///    Appraise
										DataLoader.WriteInt8(writer,PlayerSkills.Appraise);break;
								case 0x35  : ///    Swimming
										DataLoader.WriteInt8(writer,PlayerSkills.Swimming);break;
								case 0x36://Curvit
										DataLoader.WriteInt8(writer,CurVIT);break;
								case 0x37 : ///    max. vitality
										DataLoader.WriteInt8(writer,MaxVIT);break;
								case 0x38 : ///    current mana, (play_mana)
										DataLoader.WriteInt8(writer,PlayerMagic.CurMana);break;
								case 0x39  : ///    max. mana
										DataLoader.WriteInt8(writer,PlayerMagic.MaxMana);break;
								case 0x3A : ///    hunger, play_hunger
										DataLoader.WriteInt8(writer,FoodLevel);break;

								case 0x3B://Unknown s
								case 0x3C:		
										DataLoader.WriteInt8(writer,64);break;
								case 0x3E : ///    character level (play_level)
										DataLoader.WriteInt8(writer,CharLevel);break;
								case 0x3F:
								case 0x41:
								case 0x43://Active spell effect
										{
											if (ActiveSpell[ActiveEffectIndex]!=null)
											{
												int effectId= ActiveSpell[ActiveEffectIndex].EffectID;
														//int effectID= ((val & 0xf)<<4) | ((val & 0xf0) >> 4*/
												int byteToWrite =((effectId & 0xf0)>> 4) | ((effectId & 0xf) <<4);
												DataLoader.WriteInt16(writer,byteToWrite);
											}
											else
											{//No effect leave empty
												DataLoader.WriteInt16(writer,0);		
											}
										ActiveEffectIndex++;
										break;
										}

								case 0x3F+1:
								case 0x41+1:
								case 0x43+1://Active spell effect. 2nd byte do nothing here.
										break;
								case 0x45://Runebits
								case 0x46://Runebits
								case 0x47://Runebits
										{
											int RuneByte=0;
											for (int r =7; r>=0; r--)
											{
												if (PlayerMagic.PlayerRunes[7-r+runeOffset]==true)
												{
													RuneByte |= (1<<r); 
												}
											}
											DataLoader.WriteInt8(writer, RuneByte);
											runeOffset+=8;
											break;
										}
								case 0x48:
										if (PlayerMagic.ActiveRunes[0]==-1)
										{
												DataLoader.WriteInt8(writer,24);	
										}
										else
										{
												DataLoader.WriteInt8(writer,PlayerMagic.ActiveRunes[0]);	
										}
										break;
								case 0x49:
										if (PlayerMagic.ActiveRunes[1]==-1)
										{
												DataLoader.WriteInt8(writer,24);	
										}
										else
										{
												DataLoader.WriteInt8(writer,PlayerMagic.ActiveRunes[1]);	
										}
										break;
								case 0x4A:
										if (PlayerMagic.ActiveRunes[2]==-1)
										{
												DataLoader.WriteInt8(writer,24);	
										}
										else
										{
												DataLoader.WriteInt8(writer,PlayerMagic.ActiveRunes[2]);	
										}
										break;
								case 0x4D : ///   weight in 0.1 stones
										//Or STR * 2; 
										DataLoader.WriteInt16(writer,PlayerSkills.STR*2*10);
										break;
								case 0x4D+1://2nd Byte of weight. Ignore
										break;
								case 0x4F  : ///   experience in 0.1 points
										DataLoader.WriteInt32(writer,EXP);break;
								case 0x4F+1:
								case 0x4F+2:
								case 0x4F+3:
										break;
								case 0x53: // skillpoints available to spend
										DataLoader.WriteInt8(writer,TrainingPoints);break;
								case 0x55 : ///   x-position in level
										int x_position=(int)(this.transform.position.x*Ratio);
										DataLoader.WriteInt16(writer,x_position);
										break;
								case 0x57  : ///   y-position
										int y_position=(int)(this.transform.position.z*Ratio);
										DataLoader.WriteInt16(writer,y_position);
										break;
								case 0x59 : ///   z-position
										int z_position=(int)((this.transform.position.y - VertAdjust)  * (Ratio));
										DataLoader.WriteInt16(writer,z_position);
										break;
								case 0x55+1 : ///   x-position in level
								case 0x57+1  : ///   y-position
								case 0x59+1 : ///   z-position
										//Skip over int 16
										break;
								case 0x5C : ///   heading
										{
											float heading=this.transform.eulerAngles.y * (255f/360f);
											DataLoader.WriteInt8(writer,(int)heading);break;
											break;
										}
								case 0x5D  : ///   dungeon level										
										DataLoader.WriteInt8(writer,GameWorldController.instance.LevelNo+1);break;
								case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
										{
											int val = (ResurrectLevel & 0xf)<<4 | (MoonGateLevel & 0xf)	;
											DataLoader.WriteInt8(writer,val);
											break;
										}
								case 0x60  : ///    bits 2..5: play_poison
										DataLoader.WriteInt8(writer,play_poison<<2);
										break;
								case 0x65: // hand, Gender & body, and class
										{
												//bit 1 = hand left/right
												//bit 2-5 = gender & body
												//bit 6-8 = class
												int val=0;
												if (!isLefty)
												{
														val |=1;
												}
												if (isFemale)
												{
														val |= ((Body*2) + 1) <<1;
												}
												else
												{
														val |= ((Body*2) ) <<1;	
												}
												val |=CharClass<<5;
												DataLoader.WriteInt8(writer,val);break;
												break;
										}
								case 0x66://Quest flags
										{
												int val = 0;
												for (int b=0;b<32;b++)
												{
														val |= (quest().QuestVariables[b] & 0x1) << b;
												}
												DataLoader.WriteInt32(writer,val);
												break;
										}

								case 0x66+1://Quest flags ignore
								case 0x66+2://Quest flags ignore
								case 0x66+3://Quest flags ignore
										break;

								case 0x6A:
										DataLoader.WriteInt8(writer,quest().QuestVariables[32]);break;
								case 0x6B:
										DataLoader.WriteInt8(writer,quest().QuestVariables[33]);break;
								case 0x6C:
										DataLoader.WriteInt8(writer,quest().QuestVariables[34]);break;
								case 0x6D:
										DataLoader.WriteInt8(writer,quest().QuestVariables[35]);break;
								case 0x6E://Is always 8???
										DataLoader.WriteInt8(writer,8);break;
								case 0x6F://Garamon dream related?
										DataLoader.WriteInt8(writer,quest().GaramonDream);break;

								case 0x71://Game variables
								case 0x72:
								case 0x73:
								case 0x74:
								case 0x75:
								case 0x76:
								case 0x77:
								case 0x78:
								case 0x79:
								case 0x7A:
								case 0x7B:
								case 0x7C:
								case 0x7D:
								case 0x7E:
								case 0x7F:
								case 0x80:
								case 0x81:
								case 0x82:
								case 0x83:
								case 0x84:
								case 0x85:
								case 0x86:
								case 0x87:
								case 0x88:
								case 0x89:
								case 0x8A:
								case 0x8B:
								case 0x8C:
								case 0x8D:
								case 0x8E:
								case 0x8F:
								case 0x90:
										{
											DataLoader.WriteInt8(writer,GameWorldController.instance.variables[i-0x71]);
											break;
										}

										//Unknown values (possibly hardcoded)
								case 0xA1:
								case 0xA2:
								case 0xA3:
								case 0xA4:
								case 0xA5:
								case 0xA6:
								case 0xA7:
								case 0xA8:
								case 0xA9:
								case 0xAA:
								case 0xAB:
								case 0xAC:
								case 0xAD:
								case 0xAE:
								case 0xAF:
								case 0xB0:
								case 0xB1:
								case 0xB2:
								case 0xB3:
								case 0xB4:
								case 0xB5:
								case 0xB6:
								case 0xB7:
								case 0xB8:
								case 0xB9:
								case 0xBA:
								case 0xBB:
								case 0xBC:
								case 0xBD:
								case 0xBE:
								case 0xBF:
								case 0xC0:
								case 0xC1:
								case 0xC2:
								case 0xC3:
								case 0xC4:
								case 0xC5:
								case 0xC6:
								case 0xC7:
								case 0xC8:
								case 0xC9:
								case 0xCA:
								case 0xCB:
								case 0xCC:
								case 0xCD:
								case 0xCE:
								//case 0xCF:
								//case 0xD0:
								//case 0xD1:
								//case 0xD2:
								case 0xD3:
								case 0xD4:
								case 0xD5:
								case 0xD6:
								case 0xD7:
								case 0xD8:
								case 0xD9:
								case 0xDA:
								case 0xDB:
								case 0xDC:
								//case 0xDD:
								case 0xDE:
								case 0xDF:
								case 0xE0:
								case 0xE1:
								case 0xE2:
								case 0xE3:
								case 0xE4:
								case 0xE5:
								case 0xE6:
								case 0xE7:
								case 0xE8:
								case 0xE9:
								case 0xEA:
								case 0xEB:
								case 0xEC:
								case 0xED:
								case 0xEE:
								case 0xEF:
								case 0xF0:
								case 0xF1:
								case 0xF2:
								case 0xF3:
								case 0xF4:
								case 0xF5:
								case 0xF6:
								case 0xF7:
										DataLoader.WriteInt8(writer,hardcoded[i-161]);break;
										break;

								case 0xCF  : ///   game time
										DataLoader.WriteInt32(writer,game_time);break;
										break;
								case 0xD0://gametime ignore
								case 0xD1:
								case 0xD2:
										break;

								case 0xDD://Duplicate curvit
										DataLoader.WriteInt8(writer,CurVIT);break;
										break;

								case 0xF8: // Helm (all of these subsequent values are indices into the object list at offset 312
										WriteInventoryIndex(writer, inventoryObjects,0);break;
								case 0xF9: // Helm ignore
										break;
								case 0xFA: // Chest
										WriteInventoryIndex(writer, inventoryObjects,1);break;
								case 0xFB: // Chest ignore
										break;
								case 0xFC: // Gloves
										WriteInventoryIndex(writer, inventoryObjects,4);break;
								case 0xFD: // Gloves ignore
										break;
								case 0xFE: // Leggings
										WriteInventoryIndex(writer, inventoryObjects,2);break;
								case 0xFF: // Leggings ignore
										break;
								case 0x100: // Boots
										WriteInventoryIndex(writer, inventoryObjects,3);break;
								case 0x101: // Boots ignore
										break;
								case 0x102: // TopRightShoulder
										WriteInventoryIndex(writer, inventoryObjects,5);break;
								case 0x103: // TopRightShoulder ignore
										break;
								case 0x104: // TopLeftShoulder
										WriteInventoryIndex(writer, inventoryObjects,6);break;
								case 0x105: // TopLeftShoulder ignore
										break;
								case 0x106: // Righthand
										WriteInventoryIndex(writer, inventoryObjects,7);break;
								case 0x107: // Righthand ignore
										break;
								case 0x108: // LeftHand
										WriteInventoryIndex(writer, inventoryObjects,8);break;
								case 0x109: // LeftHand ignore
										break;
								case 0x10A: // RightRing
										WriteInventoryIndex(writer, inventoryObjects,9);break;
								case 0x10B: // RightRing ignore
										break;
								case 0x10C: // LeftRing
										WriteInventoryIndex(writer, inventoryObjects,10);break;
								case 0x10D: // LeftRing ignore
										break;
								case 0x10E: // Backpack0
										WriteInventoryIndex(writer, inventoryObjects,11);break;
								case 0x10F: // Backpack0 ignore
										break;
								case 0x110: // Backpack1
										WriteInventoryIndex(writer, inventoryObjects,12);break;
								case 0x111: // Backpack1 ignore
										break;
								case 0x112: // Backpack2
										WriteInventoryIndex(writer, inventoryObjects,13);break;
								case 0x113: // Backpack2 ignore
										break;
								case 0x114: // Backpack3
										WriteInventoryIndex(writer, inventoryObjects,14);break;
								case 0x115: // Backpack3 ignore
										break;
								case 0x116: // Backpack4
										WriteInventoryIndex(writer, inventoryObjects,15);break;
								case 0x117: // Backpack4 ignore
										break;
								case 0x118: // Backpack5
										WriteInventoryIndex(writer, inventoryObjects,16);break;
								case 0x119: // Backpack5 ignore
										break;
								case 0x11A: // Backpack6
										WriteInventoryIndex(writer, inventoryObjects,17);break;
								case 0x11B: // Backpack6 ignore
										break;
								case 0x11C: // Backpack7
										WriteInventoryIndex(writer, inventoryObjects,18);break;
								case 0x11D: // Backpack7 ignore
										break;	

								default://No value. Write 0									
										DataLoader.WriteInt8(writer,0);break;

										break;

								}	//endswitch


						}

				}

				//ALl things going well I should be at byte no 312 where I can write the inventory info.
				for (int o =0; o<=inventoryObjects.GetUpperBound(0); o++)
				{
						GameObject obj = GameObject.Find(inventoryObjects[o]);
						if (obj!=null)
						{
								ObjectInteraction currobj = obj.GetComponent<ObjectInteraction>();
								int ByteToWrite= (currobj.isquant << 15) |
										(currobj.invis << 14) |
										(currobj.doordir << 13) |
										(currobj.enchantment << 12) |
										((currobj.flags & 0x0F) << 9) |
										(currobj.item_id & 0x1FF) ;
							
								DataLoader.WriteInt8(writer,(ByteToWrite & 0xFF));
								DataLoader.WriteInt8(writer,((ByteToWrite>>8) & 0xFF));

								ByteToWrite = ((currobj.x & 0x7) << 13) |
										((currobj.y & 0x7) << 10) |
										((currobj.heading & 0x7) << 7) |
										((currobj.zpos & 0x7F));
								DataLoader.WriteInt8(writer,(ByteToWrite & 0xFF));
								DataLoader.WriteInt8(writer,((ByteToWrite>>8) & 0xFF));

								ByteToWrite = (((int)currobj.next & 0x3FF)<<6) |
										(currobj.quality & 0x3F); 
								DataLoader.WriteInt8(writer,(ByteToWrite & 0xFF));
								DataLoader.WriteInt8(writer,((ByteToWrite>>8) & 0xFF));	

								ByteToWrite = ((currobj.link & 0x3FF)<<6) |
										(currobj.owner & 0x3F); 
								DataLoader.WriteInt8(writer,(ByteToWrite & 0xFF));
								DataLoader.WriteInt8(writer,((ByteToWrite>>8) & 0xFF));	
						}
				}


				writer.Close();

				char[] buffer;
				//Reopen and encrypt the file
				if (DataLoader.ReadStreamFile(Loader.BasePath + "save" + slotNo + "\\playertmp.dat", out buffer))
				{
						int xOrValue= (int)buffer[0];
						int incrnum = 3;
						for(int i=1; i<220; i++)
						{
								if (i==81) 
								{
										incrnum = 3;
								}
								buffer[i] ^= (char)((xOrValue+incrnum) & 0xFF);
								incrnum += 3;
						}

						byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
						for (long i=0; i<=buffer.GetUpperBound(0);i++)
						{
								dataToWrite[i] = (byte)buffer[i];
						}
						File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\playertmpEnc.dat", dataToWrite);

				}				

		}

		static void WriteInventoryIndex(BinaryWriter writer, string[] InventoryObjects, int slotIndex)
		{
			string itemAtSlot="";
			if (slotIndex<=10)
			{
				itemAtSlot = GameWorldController.instance.playerUW.playerInventory.GetObjectAtSlot(slotIndex);	
			}
			else
			{
				itemAtSlot = GameWorldController.instance.playerUW.playerInventory.playerContainer.GetItemAt(11-slotIndex);
			}
			if (itemAtSlot!="")
			{
				int index = System.Array.IndexOf(InventoryObjects,itemAtSlot)+64;
				DataLoader.WriteInt16(writer, index);
			}
			else
			{
				DataLoader.WriteInt16(writer, 0);
			}
		}

}
