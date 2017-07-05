using UnityEngine;
using System.Collections;
/// <summary>
/// Magic projectiles that are launched from spells.
/// </summary>
/// Projectiles use properties defined by SpellProp to decide what damage or other special effects should happen.
public class MagicProjectile : MonoBehaviour {

	/// Has the projectile hit something
	public bool HasHit;
	///who has cast the project. It will ignore them to avoid self harm
	public GameObject caster;
	///Spell properties object to define the behaviour of the projectile
	public SpellProp spellprop; 

	/// <summary>
	/// The Projectile hits something.
	/// </summary>
	/// <param name="collision">Collision.</param>
	/// Does not impact the caster
	/// Calls onImpact
	/// Calls onHit
	/// Applys Attack
	/// Generates an impact effect
	void OnCollisionEnter(Collision collision)
	{//
		if(collision.gameObject.name== caster.name)
		{//Prevents the caster from hitting themselves
			return;
		}
		if (HasHit==true)
		{//Only impact once.
			return;
		}
		else
		{
			HasHit=true;

			//Code to execute when a projectile hits a spot (for launching AOE effects)
			spellprop.onImpact(this.transform);

			ObjectInteraction objInt = collision.gameObject.GetComponent<ObjectInteraction>();

			if (objInt!=null)//Has the projectile hit anything
			{
				//Special code for magic spell direct hits.
				spellprop.onHit(objInt);

				//Applies damage
				objInt.Attack(spellprop.BaseDamage,caster);

				//Create a impact animation to illustrate the collision
				if(objInt.GetHitFrameStart()>=0)
				{
					Impact.SpawnHitImpact(this.transform.name + "_impact",objInt.GetImpactPoint(),objInt.GetHitFrameStart(), objInt.GetHitFrameEnd());	
				}
			}
			else
			{
				//Test if this is a player.
				if (collision.gameObject.GetComponent<UWCharacter>()!=null)
				{
					collision.gameObject.GetComponent<UWCharacter>().ApplyDamage(spellprop.BaseDamage);
					spellprop.onHitPlayer();
				}
				else
				{
					//Do a miss impact 
					Impact.SpawnHitImpact(this.transform.name + "_impact",this.transform.position,spellprop.impactFrameStart,spellprop.impactFrameEnd);	
				
				}
			}	

			ObjectInteraction objIntThis = this.GetComponent<ObjectInteraction>();
			if (objIntThis!=null)
			{
				objIntThis.objectloaderinfo.InUseFlag=0;//Free up object slot
			}
		
			DestroyObject(this.gameObject);
		}
	}
}
