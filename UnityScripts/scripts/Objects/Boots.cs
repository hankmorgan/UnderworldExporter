using UnityEngine;
using System.Collections;
/// <summary>
/// Boots.
/// </summary>
/// Wearable boots
public class Boots : Armour {

	protected override void Start ()
	{
		base.Start();
		if ((objInt().item_id == 47) && (_RES==GAME_UW1))
		{//Retroactive fix to improperly created dragonskin boots.
				objInt().link=0;		
		}
	}

		public override int GetActualSpellIndex ()
		{
				if ((objInt().item_id == 47) && (_RES==GAME_UW1))
				{
						return SpellEffect.UW1_Spell_Effect_Flameproof_alt01;		
				}
				else
				{
						return base.GetActualSpellIndex();
				}

		}


}