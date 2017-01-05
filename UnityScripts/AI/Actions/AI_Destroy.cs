using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_Destroy : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		//Spawn a bloodstain at this spot.
		int bloodstain=-1;
		/*GameObject myObj=new GameObject("SummonedObject_" + GameWorldController.instance.playerUW.PlayerMagic.SummonCount++);
		myObj.layer=LayerMask.NameToLayer("UWObjects");
		myObj.transform.position = ai.Body.transform.position;
		myObj.transform.parent=GameWorldController.instance.LevelMarker();
		ObjectInteraction.CreateObjectGraphics(myObj,"Sprites/OBJECTS_" + bloodstain,true);
		ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_" +bloodstain, "Sprites/OBJECTS_" + bloodstain, "Sprites/OBJECTS_" + bloodstain, ObjectInteraction.SCENERY, bloodstain, 1, 40, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		myObj.AddComponent<object_base>();*/

				//Nothing = 0x00, 
				//RotwormCorpse = 0x20, 
				//Rubble = 0x40, 
				//WoodChips = 0x60, 
				//Bones = 0x80, 
				//GreenBloodPool = 0xA0, 
				//RedBloodPool = 0xC0, 
				//RedBloodPoolGiantSpider = 0xE0. 
				ObjectInteraction objInt = ai.Body.GetComponent<ObjectInteraction>();
				switch (GameWorldController.instance.critter.Remains[objInt.item_id-64])
				{

				case 0x20://Rotworm corpse
						bloodstain=217;
						break;
				case 0x40://Rubble
						bloodstain=218;
						break;
				case 0x60://Woodchips
						bloodstain=219;
						break;
				case 0x80://Bones
						bloodstain=220;
						break;
				case 0xA0://Greenblood
						bloodstain=221;
						break;
				case 0xC0://Redblood
						bloodstain=222;
						break;
				case 0xE0://RedBloodPoolGiantSpider
						bloodstain=223;
						break;
				case 0://Nothing
				default:
						bloodstain=-1;
						break;
				}

				if(bloodstain!=-1)
				{
					ObjectInteraction remains = ObjectInteraction.CreateNewObject(bloodstain);						
					remains.gameObject.transform.parent=GameWorldController.instance.LevelMarker();
					remains.transform.position=ai.Body.transform.position;
				}

		GameObject.Destroy(ai.Body);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}