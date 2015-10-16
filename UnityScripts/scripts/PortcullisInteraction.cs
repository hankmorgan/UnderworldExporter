using UnityEngine;
using System.Collections;

public class PortcullisInteraction : MonoBehaviour {

	public ObjectInteraction getParentObjectInteraction()
	{
		return this.transform.parent.parent.GetComponent<ObjectInteraction>();
	}
}
