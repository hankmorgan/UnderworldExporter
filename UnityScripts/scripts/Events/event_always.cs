using UnityEngine;
using System.Collections;
/// <summary>
/// Variant of the event trigger that will run regardless of the execution flag.
/// </summary>
public class event_always : event_base {
		

	public override void Process ()
	{
		if (CheckCondition())
		{
			ExecuteEvent();
		}
	}

}
