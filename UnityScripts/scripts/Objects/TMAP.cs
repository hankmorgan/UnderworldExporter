using UnityEngine;
using System.Collections;

public class TMAP : object_base {

	//public string trigger;
	private int TextureIndex;

	protected override void Start ()
	{
		base.Start ();
				/*
		if (objInt().y == 0)
		{
			this.transform.Translate(0.0f,0.0f,0.01f);
		}
		if (objInt().y == 7)
		{
				this.transform.Translate(0.0f,0.0f,-0.01f);
		}
		if (objInt().x == 0)
		{
				this.transform.Translate(-0.1f,0.0f,0.0f);
		}
		if (objInt().x == 7)
		{
			this.transform.Translate(0.1f,0.0f,0.0f);
		}
*/

		TextureIndex=GameWorldController.instance.currentTileMap().texture_map[objInt().owner];
		CreateTMAP(this.gameObject,TextureIndex);	
	}


	public override bool LookAt()
	{
		UWHUD.instance.MessageScroll.Add (StringController.instance.TextureDescription(TextureIndex));
		if ((TextureIndex==142) && ((_RES==GAME_UW1) || (_RES==GAME_UWDEMO)))
		{//This is a window into the abyss.
			UWHUD.instance.CutScenesSmall.anim.SetAnimation="VolcanoWindow_" + GameWorldController.instance.LevelNo;
			UWHUD.instance.CutScenesSmall.anim.looping=true;
		}
		if (objInt().link != 0)
		{
			GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link);
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
			if (objInt().link != 0)
			{
				GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link);
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
		if ((UWEBase._RES== UWEBase.GAME_UW1) && (TextureIndex==47))//The door to the base of the abyss.
		{
			if (ObjectUsed.GetComponent<ObjectInteraction>().item_id==231)//The key of infinity.
			{
				if (objInt().link != 0)
				{
					GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link);
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


		static void CreateTMAP(GameObject myObj, int textureIndex)
		{		
			ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
			TileMap tm = GameWorldController.instance.currentTileMap();
				float doorFrameOffsetX=0f;float doorFrameOffsetY=0f;
				if (tm.Tiles[objInt.tileX, objInt.tileY].isDoor)
				{
						switch (objInt.heading * 45)
						{
						case ObjectInteraction.HEADINGSOUTH:
								doorFrameOffsetX=-.03f;
								break;
						case ObjectInteraction.HEADINGNORTH:
								doorFrameOffsetX=+.03f;
								break;

						case ObjectInteraction.HEADINGEAST:
								doorFrameOffsetY=+.03f;
								break;
						case ObjectInteraction.HEADINGWEST:
								doorFrameOffsetY=-.03f;
								break;
						}
				}

			GameObject SpriteController = GameObject.CreatePrimitive(PrimitiveType.Quad);
			SpriteController.name = myObj.name + "_quad";
			SpriteController.transform.position = myObj.transform.position;
			SpriteController.layer=LayerMask.NameToLayer("UWObjects");
			SpriteController.transform.parent = myObj.transform;
			SpriteController.transform.localRotation= Quaternion.identity;
			SpriteController.transform.localScale=new Vector3(1.2f,1.2f,1.0f);
			SpriteController.transform.localPosition=new Vector3(doorFrameOffsetX,0.6f,doorFrameOffsetY );
			MeshRenderer mr = SpriteController.GetComponent<MeshRenderer>();
			//mr.material= (Material)Resources.Load (_RES+ "/Materials/tmap/" + _RES + "_" + textureIndex.ToString("d3"));
			mr.material=GameWorldController.instance.MaterialMasterList[textureIndex];//Assumes it is already loaded...
			BoxCollider bx = myObj.AddComponent<BoxCollider>();
			bx.size=new Vector3(1.25f,1.25f,0.1f);
			bx.center=new Vector3(0.0f,0.65f,0.0f);
			bx.isTrigger=true;
		}



}
