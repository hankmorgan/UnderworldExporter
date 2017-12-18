using UnityEngine;
using System.Collections;

/// <summary>
/// A hack trap texture.
/// </summary>
/// changes the texture of the object it is linked to
/// Only instance seen so far is to change the texture map object.
public class a_hack_trap_texture : a_hack_trap {


	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		if (objInt().link!=0)
		{
			GameObject obj = 	ObjectLoader.getGameObjectAt(objInt().link);
			if (obj!=null)
			{
				TMAP tmap = obj.GetComponent<TMAP>();
				if (tmap!=null)
				{
					tmap.objInt().owner=objInt().owner;	
					tmap.TextureIndex=GameWorldController.instance.currentTileMap().texture_map[objInt().owner];
					TMAP.CreateTMAP(obj, tmap.TextureIndex );
				}
				else
				{
					Debug.Log("no tmap found on " + obj.name);
				}
			}
		}		
	}

	public override void PostActivate (object_base src)
	{

	}
}