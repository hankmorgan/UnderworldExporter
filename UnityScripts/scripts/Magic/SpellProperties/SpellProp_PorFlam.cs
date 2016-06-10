using UnityEngine;
using System.Collections;

public class SpellProp_PorFlam : SpellProp {
	//Fireball
	int splashDamage;//Damage applied to the explosion.
	float splashDistance;
	
		public override void init ()
	{
			base.init ();
			ProjectileSprite = "Sprites/objects_020";
			Force=200.0f;
			BaseDamage=16;
			splashDamage=8;
			splashDistance=3.0f;
			impactFrameStart=21;
			impactFrameEnd=25;
	}


	public override void onImpact (Transform tf)
	{
		base.onImpact (tf);
		//A big old explosion
				for (int i=0;i<3;i++)
				{//The flames
						Vector3 pos = tf.position+(Random.insideUnitSphere*0.5f);
						GameObject hitimpact = new GameObject("_impact");
						hitimpact.transform.position=pos;//ray.GetPoint(weaponRange/0.7f);
						Impact imp= hitimpact.AddComponent<Impact>();
						imp.FrameNo=31;
						imp.EndFrame=35;
						imp.go();

				}
		foreach (Collider Col in Physics.OverlapSphere(tf.position,splashDistance))
		{
			if (Col.gameObject!=tf.gameObject)			
			{
					if (Col.gameObject.GetComponent<ObjectInteraction>()!=null)
					{
						Col.gameObject.GetComponent<ObjectInteraction>().Attack(splashDamage);	
					}
					if (Col.gameObject.GetComponent<UWCharacter>()!=null)
					{
						Col.gameObject.GetComponent<UWCharacter>().ApplyDamage(splashDamage);
					}	
			}
		}		
	}
}
