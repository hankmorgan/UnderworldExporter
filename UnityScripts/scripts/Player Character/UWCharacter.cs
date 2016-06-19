using UnityEngine;
using System.Collections;

/*
The basic character. Stats and interaction.
 */ 
public class UWCharacter : Character {

	//What magic spells are currently active on (and cast by) the player. (max 3)
	//These are the ones that the player can see on the hud.
	public static UWCharacter Instance;

	public SpellEffect[] ActiveSpell=new SpellEffect[3]; 

	//What effects and enchantments (eg from items are equipped on the player)
	public SpellEffect[] PassiveSpell=new SpellEffect[10];

	public int Body;//Which body/portrait this character has 

	public UWHUD playerHud;

	//Character related info
	//Character Details

	public string CharClass;
	public int CharLevel;
	public int EXP;
	public bool isFemale;
	public bool isLefty;
	public bool isSwimming;
	public bool isFlying;
	public bool isRoaming;
	public float flySpeed;
	public float walkSpeed;
	public float speedMultiplier=1.0f;
	public bool isFloating;
	public bool isWaterWalking;
	public bool onGround;//Not currently used.
	public bool isTelekinetic;
	public bool isLeaping;
	
	public int Resistance; //DR from spells.
	public bool FireProof;//Takes no damage from lava

	//Character Status
	public int FoodLevel; //0-35 range.
	public int Fatigue;   //0-29 range
	public bool Poisoned;
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

	public float lavaDamageTimer;
	public string currRegion;

	public void Awake()
	{
		Instance=this;
				DontDestroyOnLoad(this);
	}

	public override void Start ()
	{

		base.Start ();

		XAxis.enabled=false;
		YAxis.enabled=false;
		MouseLookEnabled=false;
		Cursor.SetCursor (CursorIconBlank,Vector2.zero, CursorMode.ForceSoftware);
		GuiBase.playerUW = this.gameObject.GetComponent<UWCharacter>();
		InteractionMode=UWCharacter.DefaultInteractionMode;


		//Tells other objects about this component;
		InventorySlot.playerUW=this.GetComponent<UWCharacter>();

		DoorControl.playerUW=this.gameObject.GetComponent<UWCharacter>();
		Container.playerUW=this.GetComponent<UWCharacter>();
		ContainerOpened.playerUW =this.GetComponent<UWCharacter>();
		ActiveRuneSlot.playerUW=this.GetComponent<UWCharacter>();
		SpellEffect.playerUW=this.GetComponent<UWCharacter>();
		SpellEffectsDisplay.playerUW=this.GetComponent<UWCharacter>();
		RuneSlot.playerUW=this.GetComponent<UWCharacter>();
		Eyes.playerUW=this.GetComponent<UWCharacter>();
		NPC.playerUW=this.GetComponent<UWCharacter>();
		Magic.playerUW=this.GetComponent<UWCharacter>();
		object_base.playerUW= this.gameObject.GetComponent<UWCharacter>();
		Conversation.playerUW = this.gameObject.GetComponent<UWCharacter>();
		SpellProp.playerUW = this.gameObject.GetComponent<UWCharacter>();
		StringControl.InitStringController(Application.dataPath + "//..//uw1_strings.txt");

		ObjectInteraction.playerUW =this.gameObject.GetComponent<UWCharacter>();
		playerHud.InputControl.text="";
		playerHud.InputControl.label.text="";
		playerHud.MessageScroll.Clear ();
		if (Application.loadedLevelName=="0")
		{//Load the first level
						//Debug.Log("Loading first level");
				//RoomManager.LoadRoom("1");
		}

		//Cutscene_Intro ci = playerHud.gameObject.AddComponent<Cutscene_Intro>();
		//playerHud.CutScenesFull.cs=ci;
		//playerHud.CutScenesFull.Begin();
	}

