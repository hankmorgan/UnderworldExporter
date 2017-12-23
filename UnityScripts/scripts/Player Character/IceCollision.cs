using UnityEngine;
using System.Collections;

public class IceCollision : UWEBase {

		void OnTriggerEnter(Collider other)
		{
			if (UWCharacter.Instance.onIce)
			{
				Debug.Log ("bounce off of " + other.name);	
			}

		}


}
