using UnityEngine;
using System.Collections;

/*
The basic character. Stats and interaction.
 */ 
public class UWCharacter : Character {

	//What magic spells are currently active on (and cast by) the player. (max 3)
	//These are the ones that the player can see on the hud.
	public SpellEffect[] ActiveSpell=new SpellEffect[3]; 

	//What effects and enchantments (eg from items are equipped on the player)
	public SpellEffect[] PassiveSpell=new SpellEffect[10];

	public int Body;//Which body/portrait this character has 



	//Character related info
	//Character Details

	public string CharClass;
	public int CharLevel;
	public int EXP;
	public bool isFemale;
	public bool isLefty;
	public bool isSwimming;

	//Character Status
	public int FoodLevel;
	public int Fatigue;
	public bool Poisoned;

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

	public CutsceneAnimation CutScenesSmall;

	public override void Start ()
	{
		base.Start ();

		XAxis.enabled=false;
		YAxis.enabled=false;
		MouseLookEnabled=false;
		Cursor.SetCursor (CursorIconBlank,Vector2.zero, CursorMode.ForceSoftware);

		InteractionMode=UWCharacter.DefaultInteractionMode;

		WindowDetectUW.playerUW=this.GetComponent<UWCharacter>();
		Container.playerUW=this.GetComponent<UWCharacter>();
		ContainerOpened.playerUW =this.GetComponent<UWCharacter>();
		//a_text_string_trap.SC=StringControl;
		ActiveRuneSlot.playerUW=this.GetComponent<UWCharacter>();
		SpellEffect.playerUW=this.GetComponent<UWCharacter>();
		SpellEffectsDisplay.playerUW=this.GetComponent<UWCharacter>();
		RuneSlot.playerUW=this.GetComponent<UWCharacter>();
		
		HealthFlask.playerUW=this.gameObject.GetComponent<UWCharacter>();
		Compass.playerUW=this.gameObject.GetComponent<UWCharacter>();
		StatsDisplay.playerUW=this.gameObject.GetComponent<UWCharacter>();
		
		NPC.playerUW=this.GetComponent<UWCharacter>();
		GoblinAI.player=this.gameObject;
		
		Conversation.SC=ObjectInteraction.SC;
		Conversation.playerUW = this.gameObject.GetComponent<UWCharacter>();

		StringControl.InitStringController(Application.dataPath + "//..//uw1_strings.txt");

		ObjectInteraction.playerUW =this.gameObject.GetComponent<UWCharacter>();

	}

	void PlayerDeath()
	{//CHeck if the player has planted the seed and if so send them to that position.
		mus.Death=true;

		if (CutScenesSmall!=null)
		{
			if (ResurrectPosition!=Vector3.zero)
			{
				CutScenesSmall.SetAnimation="Death_With_Sapling";
			}
			else
			{
				CutScenesSmall.SetAnimation="Death";
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



	// Update is called once per frame
	public override void Update () {
		base.Update ();
		if (WindowDetectUW.WaitingForInput==true)
		{//TODO: This should be in window detect
			MessageLog.gameObject.GetComponent<UIInput>().selected=true;
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

		if (isSwimming==true)
		{
			Camera.main.transform.localPosition=new Vector3(Camera.main.transform.localPosition.x,-1.0f,Camera.main.transform.localPosition.z);
		}
		else
		{
			Camera.main.transform.localPosition=new Vector3(Camera.main.transform.localPosition.x,0.9198418f,Camera.main.transform.localPosition.z);
		}

		mus.WeaponDrawn=(InteractionMode==UWCharacter.InteractionModeAttack);

		if (PlayerMagic.ReadiedSpell!="")
		{//Player has a spell thats about to be cast. All other activity is ignored.
			SpellMode ();
			return;
		}

		PlayerCombat.PlayerCombatUpdate();


	
	}

	public void SpellMode()
	{//Casts a spell on right click.
		if(Input.GetMouseButtonDown(1) && (WindowDetectUW.CursorInMainWindow==true))
		{
			this.GetComponent<Magic>().castSpell(this.gameObject, PlayerMagic.ReadiedSpell,false);
		}
	}


	public void OnSubmitPickup()
	{
		Time.timeScale=1.0f;
		WindowDetectUW.WaitingForInput=false;
		Debug.Log ("Value summited");

		UIInput inputctrl =MessageLog.gameObject.GetComponent<UIInput>();
		//Debug.Log (inputctrl.text);
		int quant= int.Parse(inputctrl.text);
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
	}



	public Quest quest()
	{
		return this.GetComponent<Quest>();
	}
}
