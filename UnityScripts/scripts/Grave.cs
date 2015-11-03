using UnityEngine;
using System.Collections;

public class Grave : object_base {
	public int GraveID;


	public override bool LookAt ()
	{
		CheckReferences();
		playerUW.CutScenesSmall.SetAnimation= "cs401_n01_00" + (GraveID-1).ToString ("D2");
		ml.text=playerUW.StringControl.GetString (8, objInt.Link-512);
		return true;
	}

	public override bool use ()
	{
		//return base.use ();
		return LookAt ();
	}

}
