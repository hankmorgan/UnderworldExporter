using UnityEngine;
using System.Collections;
/// <summary>
/// Spell effect.
/// </summary>
/// Magic spell effects that persist over time on the player or an NPC

public class SpellEffect : UWEBase {

	/*Enchantment Effect Ids as taken from the strings file.*/
	public const int UW1_Spell_Effect_Darkness = 0;
	public const int UW1_Spell_Effect_BurningMatch = 1;
	public const int UW1_Spell_Effect_Candlelight = 2;
	public const int UW1_Spell_Effect_Light = 3;
	public const int UW1_Spell_Effect_MagicLantern = 4;
	public const int UW1_Spell_Effect_NightVision = 5;
	public const int UW1_Spell_Effect_Daylight = 6;
	public const int UW1_Spell_Effect_Sunlight = 7;
	public const int UW1_Spell_Effect_Leap = 17;
	public const int UW1_Spell_Effect_SlowFall = 18;
	public const int UW1_Spell_Effect_Levitate = 19;
	public const int UW1_Spell_Effect_WaterWalk = 20;
	public const int UW1_Spell_Effect_Fly = 21;
	public const int UW1_Spell_Effect_ResistBlows = 34;
	public const int UW1_Spell_Effect_ThickSkin = 35;
	public const int UW1_Spell_Effect_IronFlesh = 37;
	public const int UW1_Spell_Effect_Curse = 49;
	public const int UW1_Spell_Effect_Stealth = 50;
	public const int UW1_Spell_Effect_Conceal = 51;
	public const int UW1_Spell_Effect_Invisibilty = 52;
	public const int UW1_Spell_Effect_MissileProtection = 53;
	public const int UW1_Spell_Effect_Flameproof = 54;
	public const int UW1_Spell_Effect_PoisonResistance = 55;
	public const int UW1_Spell_Effect_MagicProtection = 56;
	public const int UW1_Spell_Effect_GreaterMagicProtection = 57;
	public const int UW1_Spell_Effect_LesserHeal = 64;
	public const int UW1_Spell_Effect_LesserHeal_alt01 = 65;
	public const int UW1_Spell_Effect_LesserHeal_alt02 = 66;
	public const int UW1_Spell_Effect_LesserHeal_alt03 = 67;
	public const int UW1_Spell_Effect_Heal = 68;
	public const int UW1_Spell_Effect_Heal_alt01 = 69;
	public const int UW1_Spell_Effect_Heal_alt02 = 70;
	public const int UW1_Spell_Effect_Heal_alt03 = 71;
	public const int UW1_Spell_Effect_EnhancedHeal = 72;
	public const int UW1_Spell_Effect_EnhancedHeal_alt01 = 73;
	public const int UW1_Spell_Effect_EnhancedHeal_alt02 = 74;
	public const int UW1_Spell_Effect_EnhancedHeal_alt03 = 75;
	public const int UW1_Spell_Effect_GreaterHeal = 76;
	public const int UW1_Spell_Effect_GreaterHeal_alt01 = 77;
	public const int UW1_Spell_Effect_GreaterHeal_alt02 = 78;
	public const int UW1_Spell_Effect_GreaterHeal_alt03 = 79;
	public const int UW1_Spell_Effect_MagicArrow = 81;
	public const int UW1_Spell_Effect_ElectricalBolt = 82;
	public const int UW1_Spell_Effect_Fireball = 83;
	public const int UW1_Spell_Effect_Reveal = 97;
	public const int UW1_Spell_Effect_SheetLightning = 98;
	public const int UW1_Spell_Effect_Confusion = 99;
	public const int UW1_Spell_Effect_FlameWind = 100;
	public const int UW1_Spell_Effect_CauseFear = 113;
	public const int UW1_Spell_Effect_SmiteUndead = 114;
	public const int UW1_Spell_Effect_Ally = 115;
	public const int UW1_Spell_Effect_Poison = 116;
	public const int UW1_Spell_Effect_Paralyze = 117;
	public const int UW1_Spell_Effect_CreateFood = 129;
	public const int UW1_Spell_Effect_SetGuard = 130;
	public const int UW1_Spell_Effect_RuneofWarding = 131;
	public const int UW1_Spell_Effect_SummonMonster = 132;
	public const int UW1_Spell_Effect_Cursed = 144;
	public const int UW1_Spell_Effect_Cursed_alt01 = 145;
	public const int UW1_Spell_Effect_Cursed_alt02 = 146;
	public const int UW1_Spell_Effect_Cursed_alt03 = 147;
	public const int UW1_Spell_Effect_Cursed_alt04 = 148;
	public const int UW1_Spell_Effect_Cursed_alt05 = 149;
	public const int UW1_Spell_Effect_Cursed_alt06 = 150;
	public const int UW1_Spell_Effect_Cursed_alt07 = 151;
	public const int UW1_Spell_Effect_Cursed_alt09 = 152;
	public const int UW1_Spell_Effect_Cursed_alt10 = 153;
	public const int UW1_Spell_Effect_Cursed_alt11 = 154;
	public const int UW1_Spell_Effect_Cursed_alt12 = 155;
	public const int UW1_Spell_Effect_Cursed_alt13 = 156;
	public const int UW1_Spell_Effect_Cursed_alt14 = 157;
	public const int UW1_Spell_Effect_Cursed_alt15 = 158;
	public const int UW1_Spell_Effect_Cursed_alt16 = 159;
	public const int UW1_Spell_Effect_IncreaseMana = 160;
	public const int UW1_Spell_Effect_IncreaseMana_alt01 = 161;
	public const int UW1_Spell_Effect_IncreaseMana_alt02 = 162;
	public const int UW1_Spell_Effect_IncreaseMana_alt03 = 163;
	public const int UW1_Spell_Effect_ManaBoost = 164;
	public const int UW1_Spell_Effect_ManaBoost_alt01 = 165;
	public const int UW1_Spell_Effect_ManaBoost_alt02 = 166;
	public const int UW1_Spell_Effect_ManaBoost_alt03 = 167;
	public const int UW1_Spell_Effect_RegainMana = 168;
	public const int UW1_Spell_Effect_RegainMana_alt01 = 169;
	public const int UW1_Spell_Effect_RegainMana_alt02 = 170;
	public const int UW1_Spell_Effect_RegainMana_alt03 = 171;
	public const int UW1_Spell_Effect_RestoreMana = 172;
	public const int UW1_Spell_Effect_RestoreMana_alt01 = 173;
	public const int UW1_Spell_Effect_RestoreMana_alt02 = 174;
	public const int UW1_Spell_Effect_RestoreMana_alt03 = 175;
	public const int UW1_Spell_Effect_Speed = 176;
	public const int UW1_Spell_Effect_DetectMonster = 177;
	public const int UW1_Spell_Effect_StrengthenDoor = 178;
	public const int UW1_Spell_Effect_RemoveTrap = 179;
	public const int UW1_Spell_Effect_NameEnchantment = 180;
	public const int UW1_Spell_Effect_Open = 181;
	public const int UW1_Spell_Effect_CurePoison = 182;
	public const int UW1_Spell_Effect_RoamingSight = 183;
	public const int UW1_Spell_Effect_Telekinesis = 184;
	public const int UW1_Spell_Effect_Tremor = 185;
	public const int UW1_Spell_Effect_GateTravel = 186;
	public const int UW1_Spell_Effect_FreezeTime = 187;
	public const int UW1_Spell_Effect_Armageddon = 188;
	public const int UW1_Spell_Effect_Regeneration = 190;
	public const int UW1_Spell_Effect_ManaRegeneration = 191;
	public const int UW1_Spell_Effect_theFrog = 211;
	public const int UW1_Spell_Effect_MazeNavigation = 212;
	public const int UW1_Spell_Effect_Hallucination = 213;
	public const int UW1_Spell_Effect_Light_alt01 = 256;
	public const int UW1_Spell_Effect_ResistBlows_alt01 = 257;
	public const int UW1_Spell_Effect_MagicArrow_alt01 = 258;
	public const int UW1_Spell_Effect_CreateFood_alt01 = 259;
	public const int UW1_Spell_Effect_Stealth_alt01 = 260;
	public const int UW1_Spell_Effect_Leap_alt01 = 261;
	public const int UW1_Spell_Effect_Curse_alt01 = 262;
	public const int UW1_Spell_Effect_SlowFall_alt01 = 263;
	public const int UW1_Spell_Effect_LesserHeal_alt04 = 264;
	public const int UW1_Spell_Effect_DetectMonster_alt01 = 265;
	public const int UW1_Spell_Effect_CauseFear_alt01 = 266;
	public const int UW1_Spell_Effect_RuneofWarding_alt01 = 267;
	public const int UW1_Spell_Effect_Speed_alt01 = 268;
	public const int UW1_Spell_Effect_Conceal_alt01 = 269;
	public const int UW1_Spell_Effect_NightVision_alt01 = 270;
	public const int UW1_Spell_Effect_ElectricalBolt_alt01 = 271;
	public const int UW1_Spell_Effect_StrengthenDoor_alt01 = 272;
	public const int UW1_Spell_Effect_ThickSkin_alt01 = 273;
	public const int UW1_Spell_Effect_WaterWalk_alt01 = 274;
	public const int UW1_Spell_Effect_Heal_alt04 = 275;
	public const int UW1_Spell_Effect_Levitate_alt01 = 276;
	public const int UW1_Spell_Effect_Poison_alt01 = 277;
	public const int UW1_Spell_Effect_Flameproof_alt01 = 278;
	public const int UW1_Spell_Effect_RemoveTrap_alt01 = 279;
	public const int UW1_Spell_Effect_Fireball_alt01 = 280;
	public const int UW1_Spell_Effect_SmiteUndead_alt01 = 281;
	public const int UW1_Spell_Effect_NameEnchantment_alt01 = 282;
	public const int UW1_Spell_Effect_MissileProtection_alt01 = 283;
	public const int UW1_Spell_Effect_Open_alt01 = 284;
	public const int UW1_Spell_Effect_CurePoison_alt01 = 285;
	public const int UW1_Spell_Effect_GreaterHeal_alt04 = 286;
	public const int UW1_Spell_Effect_SheetLightning_alt01 = 287;
	public const int UW1_Spell_Effect_GateTravel_alt01 = 288;
	public const int UW1_Spell_Effect_Paralyze_alt01 = 289;
	public const int UW1_Spell_Effect_Daylight_alt01 = 290;
	public const int UW1_Spell_Effect_Telekinesis_alt01 = 291;
	public const int UW1_Spell_Effect_Fly_alt01 = 292;
	public const int UW1_Spell_Effect_Ally_alt01 = 293;
	public const int UW1_Spell_Effect_SummonMonster_alt01 = 294;
	public const int UW1_Spell_Effect_Invisibility_alt01 = 295;
	public const int UW1_Spell_Effect_Confusion_alt01 = 296;
	public const int UW1_Spell_Effect_Reveal_alt01 = 297;
	public const int UW1_Spell_Effect_IronFlesh_alt01 = 298;
	public const int UW1_Spell_Effect_Tremor_alt01 = 299;
	public const int UW1_Spell_Effect_RoamingSight_alt01 = 300;
	public const int UW1_Spell_Effect_FlameWind_alt01 = 301;
	public const int UW1_Spell_Effect_FreezeTime_alt01 = 302;
	public const int UW1_Spell_Effect_Armageddon_alt01 = 303;
	public const int UW1_Spell_Effect_MassParalyze = 304;
	public const int UW1_Spell_Effect_Acid_alt01 = 305;
	public const int UW1_Spell_Effect_LocalTeleport_alt01 = 306;
	public const int UW1_Spell_Effect_ManaBoost_alt04 = 307;
	public const int UW1_Spell_Effect_RestoreMana_alt04 = 308;
	public const int UW1_Spell_Effect_Leap_alt02 = 384;
	public const int UW1_Spell_Effect_SlowFall_alt02 = 385;
	public const int UW1_Spell_Effect_Levitate_alt02 = 386;
	public const int UW1_Spell_Effect_WaterWalk_alt02 = 387;
	public const int UW1_Spell_Effect_Fly_alt02 = 388;
	public const int UW1_Spell_Effect_Curse_alt02 = 389;
	public const int UW1_Spell_Effect_Stealth_alt02 = 390;
	public const int UW1_Spell_Effect_Conceal_alt02 = 391;
	public const int UW1_Spell_Effect_Invisibility_alt02 = 392;
	public const int UW1_Spell_Effect_MissileProtection_alt02 = 393;
	public const int UW1_Spell_Effect_Flameproof_alt02 = 394;
	public const int UW1_Spell_Effect_FreezeTime_alt02 = 395;
	public const int UW1_Spell_Effect_RoamingSight_alt02 = 396;
	public const int UW1_Spell_Effect_Haste = 397;
	public const int UW1_Spell_Effect_Telekinesis_alt02 = 398;
	public const int UW1_Spell_Effect_ResistBlows_alt02 = 399;
	public const int UW1_Spell_Effect_ThickSkin_alt02 = 400;
	public const int UW1_Spell_Effect_Light_alt02 = 401;
	public const int UW1_Spell_Effect_IronFlesh_alt02 = 402;
	public const int UW1_Spell_Effect_NightVision_alt02 = 403;
	public const int UW1_Spell_Effect_Daylight_alt02 = 404;
	public const int UW1_Spell_Effect_MinorAccuracy = 448;
	public const int UW1_Spell_Effect_Accuracy = 449;
	public const int UW1_Spell_Effect_AdditionalAccuracy = 450;
	public const int UW1_Spell_Effect_MajorAccuracy = 451;
	public const int UW1_Spell_Effect_GreatAccuracy = 452;
	public const int UW1_Spell_Effect_VeryGreatAccuracy = 453;
	public const int UW1_Spell_Effect_TremendousAccuracy = 454;
	public const int UW1_Spell_Effect_UnsurpassedAccuracy = 455;
	public const int UW1_Spell_Effect_MinorDamage = 456;
	public const int UW1_Spell_Effect_Damage = 457;
	public const int UW1_Spell_Effect_AdditionalDamage = 458;
	public const int UW1_Spell_Effect_MajorDamage = 459;
	public const int UW1_Spell_Effect_GreatDamage = 460;
	public const int UW1_Spell_Effect_VeryGreatDamage = 461;
	public const int UW1_Spell_Effect_TremendousDamage = 462;
	public const int UW1_Spell_Effect_UnsurpassedDamage = 463;
	public const int UW1_Spell_Effect_MinorProtection = 464;
	public const int UW1_Spell_Effect_Protection = 465;
	public const int UW1_Spell_Effect_AdditionalProtection = 466;
	public const int UW1_Spell_Effect_MajorProtection = 467;
	public const int UW1_Spell_Effect_GreatProtection = 468;
	public const int UW1_Spell_Effect_VeryGreatProtection = 469;
	public const int UW1_Spell_Effect_TremendousProtection = 470;
	public const int UW1_Spell_Effect_UnsurpassedProtection = 471;
	public const int UW1_Spell_Effect_MinorToughness = 472;
	public const int UW1_Spell_Effect_Toughness = 473;
	public const int UW1_Spell_Effect_AdditionalToughness = 474;
	public const int UW1_Spell_Effect_MajorToughness = 475;
	public const int UW1_Spell_Effect_GreatToughness = 476;
	public const int UW1_Spell_Effect_VeryGreatToughness = 477;
	public const int UW1_Spell_Effect_TremendousToughness = 478;
	public const int UW1_Spell_Effect_UnsurpassedToughness = 479;

