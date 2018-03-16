using UnityEngine;
using System.Collections;

public class trap_base : object_base {

	public bool ExecuteNow;
	//public string TriggerObject;//Next in the chain

	public virtual void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
	{
		//Do whatever
		Debug.Log ("Base Execute Trap " + this.name);
	}



	public virtual bool Activate(object_base src, int triggerX, int triggerY, int State)
	{	//triggerX aka quality, triggerY aka owner
		//CheckReferences();
		//Debug.Log (this.name);
		//Do what it needs to do.
		ExecuteTrap(src, triggerX,triggerY, State);

		//Trigger the next in the chain
		TriggerNext (triggerX, triggerY, State);

		//Stuff to happen after the trap has fired.
		PostActivate(src);
		return true;
	}

	public virtual void TriggerNext(int triggerX, int triggerY, int State)
	{
		if(objInt().link==0){return;}
		GameObject triggerObj= ObjectLoader.getGameObjectAt(objInt().link); // GameObject.Find (TriggerObject);
		if (triggerObj!=null)
		{
			trigger_base trig= triggerObj.GetComponent<trigger_base>();
			if (trig!=null)
			{
				trig.Activate(this.gameObject);
			}
			else
			{
				//try and find a trap instead
				trap_base trap = triggerObj.GetComponent<trap_base>();
				if (trap!=null)
				{
					trap.Activate(this, triggerX,triggerY,State);
					//return true;
				}
				else
				{									
					//Debug.Log ("no trigger or trap found on this object " + triggerObj);					
					//return false;
				}
			}
		}
	}

	public virtual void PostActivate(object_base src)
	{
		//Destruction of traps is probably controlled by the trigger.
		//int TriggerRepeat = (objInt().flags>>1) & 0x1;
		int TriggerRepeat = (objInt().flags) & 0x1;
		if (TriggerRepeat==0)
		{
			DestroyTrap (src);
		}
	}

	protected void DestroyTrap (object_base src)
	{
		if (src != null) {
			if (src.GetComponent<ObjectInteraction> () != null) {
				//Clear the link to the trigger/trap from the source if it is destroyed.
				if (src.GetComponent<ObjectInteraction> ().link == this.gameObject.GetComponent<ObjectInteraction> ().objectloaderinfo.index) {
					src.GetComponent<ObjectInteraction> ().link = 0;
				}
			}
		}
		objInt ().objectloaderinfo.InUseFlag = 0;
		//ObjectInteraction.UpdateLinkedList (objInt (), objInt ().tileX, objInt ().tileY, TileMap.ObjectStorageTile, TileMap.ObjectStorageTile);
		Destroy (this.gameObject);
	}

		/// <summary>
		/// Finds the trap of the specified type in chain of execution
		/// </summary>
		/// <returns><c>true</c>, if trap in chain was found, <c>false</c> otherwise.</returns>
		/// <param name="link">Link.</param>
		/// <param name="TrapType">Trap type.</param>
		public virtual bool FindTrapInChain(int link, int TrapType)
		{
			if (link!=0)
			{
				ObjectInteraction objLink = GameWorldController.instance.CurrentObjectList().objInfo[link].instance;
				if (objLink!=null)
				{
					if (objLink.GetItemType() == ObjectInteraction.A_DELETE_OBJECT_TRAP)
					{
						return (TrapType == ObjectInteraction.A_DELETE_OBJECT_TRAP);
					}
					if (objLink.GetItemType()== TrapType)
					{
						return true;
					}
					else
					{
						return FindTrapInChain(objLink.link, TrapType);						
					}
				}					
			}
			return false;
		}


		public virtual void Update()
		{
			if (ExecuteNow)
			{
				ExecuteNow=false;
				ExecuteTrap(this, 0 , 0 , 0);
			}
		}
}
