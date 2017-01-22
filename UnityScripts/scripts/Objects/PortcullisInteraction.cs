using UnityEngine;
using System.Collections;

public class PortcullisInteraction : MonoBehaviour {

		/// <summary>
		/// Gets the parent object interaction. Matches the trigger with the actual door control
		/// </summary>
		/// <returns>The parent object interaction.</returns>
	public ObjectInteraction getParentObjectInteraction()
	{
		return this.transform.parent.parent.GetComponent<ObjectInteraction>();
	}
}
