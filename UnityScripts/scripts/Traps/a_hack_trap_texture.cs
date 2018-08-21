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
		if (link!=0)
		{
			GameObject obj = 	ObjectLoader.getGameObjectAt(link);
			if (obj!=null)
			{
				TMAP tmap = obj.GetComponent<TMAP>();
				if (tmap!=null)
				{
					tmap.owner=owner;	
					tmap.TextureIndex=CurrentTileMap().texture_map[owner];
					TMAP.CreateTMAP(obj, tmap.TextureIndex );
				}
				else
				{
					Debug.Log("no tmap found on " + obj.name);
				}
			}
		}		
	}

	//public override void PostActivate (object_base src)
	//{
 //       Debug.Log("Overridden PostActivate to test " + this.name);
 //       base.PostActivate(src);
 //   }
}