using UnityEngine;
using System.Collections;

public class TMAP : object_base {


	public static TextureController tc;
	public string trigger;
	public int TextureIndex;
	private SpriteRenderer sr;
	//public bool isAnimated;
	//private bool HasUpdated;

	// Use this for initialization
//	void Start () {
//		base.Start ();
//	}

	public override bool LookAt()
	{
		ml.Add (playerUW.StringControl.TextureDescription(TextureIndex));
		if (TextureIndex==142)
		{//This is a window into the abyss.
			playerUW.playerHud.CutScenesSmall.SetAnimation="VolcanoWindow_" + GameWorldController.instance.LevelNo;
		}
		if (trigger != "")
		{
			GameObject triggerObj = GameObject.Find (trigger);
			if (triggerObj!=null)
				{
				ObjectInteraction objIntTrigger = triggerObj.GetComponent<ObjectInteraction>();
				if ( (objIntTrigger.ItemType==ObjectInteraction.A_LOOK_TRIGGER)
				    || 
				    (objIntTrigger.ItemType==ObjectInteraction.A_USE_TRIGGER)
				    )
					{
						objIntTrigger.GetComponent<trigger_base> ().Activate();
						return true;
					}
				}
		}
		return true;

	}

	public override bool use()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			if (trigger != "")
			{
				GameObject triggerObj = GameObject.Find (trigger);
				if (triggerObj!=null)
				{
					ObjectInteraction objIntTrigger = triggerObj.GetComponent<ObjectInteraction>();
					if (
						(objIntTrigger.ItemType==ObjectInteraction.A_USE_TRIGGER)
					    )
					{
						objIntTrigger.GetComponent<trigger_base> ().Activate();
						return true;
					}
				}
			}
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}

	public override bool ActivateByObject (GameObject ObjectUsed)
	{
		if (TextureIndex==47)//The door to the base of the abyss.
		{
			if (ObjectUsed.GetComponent<ObjectInteraction>().item_id==231)//The key of infinity.
			{
				if (trigger != "")
				{
					GameObject triggerObj = GameObject.Find (trigger);
					if (triggerObj!=null)
					{
						ObjectInteraction objIntTrigger = triggerObj.GetComponent<ObjectInteraction>();
						if (
							(objIntTrigger.ItemType==ObjectInteraction.AN_OPEN_TRIGGER)
							)
						{
							objIntTrigger.GetComponent<trigger_base> ().Activate();
							playerUW.CursorIcon= playerUW.CursorIconDefault;
							playerUW.playerInventory.ObjectInHand="";
							return true;
						}
					}
				}

			}
		}
		return base.ActivateByObject (ObjectUsed);
	}
}
