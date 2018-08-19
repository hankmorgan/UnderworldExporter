using UnityEngine;
using System.Collections;

/// <summary>
/// Map object that exists as both a game object and a 3d map object
/// </summary>
public class map_object : object_base {
	public GameObject ModelInstance;//The model that this bridge uses.


	protected override void Start ()
	{
		base.Start();
		if (invis==0)
		{
			foreach (Transform t in GameWorldController.instance.SceneryModel.transform)
			{
				if (t.name == this.name)
				{
					ModelInstance = t.gameObject;
					return;
				}
			}
		}
		else
		{//Make this bridge use it's box collider for collision
			this.gameObject.layer=LayerMask.NameToLayer("MapMesh");
		}
	}
}
