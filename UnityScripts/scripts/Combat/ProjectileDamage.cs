using UnityEngine;
using System.Collections;
/// <summary>
/// Projectile damage.
/// Applies damage to the object that the ranged projectile has hit.
/// </summary>
public class ProjectileDamage : UWEBase {

	/// Prevents ths projecile from hitting multiple targets before it destoys itself
	private bool hasHit;
	/// The damage applied by the projectile.
	public short Damage;
	///What was last hit by the projectile
	public string LastTarget;


	public int AttackScore;
	public float AttackCharge;
	public int ArmourDamage;

	/// <summary>
	/// The source of the projectile. (Trap, NPC, player)
	/// </summary>
	public GameObject Source;


	void Start()
	{
		this.gameObject.layer=LayerMask.NameToLayer ("MagicProjectile");//Sets the collision layer for this.
		BoxCollider box = this.gameObject.AddComponent<BoxCollider>();
		box.size = new Vector3(0.3f,0.3f,0.3f);
		box.center= new Vector3(0.0f,0.1f,0.0f);
		box.isTrigger=true;
	}

	void OnTriggerEnter(Collider other)
	{
		HandleImpact(other.gameObject);
	}

	void OnCollisionEnter(Collision collision) {
	
		HandleImpact(collision.gameObject);
	}

	/// <summary>
	/// Processes the projectile hitting a target
	/// </summary>
	/// <param name="other">Other.</param>
	/// When the projectile hits anything it will applydamage if applicable or will begin to count down to losing it's damage effect
	/// Half damage is applied on richochets
	void HandleImpact(GameObject other)
	{			
		if (Source==null)
		{
			Source=this.gameObject;
		}
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
			//Perform damage calls
			int otherDefenceScore=0;
			int DamageReduction=0;
            if (other == UWCharacter.Instance.gameObject) //.name=="_Gronk")
			{
				otherDefenceScore=UWCharacter.Instance.PlayerSkills.GetSkill(Skills.SkillDefense) + (UWCharacter.Instance.PlayerSkills.GetSkill(Skills.SkillMissile)/2);
				DamageReduction=UWCharacter.Instance.playerInventory.ArmourProtection;				
			}
			else if (other.GetComponent<NPC>()!=null)
			{
				otherDefenceScore= other.GetComponent<NPC>().Defence();
			}
			else
			{
					return;
			}
			int toHit =Mathf.Max( otherDefenceScore-AttackScore, 1);
			int roll = Random.Range(1,31);
			if (roll<toHit)
			{
				return; //no damage applied.
			}

			int DamageToApply = (int)(Mathf.Max(((float)(Damage))*(AttackCharge/100f),1));
			DamageToApply= Mathf.Max(1, DamageToApply-DamageReduction);

			if (other.gameObject.GetComponent<ObjectInteraction>()!=null)
			{
				other.gameObject.GetComponent<ObjectInteraction>().Attack((short)DamageToApply,Source);
			}
			else
			{
			if (other.GetComponent<UWCharacter>())
				{
					other.GetComponent<UWCharacter>().ApplyDamage(DamageToApply,Source);
					if (DamageToApply>DamageReduction)
					{
						//apply equipment damage to a random piece of armour
						UWCharacter.Instance.playerInventory.ApplyArmourDamage((short)Random.Range(0, ArmourDamage+1));
					}
				}
				else
				{//reduce damage on ricochets
					Damage=(short)(Damage/2);
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