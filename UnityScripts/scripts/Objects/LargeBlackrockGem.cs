using UnityEngine;
using System.Collections;

public class LargeBlackrockGem : Model3D {



	protected override void Start ()
	{
		return;//this gets in the way for the moment!
		GameObject SpriteController = GameObject.CreatePrimitive(PrimitiveType.Cylinder); 
		SpriteController.name = this.name + "_model";
		SpriteController.transform.position = this.transform.position;
		SpriteController.transform.rotation=this.transform.rotation;
		SpriteController.transform.parent = this.transform;
		//SpriteController.transform.localScale=new Vector3(0.5f,0.5f,0.1f);
		SpriteController.transform.localPosition=new Vector3(0.0f,0.25f,0.0f);
	}

	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand!="")
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}
		else
		{
			return base.use();
		}
	}

	public override bool ActivateByObject (GameObject ObjectUsed)
	{
		ObjectInteraction objI=ObjectUsed.GetComponent<ObjectInteraction>();
		if (objI!=null)
		{
			if (objI.GetItemType()==ObjectInteraction.A_BLACKROCK_GEM)
			{
				if (objI.owner==1)
				{	
					int thisGemIndex= objI.item_id-280;
					int bitField = (1<<thisGemIndex);
					GameWorldController.instance.playerUW.quest().x_clocks[2]++;
					GameWorldController.instance.playerUW.quest().QuestVariables[130] |= bitField;
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,338));				
								UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,338+GameWorldController.instance.playerUW.quest().x_clocks[2]));
					objI.consumeObject();						
				}
				else
				{
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,347));
				}				
				GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
				return true;
			}
		}
		return false;
	}
}
