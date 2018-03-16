using UnityEngine;
using System.Collections;

public class trigger_base : object_base {

	//public string TrapObject;//The next trap to activte
	//public int state;

		/// <summary>
		/// The trigger me now. Fire off the trigger to test it's operation.
		/// </summary>
		public bool TriggerMeNow=false;

	protected override void Start ()
	{
		base.Start ();
		this.gameObject.layer=LayerMask.NameToLayer("Ignore Raycast");
	}

	public override bool Activate (GameObject src)
	{
		GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link);
		if (triggerObj!=null)
		{
			if (triggerObj.GetComponent<trap_base>() !=null)
			{
				triggerObj.GetComponent<trap_base>().Activate (this, objInt().quality,objInt().owner,objInt().flags);	
			}
		}

		PostActivate(src);
		return true;
	}

	public virtual void PostActivate(GameObject src)
	{
		int TriggerRepeat = (objInt().flags>>1) & 0x1;
		//Debug.Log(TriggerRepeat);
		if (TriggerRepeat==0)
		{
			
			if (src!=null)
			{
				if (src.GetComponent<ObjectInteraction>()!=null)
				{//Clear the link to the trigger/trap from the source if it is destroyed.
					if (src.GetComponent<ObjectInteraction>().link == this.gameObject.GetComponent<ObjectInteraction>().objectloaderinfo.index)
					{
						src.GetComponent<ObjectInteraction>().link=0;
					}
				}	
			}
			objInt().objectloaderinfo.InUseFlag=0;
			//ObjectInteraction.UpdateLinkedList(objInt(),objInt().tileX,objInt().tileY, TileMap.ObjectStorageTile, TileMap.ObjectStorageTile);
			Destroy (this.gameObject);
		}
	}

	public virtual void Update()
	{
		if(TriggerMeNow)
		{
			TriggerMeNow=false;
			Activate(this.gameObject);
		}
	}


}

