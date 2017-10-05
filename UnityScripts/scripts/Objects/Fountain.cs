﻿using UnityEngine;
using System.Collections;

public class Fountain : object_base {
//Code for handing fountain behaviour.

	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			if ((objInt().isEnchanted()==true) &&(objInt().link>=512))
			{
				GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,objInt().link-512,Magic.SpellRule_TargetSelf);
			}
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_the_water_refreshes_you_));
			return true;
		}
		else
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());		
		}
	}


		public override string UseVerb ()
		{
			return "drink";
		}
}
