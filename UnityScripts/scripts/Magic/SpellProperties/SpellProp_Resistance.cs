using UnityEngine;
using System.Collections;

public class SpellProp_Resistance : SpellProp {

	public override void init (int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		switch (effectId)
		{
			case SpellEffect.UW1_Spell_Effect_ResistBlows:
			case SpellEffect.UW1_Spell_Effect_ResistBlows_alt01:	
			case SpellEffect.UW1_Spell_Effect_ResistBlows_alt02:	
					BaseDamage=1;counter=3;break;
			case SpellEffect.UW1_Spell_Effect_ThickSkin:
			case SpellEffect.UW1_Spell_Effect_ThickSkin_alt01:
			case SpellEffect.UW1_Spell_Effect_ThickSkin_alt02:						
					BaseDamage=2;counter=4;break;
			case SpellEffect.UW1_Spell_Effect_IronFlesh:
			case SpellEffect.UW1_Spell_Effect_IronFlesh_alt01:				
			case SpellEffect.UW1_Spell_Effect_IronFlesh_alt02:
					BaseDamage=3;counter=5;break;
				default:
						Debug.Log("Default values used in resistance spell");
						BaseDamage=1;counter=3;break;
		}
	}
}
