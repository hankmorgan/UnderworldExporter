using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsDisplay : GuiBase {
	public Text CharName;
	public Text CharClass;
	public Text CharClassLevel;
	public Text CharStr;
	public Text CharDex;
	public Text CharInt;
	public Text CharVIT;
	public Text CharMana;
	public Text CharEXP;
	public Text CharSkills;
	public Text CharSkillLevels;

	public static int Offset;

	//public static UWCharacter playerUW;

	private string[] Skillnames = {"ATTACK","DEFENSE","UNARMED","SWORD","AXE","MACE","MISSILE",
									"MANA","LORE","CASTING","TRAPS","SEARCH","TRACK","SNEAK","REPAIR",
									"CHARM","PICKLOCK","ACROBAT","APPRAISE","SWIMMING"};
	public static bool UpdateNow=true;


	string tmpSkillNames;
	string tmpSkillValues;

	// Update is called once per frame
	void Update () {
		if (UpdateNow==true)
		{
			UpdateNow=false;
			CharName.text=playerUW.CharName;
			CharClass.text=playerUW.CharClass;
			CharClassLevel.text =playerUW.CharLevel.ToString();
			CharStr.text=playerUW.PlayerSkills.STR.ToString();
			CharDex.text=playerUW.PlayerSkills.DEX.ToString();
			CharInt.text=playerUW.PlayerSkills.INT.ToString();
			CharVIT.text = playerUW.CurVIT +"/"+playerUW.MaxVIT;
			CharMana.text = playerUW.PlayerMagic.CurMana +"/"+playerUW.PlayerMagic.MaxMana;
			CharEXP.text=playerUW.EXP.ToString ();
			tmpSkillNames="";
			tmpSkillValues="";
			if (Offset>15)
			{
				Offset=15;
			}
			if (Offset<0)
			{
				Offset=0;
			}
			for (int i = 0; i<=5;i++)
			{
				tmpSkillNames = tmpSkillNames + Skillnames[i+Offset];
				tmpSkillValues=tmpSkillValues+playerUW.PlayerSkills.GetSkill(i+Offset);
				if (i!=5)
				{
					tmpSkillNames = tmpSkillNames +"\n";
					tmpSkillValues = tmpSkillValues +"\n";
				}
			}
			CharSkills.text=tmpSkillNames;
			CharSkillLevels.text=tmpSkillValues;
		}
	}
}
