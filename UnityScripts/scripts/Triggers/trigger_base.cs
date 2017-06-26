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

	public override bool Activate ()
	{
		GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link);
		if (triggerObj!=null)
		{
			if (triggerObj.GetComponent<trap_base>() !=null)
			{
				triggerObj.GetComponent<trap_base>().Activate (this, objInt().quality,objInt().owner,objInt().flags);	
			}
		}

		PostActivate();
		return true;
	}

	public virtual void PostActivate()
	{
		int TriggerRepeat = (objInt().flags>>1) & 0x1;
		//Debug.Log(TriggerRepeat);
		if (TriggerRepeat==0)
		{
			this.gameObject.GetComponent<ObjectInteraction>().objectloaderinfo.InUseFlag=0;
			Destroy (this.gameObject);
		}

	}

	public virtual void Update()
	{
		if(TriggerMeNow)
		{
			TriggerMeNow=false;
			Activate();
		}
	}


}

