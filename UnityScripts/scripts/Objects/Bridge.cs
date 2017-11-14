using UnityEngine;
using System.Collections;
/// <summary>
/// Bridge.
/// </summary>
/// Bridge Object in maps.
/// The physical bridge is created as part of the map export but look descriptions are set up here using box colliders
public class Bridge : object_base {
	//Texture index for the bridge description
	//public int TextureIndex;
	//public string UseLink;//A trigger to fire when used.


		public GameObject ModelInstance;//The model that this bridge uses.


	protected override void Start ()
	{
		base.Start ();
		BoxCollider bx = this.GetComponent<BoxCollider>();
		if (bx!=null)
		{
			bx.center=new Vector3(0.08f, 0.006f, 0.08f);	
			bx.size=new Vector3(1.2f, 0.18f, 1.2f);
		}
		if (objInt().invis==0)
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

		/// <summary>
		/// Outputs the look description of the object
		/// </summary>
		/// <returns>The <see cref="System.Boolean"/>.</returns>
		/// If flags less than 2 return a simple description
		/// If greater than or equal to 2 return a description of the texture of the bridge
		/// Examples: the tile puzzle in level6 seers and the Goblin shower in the tower in UW2
	public override bool LookAt ()
	{
		if(objInt().invis==0)	
		{
			if ( ( (objInt().enchantment<<3) | objInt().flags)<2)
			{
					return base.LookAt ();
			}
			else
			{
					int TextureIndex=(objInt().enchantment<<3) | objInt().flags & 0x3F;
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
		if (objInt().flags >= 2)
			{				
				GameObject obj = ObjectLoader.getGameObjectAt(objInt().link);
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
