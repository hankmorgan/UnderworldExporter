using UnityEngine;
using System.Collections;
/// <summary>
/// Magic spell casting code
/// </summary>
/// A whole lot of code for Casting spells and enchantments	

public class Magic : UWEBase {
		
		public static UWCharacter playerUW;

		//Spell effect rules
		///Spell is affecting another character/thing
		public const int SpellRule_TargetOther=0;
		///Spell is cast by player and/or is affecting player character.
		public const int SpellRule_TargetSelf=1;
		///Spell is cast by a hostile or a spell trap along a vector
		public const int SpellRule_TargetVector=2;

		///Spelleffect is to be stored nowhere or is not a spelleffect
		public const int SpellResultNone=0;
		///Spelleffect is to be stored in a passive array or to an npc's array
		public const int SpellResultPassive=1;
		///Spell effect is to be stored in the players active spell array
		public const int SpellResultActive=2;

		///Magic spell to be cast on next click in window
		public string ReadiedSpell;

		///Runes that the character has picked up
		public bool[] PlayerRunes=new bool[24];
		///Runes that the player has selected
		public int[] ActiveRunes=new int[3];

		///The player has unlimited mana
		public bool InfiniteMana;

		///How much mana the player can have
		public int MaxMana;
		///How much mana the player currently has
		public int CurMana;
		///The mana cost of the next spell the player will cast
		public int SpellCost;

		///For spells cast on objects in slots
		public GameObject ObjectInSlot;
		///Flags a spell as castable on inventory.
		public bool InventorySpell;

		/// String names for the runes. 
		string[] Runes=new string[]{"An","Bet","Corp","Des",
				"Ex","Flam","Grav","Hur",
				"In","Jux","Kal","Lor",
				"Mani","Nox","Ort","Por",
				"Quas","Rel","Sanct","Tym",
				"Uus","Vas","Wis","Ylem"};

		///Running count of items, monsters and other random things that are summoned by magic
		public long SummonCount=0;


		public void Update()
		{//Infinite mana.
				if ( (InfiniteMana) && (CurMana<MaxMana) )
				{
						CurMana=MaxMana;
				}
		}

		/// <summary>
		/// Sets the spell cost based on the circle of the spell x 3
		/// </summary>
		/// <param name="SpellCircle">Spell circle.</param>
		public void SetSpellCost(int SpellCircle)
		{
				SpellCost= SpellCircle*3;
		}

		/// <summary>
		/// Deducts the spellcost from the players mana level
		/// </summary>
		public void ApplySpellCost()
		{
				CurMana=CurMana-SpellCost;
				SpellCost=0;
		}

		/// <summary>
		/// Checks if the player can cast the spell.
		/// </summary>
		/// <returns><c>true</c>, if spell cast was tested, <c>false</c> otherwise.</returns>
		/// <param name="casterUW">The player character casting the spell</param>
		/// <param name="Rune1">Rune1.</param>
		/// <param name="Rune2">Rune2.</param>
		/// <param name="Rune3">Rune3.</param>
		/// Tests their spell casting level
		/// Tests their mana level
		/// Tests their casting level (for failurs and backfires)
		public bool TestSpellCast(UWCharacter casterUW,  int Rune1, int Rune2, int Rune3)
		{
				int TestSpellLevel=0;
				string MagicWords=TranslateSpellRune(Rune1,Rune2,Rune3);
				switch (MagicWords)
				{
				case "An An An":
						TestSpellLevel=1;
						break;
						//1st Circle
				case "In Mani Ylem"://Create Food
				case "In Lor":	//Light
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
							UWHUD.instance.MessageScroll.Add ("Not a spell.");
							return false;
						}
				}//magicwords

