using UnityEngine;
using System.Collections;


/// <summary>
/// Tile contact.
/// </summary>
/// Events that occur when objects come into contact with the world tiles
public class TileContact : UWEBase {


	protected virtual void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<ObjectInteraction>()!=null)
			{
				TileContactEvent(collision.gameObject.GetComponent<ObjectInteraction>(), collision.contacts[0].point);
			}
		//Debug.Log(collision.other.name + " has collided with " + this.name);
	}


	protected virtual void TileContactEvent(ObjectInteraction obj, Vector3 position)
	{
				
	}

	/// <summary>
	/// Determines whether this object is a quest object or similar object that should not be destroyed by contact. If it is a container it will search to the container for a quest object.
	/// </summary>
	/// <returns><c>true</c> if this instance is object quest related the specified obj; otherwise, <c>false</c>.</returns>
	/// <param name="obj">Object.</param>
	/// Implemented for UW1 only so far.
	public bool IsObjectDestroyable(ObjectInteraction obj)
	{
			int[] UW1_Protected_items = {453,10,50,47,54,55,151,147,
					280,281,275,272,273,276,258,259,
					260,261,262,263,265,265,266,267,
					268,269,270,285,191,175,287,290,143,315 };
				
		if (ObjectLoader.isStatic(obj.objectloaderinfo))
		{
			return false;
		}

		if ((obj.item_id>=64) && (obj.item_id<=127))
		{//For the moment don't do anything to Npcs
				return false;
		}

		if (obj.GetComponent<Rigidbody>() !=null)
		{
			if (obj.GetComponent<Rigidbody>().useGravity==false)
			{//Object has probably spawned at this point.
				return false;
			}
		}

		for (int i=0; i<=UW1_Protected_items.GetUpperBound(0); i++)
		{
			if (obj.item_id==UW1_Protected_items[i])
			{
				return false;
			}
		}

		if (obj.GetComponent<Container>()!=null)
		{
			Container cn = obj.GetComponent<Container>();
			for (int i=0; i<=UW1_Protected_items.GetUpperBound(0); i++)
			{
				if (cn.findItemOfType(UW1_Protected_items[i] )!="")
					{
						return false;
					}
			}
		}		
		return true;			
	}

			
	/// <summary>
	/// Destroies the object that has come into contact with this tile.
	/// </summary>
	/// <param name="obj">Object.</param>
	protected virtual void DestroyObject(ObjectInteraction obj)
	{
		obj.objectloaderinfo.InUseFlag=0;//Free up the slot
		Destroy (obj.gameObject);		
	}
}
