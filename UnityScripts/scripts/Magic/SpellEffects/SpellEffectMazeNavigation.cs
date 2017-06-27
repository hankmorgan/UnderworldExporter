using UnityEngine;
using System.Collections;
/// <summary>
/// Used to navigate typbals maze.
/// </summary>
/// Changes materials that contain the words "_maze" to use the color yellow as their tint.
public class SpellEffectMazeNavigation : SpellEffect {

	//public Material toChange;

	public override void ApplyEffect ()
	{
		MeshRenderer[] mr = GameWorldController.instance.getCurrentLevelModel().GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i<=mr.GetUpperBound (0);i++)
		{
			if (mr[i].sharedMaterial!=null)
			{
				if (mr[i].sharedMaterial.name.Contains("_maze"))
				{
						//toChange = mr[i].material;
						mr[i].material.SetColor ("_Color", Color.yellow);
				}	
			}

		}
		base.ApplyEffect ();
	}

	public override void CancelEffect ()
	{

		MeshRenderer[] mr = GameWorldController.instance.getCurrentLevelModel().GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i<=mr.GetUpperBound (0);i++)
		{
			if (mr[i]!=null)
			{
				if (mr[i].sharedMaterial!=null)
				{
					if (mr[i].sharedMaterial.name.Contains("_maze"))
					{
							//toChange = mr[i].material;
						mr[i].material.SetColor ("_Color", Color.white);
					}	
				}
			}
			
		}
		base.CancelEffect();	
	}
}
