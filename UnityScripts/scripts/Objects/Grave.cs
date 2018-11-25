using UnityEngine;
using System.Collections;
using System.Linq;

public class Grave : Model3D {
	///ID of the grave to lookup
	//public int GraveID;
	bool LookingAt;
	float timeOut=0f;


	public override void Update() 
	{
		if (LookingAt)
		{
			timeOut+=Time.deltaTime;
			if (timeOut>=5f)
			{
				LookingAt=false;
				UWHUD.instance.CutScenesSmall.anim.SetAnimation="Anim_Base";
			}
		}
	}


	/// <summary>
	/// Plays cutscene that displays the gravestone.
	/// </summary>
	/// <returns>The <see cref="System.Boolean"/>.</returns>
	public override bool LookAt ()
	{
		UWHUD.instance.CutScenesSmall.anim.SetAnimation= "Grave_" + GraveID();
		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (8, link-512));
		return true;
	}

	public int GraveID()
	{
		char[] graves;
		//Load in the grave information
		if (_RES!=GAME_UW2)
		{
				DataLoader.ReadStreamFile(Loader.BasePath + "DATA" + sep + "GRAVE.DAT", out graves);
				if (link >= 512)
				{
						return (short)DataLoader.getValAtAddress(graves, link - 512, 8)-1;
				}		
		}
		return 0;
	}


	public override bool use ()
	{
		if (CurrentObjectInHand==null)
		{
			return LookAt ();
		}
		else
		{
			return ActivateByObject(CurrentObjectInHand);
		}
	}

		/// <summary>
		/// Activation of this object by another. EG key on door
		/// </summary>
		/// <returns>true</returns>
		/// <c>false</c>
		/// <param name="ObjectUsed">Object used.</param>
		/// Special case here for Garamon's grave. Activates a hard coded trigger
	public override bool ActivateByObject (ObjectInteraction ObjectUsed)
	{
		//ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (GraveID()==5)
			{//Garamon's grave
			//Activates a trigger a_move_trigger_54_52_04_0495 (selected by unknown means)
			if (ObjectUsed.item_id==198)//Bones
				{
					if (ObjectUsed.quality==63)
					{//Garamons bones
					//Arise Garamon.
					//000~001~134~You thoughtfully give the bones a final resting place.
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,StringController.str_you_thoughtfully_give_the_bones_a_final_resting_place_));

					ObjectInteraction trigObj =CurrentObjectList().objInfo[495].instance; 
					if (trigObj!=null)
					{					
						link++;//Update the grave description
                        ObjectUsed.consumeObject ();
						trigObj.GetComponent<trigger_base>().Activate(this.gameObject);
						Quest.instance.isGaramonBuried=true;
						CurrentObjectInHand=null;	
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
					CurrentObjectInHand=null;						
					return true;
					}
					else
					{//Regular bones
						//000~001~259~The bones do not seem at rest in the grave, and you take them back.
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,259));
						CurrentObjectInHand=null;
						return true;
					}
				}
			else
				{
				return ObjectUsed.FailMessage();
				}
			}
		else
		{
			if ((ObjectUsed.item_id==198) && (ObjectUsed.quality==63))//Garamons Bones used on the wrong grave
			{
				//000~001~259~The bones do not seem at rest in the grave, and you take them back.
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,259));
				CurrentObjectInHand=null;
				return true;
			}
			else
			{
				CurrentObjectInHand=null;
				return ObjectUsed.FailMessage();
			}
		}
	}


	public override string UseObjectOnVerb_World ()
	{
		if (CurrentObjectInHand != null)
		{
			switch (CurrentObjectInHand.item_id)	
			{
			case 198://Bones
				return "bury remains";
			}
		}

		return base.UseObjectOnVerb_Inv();
	}


	/***************************Model definition*******************/

	public override int NoOfMeshes ()
	{
		return 2;
	}

	public override Vector3[] ModelVertices ()
	{
		Vector3[] ModelVerts=new Vector3[8];
		ModelVerts[0] = new Vector3(-0.125f,0f,-0.015625f);
		ModelVerts[1] = new Vector3(-0.125f,0.375f,-0.015625f);
		ModelVerts[2] = new Vector3(0.125f,0.375f,-0.015625f);
		ModelVerts[3] = new Vector3(0.125f,0f,-0.015625f);
		ModelVerts[4] = new Vector3(-0.125f,0f,0.015625f);
		ModelVerts[5] = new Vector3(-0.125f,0.375f,0.015625f);
		ModelVerts[6] = new Vector3(0.125f,0.375f,0.015625f);
		ModelVerts[7] = new Vector3(0.125f,0f,0.015625f);
		return ModelVerts;
	}

	public override int[] ModelTriangles (int meshNo)
	{
		switch (meshNo)
		{
		case 0://headstone
			return new int[]{0,2,1,0,3,2,4,5,6,4,6,7}.Reverse().ToArray();
		case 1://trim
			return new int[]{0,1,4,4,1,5,3,7,6,3,6,2,5,1,2,5,2,6,0,4,7,0,7,3}.Reverse().ToArray();
		}

		return base.ModelTriangles(meshNo);
	}


	public override Material ModelMaterials (int meshNo)
	{
		switch (meshNo)
		{
		case 0://headstone
			return GameWorldController.instance.MaterialObj[flags+28];
		case 1://Trim
			return GameWorldController.instance.MaterialObj[flags+28];
		}
		return base.ModelMaterials (meshNo);
	}


	public override Vector2[] ModelUVs (Vector3[] verts)
	{
		Vector2[] ModelUvs=new Vector2[8];
		ModelUvs[0] = new Vector2(0f,0f);
		ModelUvs[1] = new Vector2(0f,1f);
		ModelUvs[2] = new Vector2(1f,1f);
		ModelUvs[3] = new Vector2(1f,0f);
		ModelUvs[4] = new Vector2(0f,0f);
		ModelUvs[5] = new Vector2(0f,1f);
		ModelUvs[6] = new Vector2(1f,1f);
		ModelUvs[7] = new Vector2(1f,0f);
		return ModelUvs;
	}

}