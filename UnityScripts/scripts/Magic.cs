fusing UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {
	
	//Magic spell to be cast on next click in window
	public string ReadiedSpell;
	//Runes that the character has picked up and is currently using
	public bool[] PlayerRunes=new bool[24];
	public int[] ActiveRunes=new int[3];
	
	
	public int MaxMana;
	public int CurMana;
	public int SpellCost;
	
	string[] Runes=new string[]{"An","Bet","Corp","Des",
		"Ex","Flam","Grav","Hur",
		"In","Jux","Kal","Lor",
		"Mani","Nox","Ort","Por",
		"Quas","Rel","Sanct","Tym",
		"Uus","Vas","Wis","Ylem"};
	
	long SummonCount=0;

	public void SetSpellCost(int SpellCircle)
	{
		SpellCost= SpellCircle*3;
	}

	public void ApplySpellCost()
	{
		CurMana=CurMana-SpellCost;
		SpellCost=0;
	}

	public bool TestSpellCast(UWCharacter casterUW,  int Rune1, int Rune2, int Rune3)
	{//Checks if the player can cast the spell.
		int TestSpellLevel=0;
		string MagicWords=TranslateSpellRune(Rune1,Rune2,Rune3);
		switch (MagicWords)
		{
			//1st Circle
		case "In Mani Ylem"://Create Food
		case "In Lor":	//Light
		case "Bet Wis Ex"://Locate
		case "Ort Jux"://Magic Arrow
		case "Bet In Sanct"://Resist Blows
		case "Sanct Hur"://Stealth
			TestSpellLevel=1;
			break;

			//2nd Circle
		case "Quas Corp"://Cause Fear
		case "Wis Mani"://Detect Monster
		case "Uus Por"://Jump
		case "In Bet Mani"://Lesser Heal
		case "Rel Des Por"://Slow Fall
		case "In Sanct"://Thick Skin
		case "In Jux"://Rune of Warding
			TestSpellLevel=2;
			break;

			//3rd Circle
		case "Bet Sanct Lor"://Conceal
		case "Ort Grav"://Lightning
		case "Quas Lor"://Night Vision
		case "An Kal Corp"://Repel Undead
		case "Rel Tym Por"://Speed
		case "Ylem Por"://Water Walk
		case "Sanct Jux"://Strengten Door
			TestSpellLevel=3;
			break;

			//4th Circle
		case "An Sanct"://Curse
		case "Sanct Flam":// Flameproof
		case "In Mani"://Heal
		case "Hur Por"://Levitate
		case "Nox Ylem"://Poison
		case "An Jux"://Remove Trap
			TestSpellLevel=4;
			break;
			
			//5th Circle
		case "Por Flam"://Fireball
		case "Grav Sanct Por"://Missile Protection
		case "Ort Wis Ylem"://Name Enchantment
		case "Ex Ylem"://Open
		case "An Nox"://Cure Poison
		case "An Corp Mani"://Smite Undead
			TestSpellLevel=5;
			break;

			//6th Circle
		case "Vas In Lor"://Daylight
		case "Vas Rel Por"://Gate Travel
		case "Vas In Mani"://Greater Heal
		case "An Ex Por"://Paralyze
		case "Vas Ort Grav"://Sheet Lightning
		case "Ort Por Ylem"://Telekinesis
			TestSpellLevel=6;
			break;
			
			//7th Circle
		case "In Mani Rel"://Ally
		case "Vas An Wis"://Confusion
		case "Vas Sanct Lor"://Invisibility
		case "Vas Hur Por"://Fly
		case "Kal Mani"://Monster Summoning
		case "Ort An Quas"://Reveal
			TestSpellLevel=7;
			break;

			//8th Circle
		case "Vas Kal Corp"://Armageddon
		case "Flam Hur"://Flame Wind
		case "An Tym":// Freeze Time
		case "In Vas Sanct"://Iron Flesh
		case "Ort Por Wis"://Roaming sight
		case "Vas Por Ylem"://Tremor
			TestSpellLevel=8;
			break;
		default:
			{
			casterUW.GetMessageLog ().text= "Not a spell.";
			return false;
			}
		}//magicwords

		if (Mathf.Round(casterUW.CharLevel/2)<TestSpellLevel)
		{//Not experienced enough
			casterUW.GetMessageLog ().text =casterUW.GetMessageLog ().text=casterUW.StringControl.GetString (1,210);
			return false;
		}
		else if (CurMana< TestSpellLevel*3)
		{//Mana test
			casterUW.GetMessageLog ().text =casterUW.GetMessageLog ().text=casterUW.StringControl.GetString (1,211);
			return false;
		}
		else if( ! casterUW.PlayerSkills.TrySkill(Skills.SkillCasting, TestSpellLevel))
		{//Skill test. Random chance to backfire
			if (Random.Range(1,10)<8)
			{//TODO:decide on the chances
				//000~001~213~Casting was not successful.
				casterUW.GetMessageLog ().text =casterUW.GetMessageLog ().text=casterUW.StringControl.GetString (1,213);
			}
			else
			{//000~001~214~The spell backfires.
				casterUW.GetMessageLog ().text =casterUW.GetMessageLog ().text=casterUW.StringControl.GetString (1,214);
				casterUW.CurVIT = casterUW.CurVIT-3;
			}
			return false;
		}
		else
		{//Casting sucessful. 
			casterUW.GetMessageLog ().text ="Casting " + MagicWords;
			return true;
		}
	}

	
	public void TestSpell(GameObject caster)
	{//Test spell for testing spell effects
		SpellEffectPoison sep = caster.AddComponent<SpellEffectPoison>();
		sep.Value=100;//Poison will damage the player for 100 hp over it's duration
		sep.counter=10; //It will run for 10 ticks. Ie 10 hp damage per tick
	//	sep.isNPC=true;
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
			SetSpellCost(1);
			//Debug.Log(MagicWords+ " Create Food Cast");
			Cast_InManiYlem(caster);
			break;
		}//imy
		case "In Lor":	//Light
		{
			SetSpellCost(1);
			//Debug.Log(MagicWords+ " Light Cast");
			Cast_InLor(caster);
			break;
		}	//il
		case "Bet Wis Ex"://Locate
		{//UW2 spell?
			SetSpellCost(1);
			Debug.Log(MagicWords+ " Locate Cast");
			break;
		}//bwe
		case "Ort Jux"://Magic Arrow
		{
			SetSpellCost(1);
			//Debug.Log(MagicWords+ " Magic Arrow Cast Readied=" + ready);
			Cast_OrtJux(caster, ready);
			break;
		}//OJ
		case "Bet In Sanct"://Resist Blows
		{
			SetSpellCost(1);
			Debug.Log(MagicWords+ " Resist Blows Cast");
			break;
		}//BIS
		case "Sanct Hur"://Stealth
		{
			SetSpellCost(1);
			Debug.Log(MagicWords+ " Stealth Cast");
			break;
		}//sh
			
			//2nd Circle
		case "Quas Corp"://Cause Fear
		{
			SetSpellCost(2);
			Debug.Log(MagicWords+ " Cause Fear Cast");
			break;
		}//qc
		case "Wis Mani"://Detect Monster
		{
			SetSpellCost(2);
			Debug.Log(MagicWords+ " Detect Monster Cast");
			break;
		}//wm
		case "Uus Por"://Jump
		{
			SetSpellCost(2);
			Cast_UusPor(caster);
			//Debug.Log(MagicWords+ " Jump Cast");
			break;
		}//up
		case "In Bet Mani"://Lesser Heal
		{
			SetSpellCost(2);
			//Debug.Log(MagicWords+ " Lesser Heal Cast");
			Cast_InBetMani(caster);
			break;
		}//IBM
		case "Rel Des Por"://Slow Fall
		{
			SetSpellCost(2);
			//Debug.Log(MagicWords+ " Slow Fall Cast");
			cast_RelDesPor(caster);
			break;
		}//RDP
		case "In Sanct"://Thick Skin
		{
			SetSpellCost(2);
			Debug.Log(MagicWords+ " Thick Skin Cast");
			break;
		}//IS
		case "In Jux"://Rune of Warding
		{
			SetSpellCost(2);
			Debug.Log(MagicWords+ " Rune of Warding Cast");
			break;
		}//IJ
			
			//3rd Circle
		case "Bet Sanct Lor"://Conceal
		{
			SetSpellCost(3);
			Debug.Log(MagicWords+ " Conceal Cast");
			break;
		}//BSL
		case "Ort Grav"://Lightning
		{
			SetSpellCost(3);
			//Debug.Log(MagicWords+ " Lightning Cast");
			Cast_OrtGrav(caster, ready);
			break;
		}//OG
		case "Quas Lor"://Night Vision
		{
			SetSpellCost(3);
			Debug.Log(MagicWords+ " Night Vision Cast");
			break;
		}//QL
		case "An Kal Corp"://Repel Undead
		{
			SetSpellCost(3);
			Debug.Log(MagicWords+ " Repel Undead Cast");
			break;
		}//akc
		case "Rel Tym Por"://Speed
		{
			SetSpellCost(3);
			Debug.Log(MagicWords+ " Speed Cast");
			break;
		}//rtp
		case "Ylem Por"://Water Walk
		{
			SetSpellCost(3);
			Debug.Log(MagicWords+ " Water Walk Cast");
			break;
		}//YP
		case "Sanct Jux"://Strengten Door
		{
			SetSpellCost(3);
			Debug.Log(MagicWords+ " Strengten Door Cast");
			break;
		}//SJ
			
			//4th Circle
		case "An Sanct"://Curse
		{
			SetSpellCost(4);
			Debug.Log(MagicWords+ " Curse Cast");
			break;
		}//AS
		case "Sanct Flam":// Flameproof
		{
			SetSpellCost(4);
			Debug.Log(MagicWords+ " Flameproof Cast");
			break;
		}//SF
		case "In Mani"://Heal
		{
			SetSpellCost(4);
			//Debug.Log(MagicWords+ " Heal Cast");
			Cast_InMani (caster);
			break;
		}//IM
		case "Hur Por"://Levitate
		{	
			SetSpellCost(4);
			Debug.Log(MagicWords+ " Cast");
			break;
		}//HP
		case "Nox Ylem"://Poison
		{
			SetSpellCost(4);
			//Debug.Log(MagicWords+ " Poison Cast");
			Cast_NoxYlem(caster);
			break;
		}//NY
		case "An Jux"://Remove Trap
		{
			SetSpellCost(4);
			Debug.Log(MagicWords+ " Remove Trap Cast");
			break;
		}//AJ
			
			//5th Circle
		case "Por Flam"://Fireball
		{
			SetSpellCost(5);
			Debug.Log(MagicWords+ " Fireball Cast");
			break;
		}//PF
		case "Grav Sanct Por"://Missile Protection
		{
			SetSpellCost(5);
			Debug.Log(MagicWords+ " Missile Protection Cast");
			break;
		}//GSP
		case "Ort Wis Ylem"://Name Enchantment
		{
			SetSpellCost(5);
			Debug.Log(MagicWords+ " Name Enchantment Cast");
			break;
		}//OWY
		case "Ex Ylem"://Open
		{
			SetSpellCost(5);
			Cast_ExYlem(caster, ready);
			//Debug.Log(MagicWords+ " Open Cast");
			break;
		}//EY
		case "An Nox"://Cure Poison
		{
			SetSpellCost(5);
			Cast_AnNox(caster);
			//Debug.Log(MagicWords+ " Cure Poison Cast");
			break;
		}//AN
		case "An Corp Mani"://Smite Undead
		{
			SetSpellCost(5);
			Debug.Log(MagicWords+ " Smite Undead Cast");
			break;
		}//ACM
			
			//6th Circle
		case "Vas In Lor"://Daylight
		{
			SetSpellCost(6);
			Debug.Log(MagicWords+ " Daylight Cast");
			Cast_VasInLor(caster);
			break;
		}//VIL
		case "Vas Rel Por"://Gate Travel
		{
			SetSpellCost(6);
			Cast_VasRelPor(caster);
			break;
		}//VRP
		case "Vas In Mani"://Greater Heal
		{
			SetSpellCost(6);
			//Debug.Log(MagicWords+ " Greater Heal Cast");
			Cast_VasInMani (caster);
			break;
		}//VIM
		case "An Ex Por"://Paralyze
		{
			SetSpellCost(6);
			Debug.Log(MagicWords+ " Paralyze Cast");
			break;
		}//AEP
		case "Vas Ort Grav"://Sheet Lightning
		{
			SetSpellCost(6);
			Debug.Log(MagicWords+ " Sheet Lightning Cast");
			break;
		}//VOG
		case "Ort Por Ylem"://Telekinesis
		{
			SetSpellCost(6);
			Debug.Log(MagicWords+ " Telekinesis Cast");
			Cast_OrtPorYlem(caster);
			break;
		}//OPY
			
			//7th Circle
		case "In Mani Rel"://Ally
		{
			SetSpellCost(7);
			Debug.Log(MagicWords+ " Ally Cast");
			break;
		}//IMR
		case "Vas An Wis"://Confusion
		{
			SetSpellCost(7);
			Debug.Log(MagicWords+ " Confusion Cast");
			break;
		}//VAW
		case "Vas Sanct Lor"://Invisibility
		{
			SetSpellCost(7);
			Debug.Log(MagicWords+ " Invisibility Cast");
			break;
		}//VSL
		case "Vas Hur Por"://Fly
		{
			SetSpellCost(7);
			Debug.Log(MagicWords+ " Fly Cast");
			break;
		}//VHP
		case "Kal Mani"://Monster Summoning
		{
			SetSpellCost(7);
			Debug.Log(MagicWords+ " Monster Summoning Cast");
			break;
		}//KM
		case "Ort An Quas"://Reveal
		{
			SetSpellCost(7);
			Debug.Log(MagicWords+ " Reveal Cast");
			break;
		}//OAQ
			//8th Circle
		case "Vas Kal Corp"://Armageddon
		{
			SetSpellCost(8);
			Debug.Log(MagicWords+ " Armageddon Cast");
			Cast_VasKalCorp(caster);
			break;
		}//vkc
		case "Flam Hur"://Flame Wind
		{
			SetSpellCost(8);
			Debug.Log(MagicWords+ " Flame Wind Cast");
			break;
		}//fh
		case "An Tym":// Freeze Time
		{
			SetSpellCost(8);
			Debug.Log(MagicWords+ " Freeze Time Cast");
			break;
		}//at
		case "In Vas Sanct"://Iron Flesh
		{
			SetSpellCost(8);
			Debug.Log(MagicWords+ " Iron Flesh Cast");
			break;
		}//ivs
		case "Ort Por Wis"://Roaming sight
		{
			SetSpellCost(8);
			Debug.Log(MagicWords+ " Roaming sight Cast");
			break;
		}//opw
		case "Vas Por Ylem"://Tremor
		{
			SetSpellCost(8);
			Debug.Log(MagicWords+ " Tremor Cast");
			break;
		}//vpy
		default:
		{

			//Debug.Log("Unknown spell:" + MagicWords);
			break;
		}
		}//magicwords
	}
	
	public string TranslateSpellRune( int Rune1, int Rune2, int Rune3)
	{ //returns the string meaning of the runes,

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

		return MagicWords;
	}


	public void castSpell(GameObject caster, int Rune1, int Rune2, int Rune3, bool ready)
	{
		//Casts a magic spell based on the constructed magic rune string
		
		string MagicWords="";
		//Construct the spell words based on selected runes
	/*	if ((Rune1>=0) && (Rune1<=23))
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
		}*/
		MagicWords=TranslateSpellRune(Rune1,Rune2, Rune3);
		
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
			CastProjectile(caster,"Sprites/objects_023");
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
			CastProjectile(caster,"Sprites/objects_021");
		}
	}
	

	void Cast_ExYlem(GameObject caster, bool Ready)
	{//Open
		UWCharacter playerUW = caster.GetComponent<UWCharacter>();
		if (Ready==true)
		{//Ready the spell to be cast.
			//Debug.Log ("ExYlem is ready to cast");
			playerUW.PlayerMagic.ReadiedSpell= "Ex Ylem";
			playerUW.CursorIcon=Resources.Load<Texture2D>("Hud/Cursors/Cursors_0010");
		}
		else
		{
			playerUW.PlayerMagic.ReadiedSpell="";
			playerUW.CursorIcon=playerUW.CursorIconDefault;
			Ray ray = getRay (caster);
			RaycastHit hit = new RaycastHit(); 
			float dropRange=playerUW.GetUseRange();
			if (Physics.Raycast(ray,out hit,dropRange))
			{//The spell has hit something
				DoorControl dc =hit.transform.gameObject.GetComponent<DoorControl>();
				if (dc!=null)
				{
					dc.UnlockDoor();
					//Debug.Log ("Ex Ylem has been cast");
				}
				else if (hit.transform.GetComponent<PortcullisInteraction>()!=null)
				{
					hit.transform.GetComponent<PortcullisInteraction>().getParentObjectInteraction().gameObject.GetComponent<DoorControl>().UnlockDoor();
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
		//Debug.Log ("An Nox Cast");
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
			SpellIncantationFailed(caster);
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
			SpellIncantationFailed(caster);
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
		Cast_Heal (caster, Random.Range (1,10));
	}
	
	void Cast_InMani(GameObject caster)
	{//Heal;
		Cast_Heal (caster, Random.Range (10,20));
	}
	
	void Cast_VasInMani(GameObject caster)
	{//Greater Heal;
		Cast_Heal (caster, Random.Range (20,60));
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
			SpellIncantationFailed(caster);
//			Debug.Log ("Your incantation failed");
		}
	}


	void cast_RelDesPor(GameObject caster)
	{//SLowfall
		int SpellEffectSlot = CheckActiveSpellEffect(caster);
		
		if (SpellEffectSlot != -1)
		{
			Cast_SlowFall (caster, caster.GetComponent<UWCharacter>().ActiveSpell, SpellEffect.UW1_Spell_Effect_SlowFall,SpellEffectSlot,3);
		}
		else
		{
			SpellIncantationFailed(caster);
		}
	}


	void Cast_NoxYlem(GameObject caster)
	{//poison other.
		RaycastHit hit= new RaycastHit();
		NPC npc = GetNPCTargetRandom(caster, ref hit);
		if (npc != null)
		{
			//Apply a impact effect to the npc
			GameObject hitimpact ; 
			//if (hit==null)
			//{
			//	hitimpact= new GameObject(hit.transform.name + "_impact");
			//	hitimpact.transform.position=hit.point;
			//}
			//else
			//{
				hitimpact= new GameObject(npc.transform.name + "_impact");
				hitimpact.transform.position= npc.transform.position;
			//}
			//= new GameObject(hit.transform.name + "_impact");
			hitimpact.transform.position=hit.point;
			Impact imp= hitimpact.AddComponent<Impact>();
			imp.FrameNo=40;
			imp.EndFrame=44;
			StartCoroutine(imp.Animate());	

			//NPC npc = hit.transform.gameObject.GetComponent<NPC>();
			int EffectSlot = CheckPassiveSpellEffectNPC(npc.gameObject);
		 	if (EffectSlot!=-1)
			{
				SpellEffect sep= (SpellEffectPoison)SetSpellEffect(npc.gameObject, npc.NPCStatusEffects, EffectSlot, SpellEffect.UW1_Spell_Effect_Poison);
				sep.Value=10;
				sep.counter=5;
				sep.isNPC=true;
				sep.Go ();
			}
		}
	}

	
	void Cast_OrtPorYlem(GameObject caster)
	{//Telekinesis
		int SpellEffectSlot = CheckActiveSpellEffect(caster);
		if (SpellEffectSlot != -1)
		{
			Cast_Telekinesis (caster, caster.GetComponent<UWCharacter>().ActiveSpell, SpellEffect.UW1_Spell_Effect_Telekinesis,SpellEffectSlot, 2);
		}
		else
		{
			SpellIncantationFailed(caster);
		}
	}


	void Cast_VasRelPor(GameObject caster)
	{
		UWCharacter playerUW=caster.GetComponent<UWCharacter>();
		if (playerUW!=null)
		{
			if (playerUW.MoonGateLevel != GameWorldController.instance.LevelNo)
			{//Teleport to level
				Debug.Log ("moonstone is on another level. (or I forgot to update levelno)");
			}
			else
			{
				if (playerUW.MoonGatePosition != Vector3.zero)
				{
					caster.transform.position = playerUW.MoonGatePosition;
				}
			}
		}
	}

	
	/*Common spell effects that are used multiple times*/
	
	void Cast_Heal(GameObject caster,int HP)
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

	void Cast_Mana(GameObject caster,int MP)
	{//Increase (or decrease) the casters mana
		UWCharacter playerUW=caster.GetComponent<UWCharacter>();
		if (playerUW!=null)
		{
			playerUW.PlayerMagic.CurMana=playerUW.PlayerMagic.CurMana+MP;
			if (playerUW.PlayerMagic.CurMana > playerUW.PlayerMagic.MaxMana)
			{
				playerUW.PlayerMagic.CurMana=playerUW.PlayerMagic.MaxMana;
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

	void Cast_SlowFall(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectId, int EffectSlot, int counter)
	{
		SpellEffect slf = (SpellEffectSlowFall)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectId);
		slf.counter=counter;
		slf.Go ();
	}


	public void Cast_Poison(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectId, int EffectSlot, int counter, int value)
	{//Poison
		SpellEffectPoison sep = (SpellEffectPoison)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectId);
			//caster.AddComponent<SpellEffectPoison>();
		sep.Value=value;//Poison will damage the player for 100 hp over it's duration
		sep.counter=counter; //It will run for x ticks. Ie 10 hp damage per tick
		//	sep.isNPC=true;
		sep.Go ();
	}

	public void Cast_Telekinesis(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectId, int EffectSlot, int counter)
	{//Levitate
		SpellEffectTelekinesis setk = (SpellEffectTelekinesis)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectId);
		setk.counter=counter; //It will run for x ticks. 
		setk.Go ();
	}


	public void Cast_Levitate(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectId, int EffectSlot, int counter)
	{//Levitate
		SpellEffectLevitate sep = (SpellEffectLevitate)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectId);
		//caster.AddComponent<SpellEffectPoison>();
		sep.counter=counter; //It will run for x ticks. Ie 10 hp damage per tick
		sep.Go ();
	}
	
	/* Utility code for Spells*/

	void SpellIncantationFailed(GameObject caster)
	{
		caster.GetComponent<UWCharacter>().GetMessageLog().text = caster.GetComponent<UWCharacter>().StringControl.GetString(1,212);
	}


	NPC GetNPCTargetRandom(GameObject caster, ref RaycastHit hit)
	{
		//Targets a random NPC in the area of the npc and returns a raycast hit on the line of site
		Camera cam = caster.GetComponentInChildren<Camera>();//Camera.main;
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
		//Collider[] objectsInArea = Physics.OverlapSphere(caster.transform.position,10.0f);
		foreach (Collider Col in Physics.OverlapSphere(caster.transform.position,5.0f))
		{
			if (Col.gameObject.GetComponent<NPC>()!=null)
			{
				//Check if the NPC is in front of the camera.
				if (GeometryUtility.TestPlanesAABB(planes, Col.bounds))
				{
					//CHeck line of sight to npc.
					//Debug.Log ("NPC found " + Col.gameObject.name);
					//RaycastHit hit = new RaycastHit(); 
					Vector3 campos= Camera.main.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
					Vector3 dirtonpc = campos-Col.gameObject.transform.position;

					if (Physics.Linecast(campos,Col.gameObject.transform.position,out hit))
					{
						if (hit.collider.gameObject.name==Col.gameObject.name)
						{
							return Col.gameObject.GetComponent<NPC>();//hit;//Col.gameObject.GetComponent<NPC>();
						}
					}
					else
					{//nothing in the line of site.
						return Col.gameObject.GetComponent<NPC>();
					}
				}
			}
		}

		return null;
	}



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
		case SpellEffect.UW1_Spell_Effect_PoisonHidden:
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

	int CheckPassiveSpellEffectPC(GameObject caster)
	{//Finds the first free passive spell effect slot for the caster. If unable to find it returns -1
		UWCharacter playerUW= caster.GetComponent<UWCharacter>();

		if (playerUW!=null)
		{
			for (int i =0;i<10;i++)
			{
				if (playerUW.PassiveSpell[i] == null)
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

	int CheckPassiveSpellEffectNPC(GameObject caster)
	{//Finds the first free spell effect slot for the caster. If unable to find it returns -1
		NPC npc= caster.GetComponent<NPC>();
		
		if (npc!=null)
		{
			for (int i =0;i<3;i++)
			{
				if (npc.NPCStatusEffects[i] == null)
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


	bool CastProjectile(GameObject caster, string SpriteName)
	{//Fires off the projectile
		UWCharacter playerUW = caster.GetComponent<UWCharacter>();
		Ray ray = getRay (caster);
		RaycastHit hit = new RaycastHit(); 
		float dropRange=0.5f;
		if (!Physics.Raycast(ray,out hit,dropRange))
		{//No object interferes with the spellcast
			float force = 200.0f;
			ReadiedSpell= "";
			GameObject projectile = CreateMagicProjectile(SpriteName,"",ray.GetPoint(dropRange/2.0f), 5);
			LaunchProjectile(projectile,ray,dropRange,force);
			playerUW.CursorIcon=playerUW.CursorIconDefault;
			return true;
		}
		return false;
	}	


	GameObject CreateMagicProjectile(string ProjectileImage, string HitImage, Vector3 Location, int Damage)
	{//Creates the projectile.
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
//		objInteract.WorldString=WorldString;
	//	objInteract.InventoryString=InventoryString;
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
				if (TestSpellCast(this.gameObject.GetComponent<UWCharacter>(),ActiveRunes[0],ActiveRunes[1],ActiveRunes[2]))
				{
					castSpell(this.gameObject,ActiveRunes[0],ActiveRunes[1],ActiveRunes[2],true);
					ApplySpellCost();
				}
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



	public bool CastEnchantment(GameObject caster, int EffectId)
	{//Eventually casts spells from things like fountains, potions, enchanted weapons.
		//UWCharacter playerUW= caster.GetComponent<UWCharacter>();
		//Returns true if the effect was applied. 
		//TODO: The switch statement may need to be further divided because of passive/active effects.
		//TODO: this list is incomplete. I need to include things from my spreadsheet that are not status effects.
		UWCharacter playerUW = caster.GetComponent<UWCharacter>();
		int ActiveArrayIndex=-1;
		int PassiveArrayIndex=-1;
		if (playerUW!=null)
		{
			ActiveArrayIndex= playerUW.PlayerMagic.CheckActiveSpellEffect(caster);
			PassiveArrayIndex= playerUW.PlayerMagic.CheckPassiveSpellEffectPC(caster);
		}

		switch (EffectId)
		{

		case SpellEffect.UW1_Spell_Effect_LesserHeal:
		case SpellEffect.UW1_Spell_Effect_LesserHeal_alt01:
		case SpellEffect.UW1_Spell_Effect_LesserHeal_alt02:
		case SpellEffect.UW1_Spell_Effect_LesserHeal_alt03:
		case SpellEffect.UW1_Spell_Effect_Heal:
		case SpellEffect.UW1_Spell_Effect_Heal_alt01:
		case SpellEffect.UW1_Spell_Effect_Heal_alt02:
		case SpellEffect.UW1_Spell_Effect_Heal_alt03:
		case SpellEffect.UW1_Spell_Effect_EnhancedHeal:
		case SpellEffect.UW1_Spell_Effect_EnhancedHeal_alt01:
		case SpellEffect.UW1_Spell_Effect_EnhancedHeal_alt02:
		case SpellEffect.UW1_Spell_Effect_EnhancedHeal_alt03:
		case SpellEffect.UW1_Spell_Effect_GreaterHeal:
		case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt01:
		case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt02:
		case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt03:
		case SpellEffect.UW1_Spell_Effect_LesserHeal_alt04:
		case SpellEffect.UW1_Spell_Effect_Heal_alt04:
		case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt04:
			Cast_Heal (caster,10);//Get seperate values;
			break;

		case SpellEffect.UW1_Spell_Effect_ManaBoost:
		case SpellEffect.UW1_Spell_Effect_ManaBoost_alt01:
		case SpellEffect.UW1_Spell_Effect_ManaBoost_alt02:
		case SpellEffect.UW1_Spell_Effect_ManaBoost_alt03:
		case SpellEffect.UW1_Spell_Effect_ManaBoost_alt04:
			Cast_Mana(caster,10);
			break;


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
			//These need to have different values. Create a system of unique values array(?)
			if (PassiveArrayIndex!=-1)
			{
				Cast_Light(caster,playerUW.PassiveSpell,EffectId,PassiveArrayIndex,5,10);
			}
			else
			{
				return false;
			}

			break;
			
		case SpellEffect.UW1_Spell_Effect_Leap:
		case SpellEffect.UW1_Spell_Effect_Leap_alt01:
		case SpellEffect.UW1_Spell_Effect_Leap_alt02:
			//TODO: Find out which one of these is a magic ring effect!
			Cast_Leap(caster,playerUW.ActiveSpell,EffectId,ActiveArrayIndex,5);
			//To implement
			break;
		case SpellEffect.UW1_Spell_Effect_SlowFall:
		case SpellEffect.UW1_Spell_Effect_SlowFall_alt01:
		case SpellEffect.UW1_Spell_Effect_SlowFall_alt02:
			//cast_RelDesPor(caster);
			Cast_SlowFall(caster,playerUW.ActiveSpell,EffectId,ActiveArrayIndex,5);
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectSlowFall>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Levitate:
		case SpellEffect.UW1_Spell_Effect_Levitate_alt01:
		case SpellEffect.UW1_Spell_Effect_Levitate_alt02:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectLevitate>();
			//Debug.Log ("levitate enchantment");
			Cast_Levitate(caster,playerUW.ActiveSpell,EffectId,ActiveArrayIndex,10);
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_WaterWalk:
		case SpellEffect.UW1_Spell_Effect_WaterWalk_alt01:
		case SpellEffect.UW1_Spell_Effect_WaterWalk_alt02:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectWaterWalk>();
			Debug.Log ("Waterwalk enchantment");
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Fly:
		case SpellEffect.UW1_Spell_Effect_Fly_alt01:
		case SpellEffect.UW1_Spell_Effect_Fly_alt02:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectFly>();
			Debug.Log ("Fly enchantment");
			Cast_Levitate(caster,playerUW.ActiveSpell,EffectId,ActiveArrayIndex,10);
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
		//	ActiveSpellArray[index]=caster.AddComponent<SpellEffectResistance>();
			Debug.Log ("Resist damage enchantment");
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Stealth:
		case SpellEffect.UW1_Spell_Effect_Conceal:
		case SpellEffect.UW1_Spell_Effect_Stealth_alt01:
		case SpellEffect.UW1_Spell_Effect_Conceal_alt01:
		case SpellEffect.UW1_Spell_Effect_Stealth_alt02:
		case SpellEffect.UW1_Spell_Effect_Conceal_alt02:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectStealth>();
			Debug.Log ("stealth enchantment");
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Invisibilty:
		case SpellEffect.UW1_Spell_Effect_Invisibility_alt01:
		case SpellEffect.UW1_Spell_Effect_Invisibility_alt02:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectInvisibility>();
			Debug.Log ("Invisibilty enchantment");
			//Todo
			break;
			//Missiles
		case SpellEffect.UW1_Spell_Effect_MissileProtection:
		case SpellEffect.UW1_Spell_Effect_MissileProtection_alt01:
		case SpellEffect.UW1_Spell_Effect_MissileProtection_alt02:
			Debug.Log ("Missile protection enchantment");
			break;
			//Flames
		case SpellEffect.UW1_Spell_Effect_Flameproof:
		case SpellEffect.UW1_Spell_Effect_Flameproof_alt01:
		case SpellEffect.UW1_Spell_Effect_Flameproof_alt02:
			Debug.Log ("Flameproof Enchantment");
			break;
			//Magic
		case SpellEffect.UW1_Spell_Effect_MagicProtection:
		case SpellEffect.UW1_Spell_Effect_GreaterMagicProtection:
			Debug.Log ("Magic protection enchantment");
			
		//	ActiveSpellArray[index]=caster.AddComponent<SpellEffectResistanceAgainstType>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_PoisonResistance:
			Debug.Log ("Poison Resistance enchantment");
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectImmunityPoison>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Speed:
		case SpellEffect.UW1_Spell_Effect_Haste:
			Debug.Log ("Speed enchantment");
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectSpeed>();
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_Telekinesis:
		case SpellEffect.UW1_Spell_Effect_Telekinesis_alt01:
		case SpellEffect.UW1_Spell_Effect_Telekinesis_alt02:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectTelekinesis>();
			Cast_Telekinesis(caster,playerUW.ActiveSpell,EffectId,ActiveArrayIndex,2);
			//Todo
			break;
		case SpellEffect.UW1_Spell_Effect_FreezeTime:
		case SpellEffect.UW1_Spell_Effect_FreezeTime_alt01:
		case SpellEffect.UW1_Spell_Effect_FreezeTime_alt02:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectFreezeTime>();
			Debug.Log ("Freeze time enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_Regeneration:
		//	ActiveSpellArray[index]=caster.AddComponent<SpellEffectRegenerationHealth>();
			Debug.Log ("Regen enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_ManaRegeneration:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectRegenerationMana>();
			Debug.Log ("mana regen enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_MazeNavigation:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectMazeNavigation>();
			Debug.Log ("Maze Navigation enchantment");
			break;			
		case SpellEffect.UW1_Spell_Effect_Hallucination:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectHallucination>();
			Debug.Log ("Hallucination");
			break;
		case SpellEffect.UW1_Spell_Effect_NightVision:
		case SpellEffect.UW1_Spell_Effect_NightVision_alt01:
		case SpellEffect.UW1_Spell_Effect_NightVision_alt02:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectNightVision>();
			Debug.Log ("Nightvision enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_Poison:
		case SpellEffect.UW1_Spell_Effect_Poison_alt01:
		case SpellEffect.UW1_Spell_Effect_PoisonHidden:
			//Debug.Log ("Poison enchantment");
			Cast_Poison (caster,playerUW.PassiveSpell,EffectId,PassiveArrayIndex,10,100);
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectPoison>();
			break;
		case SpellEffect.UW1_Spell_Effect_Paralyze:
		case SpellEffect.UW1_Spell_Effect_Paralyze_alt01:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectParalyze>();
			Debug.Log ("paralyse enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_Ally:
		case SpellEffect.UW1_Spell_Effect_Ally_alt01:
		//	ActiveSpellArray[index]=caster.AddComponent<SpellEffectAlly>();
			Debug.Log ("ally enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_Confusion:
		case SpellEffect.UW1_Spell_Effect_Confusion_alt01:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectConfusion>();
			Debug.Log ("Confusion enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_MinorAccuracy:
		case SpellEffect.UW1_Spell_Effect_Accuracy:
		case SpellEffect.UW1_Spell_Effect_AdditionalAccuracy:
		case SpellEffect.UW1_Spell_Effect_MajorAccuracy:
		case SpellEffect.UW1_Spell_Effect_GreatAccuracy:
		case SpellEffect.UW1_Spell_Effect_VeryGreatAccuracy:
		case SpellEffect.UW1_Spell_Effect_TremendousAccuracy:
		case SpellEffect.UW1_Spell_Effect_UnsurpassedAccuracy:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectAccuracy>();
			Debug.Log ("accuracy enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_MinorDamage:
		case SpellEffect.UW1_Spell_Effect_Damage:
		case SpellEffect.UW1_Spell_Effect_AdditionalDamage:
		case SpellEffect.UW1_Spell_Effect_MajorDamage:
		case SpellEffect.UW1_Spell_Effect_GreatDamage:
		case SpellEffect.UW1_Spell_Effect_VeryGreatDamage:
		case SpellEffect.UW1_Spell_Effect_TremendousDamage:
		case SpellEffect.UW1_Spell_Effect_UnsurpassedDamage:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectDamage>();
			Debug.Log ("damage enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_MinorProtection:
		case SpellEffect.UW1_Spell_Effect_Protection:
		case SpellEffect.UW1_Spell_Effect_AdditionalProtection:
		case SpellEffect.UW1_Spell_Effect_MajorProtection:
		case SpellEffect.UW1_Spell_Effect_GreatProtection:
		case SpellEffect.UW1_Spell_Effect_VeryGreatProtection:
		case SpellEffect.UW1_Spell_Effect_TremendousProtection:
		case SpellEffect.UW1_Spell_Effect_UnsurpassedProtection:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectProtection>();
			Debug.Log ("protection enchantment");
			break;
		case SpellEffect.UW1_Spell_Effect_MinorToughness:
		case SpellEffect.UW1_Spell_Effect_Toughness:
		case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
		case SpellEffect.UW1_Spell_Effect_MajorToughness:
		case SpellEffect.UW1_Spell_Effect_GreatToughness:
		case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
		case SpellEffect.UW1_Spell_Effect_TremendousToughness:
		case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffectToughness>();
			Debug.Log ("toughness enchantment");
			break;
		
		case SpellEffect.UW1_Spell_Effect_MagicArrow:
		case SpellEffect.UW1_Spell_Effect_MagicArrow_alt01:
			Cast_OrtJux(caster,true);
			break;
			/*No status spells*/
		
		case SpellEffect.UW1_Spell_Effect_Open:
		case SpellEffect.UW1_Spell_Effect_Open_alt01:
			Cast_ExYlem(caster,true);
			break;

		case SpellEffect.UW1_Spell_Effect_CreateFood:
		case SpellEffect.UW1_Spell_Effect_CreateFood_alt01:
			Cast_InManiYlem(caster);
			break;

		case SpellEffect.UW1_Spell_Effect_CurePoison:
		case SpellEffect.UW1_Spell_Effect_CurePoison_alt01:
			Cast_AnNox(caster);
			Debug.Log ("");
			break;

		case SpellEffect.UW1_Spell_Effect_SheetLightning:
			Cast_OrtGrav(caster, true);
			break;

		case SpellEffect.UW1_Spell_Effect_Armageddon:
		case SpellEffect.UW1_Spell_Effect_Armageddon_alt01:
			Cast_VasKalCorp(caster);
			break;

		case SpellEffect.UW1_Spell_Effect_GateTravel:
		case SpellEffect.UW1_Spell_Effect_GateTravel_alt01:
			Cast_VasRelPor(caster);
			break;

		case SpellEffect.UW1_Spell_Effect_ElectricalBolt:
		case SpellEffect.UW1_Spell_Effect_Fireball:

		case SpellEffect.UW1_Spell_Effect_FlameWind:
		case SpellEffect.UW1_Spell_Effect_CauseFear:
		case SpellEffect.UW1_Spell_Effect_SmiteUndead:
		
		case SpellEffect.UW1_Spell_Effect_RuneofWarding:
		case SpellEffect.UW1_Spell_Effect_SummonMonster:
		case SpellEffect.UW1_Spell_Effect_IncreaseMana:
		case SpellEffect.UW1_Spell_Effect_IncreaseMana_alt01:
		case SpellEffect.UW1_Spell_Effect_IncreaseMana_alt02:
		case SpellEffect.UW1_Spell_Effect_IncreaseMana_alt03:
		case SpellEffect.UW1_Spell_Effect_RegainMana:
		case SpellEffect.UW1_Spell_Effect_RegainMana_alt01:
		case SpellEffect.UW1_Spell_Effect_RegainMana_alt02:
		case SpellEffect.UW1_Spell_Effect_RegainMana_alt03:
		case SpellEffect.UW1_Spell_Effect_RestoreMana:
		case SpellEffect.UW1_Spell_Effect_RestoreMana_alt01:
		case SpellEffect.UW1_Spell_Effect_RestoreMana_alt02:
		case SpellEffect.UW1_Spell_Effect_RestoreMana_alt03:
		case SpellEffect.UW1_Spell_Effect_DetectMonster:
		case SpellEffect.UW1_Spell_Effect_StrengthenDoor:
		case SpellEffect.UW1_Spell_Effect_RemoveTrap:
		case SpellEffect.UW1_Spell_Effect_NameEnchantment:
		
		
		case SpellEffect.UW1_Spell_Effect_Tremor:
		
		
		
		
		case SpellEffect.UW1_Spell_Effect_DetectMonster_alt01:
		case SpellEffect.UW1_Spell_Effect_RuneofWarding_alt01:
		case SpellEffect.UW1_Spell_Effect_ElectricalBolt_alt01:
		case SpellEffect.UW1_Spell_Effect_StrengthenDoor_alt01:
		case SpellEffect.UW1_Spell_Effect_RemoveTrap_alt01:
		case SpellEffect.UW1_Spell_Effect_Fireball_alt01:
		case SpellEffect.UW1_Spell_Effect_SmiteUndead_alt01:
		case SpellEffect.UW1_Spell_Effect_NameEnchantment_alt01:
		
		
		case SpellEffect.UW1_Spell_Effect_SheetLightning_alt01:
		
		case SpellEffect.UW1_Spell_Effect_SummonMonster_alt01:


			/*?*/
		case SpellEffect.UW1_Spell_Effect_Curse:
		case SpellEffect.UW1_Spell_Effect_SetGuard:
		case SpellEffect.UW1_Spell_Effect_Cursed:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt01:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt02:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt03:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt04:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt05:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt06:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt07:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt09:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt10:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt11:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt12:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt13:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt14:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt15:
		case SpellEffect.UW1_Spell_Effect_Cursed_alt16:
		case SpellEffect.UW1_Spell_Effect_RoamingSight:
		case SpellEffect.UW1_Spell_Effect_theFrog:
		case SpellEffect.UW1_Spell_Effect_Curse_alt01:
		case SpellEffect.UW1_Spell_Effect_CauseFear_alt01:
		case SpellEffect.UW1_Spell_Effect_Reveal_alt01:
		case SpellEffect.UW1_Spell_Effect_Curse_alt02:
		case SpellEffect.UW1_Spell_Effect_RoamingSight_alt02:

		/*test*/
		case SpellEffect.UW1_Spell_Effect_Reveal:

	/*Blank*/
		case SpellEffect.UW1_Spell_Effect_Tremor_alt01:
		case SpellEffect.UW1_Spell_Effect_RoamingSight_alt01:
		case SpellEffect.UW1_Spell_Effect_FlameWind_alt01:
		
		case SpellEffect.UW1_Spell_Effect_MassParalyze:
		case SpellEffect.UW1_Spell_Effect_Acid_alt01:
		case SpellEffect.UW1_Spell_Effect_LocalTeleport_alt01:
		case SpellEffect.UW1_Spell_Effect_RestoreMana_alt04:



		default:
			Debug.Log ("effect Id is " + EffectId);
			//ActiveSpellArray[index]=caster.AddComponent<SpellEffect>();
			break;
			
		}
		
		//ActiveSpellArray[index].EffectId=EffectId;
		//return ActiveSpellArray[index];
		return false;
	}



}

