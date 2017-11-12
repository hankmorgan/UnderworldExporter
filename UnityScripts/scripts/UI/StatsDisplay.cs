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

	//public static UWCharacter UWCharacter.Instance;

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
							CharName.text=UWCharacter.Instance.CharName;
							//CharClass.text=UWCharacter.Instance.CharClass;

							CharClass.text= StringController.instance.GetString(2,23+UWCharacter.Instance.CharClass);

							CharClassLevel.text =UWCharacter.Instance.CharLevel.ToString();
							CharStr.text=UWCharacter.Instance.PlayerSkills.STR.ToString();
							CharDex.text=UWCharacter.Instance.PlayerSkills.DEX.ToString();
							CharInt.text=UWCharacter.Instance.PlayerSkills.INT.ToString();
							CharVIT.text = UWCharacter.Instance.CurVIT +"/"+UWCharacter.Instance.MaxVIT;
							CharMana.text = UWCharacter.Instance.PlayerMagic.CurMana +"/"+UWCharacter.Instance.PlayerMagic.MaxMana;
							CharEXP.text=UWCharacter.Instance.EXP.ToString ();
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
									tmpSkillValues=tmpSkillValues+UWCharacter.Instance.PlayerSkills.GetSkill(i+Offset+1);
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
