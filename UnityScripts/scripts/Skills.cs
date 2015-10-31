using UnityEngine;
using System.Collections;

public class Skills : MonoBehaviour {
	//Th
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

	//Character attributes
	public int STR;
	public int DEX;
	public int INT;

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



	private string[] Skillnames = {"ATTACK","DEFENSE","UNARMED","SWORD","AXE","MACE","MISSILE",
		"MANA","LORE","CASTING","TRAPS","SEARCH","TRACK","SNEAK","REPAIR",
		"CHARM","PICKLOCK","ACROBAT","APPRAISE","SWIMMING"};


	public bool TrySkill(int SkillToUse, int CheckValue)
	{//Prototype skill check code
		Debug.Log ("Skill check Skill :" + Skillnames[SkillToUse] + " (" +GetSkill(SkillToUse) +") vs " + CheckValue);
		return (CheckValue<GetSkill(SkillToUse));
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


	public void AdvanceSkill(int SkillNo, int SkillPoints)
	{//Increase a players skill by the specificed skill let
		switch (SkillNo)
		{
		case SkillAttack : Attack +=SkillPoints;break;
		case SkillDefense : Defense +=SkillPoints;break;
		case SkillUnarmed : Unarmed+=SkillPoints;break;
		case SkillSword :  Sword+=SkillPoints;break;
		case SkillAxe : Axe+=SkillPoints;break;
		case SkillMace :  Mace+=SkillPoints;break;
		case SkillMissile : Missile+=SkillPoints;break;
		case SkillMana : ManaSkill+=SkillPoints;break;
		case SkillLore : Lore+=SkillPoints;break;
		case SkillCasting : Casting+=SkillPoints;break;
		case SkillTraps : Traps+=SkillPoints;break;
		case SkillSearch : Search+=SkillPoints;break;
		case SkillTrack : Track+=SkillPoints;break;
		case SkillSneak : Sneak+=SkillPoints;break;
		case SkillRepair : Repair+=SkillPoints;break;
		case SkillCharm : Charm+=SkillPoints;break;
		case SkillPicklock : PickLock+=SkillPoints;break;
		case SkillAcrobat : Acrobat+=SkillPoints;break;
		case SkillAppraise : Appraise+=SkillPoints;break;
		case SkillSwimming : Swimming+=SkillPoints;break;
		}
	}

	public string GetSkillName(int skillNo)
	{
		return Skillnames[skillNo];
	}
}
