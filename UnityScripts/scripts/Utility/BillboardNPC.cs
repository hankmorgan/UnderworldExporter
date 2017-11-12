using UnityEngine;
using System.Collections;

public class BillboardNPC : Billboard {

		void Update()
		{
				if (Vector3.Distance(this.transform.position, UWCharacter.Instance.CameraPos)<=8)
				{//Only rotate nearby objects.

					if (UWCharacter.Instance.dir!=Vector3.zero)
					{
						transform.rotation = Quaternion.LookRotation(UWCharacter.Instance.dirForNPC);						
					}

						//based on http://answers.unity3d.com/questions/524087/tweaking-sprite-billboard.html

				}
		}
}
