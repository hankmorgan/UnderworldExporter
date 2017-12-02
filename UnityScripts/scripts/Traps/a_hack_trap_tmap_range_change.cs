using UnityEngine;
using System.Collections;

public class a_hack_trap_tmap_range_change : a_hack_trap {


		//Looks like it changes a range of textures on TMAPs between the trap of the trigger object and the trap
		//Tmaps with a quality == 40 get incremented by the traps owner and their texture changes accordingly

		//This implementation is not fully correct yet!


	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
				int minX= Mathf.Min (triggerX, src.objInt().tileX);
				int minY= Mathf.Min (triggerY, src.objInt().tileY);
				int maxX= Mathf.Max (triggerX, src.objInt().tileX);
				int maxY= Mathf.Max (triggerY, src.objInt().tileY);
				minX=0;
				minY=0;
				maxX=63;
				maxY=63;
				ObjectLoaderInfo[] objList=GameWorldController.instance.CurrentObjectList().objInfo;
				for (int i=0; i<=objList.GetUpperBound(0);i++)
				{
						if ((objList[i].item_id == 366) || (objList[i].item_id == 367))
						{
								if (objList[i].instance!=null)
								{
										if (
												(objList[i].instance.tileX>=minX)&&
												(objList[i].instance.tileX<=maxX)&&
												(objList[i].instance.tileY>=minY)&&
												(objList[i].instance.tileY<=maxX)
												)
										{
												if (objList[i].instance.quality==40)
												{
														TMAP tmap= objList[i].instance.GetComponent<TMAP>();
														if (tmap!=null)
														{
																tmap.objInt().owner=(short)(40+objInt().owner);	
																tmap.TextureIndex=GameWorldController.instance.currentTileMap().texture_map[40+objInt().owner];
																TMAP.CreateTMAP(tmap.gameObject, tmap.TextureIndex );		
														}
												}
										}
								}
						}
				}

	}


	public override void PostActivate (object_base src)
	{

	}
}
