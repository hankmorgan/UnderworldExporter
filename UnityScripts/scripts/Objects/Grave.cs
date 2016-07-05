using UnityEngine;
using System.Collections;

public class Grave : object_base {
	///ID of the grave to lookup
	public int GraveID;

	/// <summary>
	/// Plays cutscene that displays the gravestone.
	/// </summary>
	/// <returns>The <see cref="System.Boolean"/>.</returns>
	public override bool LookAt ()
	{
		CheckReferences();
		playerUW.playerHud.CutScenesSmall.SetAnimation= "cs401_n01_00" + (GraveID-1).ToString ("D2");
		ml.Add (playerUW.StringControl.GetString (8, objInt.Link-512));
		return true;
	}

	public override bool use ()
	{
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

		/// <summary>
		/// Activation of this object by another. EG key on door
		/// </summary>
		/// <returns>true</returns>
		/// <c>false</c>
		/// <param name="ObjectUsed">Object used.</param>
		/// Special case here for Garamon's grave. Activates a hard coded trigger
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
						playerUW.playerHud.CursorIcon= playerUW.playerHud.CursorIconDefault;
						playerUW.playerInventory.ObjectInHand="";						
						return true;
					}
					else
					{//Regular bones
					//000~001~259~The bones do not seem at rest in the grave, and you take them back.
					ml.Add(playerUW.StringControl.GetString (1,259));
					playerUW.playerHud.CursorIcon= playerUW.playerHud.CursorIconDefault;
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
				playerUW.playerHud.CursorIcon= playerUW.playerHud.CursorIconDefault;
				playerUW.playerInventory.ObjectInHand="";
				return true;
			}
			else
			{
				playerUW.playerHud.CursorIcon= playerUW.playerHud.CursorIconDefault;
				playerUW.playerInventory.ObjectInHand="";
				return ObjectUsed.GetComponent<ObjectInteraction>().FailMessage();
			}
		}
	}
}