	//Spells observed in the wild that have no string.
	//Eg the poison potion in Ironwit's maze
	public const int UW1_Spell_Effect_PoisonHidden = 491;

		/// <summary>
		/// Spell Icons for the spell effect ids
		/// </summary>
		/// From a spreadsheet I created. The Icons that match up with the above effects constants
	private static int[] UW1_Spell_Icons=
	{-1,
		17,
		17,
		17,
		17,
		19,
		20,
		20,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		0,
		1,
		2,
		3,
		4,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		15,
		16,
		-1,
		18,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		6,
		7,
		8,
		9,
		10,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		13,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		12,
		14,
		-1,
		-1,
		11,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		17,
		15,
		-1,
		-1,
		6,
		0,
		-1,
		1,
		-1,
		-1,
		-1,
		-1,
		13,
		7,
		19,
		-1,
		-1,
		16,
		3,
		-1,
		2,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		20,
		14,
		4,
		-1,
		-1,
		8,
		-1,
		-1,
		18,
		-1,
		12,
		-1,
		11,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		0,
		1,
		2,
		3,
		4,
		-1,
		6,
		7,
		8,
		-1,
		-1,
		11,
		12,
		-1,
		14,
		15,
		16,
		17,
		18,
		19,
		20,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1};

	///The number of ticks the effect last for.
	public int counter;	
	///The length of time of a tick.
	public int TickTime =10; 
	///Effect Id of the current spell effect
	public int EffectID; 
	///The value for the spell effect. Eg light intensity. The Damage over time etc
	public int Value;
	///Is the effect running.
	public bool Active;
	///Used when an effect is created by equipment and needs to last as long as the player has equiped the item
	public bool Permanent;
	


