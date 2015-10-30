using UnityEngine;
using System.Collections;

public class Fountain : object_base {
//Code for handing fountain behaviour.

	public override bool use ()
	{
		base.use();
		if ((objInt.isEnchanted==true) &&(objInt.Link>=512))
		{
			//ml.text = "Casting enchantment " +  playerUW.StringControl.GetString (6,objInt.Link-512);
			playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,objInt.Link-512);
		}
		//else
		//{//Generic drink message
		ml.text= playerUW.StringControl.GetString (1,237);
		//}
		return true;
	}


}
