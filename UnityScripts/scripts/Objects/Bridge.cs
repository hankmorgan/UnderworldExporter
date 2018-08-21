using UnityEngine;
using System.Collections;
/// <summary>
/// Bridge.
/// </summary>
/// Bridge Object in maps.
/// The physical bridge is created as part of the map export but look descriptions are set up here using box colliders
public class Bridge : map_object {
	//Texture index for the bridge description
	//public int TextureIndex;
	//public string UseLink;//A trigger to fire when used.

	protected override void Start ()
	{		
        if (invis==0)
        {
            TileMapRenderer.RenderBridge(GameWorldController.instance.SceneryModel, CurrentTileMap(), CurrentObjectList(), objInt().objectloaderinfo.index);
        }

        base.Start();

        BoxCollider bx = this.GetComponent<BoxCollider>();
		if (bx!=null)
		{
			bx.center=new Vector3(0.08f, 0.006f, 0.08f);	
			bx.size=new Vector3(1.2f, 0.18f, 1.2f);
		}
		if (
				(ObjectTileX <= TileMap.TileMapSizeX)
				&&
				(ObjectTileY <= TileMap.TileMapSizeY)
			)
			{
				int TextureIndex=  (enchantment<<3) | flags & 0x3F;
				if (TextureIndex<2)
				{//Only flag the normal briges as such.
						CurrentTileMap().Tiles[ObjectTileX, ObjectTileY].hasBridge=true;				
				}
			}
	}

		/// <summary>
		/// Outputs the look description of the object
		/// </summary>
		/// <returns>The <see cref="System.Boolean"/>.</returns>
		/// If flags less than 2 return a simple description
		/// If greater than or equal to 2 return a description of the texture of the bridge
		/// Examples: the tile puzzle in level6 seers and the Goblin shower in the tower in UW2
	public override bool LookAt ()
	{
		if(invis==0)	
		{
			if ( ( (enchantment<<3) | flags)<2)
			{
					return base.LookAt ();
			}
			else
			{
					int TextureIndex=(enchantment<<3) | flags & 0x3F; //<--Is this correct. Flags is only 3 bits long!
					//Return material description
					UWHUD.instance.MessageScroll.Add (StringController.instance.TextureDescription(( 510- (TextureIndex-210)  )));
					return true;
			}	
		}
		else
		{
			return true;//No description for invisible bridges
		}
	}

		/// <summary>
		/// Allows using of a bridge to activate traps
		/// </summary>
		/// Used in the tile puzzle on the Level 6-seers
	public override bool use ()
	{
		if (flags >= 2)
			{				
				GameObject obj = ObjectLoader.getGameObjectAt(link);
				if (obj!=null)
				{
					if (obj.GetComponent<trigger_base>()!=null)
					{
						return obj.GetComponent<trigger_base>().Activate(this.gameObject);
					}
				}	
			}
		return false;
	}

	public override string ContextMenuUsedDesc ()
	{
		return "";
	}

}