	/// <summary>
	/// Returns the icon index no for this effect
	/// </summary>
	/// <returns>The icon.</returns>
	public int EffectIcon()
	{
		return UW1_Spell_Icons[EffectID];
	}

	/// <summary>
	/// Applies the effect.
	/// </summary>
	public virtual void ApplyEffect()
	{
		//Code to apply whatever effect is occuring
		Active=true;
	}
	
	/// <summary>
	/// Code to apply the periodic changes to the effect. Eg poison drains health, staged effects.
	/// </summary>
	public virtual void EffectOverTime()
	{
		return;
	}

	/// <summary>
	/// End the effect. By default it will destroy this spell effect.
	/// </summary>
	public virtual void CancelEffect()
	{
		Active=false;
		Component.DestroyImmediate (this);
	}

	/// <summary>
	/// Starts the spell effect.
	/// </summary>
	/// Applys the effect and starts the timer
	public virtual void Go()
	{
		if (counter==999)
		{
			Permanent=true;
		}
		ApplyEffect ();
		StartCoroutine(timer());
	}

		/// <summary>
		/// Timer loop for the effect.
		/// </summary>
		/// Periodically applies the effect over time when the counter ticks down.
	public IEnumerator timer() {
		while (Active==true)
		{
			yield return new WaitForSeconds(TickTime); 
			if (!Permanent)
			{
				counter--;
			}

			if (counter<=0)
			{
				Active=false;
			}
			else
			{
				if (Active)
				{
					EffectOverTime ();
				}
			}
		}
		CancelEffect();
	}

		/*
	public virtual string Status()
		{//The debug status of the effect.
			return "The spell effect has "+ counter + " remaining";
		}*/

		/// <summary>
		/// Describes the spell and how stable the spell is.
		/// </summary>
		/// <returns>The spell description.</returns>

	public string getSpellDescription()
	{
		return StringController.instance.GetString (6,EffectID);
	}

	/// <summary>
	/// Makes the spell effect permanent.
	/// </summary>
	public void SetPermanent(bool NewVal)
	{
		Permanent=NewVal;
	}
}
