using UnityEngine;
using System.Collections;

public class Grave : object_base {
	///ID of the grave to lookup
	//public int GraveID;
	bool LookingAt;
	float timeOut=0f;
	protected override void Start ()
	{
		base.Start ();
		//GraveID=  objInt().objectloaderinfo.DeathWatched;//seriously?????? Need to make this better. Look at BuildObjectList
		CreateGrave(this.gameObject,objInt());
	}

	void Update()
	{
		if (LookingAt)
		{
			timeOut+=Time.deltaTime;
			if (timeOut>=5f)
			{
				LookingAt=false;
				UWHUD.instance.CutScenesSmall.anim.SetAnimation="Anim_Base";
							//	UWHUD.instance.CutScenesSmall.TargetControl.texture=UWHUD.instance.CutScenesSmall.anim_base
			}
		}
	}


	/// <summary>
	/// Plays cutscene that displays the gravestone.
	/// </summary>
	/// <returns>The <see cref="System.Boolean"/>.</returns>
	public override bool LookAt ()
	{
		//CheckReferences();
		//UWHUD.instance.CutScenesSmall.SetAnimation= "cs401_n01_00" + (GraveID-1).ToString ("D2");
//				UWHUD.instance.mainwindow_art.mainTexture= GameWorldController.instance.cutsLoader.

		//GameWorldController.instance.cutsLoader= new CutsLoader("cs401.n01");
		//UWHUD.instance.CutScenesSmall.TargetControl.texture=GameWorldController.instance.cutsLoader.LoadImageAt(GraveID());
		UWHUD.instance.CutScenesSmall.anim.SetAnimation= "Grave_" + GraveID();
		//LookingAt=true;timeOut=0f;
		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (8, objInt().link-512));
		return true;
	}

	public int GraveID()
	{
		char[] graves;
		//Load in the grave information
		DataLoader.ReadStreamFile(Loader.BasePath + "DATA\\GRAVE.DAT", out graves);
		if (objInt().link >= 512)
		{
			return (short)DataLoader.getValAtAddress(graves, objInt().link - 512, 8)-1;
		}
		return 0;
	}


	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			return LookAt ();
		}
		else
		{
			//TODO: if garamons bones activate something special.
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
			//return UWCharacter.Instance.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
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
			if (GraveID()==5)
			{//Garamon's grave
			//Activates a trigger a_move_trigger_54_52_04_0495 (selected by unknown means)
			if (objIntUsed.item_id==198)//Bones
				{
					if (objIntUsed.quality==63)
					{//Garamons bones
					//Arise Garamon.
					//000~001~134~You thoughtfully give the bones a final resting place.
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,StringController.str_you_thoughtfully_give_the_bones_a_final_resting_place_));

					ObjectInteraction trigObj =GameWorldController.instance.CurrentObjectList().objInfo[495].instance; // GameObject.Find ("a_move_trigger_54_52_04_0495");
					if (trigObj!=null)
					{					
						objInt().link++;//Update the grave description
						objIntUsed.consumeObject ();
						trigObj.GetComponent<trigger_base>().Activate(this.gameObject);
						Quest.instance.isGaramonBuried=true;
						UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
						UWCharacter.Instance.playerInventory.ObjectInHand="";	
						//Garamon does not initiate conversation normally so I force the conversation.
						GameObject garamon = GameObject.Find(a_create_object_trap.LastObjectCreated);
						if (garamon!=null)
						{
							if (garamon.GetComponent<NPC>()!=null)
							{
								garamon.GetComponent<NPC>().TalkTo();
							}
						}
					}
					UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
					UWCharacter.Instance.playerInventory.ObjectInHand="";	
					
					return true;
					}
					else
					{//Regular bones
						//000~001~259~The bones do not seem at rest in the grave, and you take them back.
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,259));
						UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
						UWCharacter.Instance.playerInventory.ObjectInHand="";
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
			if ((objIntUsed.item_id==198) && (objIntUsed.quality==63))//Garamons Bones used on the wrong grave
			{
				//000~001~259~The bones do not seem at rest in the grave, and you take them back.
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,259));
				UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
				UWCharacter.Instance.playerInventory.ObjectInHand="";
				return true;
			}
			else
			{
				UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
				UWCharacter.Instance.playerInventory.ObjectInHand="";
				return ObjectUsed.GetComponent<ObjectInteraction>().FailMessage();
			}
		}
	}


	public override string UseObjectOnVerb_World ()
	{
		ObjectInteraction ObjIntInHand=UWCharacter.Instance.playerInventory.GetObjIntInHand();
		if (ObjIntInHand!=null)
		{
			switch (ObjIntInHand.item_id)	
			{
			case 198://Bones
				return "bury remains";
			}
		}

		return base.UseObjectOnVerb_Inv();
	}


		public static void CreateGrave(GameObject myObj, ObjectInteraction objInt)
		{//TODO:make this a properly texture model as part of map generation.
			myObj.layer=LayerMask.NameToLayer("MapMesh");

			GameObject SpriteController = GameObject.CreatePrimitive(PrimitiveType.Cube); 
			SpriteController.name = myObj.name + "_cube";
			SpriteController.transform.position = myObj.transform.position;
			SpriteController.transform.rotation=myObj.transform.rotation;
			SpriteController.transform.parent = myObj.transform;
			SpriteController.transform.localScale=new Vector3(0.5f,0.5f,0.1f);
			SpriteController.transform.localPosition=new Vector3(0.0f,0.25f,0.0f);

			MeshRenderer mr = SpriteController.GetComponent<MeshRenderer>();
			mr.material= (Material)Resources.Load (_RES+ "/Materials/tmobj/tmobj_" + objInt.flags+28);
			mr.material.mainTexture= GameWorldController.instance.TmObjArt.LoadImageAt(objInt.flags+28);
			BoxCollider bx = myObj.GetComponent<BoxCollider>();
			bx.center= new Vector3(0.0f,0.25f,0.0f);
			bx.size=new Vector3(0.5f,0.5f,0.1f);
			bx.isTrigger=false;

			bx=SpriteController.GetComponent<BoxCollider>();
			bx.enabled=false;
			Component.DestroyImmediate (bx);
		}
}