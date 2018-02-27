using UnityEngine;
using System.Collections;

public class IceCollision : UWEBase {

		void OnTriggerEnter(Collider other)
		{
				
			if (UWCharacter.Instance.onIce)
			{
						//Vector3.Reflect(UWCharacter.Instance.IceVelocity, other.
				Debug.Log ("bounce off of " + other.name);	
			}

		}


		void OnCollisionEnter(Collision collision)
		{
				if (UWCharacter.Instance.onIce)
				{
						//Vector3.Reflect(UWCharacter.Instance.IceVelocity, other.
						Debug.Log ("collision off o f " + collision.gameObject.name);	
				}

		}


}
