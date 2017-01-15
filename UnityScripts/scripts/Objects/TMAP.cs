using UnityEngine;
using System.Collections;

public class TMAP : object_base {


	//public static TextureController tc;
	public string trigger;
	public int TextureIndex;
	private SpriteRenderer sr;

	public override bool LookAt()
	{
		UWHUD.instance.MessageScroll.Add (StringController.instance.TextureDescription(TextureIndex));
		if (TextureIndex==142)
		{//This is a window into the abyss.
			UWHUD.instance.CutScenesSmall.SetAnimation="VolcanoWindow_" + GameWorldController.instance.LevelNo;
		}
		if (trigger != "")
		{
			GameObject triggerObj = GameObject.Find (trigger);
			if (triggerObj!=null)
				{
				ObjectInteraction objIntTrigger = triggerObj.GetComponent<ObjectInteraction>();
				if ( (objIntTrigger.GetItemType()==ObjectInteraction.A_LOOK_TRIGGER)
				    || 
				    (objIntTrigger.GetItemType()==ObjectInteraction.A_USE_TRIGGER)
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
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			if (trigger != "")
			{
				GameObject triggerObj = GameObject.Find (trigger);
				if (triggerObj!=null)
				{
					ObjectInteraction objIntTrigger = triggerObj.GetComponent<ObjectInteraction>();
					if (
						(objIntTrigger.GetItemType()==ObjectInteraction.A_USE_TRIGGER)
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
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
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
							(objIntTrigger.GetItemType()==ObjectInteraction.AN_OPEN_TRIGGER)
							)
						{
							objIntTrigger.GetComponent<trigger_base> ().Activate();
							UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
							GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
							return true;
						}
					}
				}

			}
		}
		return base.ActivateByObject (ObjectUsed);
	}



		public override string ContextMenuDesc(int item_id)
		{
			return "";	
		}


		public override string ContextMenuUsedDesc()
		{
			return "";	
		}

		public override string ContextMenuUsedPickup()
		{
			return "";	
		}


		public override string UseObjectOnVerb_World ()
		{
				if (TextureIndex==47)//The door to the base of the abyss.
				{
						ObjectInteraction ObjIntInHand=GameWorldController.instance.playerUW.playerInventory.GetObjIntInHand();
						if (ObjIntInHand!=null)
						{
								switch (ObjIntInHand.item_id)	
								{
								case 231:
										return "unlock the shrine";
								}
						}	
				}


				return base.UseObjectOnVerb_Inv();
		}
}