				if (Mathf.Round(casterUW.CharLevel/2)<TestSpellLevel)
				{//Not experienced enough
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,210));
						return false;
				}
				else if (CurMana< TestSpellLevel*3)
				{//Mana test
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,211));
						return false;
				}
				else if( ! casterUW.PlayerSkills.TrySkill(Skills.SkillCasting, TestSpellLevel))
				{//Skill test. Random chance to backfire
						if (Random.Range(1,10)<8)
						{//TODO:decide on the chances
								//000~001~213~Casting was not successful.
								UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,213));
						}
						else
						{//000~001~214~The spell backfires.
								UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,214));
								casterUW.CurVIT = casterUW.CurVIT-3;
						}
						return false;
				}
				else
				{//Casting sucessful. 
						UWHUD.instance.MessageScroll.Add ("Casting " + MagicWords);
						return true;
				}
		}

		/// <summary>
		/// Special spell for testing
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// Cast using An An An as the runes
		public void TestSpell(GameObject caster)
		{
			//	SpellEffectMazeNavigation sep = caster.AddComponent<SpellEffectMazeNavigation>();
			// sep.counter=2;
			//	sep.Go ();
		}

		/// <summary>
		/// Casts the spell from the selected magic runes
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="MagicWords">Magic words.</param>
		/// <param name="ready">If set to <c>true</c> then the spell is being readied (for targetted spells), false for immediate cast</param>
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
								Cast_InManiYlem(caster,SpellEffect.UW1_Spell_Effect_CreateFood);
								break;
						}//imy
				case "In Lor":	//Light
						{
								SetSpellCost(1);
								Cast_LightSpells(caster,SpellEffect.UW1_Spell_Effect_Candlelight);
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
								Cast_OrtJux(caster, ready,SpellEffect.UW1_Spell_Effect_MagicArrow);
								break;
						}//OJ
				case "Bet In Sanct"://Resist Blows
						{
								SetSpellCost(1);
								Cast_ResistanceSpells(caster,SpellEffect.UW1_Spell_Effect_ResistBlows_alt01);
								break;
						}//BIS
				case "Sanct Hur"://Stealth
						{
								SetSpellCost(1);
								//Debug.Log(MagicWords+ " Stealth Cast");
								Cast_StealthSpells(caster,SpellEffect.UW1_Spell_Effect_Stealth);
								break;
						}//sh

						//2nd Circle
				case "Quas Corp"://Cause Fear
						{
								SetSpellCost(2);
								//Debug.Log(MagicWords+ " Cause Fear Cast");
								Cast_QuasCorp(caster,SpellEffect.UW1_Spell_Effect_CauseFear);
								break;
						}//qc
				case "Wis Mani"://Detect Monster
						{
								SetSpellCost(2);
								//Debug.Log(MagicWords+ " Detect Monster Cast");
								Cast_DetectMonster(caster,SpellEffect.UW1_Spell_Effect_DetectMonster);
								break;
						}//wm
				case "Uus Por"://Jump
						{
								SetSpellCost(2);
								Cast_UusPor(caster,SpellEffect.UW1_Spell_Effect_Leap_alt01);
								break;
						}//up
				case "In Bet Mani"://Lesser Heal
						{
								SetSpellCost(2);
								Cast_Heal(caster,SpellEffect.UW1_Spell_Effect_LesserHeal);
								break;
						}//IBM
				case "Rel Des Por"://Slow Fall
						{
								SetSpellCost(2);
								Cast_RelDesPor(caster,SpellEffect.UW1_Spell_Effect_SlowFall);
								break;
						}//RDP
				case "In Sanct"://Thick Skin
						{
								SetSpellCost(2);
								Cast_ResistanceSpells(caster,SpellEffect.UW1_Spell_Effect_ThickSkin);
								break;
						}//IS
				case "In Jux"://Rune of Warding
						{
								SetSpellCost(2);
								Cast_InJux(caster,SpellEffect.UW1_Spell_Effect_RuneofWarding);
								break;
						}//IJ

						//3rd Circle
				case "Bet Sanct Lor"://Conceal
						{
								SetSpellCost(3);
								//Debug.Log(MagicWords+ " Conceal Cast");
								Cast_StealthSpells(caster,SpellEffect.UW1_Spell_Effect_Conceal);
								break;
						}//BSL
				case "Ort Grav"://Lightning
						{
								SetSpellCost(3);
								Cast_OrtGrav(caster, ready,SpellEffect.UW1_Spell_Effect_ElectricalBolt);
								break;
						}//OG
				case "Quas Lor"://Night Vision
						{
								SetSpellCost(3);
								/*Debug.Log(MagicWords+ " Night Vision Cast");*/
								Cast_LightSpells(caster,SpellEffect.UW1_Spell_Effect_NightVision);
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
								//Debug.Log(MagicWords+ " Speed Cast");
								Cast_RelTymPor(caster,SpellEffect.UW1_Spell_Effect_Speed);
								break;
						}//rtp
				case "Ylem Por"://Water Walk
						{
								SetSpellCost(3);
								Cast_YlemPor(caster,SpellEffect.UW1_Spell_Effect_WaterWalk);
								break;
						}//YP
				case "Sanct Jux"://Strengten Door
						{
								SetSpellCost(3);
								Cast_SanctJux(caster,ready,SpellEffect.UW1_Spell_Effect_StrengthenDoor);
								break;
						}//SJ

						//4th Circle
				case "An Sanct"://Curse
						{
								SetSpellCost(4);
								//Debug.Log(MagicWords+ " Curse Cast");
								Cast_Curse(caster,SpellEffect.UW1_Spell_Effect_Curse);
								break;
						}//AS
				case "Sanct Flam":// Flameproof
						{
								SetSpellCost(4);
								Cast_SanctFlam(caster,SpellEffect.UW1_Spell_Effect_Flameproof);
								break;
						}//SF
				case "In Mani"://Heal
						{
								SetSpellCost(4);
								Cast_Heal (caster,SpellEffect.UW1_Spell_Effect_Heal);
								break;
						}//IM
				case "Hur Por"://Levitate
						{	
								SetSpellCost(4);
								Cast_LevitateSpells(caster,SpellEffect.UW1_Spell_Effect_Levitate);
								break;
						}//HP
				case "Nox Ylem"://Poison
						{
								SetSpellCost(4);
								Cast_NoxYlem(caster,SpellEffect.UW1_Spell_Effect_Poison);
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
								Cast_PorFlam(caster, ready,SpellEffect.UW1_Spell_Effect_Fireball);
								break;
						}//PF
				case "Grav Sanct Por"://Missile Protection
						{
								SetSpellCost(5);
								//Debug.Log(MagicWords+ " Missile Protection Cast");
								Cast_GravSanctPor(caster,SpellEffect.UW1_Spell_Effect_MissileProtection);
								break;
						}//GSP
				case "Ort Wis Ylem"://Name Enchantment
						{
								SetSpellCost(5);
								//Debug.Log(MagicWords+ " Name Enchantment Cast");
								Cast_NameEnchantment(caster,ready,SpellEffect.UW1_Spell_Effect_NameEnchantment);
								break;
						}//OWY
				case "Ex Ylem"://Open
						{
								SetSpellCost(5);
								Cast_ExYlem(caster, ready,SpellEffect.UW1_Spell_Effect_Open);
								break;
						}//EY
				case "An Nox"://Cure Poison
						{
								SetSpellCost(5);
								Cast_AnNox(caster,SpellEffect.UW1_Spell_Effect_CurePoison);
								break;
						}//AN
				case "An Corp Mani"://Smite Undead
						{
								SetSpellCost(5);
								//Debug.Log(MagicWords+ " Smite Undead Cast");
								Cast_AnCorpMani(caster,SpellEffect.UW1_Spell_Effect_SmiteUndead);
								break;
						}//ACM

						//6th Circle
				case "Vas In Lor"://Daylight
						{
								SetSpellCost(6);
								//Debug.Log(MagicWords+ " Daylight Cast");
								Cast_LightSpells(caster,SpellEffect.UW1_Spell_Effect_Daylight);
								break;
						}//VIL
				case "Vas Rel Por"://Gate Travel
						{
								SetSpellCost(6);
								Cast_VasRelPor(caster,SpellEffect.UW1_Spell_Effect_GateTravel);
								break;
						}//VRP
				case "Vas In Mani"://Greater Heal
						{
								SetSpellCost(6);
								Cast_Heal (caster,SpellEffect.UW1_Spell_Effect_GreaterHeal);
								break;
						}//VIM
				case "An Ex Por"://Paralyze
						{
								SetSpellCost(6);
								Cast_AnExPor(caster,SpellEffect.UW1_Spell_Effect_Paralyze);
								break;
						}//AEP
				case "Vas Ort Grav"://Sheet Lightning
						{
								SetSpellCost(6);
								//Debug.Log(MagicWords+ " Sheet Lightning Cast");
								Cast_VasOrtGrav(caster,SpellEffect.UW1_Spell_Effect_SheetLightning);
								break;
						}//VOG
				case "Ort Por Ylem"://Telekinesis
						{
								SetSpellCost(6);
								//Debug.Log(MagicWords+ " Telekinesis Cast");
								Cast_OrtPorYlem(caster,SpellEffect.UW1_Spell_Effect_Telekinesis);
								break;
						}//OPY

						//7th Circle
				case "In Mani Rel"://Ally
						{
								SetSpellCost(7);
								//Debug.Log(MagicWords+ " Ally Cast");
								Cast_InManiRel(caster,SpellEffect.UW1_Spell_Effect_Ally);
								break;
						}//IMR
				case "Vas An Wis"://Confusion
						{
								SetSpellCost(7);
								//Debug.Log(MagicWords+ " Confusion Cast");
								Cast_VasAnWis(caster,SpellEffect.UW1_Spell_Effect_Confusion);
								break;
						}//VAW
				case "Vas Sanct Lor"://Invisibility
						{
								SetSpellCost(7);
								//Debug.Log(MagicWords+ " Invisibility Cast");
								Cast_StealthSpells(caster,SpellEffect.UW1_Spell_Effect_Invisibilty);
								break;
						}//VSL
				case "Vas Hur Por"://Fly
						{
								SetSpellCost(7);
								Cast_LevitateSpells	(caster,SpellEffect.UW1_Spell_Effect_Fly);
								//Debug.Log(MagicWords+ " Fly Cast");
								break;
						}//VHP
				case "Kal Mani"://Monster Summoning
						{
								SetSpellCost(7);
								Cast_KalMani(caster,SpellEffect.UW1_Spell_Effect_SummonMonster);
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
								//Debug.Log(MagicWords+ " Armageddon Cast");
								Cast_VasKalCorp(caster,SpellEffect.UW1_Spell_Effect_Armageddon);
								break;
						}//vkc
				case "Flam Hur"://Flame Wind
						{
								SetSpellCost(8);
								Cast_FlamHur(caster,SpellEffect.UW1_Spell_Effect_FlameWind);
								break;
						}//fh
				case "An Tym":// Freeze Time
						{
								SetSpellCost(8);
								Cast_AnTym(caster,SpellEffect.UW1_Spell_Effect_FreezeTime);
								break;
						}//at
				case "In Vas Sanct"://Iron Flesh
						{
								SetSpellCost(8);
								Cast_ResistanceSpells(caster,SpellEffect.UW1_Spell_Effect_IronFlesh);
								break;
						}//ivs
				case "Ort Por Wis"://Roaming sight
						{
								SetSpellCost(8);
								Cast_OrtPorWis(caster,SpellEffect.UW1_Spell_Effect_RoamingSight);
								break;
						}//opw
				case "Vas Por Ylem"://Tremor
						{
								SetSpellCost(8);
								Cast_VasPorYlem(caster,SpellEffect.UW1_Spell_Effect_Tremor);
								break;
						}//vpy
				default:
						{

								//Debug.Log("Unknown spell:" + MagicWords);
								break;
						}
				}//magicwords
		}

		/// <summary>
		/// Translates the spell runes
		/// </summary>
		/// <returns>The spell rune.</returns>
		/// <param name="Rune1">Rune1.</param>
		/// <param name="Rune2">Rune2.</param>
		/// <param name="Rune3">Rune3.</param>
		public string TranslateSpellRune( int Rune1, int Rune2, int Rune3)
		{

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


		/// <summary>
		/// Casts a magic spell based on the constructed magic rune string
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="Rune1">Rune1.</param>
		/// <param name="Rune2">Rune2.</param>
		/// <param name="Rune3">Rune3.</param>
		public void castSpell(GameObject caster, int Rune1, int Rune2, int Rune3, bool ready)
		{
			string MagicWords="";
			//Construct the spell words based on selected runes
			MagicWords=TranslateSpellRune(Rune1,Rune2, Rune3);
			castSpell (caster, MagicWords,ready);						
		}

		/// <summary>
		/// Casts Magic Arrow/Missile
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="Ready">If set to <c>true</c> ready.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_OrtJux(GameObject caster, bool Ready, int EffectID)
		{//Magic Missile Spell
				if (Ready==true)
				{//Ready the spell to be cast.
						ReadiedSpell= "Ort Jux";
						UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconTarget;
				}
				else
				{
						SpellProp_MagicArrow spOJ =new SpellProp_MagicArrow();
						spOJ.init (EffectID,caster);
						CastProjectile(caster, (SpellProp)spOJ);
				}
		}

		/// <summary>
		/// Casts electric/lightning bolt.
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="Ready">If set to <c>true</c> ready.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_OrtGrav(GameObject caster, bool Ready, int EffectID)
		{//Lightning Bolt
				if (Ready==true)
				{//Ready the spell to be cast.
						ReadiedSpell= "Ort Grav";
						UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconTarget;
				}
				else
				{
						SpellProp_ElectricBolt spOG =new SpellProp_ElectricBolt();
						spOG.init (EffectID,caster);
						CastProjectile(caster, (SpellProp)spOG);
				}
		}

		/// <summary>
		/// Casts the fireball spell
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="Ready">If set to <c>true</c> ready.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_PorFlam(GameObject caster, bool Ready, int EffectID)
		{//Fireball Spell
				if (Ready==true)
				{//Ready the spell to be cast.
						ReadiedSpell= "Por Flam";
						UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconTarget;
				}
				else
				{
						SpellProp_Fireball spPF =new SpellProp_Fireball();
						spPF.init (EffectID,caster);
						spPF.caster=caster;
						CastProjectile(caster, (SpellProp)spPF);
				}
		}

		/// <summary>
		/// Casts flame wind
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_FlamHur(GameObject caster, int EffectID)
		{//Flamewind. Casts instantly.
				SpellProp_FlameWind spFH =new SpellProp_FlameWind();
				spFH.init (EffectID,caster);
				spFH.caster=caster;
				CastProjectile(caster, (SpellProp)spFH);
		}

		/// <summary>
		/// Casts sheet lightning
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_VasOrtGrav(GameObject caster, int EffectID)
		{//Sheet lightning
				SpellProp_SheetLightning spVOG =new SpellProp_SheetLightning();
				spVOG.init (EffectID,caster);
				CastProjectile(caster, (SpellProp)spVOG);
		}

		/// <summary>
		/// Casts the magic open
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="Ready">If set to <c>true</c> ready.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_ExYlem(GameObject caster, bool Ready, int EffectID)
		{//Open
				if (Ready==true)
				{//Ready the spell to be cast.
						playerUW.PlayerMagic.ReadiedSpell= "Ex Ylem";
						//UWHUD.instance.CursorIcon=Resources.Load<Texture2D>(_RES +"/Hud/Cursors/Cursors_0010");
						UWHUD.instance.CursorIcon=GameWorldController.instance.grCursors.LoadImageAt(10);
				}
				else
				{
						playerUW.PlayerMagic.ReadiedSpell="";
						UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
						Ray ray = getRay (caster);
						RaycastHit hit = new RaycastHit(); 
						float dropRange=playerUW.GetUseRange();
						if (Physics.Raycast(ray,out hit,dropRange))
						{//The spell has hit something
								DoorControl dc =hit.transform.gameObject.GetComponent<DoorControl>();
								if (dc!=null)
								{
										dc.UnlockDoor();
								}
								else if (hit.transform.GetComponent<PortcullisInteraction>()!=null)
								{
										hit.transform.GetComponent<PortcullisInteraction>().getParentObjectInteraction().gameObject.GetComponent<DoorControl>().UnlockDoor();
								}
						}
				}
		}

		/// <summary>
		/// Cast Strengthen Door
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="Ready">If set to <c>true</c> ready.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_SanctJux(GameObject caster, bool Ready, int EffectID)
		{//Strengthen DOor
				if (Ready==true)
				{//Ready the spell to be cast.
						playerUW.PlayerMagic.ReadiedSpell= "Sanct Jux";
						//UWHUD.instance.CursorIcon=Resources.Load<Texture2D>(_RES +"/Hud/Cursors/Cursors_0010");
						UWHUD.instance.CursorIcon=GameWorldController.instance.grCursors.LoadImageAt(10);
				}
				else
				{
						playerUW.PlayerMagic.ReadiedSpell="";
						UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
						Ray ray = getRay (caster);
						RaycastHit hit = new RaycastHit(); 
						float dropRange=playerUW.GetUseRange();
						if (Physics.Raycast(ray,out hit,dropRange))
						{//The spell has hit something
								DoorControl dc =hit.transform.gameObject.GetComponent<DoorControl>();
								if (dc!=null)
								{
										dc.Spike();
								}
						}
				}
		}


		/// <summary>
		/// Casts Cure Poison
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_AnNox(GameObject caster, int EffectID)
		{//Cure Poison
				//UWCharacter playerUW = caster.GetComponent<UWCharacter>();
				//Get all instances of poison effect on the character and destroy them.
				SpellEffectPoison[] seps= caster.GetComponents<SpellEffectPoison>();
				for (int i =0; i<= seps.GetUpperBound(0);i++)
				{
						seps[i].CancelEffect();
				}
				playerUW.Poisoned=false;
		}

		/// <summary>
		/// Casts Missile Protection
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_GravSanctPor(GameObject caster, int EffectID)
		{
				int effectSlot = CheckActiveSpellEffect(caster);
				if (effectSlot!=-1)
				{
					Cast_ResistanceAgainstType(caster,playerUW.ActiveSpell,EffectID,effectSlot);		
				}
				else
				{
					SpellIncantationFailed(caster);
				}	
		}

		/// <summary>
		/// Casts Time Stop
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_AnTym(GameObject caster, int EffectID)
		{
		int SpellEffectSlot = CheckActiveSpellEffect(caster);
		if (SpellEffectSlot != -1)
		{
				Cast_FreezeTime (caster, caster.GetComponent<UWCharacter>().ActiveSpell, EffectID,SpellEffectSlot);
		}
		else
		{
				SpellIncantationFailed(caster);
		}
		}

		/// <summary>
		/// Casts freeze time (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>

		void Cast_FreezeTime(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{
				SpellProp_Mind mind = new SpellProp_Mind();
				mind.init (EffectID,caster);		
				//Apply to the player
				SpellEffectFreezeTime timeFreezePlayer= (SpellEffectFreezeTime)SetSpellEffect(caster, ActiveSpellArray, EffectSlot, EffectID);
				timeFreezePlayer.counter= mind.counter;
				long Key = Random.Range(1,200000);
				timeFreezePlayer.Key=Key;
				timeFreezePlayer.Go();
				GameObject[] npcs= GameObject.FindGameObjectsWithTag("NPCs");
				for (int i = 0; i<=npcs.GetUpperBound(0); i++)
				{
						if (npcs[i].GetComponent<SpellEffectFreezeTime>()==null)//Don't apply if they already have it
						{	
							int NPCEffectSlot =CheckPassiveSpellEffectNPC(npcs[i]);
							//Cast_FreezeTime(npcs[i],npcs[i].GetComponent<NPC>().NPCStatusEffects,EffectID,EffectSlot);
							if (NPCEffectSlot!=-1)
							{//Check if the NPC has a freeze time already.
									SpellEffectFreezeTime timeFreezeNPC=(SpellEffectFreezeTime)SetSpellEffect(npcs[i],npcs[i].GetComponent<NPC>().NPCStatusEffects,NPCEffectSlot,EffectID);
									timeFreezeNPC.Key=Key;
									timeFreezeNPC.isNPC=true;
									timeFreezeNPC.counter=mind.counter;
									timeFreezeNPC.Go();
							}
						}
						else
							{//Restart the effect timer and match the key
										npcs[i].GetComponent<SpellEffectFreezeTime>().Key=Key;		
										npcs[i].GetComponent<SpellEffectFreezeTime>().counter=mind.counter;
							}

				}

		}


		/// <summary>
		/// Casts the light spells (generic).
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_LightSpells(GameObject caster, int EffectID)
		{//Light
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_Light (caster, caster.GetComponent<UWCharacter>().ActiveSpell, EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}
		}

		/// <summary>
		/// Casts Create Food
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_InManiYlem(GameObject caster, int EffectID)
		{//Create food
				Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
				RaycastHit hit = new RaycastHit(); 
				float dropRange=1.2f;
				if (!Physics.Raycast(ray,out hit,dropRange))
				{//No object interferes with the spellcast
						int ObjectNo = 176 + Random.Range(0,7);
						GameObject myObj=  new GameObject("SummonedObject_" + SummonCount++);
						myObj.layer=LayerMask.NameToLayer("UWObjects");
						myObj.transform.position = ray.GetPoint(dropRange);
						myObj.transform.parent=GameWorldController.instance.LevelMarker();
						GameWorldController.MoveToWorld(myObj);
						ObjectInteraction.CreateObjectGraphics(myObj,_RES +"/Sprites/Objects/Objects_182",true);
						ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_" +ObjectNo, _RES +"/Sprites/Objects/Objects_" +ObjectNo, _RES +"/Sprites/Objects/Objects_182_" +ObjectNo, ObjectInteraction.FOOD, 182, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
						Food fd = myObj.AddComponent<Food>();
						fd.Nutrition=5;//TODO:determine values to use here.
						GameWorldController.UnFreezeMovement(myObj);
				}
		}

		/// <summary>
		/// Create Summon Monster
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_KalMani(GameObject caster, int EffectID)
		{//Summon monster
				Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
				RaycastHit hit = new RaycastHit(); 
				float dropRange=1.2f;
				if (!Physics.Raycast(ray,out hit,dropRange))
				{//No object interferes with the spellcast

						//First determine the target ai to attack
						//RaycastHit ht;
						int goal=3;//Default behaviour is to follow the player
						int gtarg = 1;
						string targetName="";
						NPC target = GetNPCTargetRandom(caster,ref hit);
						//If not make the summon a follower
						if (target!=null)
						{
								//Only attack hostiles or player enemies
								if (target.npc_attitude==0)
								{
								targetName=target.name;
								gtarg=999;
								}
						}


						//int ObjectNo = 176 + Random.Range(0,7);
						GameObject myObj=  new GameObject("SummonedObject_" + SummonCount++);
						myObj.layer=LayerMask.NameToLayer("NPCs");
						myObj.tag="NPCs";
						myObj.transform.position = ray.GetPoint(dropRange);
						myObj.transform.parent = GameWorldController.instance.LevelMarker();
						GameWorldController.MoveToWorld(myObj);
						SpellProp_SummonMonster spKM = new SpellProp_SummonMonster();
						spKM.init(SpellEffect.UW1_Spell_Effect_SummonMonster,caster);

						ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_" + spKM.RndNPC.ToString("000"), _RES +"/Sprites/Objects/Objects_" + spKM.RndNPC.ToString("000"), _RES +"/Sprites/Objects/Objects_" +spKM.RndNPC.ToString("000"), 0, spKM.RndNPC, 0, 31, 1, 0, 1, 0, 1, 0, 0, 0, 1);

						ObjectInteraction.CreateNPC(myObj,spKM.RndNPC.ToString(),_RES +"/Sprites/Objects/Objects_" + spKM.RndNPC.ToString("000"), 0);
						//Assumes the npc is spawning in the region the player is in
						string[] Regionarr=	playerUW.currRegion.Split(new string [] {"_"}, System.StringSplitOptions.None);
						string navMeshName="";
						int levelno = GameWorldController.instance.LevelNo;
						switch (Regionarr[0].ToUpper())
						{//Calcualte the nav mesh this npc should use
						case "LAND":
								navMeshName="_GroundMesh_"   +levelno + "_" + Regionarr[1];break;
						case "LAVA":
								navMeshName="_LavaMesh_"   +levelno + "_" + Regionarr[1];break;
						case "WATER":
								navMeshName="_WaterMesh_"   +levelno + "_" + Regionarr[1];break;

						}


						//TODO:Set up these properties to use correct values
						ObjectInteraction.SetNPCProps(myObj, 0, 0, 0, 13, 10, 61, 0, 0, goal, 1, gtarg, 0, 4, 0, targetName, navMeshName);


						GameWorldController.UnFreezeMovement(myObj);
				}
		}

		/// <summary>
		/// Cast Armageddon
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_VasKalCorp(GameObject caster, int EffectID)
		{//Armageddon//Destroys almost everything!
				GameObject[] allGameObj =GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
				for (int i=0; i<= allGameObj.GetUpperBound(0);i++)
				{
						if  ( (allGameObj[i].layer== LayerMask.NameToLayer("UWObjects"))
								||
								(allGameObj[i].layer== LayerMask.NameToLayer("NPCs"))
								||
								(allGameObj[i].layer== LayerMask.NameToLayer("Doors"))
						)
						{
								if (allGameObj[i].transform.parent==null)
								{//Only deactivate top level items
										allGameObj[i].SetActive(false);				
								}
						}
				}
		}


		/// <summary>
		/// Cast Leap/Jump
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_UusPor(GameObject caster, int EffectID)
		{//Leap/junp
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_Leap (caster, caster.GetComponent<UWCharacter>().ActiveSpell, EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}
		}


		/// <summary>
		/// Casts slowfall
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_RelDesPor(GameObject caster, int EffectID)
		{//SLowfall
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_SlowFall (caster, caster.GetComponent<UWCharacter>().ActiveSpell, EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}
		}


		/// <summary>
		/// Casts poison other
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_NoxYlem(GameObject caster, int EffectID)
		{//poison other.
				RaycastHit hit= new RaycastHit();
				NPC npc = GetNPCTargetRandom(caster, ref hit);
				if (npc != null)
				{
						SpellProp_Poison poison = new SpellProp_Poison();
						poison.init (EffectID,caster);						
						//Apply a impact effect to the npc
						Impact.SpawnHitImpact(npc.transform.name + "_impact",npc.GetImpactPoint(),poison.impactFrameStart,poison.impactFrameEnd);		


						int EffectSlot = CheckPassiveSpellEffectNPC(npc.gameObject);
						if (EffectSlot!=-1)
						{
								SpellEffectPoison sep= (SpellEffectPoison)SetSpellEffect(npc.gameObject, npc.NPCStatusEffects, EffectSlot, EffectID);
								sep.Value=poison.BaseDamage;
								sep.counter=poison.counter;
								sep.isNPC=true;
								sep.Go ();
						}
				}
		}

		/// <summary>
		/// Casts curse (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_Curse(GameObject caster, int EffectID)
		{//Curse other.
				RaycastHit hit= new RaycastHit();
				NPC npc = GetNPCTargetRandom(caster, ref hit);
				if (npc != null)
				{
						//Debug.Log(npc.name);
						SpellProp_Curse curse = new SpellProp_Curse();
						curse.init (EffectID,caster);				
						//Apply a impact effect to the npc
						Impact.SpawnHitImpact(npc.transform.name + "_impact",npc.GetImpactPoint(),curse.impactFrameStart,curse.impactFrameEnd);		

						int EffectSlot = CheckPassiveSpellEffectNPC(npc.gameObject);
						if (EffectSlot!=-1)
						{
								SpellEffectCurse sep= (SpellEffectCurse)SetSpellEffect(npc.gameObject, npc.NPCStatusEffects, EffectSlot, EffectID);
								sep.isNPC=true;
								sep.Go ();
						}
				}
		}

		/// <summary>
		/// Casts ally
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_InManiRel(GameObject caster, int EffectID)
		{//Ally.
				RaycastHit hit= new RaycastHit();
				NPC npc = GetNPCTargetRandom(caster, ref hit);
				if (npc != null)
				{
						SpellProp_Mind mindspell = new SpellProp_Mind();
						mindspell.init (EffectID,caster);
						//Apply a impact effect to the npc
						Impact.SpawnHitImpact(npc.transform.name + "_impact",npc.GetImpactPoint(),mindspell.impactFrameStart,mindspell.impactFrameEnd);		


						if (npc.gameObject.GetComponent<SpellEffectAlly>()!=null)
						{//Npc already has this effect. Only allow one cast.
								npc.gameObject.GetComponent<SpellEffectAlly>().counter=mindspell.counter;//Restart the counter
						}
						else
						{//A new cast
								int EffectSlot = CheckPassiveSpellEffectNPC(npc.gameObject);
								if (EffectSlot!=-1)
								{
										SpellEffectAlly sea= (SpellEffectAlly)SetSpellEffect(npc.gameObject, npc.NPCStatusEffects, EffectSlot, EffectID);
										sea.counter=mindspell.counter;
										sea.Go ();
								}	
						}

				}
		}

		/// <summary>
		/// Cast Confusion
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>

		void Cast_VasAnWis(GameObject caster, int EffectID)
		{//Confusion.
				RaycastHit hit= new RaycastHit();
				NPC npc = GetNPCTargetRandom(caster, ref hit);
				if (npc != null)
				{
						SpellProp_Mind mindspell = new SpellProp_Mind();
						mindspell.init (EffectID,caster);						
						//Apply a impact effect to the npc
						Impact.SpawnHitImpact(npc.transform.name + "_impact",npc.GetImpactPoint(),mindspell.impactFrameStart,mindspell.impactFrameEnd);		

						if (npc.gameObject.GetComponent<SpellEffectConfusion>()!=null)
						{//Npc already has this effect. Only allow one cast.
								npc.gameObject.GetComponent<SpellEffectConfusion>().counter=5;//Restart the counter
						}
						else
						{//A new cast
								int EffectSlot = CheckPassiveSpellEffectNPC(npc.gameObject);
								if (EffectSlot!=-1)
								{
										SpellEffectConfusion sec= (SpellEffectConfusion)SetSpellEffect(npc.gameObject, npc.NPCStatusEffects, EffectSlot, EffectID);
										sec.counter=mindspell.counter;
										sec.Go ();
								}	
						}
				}
		}

		/// <summary>
		/// Casts fear
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_QuasCorp(GameObject caster, int EffectID)
		{//Fear.
				RaycastHit hit= new RaycastHit();
				NPC npc = GetNPCTargetRandom(caster, ref hit);
				if (npc != null)
				{
						SpellProp_Mind mindspell = new SpellProp_Mind();
						mindspell.init (EffectID,caster);							
						//Apply a impact effect to the npc
						Impact.SpawnHitImpact(npc.transform.name + "_impact",npc.GetImpactPoint(),mindspell.impactFrameStart,mindspell.impactFrameEnd);		

						if (npc.gameObject.GetComponent<SpellEffectFear>()!=null)
						{//Npc already has this effect. Only allow one cast.
								npc.gameObject.GetComponent<SpellEffectFear>().counter=5;//Restart the counter
						}
						else
						{//A new cast
								int EffectSlot = CheckPassiveSpellEffectNPC(npc.gameObject);
								if (EffectSlot!=-1)
								{
										SpellEffectFear sef= (SpellEffectFear)SetSpellEffect(npc.gameObject, npc.NPCStatusEffects, EffectSlot, SpellEffect.UW1_Spell_Effect_CauseFear);
										sef.counter=mindspell.counter;
										sef.Go ();
								}	
						}
				}
		}


		/// <summary>
		/// Casts Paralyze
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_AnExPor(GameObject caster,int EffectID)
		{//Paralyze
				RaycastHit hit= new RaycastHit();
				NPC npc = GetNPCTargetRandom(caster, ref hit);
				if (npc != null)
				{
						SpellProp_Mind mindspell = new SpellProp_Mind();
						mindspell.init (EffectID,caster);						
						//Apply a impact effect to the npc
						Impact.SpawnHitImpact(npc.transform.name + "_impact",npc.GetImpactPoint(),mindspell.impactFrameStart,mindspell.impactFrameEnd);		

						int EffectSlot = CheckPassiveSpellEffectNPC(npc.gameObject);
						if (EffectSlot!=-1)
						{
								SpellEffectParalyze sep= (SpellEffectParalyze)SetSpellEffect(npc.gameObject, npc.NPCStatusEffects, EffectSlot, EffectID);
								sep.isNPC=true;
								sep.counter=mindspell.counter;
								sep.Go ();
						}
				}
		}


		/// <summary>
		/// Casts smite undead
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// Only affects undead as set by GetNPCTargetRandom
		void Cast_AnCorpMani(GameObject caster, int EffectID)
		{//Smite undead
				RaycastHit hit= new RaycastHit();
				NPC npc = GetNPCTargetRandom(caster, ref hit, 1);
				if (npc != null)
				{
						SpellProp_Mind mindspell = new SpellProp_Mind();
						mindspell.init (EffectID,caster);						
						//Apply a impact effect to the npc
						Impact.SpawnHitImpact(npc.transform.name + "_impact",npc.GetImpactPoint(),mindspell.impactFrameStart,mindspell.impactFrameEnd);		

						SpellProp_DirectDamage damage = new SpellProp_DirectDamage();
						damage.init (EffectID,caster);
						npc.ApplyAttack(damage.BaseDamage,caster);			
				}
		}

		/// <summary>
		/// Casts telekinesis
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_OrtPorYlem(GameObject caster, int EffectID)
		{//Telekinesis
				int SpellEffectSlot = CheckActiveSpellEffect(caster);

				if (SpellEffectSlot != -1)
				{
						Cast_Telekinesis (caster, caster.GetComponent<UWCharacter>().ActiveSpell, EffectID, SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}
		}	


		/// <summary>
		/// Casts gate travel
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// Needs to know the position of the moonstone.
		void Cast_VasRelPor(GameObject caster, int EffectID)
		{//Gate Travel
				if (playerUW!=null)
				{
						if (playerUW.MoonGatePosition != Vector3.zero)
						{
								if (playerUW.MoonGateLevel != GameWorldController.instance.LevelNo)
								{//Teleport to level
										GameWorldController.instance.SwitchLevel(playerUW.MoonGateLevel);
								}
								caster.transform.position = playerUW.MoonGatePosition;
						}
						else
						{
								UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,273));
						}

				}
		}


		/// <summary>
		/// Casts the levitate spells
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_LevitateSpells(GameObject caster, int EffectID)
		{
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_Levitate (caster, caster.GetComponent<UWCharacter>().ActiveSpell, EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}		
		}

		/// <summary>
		/// Casts Speed
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_RelTymPor(GameObject caster, int EffectID)
		{//Speed
				//TODO:SpellProperties
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_Speed (caster, caster.GetComponent<UWCharacter>().ActiveSpell, EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}
		}	

		/// <summary>
		/// Casts waterwalk
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_YlemPor(GameObject caster, int EffectID)
		{//Waterwalk
				//TODO:SpellProperties
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_WaterWalk (caster, caster.GetComponent<UWCharacter>().ActiveSpell, EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}
		}

		/// <summary>
		/// Casts the resistance spells.
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_ResistanceSpells(GameObject caster, int EffectID)
		{
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_Resistance(caster, caster.GetComponent<UWCharacter>().ActiveSpell,EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}	
		}
	
		/// <summary>
		/// Casts flame proof
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect I.</param>
		void Cast_SanctFlam(GameObject caster, int EffectID)
		{
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_Flameproof(caster, caster.GetComponent<UWCharacter>().ActiveSpell, EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}
		}


		/// <summary>
		/// Roaming Sight
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_OrtPorWis(GameObject caster, int EffectID)
		{//Roaming sight
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_RoamingSight(caster, caster.GetComponent<UWCharacter>().ActiveSpell,EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}
		}

		/// <summary>
		/// Casts the stealth spells.
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_StealthSpells(GameObject caster, int EffectID)
		{//Stealth/invisibility/conceal
				int SpellEffectSlot = CheckActiveSpellEffect(caster);
				if (SpellEffectSlot != -1)
				{
						Cast_Stealth(caster, caster.GetComponent<UWCharacter>().ActiveSpell,EffectID,SpellEffectSlot);
				}
				else
				{
						SpellIncantationFailed(caster);
				}
		}

		/// <summary>
		/// Casts detect monster.
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_DetectMonster(GameObject caster, int EffectID)
		{
				SpellProp_Mind mind = new SpellProp_Mind();
				mind.init (EffectID,caster);
				Skills.TrackMonsters(caster,(float)mind.BaseDamage,true);
		}


		/// <summary>
		/// Casts name enchantment.
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="Ready">If set to <c>true</c> ready.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_NameEnchantment(GameObject caster, bool Ready, int EffectID)
		{
				if (Ready==true)
				{//Ready the spell to be cast.
						InventorySpell=true;
						playerUW.PlayerMagic.ReadiedSpell= "Ort Wis Ylem";
						//UWHUD.instance.CursorIcon=Resources.Load<Texture2D>(_RES +"/Hud/Cursors/Cursors_0010");
						UWHUD.instance.CursorIcon=GameWorldController.instance.grCursors.LoadImageAt(10);
				}
				else
				{
						InventorySpell=false;
						//Is this an inventory slot click or in the window
						if (WindowDetect.CursorInMainWindow)
						{
								playerUW.PlayerMagic.ReadiedSpell="";		
								UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
								Ray ray = getRay (caster);
								RaycastHit hit = new RaycastHit(); 
								float dropRange=playerUW.GetUseRange();
								if (Physics.Raycast(ray,out hit,dropRange))	
								{//The spell has hit something
										ObjectInteraction objInt =hit.transform.gameObject.GetComponent<ObjectInteraction>();
										if (objInt!=null)
										{
												objInt.isIdentified=true;
										}
								}										
						}
						else
						{
								if (ObjectInSlot!=null)	
								{
										ReadiedSpell= "";
										UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
										ObjectInteraction objInt =ObjectInSlot.GetComponent<ObjectInteraction>();
										if (objInt!=null)
										{
												objInt.isIdentified=true;
										}		
								}
						}
				}
		}

		/// <summary>
		/// Casts tremor
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_VasPorYlem(GameObject caster, int EffectID)
		{//Tremor. Spawn a couple of arrow traps and set them off?

				//TODO:reimplement this.
				//Possible spawn boulders with temporary damage effects???
				TileMap tm = GameObject.Find("Tilemap").GetComponent<TileMap>();
				for (int i =0 ; i <= Random.Range(1,4);i++)			
				{
						int boulderTypeOffset=Random.Range(0,4);

						Vector3 pos = caster.transform.position+(Random.insideUnitSphere * Random.Range(1,3));
						//Try and keep it in map range
						//Debug.Log(pos);
						if (tm.ValidTile(pos))
						{
								pos.Set(pos.x,4.5f,pos.z); //Put it on the roof.

								GameObject myObj = new GameObject("summoned_launcher_"+ SummonCount++);
								myObj.layer=LayerMask.NameToLayer("UWObjects");
								myObj.transform.position=pos;
								myObj.transform.Rotate(-90,0,0);
								myObj.transform.parent=GameWorldController.instance.LevelMarker();
								GameWorldController.MoveToWorld(myObj);
								ObjectInteraction.CreateObjectGraphics(myObj,_RES +"/Sprites/Objects/Objects_386",false);
								ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_386", _RES +"/Sprites/Objects/Objects_386", _RES +"/Sprites/Objects/Objects_386", 39, 386, 573, 9, 37, 0, 0, 0, 1, 1, 0, 5, 1);
								a_arrow_trap arrow=	myObj.AddComponent<a_arrow_trap>();
								//TODO: Fix this
								//arrow.item_index=339+boulderTypeOffset;
								//arrow.objInt().o
								//arrow.item_type=23;
								arrow.ExecuteTrap(0,0,0);
								Destroy(myObj);
						}					
				}
		}


		/// <summary>
		/// Casts rune of warding
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect I.</param>
		void Cast_InJux(GameObject caster, int EffectID)
		{
				Cast_RuneOfWarding(caster.transform.position + (transform.forward * 0.3f), EffectID);
		}


		/// <summary>
		/// Casts bullfrog spell
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// Special case spell that should only work on one level that has a_do_trapBullfrog
		void CastTheFrog(GameObject caster, int EffectID)
		{//The bullfrog trap. Special spell.
				a_do_trapBullfrog frog= (a_do_trapBullfrog)FindObjectOfType(typeof(a_do_trapBullfrog));
				if (frog !=null)
				{
						frog.ResetBullFrog();
				}
				else
				{//000~001~191~There is a pained whining sound.
						UWHUD.instance.MessageScroll.Add( StringController.instance.GetString (1,191));
				}
		}

		/// <summary>
		/// Casts the heal spell (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_Heal(GameObject caster,int EffectID)
		{
				SpellProp_Heal healing= new SpellProp_Heal();
				healing.init (EffectID,caster);
				int HP = healing.BaseDamage;
				if (playerUW!=null)
				{
						playerUW.CurVIT=playerUW.CurVIT+HP;
						if (playerUW.CurVIT > playerUW.MaxVIT)
						{
								playerUW.CurVIT=playerUW.MaxVIT;
						}
				}
		}


		/// <summary>
		/// Casts the resistance spells (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		void Cast_Resistance(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{//Eg resist blows, thick skin etc
				SpellProp_Resistance resist = new SpellProp_Resistance();
				resist.init (EffectID,caster);				
				SpellEffectResistance sea = (SpellEffectResistance)SetSpellEffect (caster,ActiveSpellArray,EffectSlot,EffectID);
				sea.Value = resist.BaseDamage;
				sea.counter= resist.counter;
				sea.Go ();
		}


		/// <summary>
		/// Casts the flameproof. (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		void Cast_Flameproof(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{//Eg resist blows, thick skin etc
				SpellProp_ResistanceAgainstType resist = new SpellProp_ResistanceAgainstType();
				resist.init (EffectID,caster);
				SpellEffectFlameproof sef = (SpellEffectFlameproof)SetSpellEffect (caster,ActiveSpellArray,EffectSlot,EffectID);
				sef.counter=resist.counter;
				sef.Go ();
		}

		/// <summary>
		/// Casts the mana spells
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		void Cast_Mana(GameObject caster,int EffectID)
		{//Increase (or decrease) the casters mana
				//UWCharacter playerUW=caster.GetComponent<UWCharacter>();
				SpellProp_Mana mn = new SpellProp_Mana();
				mn.init (EffectID,caster);
				int MP=mn.BaseDamage;
				if (playerUW!=null)
				{
						playerUW.PlayerMagic.CurMana=playerUW.PlayerMagic.CurMana+MP;
						if (playerUW.PlayerMagic.CurMana > playerUW.PlayerMagic.MaxMana)
						{
								playerUW.PlayerMagic.CurMana=playerUW.PlayerMagic.MaxMana;
						}
				}
		}


		/// <summary>
		/// Casts the light spells (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		void Cast_Light(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{
				SpellProp_Light spl = new SpellProp_Light();
				spl.init (EffectID,caster);		
				LightSource.MagicBrightness=spl.BaseDamage;
				SpellEffect sel= (SpellEffectLight)SetSpellEffect(caster, ActiveSpellArray, EffectSlot, EffectID);
				sel.Value = spl.BaseDamage;
				sel.counter= spl.counter;
				sel.Go ();// Apply the effect and Start the timer.
		}

		/// <summary>
		/// Casts the night vision (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect I.</param>
		/// <param name="EffectSlot">Effect slot.</param>
		void Cast_NightVision(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{
				SpellProp_Light spl = new SpellProp_Light();
				spl.init (EffectID,caster);						
				LightSource.MagicBrightness=spl.BaseDamage;
				SpellEffect nv= (SpellEffectNightVision)SetSpellEffect(caster, ActiveSpellArray, EffectSlot, EffectID);
				nv.Value = spl.BaseDamage;
				nv.counter= spl.counter;
				//sel.ApplyEffect();//Apply the effect.
				nv.Go ();// Apply the effect and Start the timer.
				//StartCoroutine(sel.timer());
		}

		/// <summary>
		/// Casts the hallucination effect
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect I.</param>
		/// <param name="EffectSlot">Effect slot.</param>
		void Cast_Hallucination(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{
				SpellProp_Mind mindspell = new SpellProp_Mind();
				mindspell.init (EffectID,caster);				
				SpellEffect hn= (SpellEffectHallucination)SetSpellEffect(caster, ActiveSpellArray, EffectSlot, EffectID);
				hn.counter= mindspell.counter;
				//sel.ApplyEffect();//Apply the effect.
				hn.Go ();// Apply the effect and Start the timer.
				//StartCoroutine(sel.timer());
		}


		/// <summary>
		/// Casts the leap spell (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		void Cast_Leap(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{
				SpellProp_Movement movement = new SpellProp_Movement();
				movement.init (EffectID,caster);				
				SpellEffect lep = (SpellEffectLeap)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				lep.counter=movement.counter;
				lep.Go ();
		}


		/// <summary>
		/// Casts the slow fall. generic
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		void Cast_SlowFall(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{
				SpellProp_Movement movement = new SpellProp_Movement();
				movement.init (EffectID,caster);				
				SpellEffect slf = (SpellEffectSlowFall)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				slf.counter=movement.counter;
				slf.Go ();
		}	


		/// <summary>
		/// Casts the roaming sight generic
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		void Cast_RoamingSight(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{
				SpellProp_Mind mindspell = new SpellProp_Mind();
				mindspell.init (EffectID,caster);				
				SpellEffect srs = (SpellEffectRoamingSight)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				srs.counter=mindspell.counter;
				srs.Go ();
		}	


		/// <summary>
		/// Casts the stealth spells (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		void Cast_Stealth(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{		
				SpellProp_Stealth stealth = new SpellProp_Stealth();
				stealth.init (EffectID,caster);				
				SpellEffectStealth st = (SpellEffectStealth)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				st.counter=stealth.counter;
				st.StealthLevel=stealth.StealthLevel;
				st.Go ();			
		}

		/// <summary>
		/// Casts the rune of warding (generic)
		/// </summary>
		/// <param name="pos">Position.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// 
		void Cast_RuneOfWarding(Vector3 pos, int EffectID)
		{
				GameObject myObj=  new GameObject("SummonedObject_" + SummonCount++);
				myObj.layer=LayerMask.NameToLayer("Ward");
				myObj.transform.position = pos;
				myObj.transform.parent=GameWorldController.instance.LevelMarker();
				GameWorldController.MoveToWorld(myObj);
				ObjectInteraction.CreateObjectGraphics(myObj,_RES +"/Sprites/Objects/Objects_393",true);
				ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_393", _RES +"/Sprites/Objects/Objects_393", _RES +"/Sprites/Objects/Objects_393",ObjectInteraction.A_WARD_TRAP, 393, 1, 40, 0, 0, 0, 0, 1, 0, 1, 0, 1);
				a_ward_trap awt = myObj.AddComponent<a_ward_trap>();
				BoxCollider bx=myObj.GetComponent<BoxCollider>();
				if (bx==null)
				{
						bx=myObj.AddComponent<BoxCollider>();	
				}
				bx.size=new Vector3(0.2f,0.2f,0.2f);
				bx.center=new Vector3(0.0f,0.1f,0.0f);
				bx.isTrigger=true;
				SpellProp_RuneOfWarding spIJ = new SpellProp_RuneOfWarding();//myObj.AddComponent<SpellProp_RuneOfWarding>();
				spIJ.init (EffectID,GameWorldController.instance.playerUW.gameObject);
				awt.spellprop=spIJ;
				//000~001~276~The Rune of Warding is placed. \n
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,276));
		}

		/// <summary>
		/// Casts the poison spells (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		public void Cast_Poison(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{//Poison
				SpellProp_Poison spp = new SpellProp_Poison();
				spp.init (EffectID,caster);
				SpellEffectPoison sep = (SpellEffectPoison)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				sep.Value=spp.BaseDamage;//Poison will damage the player for 100 hp over it's duration
				sep.counter=spp.counter; //It will run for x ticks. Ie 10 hp damage per tick
				if (caster.name!=GameWorldController.instance.playerUW.name)
				{
						sep.isNPC=true;
				}
				//	
				sep.Go ();
		}

		/// <summary>
		/// Casts the resistance against type spells (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		public void Cast_ResistanceAgainstType(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{
			SpellProp_ResistanceAgainstType resistProp = new SpellProp_ResistanceAgainstType();
			resistProp.init (EffectID,caster);
			SpellEffectResistanceAgainstType resistEffect = (SpellEffectResistanceAgainstType)SetSpellEffect(caster,ActiveSpellArray,EffectSlot,EffectID);
			//TODO:What properties to apply
			resistEffect.counter=resistProp.counter;
			resistEffect.Go();
		}

		/// <summary>
		/// Casts the paralyze spells (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		public void Cast_Paralyze(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{//Paralyze
				SpellProp_Mind mindspell = new SpellProp_Mind();
				mindspell.init (EffectID,caster);	
				SpellEffectParalyze sep = (SpellEffectParalyze)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				sep.counter=mindspell.counter; //It will run for x ticks. 
				if (caster.name!=GameWorldController.instance.playerUW.name)
				{
						sep.isNPC=true;
				}
				sep.Go ();
		}

		/// <summary>
		/// Casts the telekinesis spell generic
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		public void Cast_Telekinesis(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{//Telekenisis
				SpellProp_Mind mindspell = new SpellProp_Mind();
				mindspell.init (EffectID,caster);					
				SpellEffectTelekinesis setk = (SpellEffectTelekinesis)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				setk.counter=mindspell.counter; //It will run for x ticks. 
				setk.Go ();
		}	

		/// <summary>
		/// Casts the levitate spels (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		public void Cast_Levitate(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{//Levitate
				SpellProp_Movement flight = new SpellProp_Movement();
				flight.init (EffectID,caster);
				SpellEffectLevitate sep = (SpellEffectLevitate)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				sep.counter=flight.counter; 
				sep.Go ();
		}

		/// <summary>
		/// Casts the speed spells generic 
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		public void Cast_Speed(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{//Speed
				SpellProp_Movement movement = new SpellProp_Movement();
				movement.init (EffectID,caster);
				SpellEffectSpeed ses = (SpellEffectSpeed)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				ses.counter=movement.counter;
				ses.speedMultiplier=movement.Speed;
				ses.Go ();
		}	

		/// <summary>
		/// Casts the water walk spell (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		public void Cast_WaterWalk(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{//Waterwalk
				SpellProp_Movement movement = new SpellProp_Movement();
				movement.init (EffectID,caster);				
				SpellEffectWaterWalk seww = (SpellEffectWaterWalk)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				seww.counter=movement.counter; //It will run for x ticks. 
				seww.Go ();
		}


		/// <summary>
		/// Casts the maze navigation spell generic
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		public void Cast_MazeNavigation(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{
				SpellProp_Mind mindspell = new SpellProp_Mind();
				mindspell.init (EffectID,caster);				
				SpellEffectMazeNavigation sem = (SpellEffectMazeNavigation)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				sem.counter=mindspell.counter;
				sem.Go ();
		}

		/// <summary>
		/// Casts the cursed item spell (generic)
		/// </summary>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="EffectSlot">Effect slot.</param>
		public void Cast_CursedItem(GameObject caster, SpellEffect[] ActiveSpellArray, int EffectID, int EffectSlot)
		{//Cursed
				SpellProp_Curse curse = new SpellProp_Curse();
				curse.init (EffectID,caster);	
				SpellEffectCurse sep = (SpellEffectCurse)SetSpellEffect (caster, ActiveSpellArray,EffectSlot,EffectID);
				sep.counter=curse.counter; //It will run for x ticks. 
				if (caster.name!=GameWorldController.instance.playerUW.name)
				{
						sep.isNPC=true;
				}
				sep.Go ();
		}

		/* Utility code for Spells*/

		/// <summary>
		/// Spells incantation failure
		/// </summary>
		/// <param name="caster">Caster.</param>
		void SpellIncantationFailed(GameObject caster)
		{
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,212));
		}

		/// <summary>
		/// Gets a Random NPC target 
		/// </summary>
		/// <returns>The NPC target random.</returns>
		/// <param name="caster">Caster.</param>
		/// <param name="hit">RayCast to the found npc for line of sight tests</param>
		NPC GetNPCTargetRandom(GameObject caster, ref RaycastHit hit)
		{
				return GetNPCTargetRandom(caster,ref hit,0)	;
		}

		/// <summary>
		/// Gets a random npc target
		/// </summary>
		/// <returns>The NPC target random.</returns>
		/// <param name="caster">Caster.</param>
		/// <param name="hit">RayCast to the found npc for line of sight tests</param>
		/// <param name="isUndead">0=Any NPCs, 1=Just Undead, 2=Except Undead</param>
		NPC GetNPCTargetRandom(GameObject caster, ref RaycastHit hit, int isUndead)
		{//TODO: is it better to just pick an enemy and just try and launch an invisible projectile at them.
				//isUndead param
				//0 = any npc
				//1 = just undead
				//2 = except undead?
				//Targets a random NPC in the area of the npc and returns a raycast hit on the line of site
				Camera cam = caster.GetComponentInChildren<Camera>();//Camera.main;
				Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
				//Collider[] objectsInArea = Physics.OverlapSphere(caster.transform.position,10.0f);
				foreach (Collider Col in Physics.OverlapSphere(caster.transform.position,5.0f))
				{
						bool ValidNPCtype=false;
						if (Col.gameObject.GetComponent<NPC>()!=null)
						{
								switch (isUndead)				
								{
								case 0:
										ValidNPCtype=true;break;
								case 1:
										if(Col.gameObject.GetComponent<NPC>().isUndead==true)
										{ValidNPCtype=true;}
										break;
								case 2:
										if(Col.gameObject.GetComponent<NPC>().isUndead==false)
										{ValidNPCtype=true;}	
										break;
								}
								if (ValidNPCtype)
								{
										//Check if the NPC is in front of the camera.
										if (GeometryUtility.TestPlanesAABB(planes, Col.bounds))
										{
												Vector3 campos= Camera.main.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
												//Vector3 dirtonpc = campos-Col.gameObject.transform.position;

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
				}

				return null;
		}


		/// <summary>
		/// Creates and sets the spell effect on the array passed
		/// </summary>
		/// <returns>The spell effect created</returns>
		/// <param name="caster">Caster.</param>
		/// <param name="ActiveSpellArray">Active spell array.</param>
		/// <param name="index">Index.</param>
		/// <param name="EffectID">Effect I.</param>
		SpellEffect SetSpellEffect(GameObject caster, SpellEffect[] ActiveSpellArray, int index, int EffectID)
		{
				//Adds an effect to the player from a spell.
				//TODO:Validate this list versus all available spell effects
				//UWCharacter playerUW= caster.GetComponent<UWCharacter>();

				switch (EffectID)
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
						break;
				case SpellEffect.UW1_Spell_Effect_Levitate:
				case SpellEffect.UW1_Spell_Effect_Levitate_alt01:
				case SpellEffect.UW1_Spell_Effect_Levitate_alt02:
				case SpellEffect.UW1_Spell_Effect_Fly:
				case SpellEffect.UW1_Spell_Effect_Fly_alt01:
				case SpellEffect.UW1_Spell_Effect_Fly_alt02:						
						ActiveSpellArray[index]=caster.AddComponent<SpellEffectLevitate>();
						break;
				case SpellEffect.UW1_Spell_Effect_WaterWalk:
				case SpellEffect.UW1_Spell_Effect_WaterWalk_alt01:
				case SpellEffect.UW1_Spell_Effect_WaterWalk_alt02:
						ActiveSpellArray[index]=caster.AddComponent<SpellEffectWaterWalk>();
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
				case SpellEffect.UW1_Spell_Effect_Invisibilty:
				case SpellEffect.UW1_Spell_Effect_Invisibility_alt01:
				case SpellEffect.UW1_Spell_Effect_Invisibility_alt02:						
						ActiveSpellArray[index]=caster.AddComponent<SpellEffectStealth>();
						//Todo
						break;

						//Missiles
				case SpellEffect.UW1_Spell_Effect_MissileProtection:
				case SpellEffect.UW1_Spell_Effect_MissileProtection_alt01:
				case SpellEffect.UW1_Spell_Effect_MissileProtection_alt02:

						//Magic
				case SpellEffect.UW1_Spell_Effect_MagicProtection:
				case SpellEffect.UW1_Spell_Effect_GreaterMagicProtection:

						ActiveSpellArray[index]=caster.AddComponent<SpellEffectResistanceAgainstType>();
						//Todo
						break;
						//Flames
				case SpellEffect.UW1_Spell_Effect_Flameproof:
				case SpellEffect.UW1_Spell_Effect_Flameproof_alt01:
				case SpellEffect.UW1_Spell_Effect_Flameproof_alt02:
						ActiveSpellArray[index]=caster.AddComponent<SpellEffectFlameproof>();
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
				case SpellEffect.UW1_Spell_Effect_CauseFear:
				case SpellEffect.UW1_Spell_Effect_CauseFear_alt01:	
						ActiveSpellArray[index]=caster.AddComponent<SpellEffectFear>();
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
				case SpellEffect.UW1_Spell_Effect_RoamingSight:
				case SpellEffect.UW1_Spell_Effect_RoamingSight_alt01:
				case SpellEffect.UW1_Spell_Effect_RoamingSight_alt02:
						ActiveSpellArray[index]=caster.AddComponent<SpellEffectRoamingSight>();
						break;		
				case SpellEffect.UW1_Spell_Effect_Curse:
				case SpellEffect.UW1_Spell_Effect_Curse_alt01:
				case SpellEffect.UW1_Spell_Effect_Curse_alt02:
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
						ActiveSpellArray[index]=caster.AddComponent<SpellEffectCurse>();
						break;		
				default:
						Debug.Log ("effect Id is " + EffectID);
						ActiveSpellArray[index]=caster.AddComponent<SpellEffect>();
						break;

				}

				ActiveSpellArray[index].EffectID=EffectID;
				return ActiveSpellArray[index];
		}

		/// <summary>
		/// Finds the first free spell effect slot for the caster.
		/// </summary>
		/// <returns> If unable to find it returns -1 otherwise the array index.</returns>
		/// <param name="caster">Caster.</param>
		int CheckActiveSpellEffect(GameObject caster)
		{
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

		/// <summary>
		/// Finds the first free passive spell effect slot for the player character.
		/// </summary>
		/// <returns>If unable to find it returns -1 otherwise the array index</returns>
		/// <param name="caster">Caster.</param>
		int CheckPassiveSpellEffectPC(GameObject caster)
		{				
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

		/// <summary>
		/// Finds the first free passive spell effect slot for an NPC.
		/// </summary>
		/// <returns>If unable to find it returns -1 otherwise the array index</returns>
		/// <param name="caster">Caster.</param>
		int CheckPassiveSpellEffectNPC(GameObject caster)
		{//Finds the first free spell effect slot for the caster. If unable to find it returns -1
				if (caster==null)
				{
						return -1;
				}
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

		/// <summary>
		/// Casts a magic projectile.
		/// </summary>
		/// <returns><c>true</c>, if projectile was cast, <c>false</c> otherwise.</returns>
		/// <param name="caster">Caster.</param>
		/// <param name="spellprop">Properties for the projectile.</param>
		bool CastProjectile(GameObject caster, SpellProp spellprop)
		{//Fires off the projectile
				UWCharacter playerUWLocal = caster.GetComponent<UWCharacter>();
				if (playerUWLocal !=null)
				{
						Ray ray = getRay (caster);
						RaycastHit hit = new RaycastHit(); 
						float dropRange=0.5f;
						if (!Physics.Raycast(ray,out hit,dropRange))
						{//No object interferes with the spellcast
								//float force = 200.0f;
								ReadiedSpell= "";
								for (int i=0;i<spellprop.noOfCasts;i++)
								{
										GameObject projectile = CreateMagicProjectile(ray.GetPoint(dropRange/2.0f), caster,spellprop);
										projectile.transform.rotation=Quaternion.LookRotation(ray.direction.normalized);
										LaunchProjectile(projectile,ray,dropRange,spellprop.Force,spellprop.spread);										
								}

								UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
								return true;
						}
						return false;
				}
				else
				{//Is being cast by an npc or a spell trap
						//float force = 200.0f;
						for (int i=0;i<spellprop.noOfCasts;i++)
						{
							GameObject projectile = CreateMagicProjectile(caster.GetComponent<ObjectInteraction>().GetImpactPoint(), caster.GetComponent<ObjectInteraction>().GetImpactGameObject(),spellprop);
							LaunchProjectile(projectile,spellprop.Force);
						}
						return true;
				}
		}	

		/// <summary>
		/// Casts the projectile at the target
		/// </summary>
		/// <returns><c>true</c>, if projectile was cast, <c>false</c> otherwise.</returns>
		/// <param name="caster">Caster.</param>
		/// <param name="target">Target.</param>
		/// <param name="spellprop">Properties for the projectile.</param>
		bool CastProjectile(GameObject caster, GameObject target, SpellProp spellprop)
		{//Fires off the projectile at a gameobject.
				GameObject projectile = CreateMagicProjectile(caster.transform.position, caster, spellprop);
				Vector3 direction;
				if (spellprop.spread==0)
				{
						direction = (target.transform.position-caster.transform.position);
						direction.Normalize();
						//LaunchProjectile(projectile,spellprop.Force,direction);	
				}
				else
				{
						//From http://answers.unity3d.com/questions/467742/how-can-i-create-raycast-bullet-innaccuracy-as-a-c.html
						//Start

						//  Try this one first, before using the second one
						//  The Ray-hits will form a ring
						//float randomRadius = spellprop.spread;            
						//  The Ray-hits will be in a circular area
						float randomRadius = Random.Range( 0, spellprop.spread );        

						float randomAngle = Random.Range ( 0, 2 * Mathf.PI );

						//Calculating the raycast direction
						direction = new Vector3(
								randomRadius * Mathf.Cos( randomAngle ),
								randomRadius * Mathf.Sin( randomAngle ),
								10f
						);

						//Make the direction match the transform
						//It is like converting the Vector3.forward to transform.forward
						direction = projectile.transform.TransformDirection( direction.normalized );
						//End	
				}
				LaunchProjectile(projectile,spellprop.Force,direction);	
				return true;
		}	

		/// <summary>
		/// Casts the projectile along a vector
		/// </summary>
		/// <returns><c>true</c>, if projectile was cast, <c>false</c> otherwise.</returns>
		/// <param name="caster">Caster.</param>
		/// <param name="targetV">Target v.</param>
		/// <param name="spellprop">Properties for the projectile.</param>
		bool CastProjectile(GameObject caster, Vector3 targetV, SpellProp spellprop)
		{//Fires off the projectile at a vector3 position.
				//float force = ;//200.0f;
				GameObject projectile = CreateMagicProjectile(caster.transform.position, caster,spellprop);
				//Vector3 direction = (targetV-caster.transform.position);
				//direction.Normalize();
				LaunchProjectile(projectile,spellprop.Force,targetV);
				return true;
		}	


		/// <summary>
		/// Creates the magic projectile.
		/// </summary>
		/// <returns>The magic projectile.</returns>
		/// <param name="Location">Location.</param>
		/// <param name="Caster">Caster.</param>
		/// <param name="spellprop">Properties for the projectile.</param>
		GameObject CreateMagicProjectile(Vector3 Location, GameObject Caster, SpellProp spellprop)
		{//Creates the projectile.
				int index;
				//Create an object info
				GameWorldController.instance.CurrentObjectList().getFreeSlot(256, out index);
				ObjectLoaderInfo oli = GameWorldController.instance.CurrentObjectList().objInfo[index];
				oli.item_id=spellprop.ProjectileItemId;

				GameObject projectile = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),oli,GameWorldController.instance.LevelMarker().gameObject,Location).gameObject;
				projectile.layer = LayerMask.NameToLayer("MagicProjectile");
				projectile.name = "MagicProjectile_" + SummonCount++;
				projectile.transform.parent=GameWorldController.instance.LevelMarker();
				GameWorldController.MoveToWorld(projectile);
				//ObjectInteraction.CreateObjectGraphics(projectile,spellprop.ProjectileSprite,true);


				MagicProjectile mgp = projectile.AddComponent<MagicProjectile>();
				mgp.spellprop=spellprop;

				if (Caster.name.Contains("NPC_Launcher"))
				{
						mgp.caster=Caster.transform.parent.gameObject;
				}
				else
				{
						mgp.caster=Caster;
				}

				BoxCollider box = projectile.GetComponent<BoxCollider>();
				box.size = new Vector3(0.2f,0.2f,0.2f);
				box.center= new Vector3(0.0f,0.1f,0.0f);
				Rigidbody rgd = projectile.GetComponent<Rigidbody>();
				rgd.freezeRotation =true;
				GameWorldController.UnFreezeMovement(projectile);
				rgd.useGravity=false;

				rgd.collisionDetectionMode=CollisionDetectionMode.Continuous;
				if (Caster.name!=GameWorldController.instance.playerUW.name)
				{
						projectile.transform.position=Caster.transform.position;
						projectile.transform.rotation=Caster.transform.rotation;
				}	
				else
				{
						projectile.transform.position=Location;
				}
				return projectile;
		}


		/// <summary>
		/// Launchs the projectile.
		/// </summary>
		/// <param name="projectile">Projectile.</param>
		/// <param name="ray">Ray.</param>
		/// <param name="dropRange">How far away from the caster to launch</param>
		/// <param name="force">Force of the projectile</param>
		/// <param name="spread">Spread radius</param>
		void LaunchProjectile(GameObject projectile, Ray ray,float dropRange, float force,float spread)
		{
				//Vector3 ThrowDir = ray.GetPoint(dropRange)  - (projectile.transform.position);
			//	Vector3 ThrowDir = ray.GetPoint(dropRange)  - ray.origin;

				//From http://answers.unity3d.com/questions/467742/how-can-i-create-raycast-bullet-innaccuracy-as-a-c.html
				//Start

				//  Try this one first, before using the second one
				//  The Ray-hits will form a ring
				//float randomRadius = spread;            
				//  The Ray-hits will be in a circular area
				float randomRadius = Random.Range( 0, spread );        

				float randomAngle = Random.Range ( 0, 2 * Mathf.PI );

				//Calculating the raycast direction
				Vector3 direction = new Vector3(
						randomRadius * Mathf.Cos( randomAngle ),
						randomRadius * Mathf.Sin( randomAngle ),
						10f
				);
				//direction= ray.direction+direction;
				//Make the direction match the transform
				//It is like converting the Vector3.forward to transform.forward
				direction = projectile.transform.TransformDirection( direction.normalized );
				//End	

				projectile.GetComponent<Rigidbody>().AddForce(direction*force);




				//	projectile.GetComponent<Rigidbody>().AddForce(ThrowDir*force);
		}

		/// <summary>
		/// Launchs the projectile directly forward
		/// </summary>
		/// <param name="projectile">Projectile.</param>
		/// <param name="force">Force to apply to the projectile</param>
		void LaunchProjectile(GameObject projectile, float force)
		{//Launch directly forward
				projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward*force);
		}

		/// <summary>
		/// Launchs the projectile along the specified vector
		/// </summary>
		/// <param name="projectile">Projectile.</param>
		/// <param name="force">Force.</param>
		/// <param name="direction">Direction to launch the projectile in</param>
		void LaunchProjectile (GameObject projectile, float force, Vector3 direction)
		{
				projectile.GetComponent<Rigidbody>().AddForce (direction*force);
		}

		/// <summary>
		/// Handles pressing Q to cast the current spell runes
		/// </summary>
		void OnGUI()
		{
			if ((WindowDetectUW.InMap==true) || (WindowDetectUW.WaitingForInput) || (Conversation.InConversation)){return;}
			if (
					(Event.current.Equals(Event.KeyboardEvent("q")))
					&&
					(UWHUD.instance.window.JustClicked==false)
					&&
					((playerUW.PlayerCombat.AttackCharging==false) && (playerUW.PlayerCombat.AttackExecuting==false))
			)
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

		/// <summary>
		/// Gets a raycast from the player
		/// </summary>
		/// <returns>The ray</returns>
		/// <param name="caster">Caster.</param>
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


		/// <summary>
		/// Casts the enchantment immediately
		/// </summary>
		/// <returns>The enchantment immediate.</returns>
		/// <param name="caster">Caster.</param>
		/// <param name="target">Target.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="SpellRule">What spell rule is applicable</param>
		public SpellEffect CastEnchantmentImmediate(GameObject caster, GameObject target, int EffectID, int SpellRule)
		{//Either cast enchantment now or skip straight to fire off a readied spell.
				return CastEnchantment (caster,target,EffectID,false,SpellRule);
		}

		/// <summary>
		/// Casts the enchantment that may need readying
		/// </summary>
		/// <returns>The enchantment.</returns>
		/// <param name="caster">Caster.</param>
		/// <param name="target">Target.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="SpellRule">What spell rule is applicable</param>
		public SpellEffect CastEnchantment(GameObject caster, GameObject target, int EffectID, int SpellRule)
		{//Either cast enchantment now or ready it for casting.
				return CastEnchantment (caster,target,EffectID,true,SpellRule);
		}

		/// <summary>
		/// Casts the enchantment based on the spell rules, targets and ready state
		/// </summary>
		/// <returns>The enchantment applied</returns>
		/// <param name="caster">Caster.</param>
		/// <param name="target">Target.</param>
		/// <param name="EffectID">Effect ID of the spell</param>
		/// <param name="ready">If set to <c>true</c> ready.</param>
		/// <param name="SpellRule">Spell rule to apply.</param>
		/// Spells cast from anything that carries and enchantment.
		public SpellEffect CastEnchantment(GameObject caster, GameObject target, int EffectID, bool ready, int SpellRule)
		{//Eventually casts spells from things like fountains, potions, enchanted weapons.
			//TODO: The switch statement may need to be further divided because of passive/active effects.
			//TODO: this list may be incomplete. I need to include things from my spreadsheet that are not status effects.
			//UWCharacter playerUW = caster.GetComponent<UWCharacter>();
			int ActiveArrayIndex=-1;
			int PassiveArrayIndex=-1;
			int SpellResultType= SpellResultNone;//0=no spell effect, 1= passive spell effect, 2= active spell effect.
			SpellEffect[] other=null;

			if (SpellRule!=SpellRule_TargetVector)
			{	
					ActiveArrayIndex= playerUW.PlayerMagic.CheckActiveSpellEffect(caster);
					PassiveArrayIndex= playerUW.PlayerMagic.CheckPassiveSpellEffectPC(caster);

					if (target!=null)
					{
							PassiveArrayIndex=CheckPassiveSpellEffectNPC(target);//Was other.
							if (target.GetComponent<NPC>()!=null)
							{
									other= target.GetComponent<NPC>().NPCStatusEffects;
							}
					}
			}


			switch (EffectID)
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
						//Only ever heal the player
						Cast_Heal (caster,EffectID);//Get seperate values;
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_ManaBoost:
				case SpellEffect.UW1_Spell_Effect_ManaBoost_alt01:
				case SpellEffect.UW1_Spell_Effect_ManaBoost_alt02:
				case SpellEffect.UW1_Spell_Effect_ManaBoost_alt03:
				case SpellEffect.UW1_Spell_Effect_ManaBoost_alt04:
				case SpellEffect.UW1_Spell_Effect_RestoreMana_alt04:
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
						//Only ever regen the player
						Cast_Mana(caster,EffectID);
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_Darkness:
				case SpellEffect.UW1_Spell_Effect_BurningMatch:
				case SpellEffect.UW1_Spell_Effect_Candlelight:
				case SpellEffect.UW1_Spell_Effect_Light:
				case SpellEffect.UW1_Spell_Effect_Daylight:
				case SpellEffect.UW1_Spell_Effect_Sunlight:			

						//These need to have different values. Create a system of unique values array(?)
						//Only the player needs light.
						if (ActiveArrayIndex!=-1)
						{
								Cast_Light(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;

				case SpellEffect.UW1_Spell_Effect_MagicLantern:
				case SpellEffect.UW1_Spell_Effect_Light_alt01:
				case SpellEffect.UW1_Spell_Effect_Daylight_alt01:
				case SpellEffect.UW1_Spell_Effect_Light_alt02:
				case SpellEffect.UW1_Spell_Effect_Daylight_alt02:
						if (PassiveArrayIndex!=-1)
						{
								Cast_Light(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;
						}
						break;


				case SpellEffect.UW1_Spell_Effect_Leap:
						if (PassiveArrayIndex!=-1)
						{
								Cast_Leap(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
						}
						SpellResultType=SpellResultPassive;
						break;
				case SpellEffect.UW1_Spell_Effect_Leap_alt01:
				case SpellEffect.UW1_Spell_Effect_Leap_alt02:
						//TODO: Find out which one of these is a magic ring effect!
						//Player only
						if (ActiveArrayIndex!=-1)
						{
								Cast_Leap(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;

				case SpellEffect.UW1_Spell_Effect_SlowFall:
						//Player only
						if (ActiveArrayIndex!=-1)
						{
							Cast_SlowFall(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
							SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_SlowFall_alt01:
				case SpellEffect.UW1_Spell_Effect_SlowFall_alt02:
						if (PassiveArrayIndex!=-1)
						{
							Cast_SlowFall(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
							SpellResultType=SpellResultPassive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_Levitate:
				case SpellEffect.UW1_Spell_Effect_Fly:
						if (PassiveArrayIndex!=-1)
						{
								Cast_Levitate(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_Fly_alt01:
				case SpellEffect.UW1_Spell_Effect_Levitate_alt01:						
				case SpellEffect.UW1_Spell_Effect_Levitate_alt02:
				case SpellEffect.UW1_Spell_Effect_Fly_alt02:
						if (ActiveArrayIndex!=-1)
						{
								Cast_Levitate(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_WaterWalk:
						if (ActiveArrayIndex!=-1)
						{
								Cast_WaterWalk(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_WaterWalk_alt01:
				case SpellEffect.UW1_Spell_Effect_WaterWalk_alt02:
						if (PassiveArrayIndex!=-1)
						{
								Cast_WaterWalk(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;
						}
						break;					

				case SpellEffect.UW1_Spell_Effect_ResistBlows:
				case SpellEffect.UW1_Spell_Effect_ThickSkin:
				case SpellEffect.UW1_Spell_Effect_IronFlesh:
						{
								if (PassiveArrayIndex!=-1)
								{
										Cast_Resistance(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
										SpellResultType=SpellResultPassive;
								}

								break;
						}
				case SpellEffect.UW1_Spell_Effect_ResistBlows_alt01:
				case SpellEffect.UW1_Spell_Effect_ThickSkin_alt01:
				case SpellEffect.UW1_Spell_Effect_IronFlesh_alt01:
				case SpellEffect.UW1_Spell_Effect_ResistBlows_alt02:
				case SpellEffect.UW1_Spell_Effect_ThickSkin_alt02:
				case SpellEffect.UW1_Spell_Effect_IronFlesh_alt02:
						{
								if (ActiveArrayIndex!=-1)
								{
										Cast_Resistance(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
										SpellResultType=SpellResultActive;
								}
								break;
						}


				case SpellEffect.UW1_Spell_Effect_Stealth:
				case SpellEffect.UW1_Spell_Effect_Conceal:
				case SpellEffect.UW1_Spell_Effect_Invisibilty:
						//PLayer only
						if (ActiveArrayIndex!=-1)
						{
								Cast_Stealth(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_Stealth_alt01:
				case SpellEffect.UW1_Spell_Effect_Conceal_alt01:
				case SpellEffect.UW1_Spell_Effect_Stealth_alt02:
				case SpellEffect.UW1_Spell_Effect_Conceal_alt02:
				case SpellEffect.UW1_Spell_Effect_Invisibility_alt01:
				case SpellEffect.UW1_Spell_Effect_Invisibility_alt02:						
						//PLayer only
						if (PassiveArrayIndex!=-1)
						{
								Cast_Stealth(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;
						}
						break;
						//Missiles
				case SpellEffect.UW1_Spell_Effect_MissileProtection:
						if (ActiveArrayIndex!=-1)
						{
								Cast_ResistanceAgainstType(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_MissileProtection_alt01:
				case SpellEffect.UW1_Spell_Effect_MissileProtection_alt02:
						if (PassiveArrayIndex!=-1)
						{
								Cast_ResistanceAgainstType(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;	
						}
						break;

						//Flameproof. PLayer only.
				case SpellEffect.UW1_Spell_Effect_Flameproof:
						if (ActiveArrayIndex!=-1)
						{
								Cast_Flameproof(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_Flameproof_alt01:
				case SpellEffect.UW1_Spell_Effect_Flameproof_alt02:
						if (PassiveArrayIndex!=-1)
						{
								Cast_Flameproof(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;
						}
						break;
						//Magic
				case SpellEffect.UW1_Spell_Effect_MagicProtection:
				case SpellEffect.UW1_Spell_Effect_GreaterMagicProtection:
						//player only
						if (PassiveArrayIndex!=-1)
						{
							Cast_ResistanceAgainstType(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
							SpellResultType=SpellResultPassive;
						}

						break;
				case SpellEffect.UW1_Spell_Effect_PoisonResistance:
						//player only
						Debug.Log ("Poison Resistance enchantment");
						SpellResultType=SpellResultNone;
						break;
				case SpellEffect.UW1_Spell_Effect_Speed:
				case SpellEffect.UW1_Spell_Effect_Haste:
						//player only
						if (ActiveArrayIndex!=-1)
						{
								Cast_Speed(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_Telekinesis:

						//player only
						if (ActiveArrayIndex!=-1)
						{
								Cast_Telekinesis(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_Telekinesis_alt01:
				case SpellEffect.UW1_Spell_Effect_Telekinesis_alt02:
						if (PassiveArrayIndex!=-1)
						{
								Cast_Telekinesis(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;
						}
						break;

				case SpellEffect.UW1_Spell_Effect_FreezeTime:
						//Active variation.
						if (ActiveArrayIndex!=-1)
						{
								Cast_FreezeTime(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_FreezeTime_alt01:
				case SpellEffect.UW1_Spell_Effect_FreezeTime_alt02:
						//player only
						if (PassiveArrayIndex!=-1)
						{
								Cast_FreezeTime(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;
						}
						//Cast_AnTym(target,EffectID);
					//	SpellResultType=SpellResultNone;

						break;
				case SpellEffect.UW1_Spell_Effect_Regeneration:
						//player only
						Debug.Log ("Regen enchantment");
						SpellResultType=SpellResultNone;
						break;
				case SpellEffect.UW1_Spell_Effect_ManaRegeneration:
						//player only
						Debug.Log ("mana regen enchantment");
						SpellResultType=SpellResultNone;
						break;
				case SpellEffect.UW1_Spell_Effect_MazeNavigation:
						//player only
						//Debug.Log ("Maze Navigation enchantment");
						if (PassiveArrayIndex!=-1)
						{
								Cast_MazeNavigation(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;
						}
						break;			
				case SpellEffect.UW1_Spell_Effect_Hallucination:
						//player only
						Cast_Hallucination(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
						SpellResultType=SpellResultPassive;
						break;
				case SpellEffect.UW1_Spell_Effect_NightVision:
						if (ActiveArrayIndex!=-1)
						{
								Cast_NightVision(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultActive;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_NightVision_alt01:
				case SpellEffect.UW1_Spell_Effect_NightVision_alt02:
						if (PassiveArrayIndex!=-1)
						{
								Cast_NightVision(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
								SpellResultType=SpellResultPassive;
						}	
						break;
				case SpellEffect.UW1_Spell_Effect_Poison:
				case SpellEffect.UW1_Spell_Effect_Poison_alt01:
				case SpellEffect.UW1_Spell_Effect_PoisonHidden:
						//Can effect player and npc
						switch(SpellRule)
						{
						case SpellRule_TargetOther:
								if (target!=null)
								{
										if (PassiveArrayIndex!=-1)
										{
												Cast_Poison (target,other,EffectID,PassiveArrayIndex);SpellResultType=SpellResultNone;
										}
								}break;
						case SpellRule_TargetSelf:
								if (PassiveArrayIndex!=-1)
								{
										Cast_Poison (caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);SpellResultType=SpellResultPassive;
								}break;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_Paralyze:
				case SpellEffect.UW1_Spell_Effect_Paralyze_alt01:
						//Can effect player and npc
						//TODO: does this spell work from wands and the like. If so do I need to figure out targetting.
						//Enchantment spells come in as target self. Presumably there is one version that is player paralyzes themselves
						//and another where it is get random target. For now paralyze self :)
						switch(SpellRule)
						{
						case SpellRule_TargetOther:
								if (target!=null)
								{
										if (PassiveArrayIndex!=-1)
										{
												Cast_Paralyze (target,other,EffectID,PassiveArrayIndex);SpellResultType=SpellResultNone;
										}
								}break;
						case SpellRule_TargetSelf:
								if (PassiveArrayIndex!=-1)
								{
										Cast_Paralyze (caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);SpellResultType=SpellResultPassive;
								}
								break;
						}
						break;
				case SpellEffect.UW1_Spell_Effect_Ally:
				case SpellEffect.UW1_Spell_Effect_Ally_alt01:
						//NPC only
						Cast_InManiRel(caster,EffectID);
						SpellResultType=SpellResultNone;
						break;
				case SpellEffect.UW1_Spell_Effect_Confusion:
				case SpellEffect.UW1_Spell_Effect_Confusion_alt01:
						//NPC only
						Cast_VasAnWis(caster,EffectID);
						SpellResultType=SpellResultNone;
						break;
				case SpellEffect.UW1_Spell_Effect_MinorAccuracy:
				case SpellEffect.UW1_Spell_Effect_Accuracy:
				case SpellEffect.UW1_Spell_Effect_AdditionalAccuracy:
				case SpellEffect.UW1_Spell_Effect_MajorAccuracy:
				case SpellEffect.UW1_Spell_Effect_GreatAccuracy:
				case SpellEffect.UW1_Spell_Effect_VeryGreatAccuracy:
				case SpellEffect.UW1_Spell_Effect_TremendousAccuracy:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedAccuracy:
						//Applies to weapon only do not implement here.
						Debug.Log ("accuracy enchantment");
						SpellResultType=SpellResultNone;
						break;
				case SpellEffect.UW1_Spell_Effect_MinorDamage:
				case SpellEffect.UW1_Spell_Effect_Damage:
				case SpellEffect.UW1_Spell_Effect_AdditionalDamage:
				case SpellEffect.UW1_Spell_Effect_MajorDamage:
				case SpellEffect.UW1_Spell_Effect_GreatDamage:
				case SpellEffect.UW1_Spell_Effect_VeryGreatDamage:
				case SpellEffect.UW1_Spell_Effect_TremendousDamage:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedDamage:
						//Applies to weapon only do not implement here.
						SpellResultType=SpellResultNone;
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
						//Applies to armour only do not implement here.
						SpellResultType=SpellResultNone;
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
						//Applies to armour only do not implement here.
						SpellResultType=SpellResultNone;
						Debug.Log ("toughness enchantment");
						break;



				case SpellEffect.UW1_Spell_Effect_Open:
				case SpellEffect.UW1_Spell_Effect_Open_alt01:
						//Cast spell/no spell effect
						Cast_ExYlem(caster,ready,EffectID);
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_CreateFood:
				case SpellEffect.UW1_Spell_Effect_CreateFood_alt01:
						//Cast spell/no spell effect
						Cast_InManiYlem(caster,EffectID);
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_CurePoison:
				case SpellEffect.UW1_Spell_Effect_CurePoison_alt01:
						//Cast spell/no spell effect
						Cast_AnNox(caster,EffectID);
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_SheetLightning:
				case SpellEffect.UW1_Spell_Effect_SheetLightning_alt01:						
						if (SpellRule!=SpellRule_TargetVector)
						{
								Cast_VasOrtGrav(caster,EffectID);
						}
						else
						{
								SpellProp_SheetLightning spVOG =new SpellProp_SheetLightning();
								spVOG.init (EffectID,caster);
								CastProjectile(caster,GetBestSpellVector(caster),(SpellProp)spVOG);
						}
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_Armageddon:
				case SpellEffect.UW1_Spell_Effect_Armageddon_alt01:
						//Cast spell/no spell effect
						Cast_VasKalCorp(caster,EffectID);
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_GateTravel:
				case SpellEffect.UW1_Spell_Effect_GateTravel_alt01:
						//Cast spell/no spell effect
						Cast_VasRelPor(caster,EffectID);
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_MagicArrow:
				case SpellEffect.UW1_Spell_Effect_MagicArrow_alt01:
						if (SpellRule!=SpellRule_TargetVector)
						{
								Cast_OrtJux(caster,ready,EffectID);
						}
						else
						{
								SpellProp_MagicArrow spOJ =new SpellProp_MagicArrow();
								spOJ.init (EffectID,caster);
								CastProjectile(caster,GetBestSpellVector(caster), (SpellProp)spOJ);
						}
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_ElectricalBolt:
				case SpellEffect.UW1_Spell_Effect_ElectricalBolt_alt01:						
						{
								if (SpellRule!=SpellRule_TargetVector)
								{
										Cast_OrtGrav(caster,ready,EffectID);
								}
								else
								{
										SpellProp_ElectricBolt spOG =new SpellProp_ElectricBolt();
										spOG.init (EffectID,caster);
										CastProjectile(caster,GetBestSpellVector(caster), (SpellProp)spOG);
								}
								SpellResultType=SpellResultNone;
								break;
						}
				case SpellEffect.UW1_Spell_Effect_Fireball:
				case SpellEffect.UW1_Spell_Effect_Fireball_alt01:						
						{
								if (SpellRule!=SpellRule_TargetVector)
								{
										Cast_PorFlam(caster,ready,EffectID);
								}
								else
								{
										SpellProp_Fireball spPF =new SpellProp_Fireball();
										spPF.init (EffectID,caster);
										spPF.caster=caster;
										CastProjectile(caster,GetBestSpellVector(caster),(SpellProp)spPF);
								}
								SpellResultType=SpellResultNone;
								break;
						}

				case SpellEffect.UW1_Spell_Effect_FlameWind:
				case SpellEffect.UW1_Spell_Effect_FlameWind_alt01:						
						{
								if (SpellRule!=SpellRule_TargetVector)
								{
										Cast_FlamHur(caster,EffectID);
								}
								else
								{
										SpellProp_FlameWind spFH =new SpellProp_FlameWind();
										spFH.init (EffectID,caster);
										CastProjectile(caster,GetBestSpellVector(caster), (SpellProp)spFH);
								}
								SpellResultType=SpellResultNone;
								break;
						}
				case SpellEffect.UW1_Spell_Effect_RoamingSight:						
				case SpellEffect.UW1_Spell_Effect_RoamingSight_alt01:
				case SpellEffect.UW1_Spell_Effect_RoamingSight_alt02:
						{
								Cast_RoamingSight(caster,playerUW.ActiveSpell,EffectID,ActiveArrayIndex);
								SpellResultType=SpellResultNone;
								break;
						}
				case SpellEffect.UW1_Spell_Effect_RuneofWarding:
				case SpellEffect.UW1_Spell_Effect_RuneofWarding_alt01:						
						{
								Cast_RuneOfWarding(caster.transform.position + (transform.forward * 0.3f),EffectID);
								SpellResultType=SpellResultNone;							
								break;
						}
				case SpellEffect.UW1_Spell_Effect_StrengthenDoor:
				case SpellEffect.UW1_Spell_Effect_StrengthenDoor_alt01:						
						{
								Cast_SanctJux(caster,ready,EffectID);
								SpellResultType=SpellResultNone;	
								break;
						}
				case SpellEffect.UW1_Spell_Effect_Tremor:
				case SpellEffect.UW1_Spell_Effect_Tremor_alt01:
						{
								Cast_VasPorYlem(caster,EffectID);	
								SpellResultType=SpellResultNone;	
								break;
						}	
				case SpellEffect.UW1_Spell_Effect_SummonMonster:
				case SpellEffect.UW1_Spell_Effect_SummonMonster_alt01:		
						{
								Cast_KalMani(caster,EffectID);
								SpellResultType=SpellResultNone;
								break;
						}
				case SpellEffect.UW1_Spell_Effect_CauseFear:
				case SpellEffect.UW1_Spell_Effect_CauseFear_alt01:						
						{
								Cast_QuasCorp(caster,EffectID);
								SpellResultType=SpellResultNone;
								break;
						}
				case SpellEffect.UW1_Spell_Effect_SmiteUndead:
				case SpellEffect.UW1_Spell_Effect_SmiteUndead_alt01:						
						{
								Cast_AnCorpMani(caster,EffectID);
								SpellResultType=SpellResultNone;
								break;
						}



				case SpellEffect.UW1_Spell_Effect_DetectMonster:
				case SpellEffect.UW1_Spell_Effect_DetectMonster_alt01:						
						{
								Cast_DetectMonster(caster,EffectID);
								SpellResultType=SpellResultNone;
								break;
						}

				case SpellEffect.UW1_Spell_Effect_NameEnchantment:
				case SpellEffect.UW1_Spell_Effect_NameEnchantment_alt01:						
						{
								Cast_NameEnchantment(caster,ready,EffectID);
								SpellResultType=SpellResultNone;
								break;
						}

				case SpellEffect.UW1_Spell_Effect_Curse:
				case SpellEffect.UW1_Spell_Effect_Curse_alt01:
				case SpellEffect.UW1_Spell_Effect_Curse_alt02:
					
						{
								Cast_Curse(caster,EffectID);
								SpellResultType=SpellResultNone;
								break;							
						}

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
						//Affect player from cursed items
						if (PassiveArrayIndex!=-1)
						{
							Cast_CursedItem(caster,playerUW.PassiveSpell,EffectID,PassiveArrayIndex);
							SpellResultType=SpellResultPassive;
														
						}
						break;
				case SpellEffect.UW1_Spell_Effect_RemoveTrap:
				case SpellEffect.UW1_Spell_Effect_RemoveTrap_alt01:

						/*?*/

				case SpellEffect.UW1_Spell_Effect_SetGuard://?

						//Cursed items? Apply spell effect to playe




				case SpellEffect.UW1_Spell_Effect_Reveal_alt01:



						/*test*/
				case SpellEffect.UW1_Spell_Effect_Reveal:

						/*Blank*/



				case SpellEffect.UW1_Spell_Effect_MassParalyze:
				case SpellEffect.UW1_Spell_Effect_Acid_alt01:
				case SpellEffect.UW1_Spell_Effect_LocalTeleport_alt01:
						//Cast spell/no spell effect
						SpellResultType=SpellResultNone;
						break;

				case SpellEffect.UW1_Spell_Effect_theFrog:
						//Debug.Log ("The frog");
						//PC only
						CastTheFrog(caster,EffectID);
						SpellResultType=SpellResultNone;
						break;

						//Some cutscences can be played by a spell trap these are as follows (some known cases)
				case 224:
						//Debug.Log ("play the intro cutscene");
						Cutscene_Intro ci = UWHUD.instance.gameObject.AddComponent<Cutscene_Intro>();
						UWHUD.instance.CutScenesFull.cs=ci;
						UWHUD.instance.CutScenesFull.Begin();
						break;
				case 225:
						Cutscene_EndGame ce = UWHUD.instance.gameObject.AddComponent<Cutscene_EndGame>();
						UWHUD.instance.CutScenesFull.cs=ce;
						UWHUD.instance.CutScenesFull.Begin();
						break;
				case 226:
						Cutscene_Tybal ct = UWHUD.instance.gameObject.AddComponent<Cutscene_Tybal>();
						UWHUD.instance.CutScenesFull.cs=ct;
						UWHUD.instance.CutScenesFull.Begin();
						break;
				case 227:
						Cutscene_Arial ca = UWHUD.instance.gameObject.AddComponent<Cutscene_Arial>();
						UWHUD.instance.CutScenesFull.cs=ca;
						UWHUD.instance.CutScenesFull.Begin();
						break;
				case 233:
						Cutscene_Splash cs = UWHUD.instance.gameObject.AddComponent<Cutscene_Splash>();
						UWHUD.instance.CutScenesFull.cs=cs;
						UWHUD.instance.CutScenesFull.Begin();
						break;
				case 234:
						Cutscene_Credits cc = UWHUD.instance.gameObject.AddComponent<Cutscene_Credits>();
						UWHUD.instance.CutScenesFull.cs=cc;
						UWHUD.instance.CutScenesFull.Begin();
						break;
				case 235:
						Debug.Log ("Vision - IN");
						break;
				case 236:
						Debug.Log ("Vision - SA");
						break;
				case 237:
						Debug.Log ("Vision - HN");
						break;

				default:
						Debug.Log ("effect Id is " + EffectID);
						SpellResultType=SpellResultNone;
						//ActiveSpellArray[index]=caster.AddComponent<SpellEffect>();
						break;

				}
				//Return a reference to the spell effect. If any.
				switch (SpellResultType)
				{
				case SpellResultNone://No spell effect or unimplemented spell
						return null;
				case SpellResultPassive://Passive spell effect
						return playerUW.PassiveSpell[PassiveArrayIndex];
				case SpellResultActive://Active spell effect
						return playerUW.ActiveSpell[ActiveArrayIndex];
				default:
						return null;
				}
		}

		/// <summary>
		/// Gets the best spell vector to use depending on type of caster
		/// </summary>
		/// <returns>The best spell vector.</returns>
		/// <param name="caster">Caster.</param>
		/// If npc target the gtarg
		/// If other object target the forward direction
		Vector3 GetBestSpellVector(GameObject casterToEval)
		{
				GameObject caster;
				if (casterToEval.name.Contains("NPC_Launcher"))
				{
						caster=casterToEval.transform.parent.gameObject;
				}
				else
				{
						caster=casterToEval;
				}
				if (caster.GetComponent<NPC>()!=null)	
				{
						if (caster.GetComponent<NPC>().gtargName=="_Gronk")
						{
							return (GameWorldController.instance.playerUW.TargetPoint.transform.position- caster.GetComponent<ObjectInteraction>().GetImpactPoint()).normalized;
						}
						else
						{
							return (caster.GetComponent<NPC>().getGtarg().transform.position - caster.GetComponent<ObjectInteraction>().GetImpactPoint()).normalized;
						}
						//Get a vector between the npcs launcher and the player cam

				}
				else
				{
					return caster.transform.forward;
				}
		}
}