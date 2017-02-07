using UnityEngine;
using System.Collections;

public class SpellProp_Fireball : SpellProp {
	//Fireball
	protected int splashDamage;//Damage applied to the explosion.
	protected float splashDistance;
	protected int SecondaryStartFrame;
	protected int SecondaryEndFrame;
	//public GameObject caster; //who casted the spell

	public override void init(int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		//ProjectileSprite =UWEBase._RES +"/Sprites/Objects/Objects_020";
		ProjectileItemId=20;
		Force=200.0f;
		BaseDamage=16;
		splashDamage=4;
		splashDistance=1.0f;
		impactFrameStart=21;
		impactFrameEnd=25;
		SecondaryStartFrame=31;
		SecondaryEndFrame=35;
	}


	public override void onImpact (Transform tf)
	{
		base.onImpact (tf);
		//A big old explosion
		for (int i=0;i<3;i++)
		{//The flames
			Impact.SpawnHitImpact(tf.name+ "_impact",tf.position+(Random.insideUnitSphere*0.5f),SecondaryStartFrame, SecondaryEndFrame);	
		}
		foreach (Collider Col in Physics.OverlapSphere(tf.position,splashDistance))
		{
			if (Col.gameObject!=tf.gameObject)			
			{
					if (Col.gameObject.GetComponent<ObjectInteraction>()!=null)
					{
						Col.gameObject.GetComponent<ObjectInteraction>().Attack(splashDamage,caster);	
					}
					if (Col.gameObject.GetComponent<UWCharacter>()!=null)
					{
						Col.gameObject.GetComponent<UWCharacter>().ApplyDamage(splashDamage,caster);
					}	
			}
		}		
	}
}
