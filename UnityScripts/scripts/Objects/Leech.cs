using UnityEngine;
using System.Collections;
/// <summary>
/// Leches can be used to cure poison
/// </summary>
public class Leech : object_base {


public override bool use ()
	{
		if (CurrentObjectInHand==null)
		{
			UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null, SpellEffect.UW1_Spell_Effect_CurePoison,Magic.SpellRule_TargetSelf,Magic.SpellRule_Consumable);
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,StringController.str_the_leeches_remove_the_poison_as_well_as_some_of_your_skin_and_blood_));
			UWCharacter.Instance.ApplyDamage(Random.Range (1,6));
			objInt().consumeObject();
			return true;
		}
		else
		{
			return ActivateByObject (CurrentObjectInHand);
		}
	}
}
