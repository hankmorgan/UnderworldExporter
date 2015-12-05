using UnityEngine;
using System.Collections;

public class Grave : object_base {
	/*Code for gravestones*/
	public int GraveID;


	public override bool LookAt ()
	{
		CheckReferences();
		playerUW.playerHud.CutScenesSmall.SetAnimation= "cs401_n01_00" + (GraveID-1).ToString ("D2");
		ml.Add (playerUW.StringControl.GetString (8, objInt.Link-512));
		return true;
	}

	public override bool use ()
	{
		//return base.use ();
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			return LookAt ();
		}
		else
		{
			//TODO: if garamons bones activate something special.
			return playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
		}

	}

}
