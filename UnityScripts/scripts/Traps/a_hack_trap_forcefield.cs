using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A hack trap forcefield.
/// </summary>
/// Raises or lowers a forcefield in scintilus level 5.
public class a_hack_trap_forcefield : a_hack_trap {



	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
				ObjectInteraction forcefieldtoMove= findForceField();
				if (forcefieldtoMove!=null)
				{
						if (forcefieldtoMove.zpos==127)
						{
								forcefieldtoMove.zpos=0;
								forcefieldtoMove.objectloaderinfo.zpos=0;
						}
						else
						{
								forcefieldtoMove.zpos=127;
								forcefieldtoMove.objectloaderinfo.zpos=127;
						}
						forcefieldtoMove.transform.position= ObjectLoader.CalcObjectXYZ(_RES, 
								GameWorldController.instance.currentTileMap(),
								GameWorldController.instance.currentTileMap().Tiles,
								GameWorldController.instance.CurrentObjectList().objInfo,
								forcefieldtoMove.objectloaderinfo.index,
								forcefieldtoMove.tileX,
								forcefieldtoMove.tileY,
								1
						);
				}
	}

	public override void PostActivate (object_base src)
	{

	}

	ObjectInteraction findForceField()
	{
		ObjectLoaderInfo[] objList=GameWorldController.instance.CurrentObjectList().objInfo;
		for (int i= 256; i<=objList.GetUpperBound(0);i++)
		{
      if ((objList[i].InUseFlag==1) && (objList[i].instance!=null) && objList[i].item_id==365)
			{
								if (
										(objList[i].instance.tileX== objInt().tileX)
										&&
										(objList[i].instance.tileY== objInt().tileY)
								)
								{
										return objList[i].instance;
								}
			}
		}
		return null;
	}
}
