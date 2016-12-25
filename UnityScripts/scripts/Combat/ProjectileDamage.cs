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
		this.gameObject.layer=LayerMask.NameToLayer ("MapMesh");
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
		if (hasHit==false)
		{
			hasHit=true;
			StartCoroutine(EndProjectile());
		}
		if (LastTarget != other.gameObject.name)
		{//only get hit once.
			LastTarget=other.gameObject.name;
			if (other.gameObject.GetComponent<object_base>()!=null)
			{
				other.gameObject.GetComponent<object_base>().ApplyAttack(Damage,Source);
			}
			else
			{
				if (other.gameObject.GetComponent<UWCharacter>())
				{
					other.gameObject.GetComponent<UWCharacter>().ApplyDamage(Damage,Source);
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

