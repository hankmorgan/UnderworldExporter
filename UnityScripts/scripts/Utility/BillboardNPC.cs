using UnityEngine;
using System.Collections;

public class BillboardNPC : Billboard {

		void Update()
		{
				if (Vector3.Distance(this.transform.position, GameWorldController.instance.playerUW.CameraPos)<=8)
				{//Only rotate nearby objects.

					if (GameWorldController.instance.playerUW.dir!=Vector3.zero)
					{
						transform.rotation = Quaternion.LookRotation(GameWorldController.instance.playerUW.dirForNPC);						
					}

						//based on http://answers.unity3d.com/questions/524087/tweaking-sprite-billboard.html

				}
		}
}