	void PlayerDeath()
	{//CHeck if the player has planted the seed and if so send them to that position.
		mus.Death=true;
		if ( playerHud.CutScenesSmall!=null)
		{
			if (ResurrectPosition!=Vector3.zero)
			{
				 playerHud.CutScenesSmall.SetAnimation="Death_With_Sapling";
			}
			else
			{
				playerHud.CutScenesSmall.SetAnimation="Death";
			}
		}

		if (ResurrectPosition!=Vector3.zero)
		{
			this.transform.position=ResurrectPosition;
		}
		//Cancel the spell
		if (PlayerMagic.ReadiedSpell!="")
		{
			PlayerMagic.ReadiedSpell="";
			CursorIcon=CursorIconDefault;
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
					switch (objIntInHand.ItemType)
					{
						case ObjectInteraction.POLE:
							return useRange *2;
							break;
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
		base.Update ();
		if ((WindowDetectUW.WaitingForInput==true) && (Instrument.PlayingInstrument==false))//TODO:Make this cleaner!!
		{//TODO: This should be in window detect
			//playerHud.MessageScroll.gameObject.GetComponent<UIInput>().selected=true;
			//playerHud.MessageScroll.gameObject.GetComponent<UIInput>().selected=true;
			playerHud.InputControl.selected=true;
		}
		if ((CurVIT<=0) && (mus.Death==false))
		{

			PlayerDeath();
			return;
		}
		if(mus.Death==true)
		{
			//Still processing death.
			return;
		}

		if (playerCam.enabled==true)
		{
			if (isSwimming==true)
			{
				Camera.main.transform.localPosition=new Vector3(Camera.main.transform.localPosition.x,-0.8f,Camera.main.transform.localPosition.z);
			}
			else
			{
				Camera.main.transform.localPosition=new Vector3(Camera.main.transform.localPosition.x,0.9198418f,Camera.main.transform.localPosition.z);
			}
		}
		playerMotor.enabled=!Paralyzed;
		
		if (isFlying)
		{//Flying spell
			playerMotor.movement.maxFallSpeed=0.0f;
			playerMotor.movement.maxForwardSpeed=flySpeed*speedMultiplier;
			if ((Input.GetKeyDown(KeyCode.R)) || (Input.GetKey(KeyCode.R)))
			{//Fly up
				this.GetComponent<CharacterController>().Move(new Vector3(0,0.2f,0));
			}
			else if ((Input.GetKeyDown(KeyCode.V)) || (Input.GetKey(KeyCode.V)))
			{//Fly down
				this.GetComponent<CharacterController>().Move(new Vector3(0,-0.2f,0));
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
				playerMotor.movement.maxForwardSpeed=walkSpeed*speedMultiplier;
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

		mus.WeaponDrawn=(InteractionMode==UWCharacter.InteractionModeAttack);

		if (PlayerMagic.ReadiedSpell!="")
		{//Player has a spell thats about to be cast. All other activity is ignored.
			SpellMode ();
			return;
		}

		if (playerHud.window.JustClicked==false)
		{
			if(Paralyzed==false)
			{
					PlayerCombat.PlayerCombatUpdate();					
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
	
	}

	public void SpellMode()
	{//Casts a spell on right click.
		if(
			(Input.GetMouseButtonDown(1)) 
			 && (WindowDetectUW.CursorInMainWindow==true)
			 && (playerHud.window.JustClicked==false)
			&& ((PlayerCombat.AttackCharging==false)&&(PlayerCombat.AttackExecuting==false))
		 )
		{
			PlayerMagic.castSpell(this.gameObject, PlayerMagic.ReadiedSpell,false);
			PlayerMagic.SpellCost=0;
			playerHud.window.UWWindowWait (1.0f);
		}
	}


	public void OnSubmitPickup()
	{

		//Debug.Log ("Value summited");

		UIInput inputctrl =playerHud.InputControl;//playerHud.MessageScroll.gameObject.GetComponent<UIInput>();
		//Debug.Log (inputctrl.text);
		int quant=0;
		if (int.TryParse(inputctrl.text,out quant)==false)
		{
			quant=0;
		}
		Time.timeScale=1.0f;
		WindowDetectUW.WaitingForInput=false;
		inputctrl.text="";
		inputctrl.label.text="";
		playerHud.MessageScroll.Clear ();
		//int quant= int.Parse(inputctrl.text);
		if (quant==0)
		{//cancel
			QuantityObj=null;
		}
		if (QuantityObj!=null)
			{
			if (quant >= QuantityObj.Link)
				{
				Pickup(QuantityObj,playerInventory);
				}
			else
				{
				//split the obj.
				GameObject Split = Instantiate(QuantityObj.gameObject);//What we are picking up.
				Split.GetComponent<ObjectInteraction>().Link =quant;
				Split.name = Split.name+"_"+summonCount++;
				QuantityObj.Link=QuantityObj.Link-quant;
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
			playerHud.MessageScroll.Add ("Talking to yourself?");
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
						playerHud.MessageScroll.Add ("You see the ceiling");
						//GetMessageLog().text = "You see the ceiling";
						break;	
					case "PILL":
						//GetMessageLog().text = 
						playerHud.MessageScroll.Add("You see a pillar");
						break;	
					case "BRID":
						//000~001~171~You see a bridge.
						//GetMessageLog().text= 
						playerHud.MessageScroll.Add(StringControl.GetString(1,171));
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
								if (textureIndex==142)
								{//This is a window into the abyss.
									playerHud.CutScenesSmall.SetAnimation="VolcanoWindow_" + GameWorldController.instance.LevelNo;
								}
								playerHud.MessageScroll.Add("You see " + StringControl.GetTextureName(textureIndex));
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


	public override void PickupMode ()
	{
		//Picks up the clicked object in the view.
		PlayerInventory pInv = this.GetComponent<PlayerInventory>();
		if (InvMarker==null)
		{
			InvMarker=GameWorldController.instance.InventoryMarker;//InvMarker=GameObject.Find ("InventoryMarker");
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
						//check for weight
						if (objPicked.GetWeight() > playerInventory.getEncumberance())
						{//000~001~095~That is too heavy for you to pick up.
							playerHud.MessageScroll.Add(StringControl.GetString(1,95));
							return;
						}
						if (UICamera.currentTouchID==-2)
						{
							//right click check for quant.
							//Pickup if either not a quantity or is a quantity of one.
							if ((objPicked.isQuant ==false) || ((objPicked.isQuant)&&(objPicked.Link==1)) || (objPicked.isEnchanted))
							{
								objPicked=Pickup(objPicked,pInv);
							}
							else
							{
								//Debug.Log("attempting to pick up a quantity");

								playerHud.MessageScroll.Set ("Move how many?");
								UIInput inputctrl =playerHud.InputControl;//playerHud.MessageScroll.GetComponent<UIInput>();
								inputctrl.GetComponent<GuiBase>().SetAnchorX(0.3f);
								inputctrl.eventReceiver=this.gameObject;
								inputctrl.type=UIInput.KeyboardType.NumberPad;
								inputctrl.text="1";
								inputctrl.label.text="1";
								inputctrl.selected=true;
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
						playerHud.MessageScroll.Add(StringControl.GetString(1,96));
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
		return StringControl.GetString (1,104+((FoodLevel)/4));
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
		return StringControl.GetString (1,113+((Fatigue)/5));
	}

	public void RegenMana()
	{//Natural Regeneration of mana over time;
		PlayerMagic.CurMana += Random.Range (1,6);
		if (PlayerMagic.CurMana>PlayerMagic.MaxMana)
		{
			PlayerMagic.CurMana=PlayerMagic.MaxMana;
		}
	}

}
