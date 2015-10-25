using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {
	
	//Magic spell to be cast on next click in window
	public string ReadiedSpell;
	//Runes that the character has picked up and is currently using
	public bool[] PlayerRunes=new bool[24];
	public int[] ActiveRunes=new int[3];
	
	
	public int MaxMana;
	public int CurMana;
	
	
	string[] Runes=new string[]{"An","Bet","Corp","Des",
		"Ex","Flam","Grav","Hur",
		"In","Jux","Kal","Lor",
		"Mani","Nox","Ort","Por",
		"Quas","Rel","Sanct","Tym",
		"Uus","Vas","Wis","Ylem"};
	
	long SummonCount=0;
	
	
	
	
	public void TestSpell(GameObject caster)
	{//Test spell for testing spell effects
		SpellEffectPoison sep = caster.AddComponent<SpellEffectPoison>();
		sep.Value=100;//Poison will damage the player for 100 hp over it's duration
		sep.counter=10; //It will run for 10 ticks. Ie 10 hp damage per tick
		sep.Go ();
		//sep.ApplyEffect();
		//StartCoroutine(sep.timer()) ;
	}
	
	public void castSpell(GameObject caster, string MagicWords, bool ready)
	{
		switch (MagicWords)
		{
		case "An An An":
		{
			TestSpell (caster);
			break;
		}
			
			//1st Circle
		case "In Mani Ylem"://Create Food
		{
			//Debug.Log(MagicWords+ " Create Food Cast");
			Cast_InManiYlem(caster);
			break;
		}//imy
		case "In Lor":	//Light
		{
			//Debug.Log(MagicWords+ " Light Cast");
			Cast_InLor(caster);
			break;
		}	//il
		case "Bet Wis Ex"://Locate
		{//UW2 spell?
			Debug.Log(MagicWords+ " Locate Cast");
			break;
		}//bwe
		case "Ort Jux"://Magic Arrow
		{
			//Debug.Log(MagicWords+ " Magic Arrow Cast Readied=" + ready);
			Cast_OrtJux(caster, ready);
			break;
		}//OJ
		case "Bet In Sanct"://Resist Blows
		{
			Debug.Log(MagicWords+ " Resist Blows Cast");
			break;
		}//BIS
		case "Sanct Hur"://Stealth
		{
			Debug.Log(MagicWords+ " Stealth Cast");
			break;
		}//sh
			
			//2nd Circle
		case "Quas Corp"://Cause Fear
		{
			Debug.Log(MagicWords+ " Cause Fear Cast");
			break;
		}//qc
		case "Wis Mani"://Detect Monster
		{
			Debug.Log(MagicWords+ " Detect Monster Cast");
			break;
		}//wm
		case "Uus Por"://Jump
		{
			Cast_UusPor(caster);
			//Debug.Log(MagicWords+ " Jump Cast");
			break;
		}//up
		case "In Bet Mani"://Lesser Heal
		{
			//Debug.Log(MagicWords+ " Lesser Heal Cast");
			Cast_InBetMani(caster);
			break;
		}//IBM
		case "Rel Des Por"://Slow Fall
		{
			Debug.Log(MagicWords+ " Slow Fall Cast");
			break;
		}//RDP
		case "In Sanct"://Thick Skin
		{
			Debug.Log(MagicWords+ " Thick Skin Cast");
			break;
		}//IS
		case "In Jux"://Rune of Warding
		{
			Debug.Log(MagicWords+ " Rune of Warding Cast");
			break;
		}//IJ
			
			//3rd Circle
		case "Bet Sanct Lor"://Conceal
		{
			Debug.Log(MagicWords+ " Conceal Cast");
			break;
		}//BSL
		case "Ort Grav"://Lightning
		{
			//Debug.Log(MagicWords+ " Lightning Cast");
			Cast_OrtGrav(caster, ready);
			break;
		}//OG
		case "Quas Lor"://Night Vision
		{
			Debug.Log(MagicWords+ " Night Vision Cast");
			break;
		}//QL
		case "An Kal Corp"://Repel Undead
		{
			Debug.Log(MagicWords+ " Repel Undead Cast");
			break;
		}//akc
		case "Rel Tym Por"://Speed
		{
			Debug.Log(MagicWords+ " Speed Cast");
			break;
		}//rtp
		case "Ylem Por"://Water Walk
		{
			Debug.Log(MagicWords+ " Water Walk Cast");
			break;
		}//YP
		case "Sanct Jux"://Strengten Door
		{
			Debug.Log(MagicWords+ " Strengten Door Cast");
			break;
		}//SJ
			
			//4th Circle
		case "An Sanct"://Curse
		{
			Debug.Log(MagicWords+ " Curse Cast");
			break;
		}//AS
		case "Sanct Flam":// Flameproof
		{
			Debug.Log(MagicWords+ " Flameproof Cast");
			break;
		}//SF
		case "In Mani"://Heal
		{
			//Debug.Log(MagicWords+ " Heal Cast");
			Cast_InMani (caster);
			break;
		}//IM
		case "Hur Por"://Levitate
		{	
			Debug.Log(MagicWords+ " Cast");
			break;
		}//HP
		case "Nox Ylem"://Poison
		{
			Debug.Log(MagicWords+ " Poison Cast");
			break;
		}//NY
		case "An Jux"://Remove Trap
		{
			Debug.Log(MagicWords+ " Remove Trap Cast");
			break;
		}//AJ
			
			//5th Circle
		case "Por Flam"://Fireball
		{
			Debug.Log(MagicWords+ " Fireball Cast");
			break;
		}//PF
		case "Grav Sanct Por"://Missile Protection
		{
			Debug.Log(MagicWords+ " Missile Protection Cast");
			break;
		}//GSP
		case "Ort Wis Ylem"://Name Enchantment
		{
			Debug.Log(MagicWords+ " Name Enchantment Cast");
			break;
		}//OWY
		case "Ex Ylem"://Open
		{
			Cast_ExYlem(caster, ready);
			//Debug.Log(MagicWords+ " Open Cast");
			break;
		}//EY
		case "An Nox"://Cure Poison
		{
			Cast_AnNox(caster);
			//Debug.Log(MagicWords+ " Cure Poison Cast");
			break;
		}//AN
		case "An Corp Mani"://Smite Undead
		{
			Debug.Log(MagicWords+ " Smite Undead Cast");
			break;
		}//ACM
			
			//6th Circle
		case "Vas In Lor"://Daylight
		{
			Debug.Log(MagicWords+ " Daylight Cast");
			Cast_VasInLor(caster);
			break;
		}//VIL
		case "Vas Rel Por"://Gate Travel
		{
			Debug.Log(MagicWords+ " Gate Travel Cast");
			break;
		}//VRP
		case "Vas In Mani"://Greater Heal
		{
			//Debug.Log(MagicWords+ " Greater Heal Cast");
			Cast_VasInMani (caster);
			break;
		}//VIM
		case "An Ex Por"://Paralyze
		{
			Debug.Log(MagicWords+ " Paralyze Cast");
			break;
		}//AEP
		case "Vas Ort Grav"://Sheet Lightning
		{
			Debug.Log(MagicWords+ " Sheet Lightning Cast");
			break;
		}//VOG
		case "Ort Por Ylem"://Telekinesis
		{
			Debug.Log(MagicWords+ " Telekinesis Cast");
			Cast_OrtPorYlem(caster);
			break;
		}//OPY
			
			//7th Circle
		case "In Mani Rel"://Ally
		{
			Debug.Log(MagicWords+ " Ally Cast");
			break;
		}//IMR
		case "Vas An Wis"://Confusion
		{
			Debug.Log(MagicWords+ " Confusion Cast");
			break;
		}//VAW
		case "Vas Sanct Lor"://Invisibility
		{
			Debug.Log(MagicWords+ " Invisibility Cast");
			break;
		}//VSL
		case "Vas Hur Por"://Fly
		{
			Debug.Log(MagicWords+ " Fly Cast");
			break;
		}//VHP
		case "Kal Mani"://Monster Summoning
		{
			Debug.Log(MagicWords+ " Monster Summoning Cast");
			break;
		}//KM
		case "Ort An Quas"://Reveal
		{
			Debug.Log(MagicWords+ " Reveal Cast");
			break;
		}//OAQ
			//8th Circle
		case "Vas Kal Corp"://Armageddon
		{
			Debug.Log(MagicWords+ " Armageddon Cast");
			Cast_VasKalCorp(caster);
			break;
		}//vkc
		case "Flam Hur"://Flame Wind
		{
			Debug.Log(MagicWords+ " Flame Wind Cast");
			break;
		}//fh
		case "An Tym":// Freeze Time
		{
			Debug.Log(MagicWords+ " Freeze Time Cast");
			break;
		}//at
		case "In Vas Sanct"://Iron Flesh
		{
			Debug.Log(MagicWords+ " Iron Flesh Cast");
			break;
		}//ivs
		case "Ort Por Wis"://Roaming sight
		{
			Debug.Log(MagicWords+ " Roaming sight Cast");
			break;
		}//opw
		case "Vas Por Ylem"://Tremor
		{
			Debug.Log(MagicWords+ " Tremor Cast");
			break;
		}//vpy
		default:
		{
			Debug.Log("Unknown spell:" + MagicWords);
			break;
		}
		}//magicwords
	}
	
	
	public void castSpell(GameObject caster, int Rune1, int Rune2, int Rune3, bool ready)
	{
		//Casts a magic spell based on the constructed magic rune string
		
		string MagicWords="";
		//Construct the spell words based on selected runes
		if ((Rune1>=0) && (Rune1<=23))
		{
			MagicWords= Runes[Rune1];
		}
		if ((Rune2>=0) && (Rune2<=23))
		{
			MagicWords=MagicWords + " " + Runes[Rune2];
		}
		if ((Rune3>=0) && (Rune3<=23))
		{
			MagicWords=MagicWords + " " + Runes[Rune3];
		}
		
		castSpell (caster, MagicWords,ready);
		
	}
	
	
	void Cast_OrtJux(GameObject caster, bool Ready)
	{//Magic Missile Spell
		UWCharacter playerUW = caster.GetComponent<UWCharacter>();
		if (Ready==true)
		{//Ready the spell to be cast.
			ReadiedSpell= "Ort Jux";
			playerUW.CursorIcon=Resources.Load<Texture2D>("Hud/Cursors/Cursors_0009");
		}
		else
		{
			Ray ray = getRay (caster);
			
			
			RaycastHit hit = new RaycastHit(); 
			float dropRange=0.5f;
			if (!Physics.Raycast(ray,out hit,dropRange))
			{//No object interferes with the spellcast
				float force = 200.0f;
				ReadiedSpell= "";
				GameObject projectile = CreateMagicProjectile("Sprites/objects_023","",ray.GetPoint(dropRange/2.0f), 5);
				LaunchProjectile(projectile,ray,dropRange,force);
				playerUW.CursorIcon=playerUW.CursorIconDefault;
			}
		}
	}
	
	void Cast_OrtGrav(GameObject caster, bool Ready)
	{//Lightning Bolt
		UWCharacter playerUW = caster.GetComponent<UWCharacter>();
		if (Ready==true)
		{//Ready the spell to be cast.
			ReadiedSpell= "Ort Grav";
			playerUW.CursorIcon=Resources.Load<Texture2D>("Hud/Cursors/Cursors_0009");
		}
		else
		{
			Ray ray = getRay (caster);
			RaycastHit hit = new RaycastHit(); 
			float dropRange=0.5f;
			if (!Physics.Raycast(ray,out hit,dropRange))
			{//No object interferes with the spellcast
				float force = 200.0f;
				ReadiedSpell= "";
				GameObject projectile = CreateMagicProjectile("Sprites/objects_021","",ray.GetPoint(dropRange/2.0f), 5);
				LaunchProjectile(projectile,ray,dropRange,force);
				playerUW.CursorIcon=playerUW.CursorIconDefault;
			}
		}
	}
	
	
	
	void Cast_ExYlem(GameObject caster, bool Ready)
	{//Open
		UWCharacter playerUW = caster.GetComponent<UWCharacter>();
		if (Ready==true)
		{//Ready the spell to be cast.
			Debug.Log ("ExYlem is ready to cast");
			playerUW.PlayerMagic.ReadiedSpell= "Ex Ylem";
			playerUW.CursorIcon=Resources.Load<Texture2D>("Hud/Cursors/Cursors_0010");
		}
		else
		{
			Ray ray = getRay (caster);
			RaycastHit hit = new RaycastHit(); 
			float dropRange=playerUW.useRange;
			if (Physics.Raycast(ray,out hit,dropRange))
			{//The spell has hit something
				DoorControl dc =hit.transform.gameObject.GetComponent<DoorControl>();
				if (dc!=null)
				{
					dc.UnlockDoor();
					Debug.Log ("Ex Ylem has been cast");
					playerUW.CursorIcon=playerUW.CursorIconDefault;
				}
			}
		}
	}
	
	
	
	void Cast_AnNox(GameObject caster)
	{//Cure Poison
		UWCharacter playerUW = caster.GetComponent<UWCharacter>();
		//Get all instances of poison effect on the character and destroy them.
		SpellEffectPoison[] seps= caster.GetComponents<SpellEffectPoison>();
		for (int i =0; i<= seps.GetUpperBound(0);i++)
		{
			seps[i].CancelEffect();
		}
		playerUW.Poisoned=false;
		Debug.Log ("An Nox Cast");
	}
	
	void Cast_InLor(GameObject caster)
	{//Light
		int SpellEffectSlot = CheckActiveSpellEffect(caster);

		if (SpellEffectSlot != -1)
		{
			Cast_Light (caster, caster.GetComponent<UWCharacter>().ActiveSpell, SpellEffect.UW1_Spell_Effect_Light,SpellEffectSlot, 3, 5);//TODO:Standardise light levels.
		}
		else
		{
			//Debug.Log ("Your incantation failed");
			caster.GetComponent<UWCharacter>().GetMessageLog().text = caster.GetComponent<UWCharacter>().StringControl.GetString(1,212);
		}
	}
	
	void Cast_VasInLor(GameObject caster)
	{//Daylight
		int SpellEffectSlot = CheckActiveSpellEffect(caster);
		if (SpellEffectSlot != -1)
		{
			Cast_Light (caster, caster.GetComponent<UWCharacter>().ActiveSpell, SpellEffect.UW1_Spell_Effect_Daylight, SpellEffectSlot, 8, 10);//TODO:Standardise light levels.
			//SetSpellEffect(caster,SpellEffectSlot,20);
		}
		else
		{
			//Debug.Log ("Your incantation failed");
			caster.GetComponent<UWCharacter>().GetMessageLog().text = caster.GetComponent<UWCharacter>().StringControl.GetString(1,212);
		}
	}
	
	
	
	void Cast_InManiYlem(GameObject caster)
	{//Create food
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		//Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit(); 
		float dropRange=1.2f;
		if (!Physics.Raycast(ray,out hit,dropRange))
		{//No object interferes with the spellcast
			int ObjectNo = 176 + Random.Range(0,7);
			GameObject myObj=  new GameObject("SummonedObject_" + SummonCount++);
			myObj.transform.position = ray.GetPoint(dropRange);
			CreateObjectGraphics(myObj,"Sprites/OBJECTS_182",true);
			CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_" +ObjectNo, "Sprites/OBJECTS_"+ObjectNo, "Sprites/OBJECTS_"+ObjectNo, ObjectInteraction.FOOD, ObjectNo, 0, 40, 0, 1, 0, 1);
			Food fd = myObj.AddComponent<Food>();
			fd.Nutrition=5;//TODO:determine values to use here.
			WindowDetect.UnFreezeMovement(myObj);
		}
	}
	
	void Cast_InBetMani(GameObject caster)
	{//Lesser Heal;
		Heal (caster, Random.Range (1,10));
	}
	
	void Cast_InMani(GameObject caster)
	{//Heal;
		Heal (caster, Random.Range (10,20));
	}
	
	void Cast_VasInMani(GameObject caster)
	{//Greater Heal;
		Heal (caster, Random.Range (20,60));
	}
	
	void Cast_VasKalCorp(GameObject caster)
	{//Armageddon//Destroys almost everything!
		GameObject[] allGameObj =GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		for (int i=0; i<= allGameObj.GetUpperBound(0);i++)
		{
			if ((allGameObj[i].name!="fbx_output") 
			    && (allGameObj[i].name!="UW_HUD") 
			    && (allGameObj[i].name!="HudAnimations") 
			    && (allGameObj[i].name!="Automap") 
			    && (allGameObj[i].name!="AI_Base_Animator") 
			    && (allGameObj[i]!=caster)
			    
			    )
			{
				if (allGameObj[i].transform.parent==null)
				{//Only deactivate top level items
					allGameObj[i].SetActive(false);				
				}
				//Debug.Log ("Destroying " + allGameObj[i].name) ;
				
			}
			
		}
		
	}



	void Cast_UusPor(GameObject caster)
	{//Leap/junp
		int SpellEffectSlot = CheckActiveSpellEffect(caster);
		
		if (SpellEffectSlot != -1)
		{
			Cast_Leap (caster, caster.GetComponent<UWCharacter>().ActiveSpell, SpellEffect.UW1_Spell_Effect_Leap,SpellEffectSlot,5);
		}
		else
		{
			caster.GetComponent<UWCharacter>().GetMessageLog().text = caster.GetComponent<UWCharacter>().StringControl.GetString(1,212);
//			Debug.Log ("Your incantation failed");
		}
	}


	
	/*Common spell effects that are used multiple times*/
	
	void Heal(GameObject caster,int HP)
	{
		UWCharacter playerUW=caster.GetComponent<UWCharacter>();
		if (playerUW!=null)
		{
			playerUW.CurVIT=playerUW.CurVIT+HP;
			if (playerUW.CurVIT > playerUW.MaxVIT)
			{
				playerUW.CurVIT=playerUW.MaxVIT;
			}
		}
	}
	
	
	
	void Cast_Light(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectId, int EffectSlot, int counter, int LightLevel)
	{
		LightSource.MagicBrightness=LightLevel;
		SpellEffect sel= (SpellEffectLight)SetSpellEffect(caster, ActiveSpellArray, EffectSlot, EffectId);
		sel.Value = LightLevel;
		sel.counter= counter;
		//sel.ApplyEffect();//Apply the effect.
		sel.Go ();// Apply the effect and Start the timer.
		//StartCoroutine(sel.timer());
	}

	void Cast_Leap(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectId, int EffectSlot, int counter)
	{
		SpellEffect lep = (SpellEffectLeap)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectId);
		lep.counter=counter;
		lep.Go ();
	}
	
	void Cast_OrtPorYlem(GameObject Caster)
	{
		UWCharacter playerUW = Caster.GetComponent<UWCharacter>();
		if (playerUW!=null)
		{
			playerUW.useRange=20;
			playerUW.pickupRange=20;
		}
	}
	
	/* Utility code for Spells*/
	
	SpellEffect SetSpellEffect(GameObject caster, SpellEffect[] ActiveSpellArray, int index, int EffectId)
	{
		//Adds an effect to the player from a spell.

		//UWCharacter playerUW= caster.GetComponent<UWCharacter>();
		
		switch (EffectId)
		{
		case SpellEffect.UW1_Spell_Effect_Darkness:
		case SpellEffect.UW1_Spell_Effect_BurningMatch:
		case SpellEffect.UW1_Spell_Effect_Candlelight:
		case SpellEffect.UW1_Spell_Effect_Light:
		case SpellEffect.UW1_Spell_Effect_MagicLantern:
		case SpellEffect.UW1_Spell_Effect_Daylight:
		case SpellEffect.UW1_Spell_Effect_Sunlight:
		case SpellEffect.UW1_Spell_Effect_Light_alt01:
		case SpellEffect.UW1_Spell_Effect_Daylight_alt01:
		case SpellEffect.UW1_Spell_Effect_Light_alt02:
		case SpellEffect.UW1_Spell_Effect_Daylight_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectLight>();
			break;

		case SpellEffect.UW1_Spell_Effect_Leap:
		case SpellEffect.UW1_Spell_Effect_Leap_alt01:
		case SpellEffect.UW1_Spell_Effect_Leap_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectLeap>();
			//To implement
			break;
		case SpellEffect.UW1_Spell_Effect_SlowFall:
		case SpellEffect.UW1_Spell_Effect_SlowFall_alt01:
		case SpellEffect.UW1_Spell_Effect_SlowFall_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectSlowFall>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Levitate:
		case SpellEffect.UW1_Spell_Effect_Levitate_alt01:
		case SpellEffect.UW1_Spell_Effect_Levitate_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectLevitate>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_WaterWalk:
		case SpellEffect.UW1_Spell_Effect_WaterWalk_alt01:
		case SpellEffect.UW1_Spell_Effect_WaterWalk_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectWaterWalk>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Fly:
		case SpellEffect.UW1_Spell_Effect_Fly_alt01:
		case SpellEffect.UW1_Spell_Effect_Fly_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectFly>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_ResistBlows:
		case SpellEffect.UW1_Spell_Effect_ThickSkin:
		case SpellEffect.UW1_Spell_Effect_IronFlesh:
		case SpellEffect.UW1_Spell_Effect_ResistBlows_alt01:
		case SpellEffect.UW1_Spell_Effect_ThickSkin_alt01:
		case SpellEffect.UW1_Spell_Effect_IronFlesh_alt01:
		case SpellEffect.UW1_Spell_Effect_ResistBlows_alt02:
		case SpellEffect.UW1_Spell_Effect_ThickSkin_alt02:
		case SpellEffect.UW1_Spell_Effect_IronFlesh_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectResistance>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Stealth:
		case SpellEffect.UW1_Spell_Effect_Conceal:
		case SpellEffect.UW1_Spell_Effect_Stealth_alt01:
		case SpellEffect.UW1_Spell_Effect_Conceal_alt01:
		case SpellEffect.UW1_Spell_Effect_Stealth_alt02:
		case SpellEffect.UW1_Spell_Effect_Conceal_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectStealth>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Invisibilty:
		case SpellEffect.UW1_Spell_Effect_Invisibility_alt01:
		case SpellEffect.UW1_Spell_Effect_Invisibility_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectInvisibility>();
			//Todo
			break;
			//Missiles
		case SpellEffect.UW1_Spell_Effect_MissileProtection:
		case SpellEffect.UW1_Spell_Effect_MissileProtection_alt01:
		case SpellEffect.UW1_Spell_Effect_MissileProtection_alt02:
			//Flames
		case SpellEffect.UW1_Spell_Effect_Flameproof:
		case SpellEffect.UW1_Spell_Effect_Flameproof_alt01:
		case SpellEffect.UW1_Spell_Effect_Flameproof_alt02:
			//Magic
		case SpellEffect.UW1_Spell_Effect_MagicProtection:
		case SpellEffect.UW1_Spell_Effect_GreaterMagicProtection:

			ActiveSpellArray[index]=caster.AddComponent<SpellEffectResistanceAgainstType>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_PoisonResistance:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectImmunityPoison>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Speed:
		case SpellEffect.UW1_Spell_Effect_Haste:

			ActiveSpellArray[index]=caster.AddComponent<SpellEffectSpeed>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Telekinesis:
		case SpellEffect.UW1_Spell_Effect_Telekinesis_alt01:
		case SpellEffect.UW1_Spell_Effect_Telekinesis_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectTelekinesis>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_FreezeTime:
		case SpellEffect.UW1_Spell_Effect_FreezeTime_alt01:
		case SpellEffect.UW1_Spell_Effect_FreezeTime_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectFreezeTime>();
			break;
		case SpellEffect.UW1_Spell_Effect_Regeneration:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectRegenerationHealth>();
			break;
		case SpellEffect.UW1_Spell_Effect_ManaRegeneration:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectRegenerationMana>();
			break;
		case SpellEffect.UW1_Spell_Effect_MazeNavigation:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectMazeNavigation>();
			break;			
		case SpellEffect.UW1_Spell_Effect_Hallucination:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectHallucination>();
			break;
		case SpellEffect.UW1_Spell_Effect_NightVision:
		case SpellEffect.UW1_Spell_Effect_NightVision_alt01:
		case SpellEffect.UW1_Spell_Effect_NightVision_alt02:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectNightVision>();
			break;
		case SpellEffect.UW1_Spell_Effect_Poison:
		case SpellEffect.UW1_Spell_Effect_Poison_alt01:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectPoison>();
			break;
		case SpellEffect.UW1_Spell_Effect_Paralyze:
		case SpellEffect.UW1_Spell_Effect_Paralyze_alt01:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectParalyze>();
			break;
		case SpellEffect.UW1_Spell_Effect_Ally:
		case SpellEffect.UW1_Spell_Effect_Ally_alt01:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectAlly>();
			break;
		case SpellEffect.UW1_Spell_Effect_Confusion:
		case SpellEffect.UW1_Spell_Effect_Confusion_alt01:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectConfusion>();
			break;
		case SpellEffect.UW1_Spell_Effect_MinorAccuracy:
		case SpellEffect.UW1_Spell_Effect_Accuracy:
		case SpellEffect.UW1_Spell_Effect_AdditionalAccuracy:
		case SpellEffect.UW1_Spell_Effect_MajorAccuracy:
		case SpellEffect.UW1_Spell_Effect_GreatAccuracy:
		case SpellEffect.UW1_Spell_Effect_VeryGreatAccuracy:
		case SpellEffect.UW1_Spell_Effect_TremendousAccuracy:
		case SpellEffect.UW1_Spell_Effect_UnsurpassedAccuracy:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectAccuracy>();
			break;
		case SpellEffect.UW1_Spell_Effect_MinorDamage:
		case SpellEffect.UW1_Spell_Effect_Damage:
		case SpellEffect.UW1_Spell_Effect_AdditionalDamage:
		case SpellEffect.UW1_Spell_Effect_MajorDamage:
		case SpellEffect.UW1_Spell_Effect_GreatDamage:
		case SpellEffect.UW1_Spell_Effect_VeryGreatDamage:
		case SpellEffect.UW1_Spell_Effect_TremendousDamage:
		case SpellEffect.UW1_Spell_Effect_UnsurpassedDamage:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectDamage>();
			break;
		case SpellEffect.UW1_Spell_Effect_MinorProtection:
		case SpellEffect.UW1_Spell_Effect_Protection:
		case SpellEffect.UW1_Spell_Effect_AdditionalProtection:
		case SpellEffect.UW1_Spell_Effect_MajorProtection:
		case SpellEffect.UW1_Spell_Effect_GreatProtection:
		case SpellEffect.UW1_Spell_Effect_VeryGreatProtection:
		case SpellEffect.UW1_Spell_Effect_TremendousProtection:
		case SpellEffect.UW1_Spell_Effect_UnsurpassedProtection:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectProtection>();
			break;
		case SpellEffect.UW1_Spell_Effect_MinorToughness:
		case SpellEffect.UW1_Spell_Effect_Toughness:
		case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
		case SpellEffect.UW1_Spell_Effect_MajorToughness:
		case SpellEffect.UW1_Spell_Effect_GreatToughness:
		case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
		case SpellEffect.UW1_Spell_Effect_TremendousToughness:
		case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
			ActiveSpellArray[index]=caster.AddComponent<SpellEffectToughness>();
			break;
			
		default:
			Debug.Log ("effect Id is " + EffectId);
			ActiveSpellArray[index]=caster.AddComponent<SpellEffect>();
			break;

		}

		ActiveSpellArray[index].EffectId=EffectId;
		return ActiveSpellArray[index];
	}
	
	int CheckActiveSpellEffect(GameObject caster)
	{//Finds the first free spell effect slot for the caster. If unable to find it returns -1
		UWCharacter playerUW= caster.GetComponent<UWCharacter>();
		if (playerUW!=null)
		{
			for (int i =0;i<3;i++)
			{
				if (playerUW.ActiveSpell[i] == null)
				{
					return i;
				}
			}
			return -1;
		}
		else
		{
			return -1;
		}
	}
	
	GameObject CreateMagicProjectile(string ProjectileImage, string HitImage, Vector3 Location, int Damage)
	{
		GameObject projectile = new GameObject();
		CreateObjectGraphics(projectile,ProjectileImage,true);
		MagicProjectile mgp = projectile.AddComponent<MagicProjectile>();
		mgp.damage=Damage;
		BoxCollider box = projectile.AddComponent<BoxCollider>();
		box.size = new Vector3(0.2f,0.2f,0.2f);
		box.center= new Vector3(0.0f,0.1f,0.0f);
		//box.isTrigger=true;
		Rigidbody rgd =projectile.AddComponent<Rigidbody>();
		rgd.freezeRotation =true;
		rgd.useGravity=false;
		projectile.transform.position=Location;
		
		return projectile;
	}
	
	void LaunchProjectile(GameObject projectile, Ray ray,float dropRange, float force)
	{
		Vector3 ThrowDir = ray.GetPoint(dropRange)  - (projectile.transform.position);
		projectile.GetComponent<Rigidbody>().AddForce(ThrowDir*force);
	}
	
	
	private void CreateObjectGraphics(GameObject myObj,string AssetPath, bool BillBoard)
	{	
		//Create a sprite.
		GameObject SpriteController = new GameObject(myObj.name + "_sprite");
		SpriteController.transform.position = myObj.transform.position;
		
		SpriteRenderer mysprite = SpriteController.AddComponent<SpriteRenderer>();//Adds the sprite gameobject
		//mysprite.transform.position = new Vector3 (0f, 0f, 0f);
		//Sprite image = Resources.LoadAssetAtPath <Sprite> (AssetPath);//Loads the sprite.
		Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
		mysprite.sprite = image;//Assigns the sprite to the object.
		SpriteController.transform.parent = myObj.transform;
		//SpriteController.transform.localScale = new Vector3(30.0f, 30.0f, 30.0f);
		//Create a billboard script for display
		// Billboard ScriptController = 
		if (BillBoard)
		{
			SpriteController.AddComponent<Billboard> ();
		}
		
	}
	
	void CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isAnimated, int useSprite,string ChildName)
	{
		GameObject newObj = new GameObject(myObj.name+"_"+ChildName);
		
		newObj.transform.parent=myObj.transform;
		newObj.transform.localPosition=new Vector3(0.0f,0.0f,0.0f);
		CreateObjectInteraction (newObj,DimX,DimY,DimZ,CenterY , WorldString,InventoryString,EquipString,ItemType ,link, Quality, Owner,ItemId,isMoveable, isAnimated, useSprite);
	}
	
	void CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isAnimated, int useSprite)
	{
		CreateObjectInteraction (myObj,myObj,DimX,DimY,DimZ,CenterY, WorldString,InventoryString,EquipString,ItemType,ItemId,link,Quality,Owner,isMoveable, isAnimated, useSprite);
	}
	
	void CreateObjectInteraction(GameObject myObj, GameObject parentObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isAnimated, int useSprite)
	{
		//Debug.Log (myObj.name);
		//Add a script.
		ObjectInteraction objInteract = myObj.AddComponent<ObjectInteraction>();
		
		BoxCollider box =myObj.GetComponent<BoxCollider>();
		if (box==null)
		{
			//add a mesh for interaction
			box= myObj.AddComponent<BoxCollider>();
			box.size = new Vector3(0.2f,0.2f,0.2f);
			box.center= new Vector3(0.0f,0.1f,0.0f);
		}
		
		objInteract.WorldDisplayIndex = int.Parse(WorldString.Substring (WorldString.Length-3,3));
		objInteract.InvDisplayIndex= int.Parse (InventoryString.Substring (InventoryString.Length-3,3));
		
		
		//SpriteRenderer objSprite =  myObj.transform.FindChild(myObj.name + "_sprite").GetComponent<SpriteRenderer>();
		//		SpriteRenderer objSprite =  parentObj.GetComponentInChildren<SpriteRenderer>();
		objInteract.WorldString=WorldString;
		objInteract.InventoryString=InventoryString;
		objInteract.EquipString=EquipString;
		objInteract.ItemType=ItemType;//UWexporter id type
		objInteract.item_id=ItemId;//Internal ItemID
		objInteract.Link=link;
		objInteract.Quality=Quality;
		objInteract.Owner=Owner;
		if (isMoveable==1)
		{
			objInteract.CanBePickedUp=true;
			parentObj.AddComponent<Rigidbody>();
			WindowDetect.FreezeMovement(myObj);
		}
		
		if (isAnimated==1)
		{
			objInteract.isAnimated=true;
		}
		
		if (useSprite==1)
		{
			objInteract.ignoreSprite=false;
		}
		else
		{
			objInteract.ignoreSprite=true;
		}
		
	}
	
	void OnGUI()
	{
		if (Event.current.Equals(Event.KeyboardEvent("q")))
		{//Cast a spell or readies it.
			if (ReadiedSpell=="")
			{
				castSpell(this.gameObject,ActiveRunes[0],ActiveRunes[1],ActiveRunes[2],true);
			}
		}
	}
	
	Ray getRay(GameObject caster)
	{
		Ray ray ;
		if (caster.GetComponent<UWCharacter>().MouseLookEnabled==true)
		{
			ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		}
		else
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		}
		return ray;
	}
}

