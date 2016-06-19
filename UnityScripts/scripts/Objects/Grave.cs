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
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
			//return playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
		}
	}

	public override bool ActivateByObject (GameObject ObjectUsed)
	{
	ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
	if (GraveID==6)
			{//Garamon's grave
			//Activates a trigger a_move_trigger_54_52_04_0495 (selected by unknown means)
			if (objIntUsed.item_id==198)//Bones
				{
					if (objIntUsed.Quality==63)
					{//Garamons bones
					//Arise Garamon.
					//000~001~134~You thoughtfully give the bones a final resting place.
					ml.Add(playerUW.StringControl.GetString (1,134));
					GameObject trig = GameObject.Find ("a_move_trigger_54_52_04_0495");
						if (trig!=null)
						{					
							objInt.Link++;//Update the grave description
							objIntUsed.consumeObject ();
							trig.GetComponent<ObjectInteraction>().GetComponent<trigger_base>().Activate();
						}
						playerUW.CursorIcon= playerUW.CursorIconDefault;
						playerUW.playerInventory.ObjectInHand="";						
						return true;
					}
					else
					{//Regular bones
					//000~001~259~The bones do not seem at rest in the grave, and you take them back.
					ml.Add(playerUW.StringControl.GetString (1,259));
					playerUW.CursorIcon= playerUW.CursorIconDefault;
					playerUW.playerInventory.ObjectInHand="";
					return true;
					}
				}
			else
				{
				return ObjectUsed.GetComponent<ObjectInteraction>().FailMessage();
				}
			}
		else
		{
			if ((objIntUsed.item_id==198) && (objIntUsed.Quality==63))//Garamons Bones used on the wrong grave
			{
				//000~001~259~The bones do not seem at rest in the grave, and you take them back.
				ml.Add(playerUW.StringControl.GetString (1,259));
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.playerInventory.ObjectInHand="";
				return true;
			}
			else
			{
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.playerInventory.ObjectInHand="";
				return ObjectUsed.GetComponent<ObjectInteraction>().FailMessage();
			}
		}
	}

}
