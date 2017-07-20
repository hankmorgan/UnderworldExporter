using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsDisplay : GuiBase_Draggable {
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

	//public static UWCharacter GameWorldController.instance.playerUW;

	private string[] Skillnames = {"ATTACK","DEFENSE","UNARMED","SWORD","AXE","MACE","MISSILE",
									"MANA","LORE","CASTING","TRAPS","SEARCH","TRACK","SNEAK","REPAIR",
									"CHARM","PICKLOCK","ACROBAT","APPRAISE","SWIMMING"};
	public static bool UpdateNow=true;


	string tmpSkillNames;
	string tmpSkillValues;

	// Update is called once per frame
	void Update () {
			if (!GameWorldController.instance.AtMainMenu)
			{
					if (UpdateNow==true)
					{
							UpdateNow=false;
							CharName.text=GameWorldController.instance.playerUW.CharName;
							//CharClass.text=GameWorldController.instance.playerUW.CharClass;

							CharClass.text= StringController.instance.GetString(2,23+GameWorldController.instance.playerUW.CharClass);

							CharClassLevel.text =GameWorldController.instance.playerUW.CharLevel.ToString();
							CharStr.text=GameWorldController.instance.playerUW.PlayerSkills.STR.ToString();
							CharDex.text=GameWorldController.instance.playerUW.PlayerSkills.DEX.ToString();
							CharInt.text=GameWorldController.instance.playerUW.PlayerSkills.INT.ToString();
							CharVIT.text = GameWorldController.instance.playerUW.CurVIT +"/"+GameWorldController.instance.playerUW.MaxVIT;
							CharMana.text = GameWorldController.instance.playerUW.PlayerMagic.CurMana +"/"+GameWorldController.instance.playerUW.PlayerMagic.MaxMana;
							CharEXP.text=GameWorldController.instance.playerUW.EXP.ToString ();
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
									tmpSkillValues=tmpSkillValues+GameWorldController.instance.playerUW.PlayerSkills.GetSkill(i+Offset+1);
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
}
