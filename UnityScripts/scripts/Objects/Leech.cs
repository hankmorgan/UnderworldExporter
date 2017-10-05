using UnityEngine;
using System.Collections;
/// <summary>
/// Leches can be used to cure poison
/// </summary>
public class Leech : object_base {


public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null, SpellEffect.UW1_Spell_Effect_CurePoison,Magic.SpellRule_TargetSelf);
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,StringController.str_the_leeches_remove_the_poison_as_well_as_some_of_your_skin_and_blood_));
			GameWorldController.instance.playerUW.ApplyDamage(Random.Range (1,6));
			objInt().consumeObject();
			return true;
		}
		else
		{
			return ActivateByObject (GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}
	}
}
