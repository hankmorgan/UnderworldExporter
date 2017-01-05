using UnityEngine;
using System.Collections;
/// <summary>
/// Projectile damage.
/// Applies damage to the object that the ranged projectile has hit.
/// </summary>
public class ProjectileDamage : MonoBehaviour {

	/// Prevents ths projecile from hitting multiple targets before it destoys itself
	public bool hasHit;
	/// The damage applied by the projectile.
	public int Damage;
	///What was last hit by the projectile
	public string LastTarget;

		/// <summary>
		/// The source of the projectile. (Trap, NPC, player)
		/// </summary>
	public GameObject Source;


	void Start()
	{
		this.gameObject.layer=LayerMask.NameToLayer ("MagicProjectile");
		BoxCollider box = this.gameObject.AddComponent<BoxCollider>();
		box.size = new Vector3(0.3f,0.3f,0.3f);
		box.center= new Vector3(0.0f,0.1f,0.0f);
		box.isTrigger=true;
	}


	/// <summary>
	/// When the projectile hits anything it will applydamage if applicable or will begin to count down to losing it's damage effect
	/// Half damage is applied on richochets
	/// </summary>
	void OnTriggerEnter(Collider other)
	{
		HandleImpact(other.gameObject);
	}

		void OnCollisionEnter(Collision collision) {
		
			HandleImpact(collision.gameObject);
		}


		void HandleImpact(GameObject other)
		{			
				if ((hasHit==false) && (other.name==Source.name))
				{//prevent the first hit suiciding the character
						return;
				}
				if (hasHit==false)
				{
						hasHit=true;
						StartCoroutine(EndProjectile());
				}
				if (LastTarget != other.name)
				{//only get hit once.
						LastTarget=other.name;
						if (other.gameObject.GetComponent<ObjectInteraction>()!=null)
						{
								other.gameObject.GetComponent<ObjectInteraction>().Attack(Damage,Source);
						}
						else
						{
							if (other.GetComponent<UWCharacter>())
								{
										other.GetComponent<UWCharacter>().ApplyDamage(Damage,Source);
								}
								else
								{//reduce damage on ricochets
										Damage=Damage/2;
								}
						}
				}

		}
	
	/// <summary>
	/// The projectile will only damage anything for a short period after it hits something
	/// To support bouncing around
	/// </summary>
	public IEnumerator EndProjectile()
	{
		yield return new WaitForSeconds(1.0f);
		Destroy(this.gameObject);
	}
}

