using UnityEngine;
using System.Collections;

public class ProjectileDamage : MonoBehaviour {
//For launched missiles
	public bool hasHit;
	public int Damage;
	public string LastTarget;//What was last hit by the projectile
	void Start()
	{
		this.gameObject.layer=LayerMask.NameToLayer ("MapMesh");
		BoxCollider box = this.gameObject.AddComponent<BoxCollider>();
		box.size = new Vector3(0.3f,0.3f,0.3f);
		box.center= new Vector3(0.0f,0.1f,0.0f);
		box.isTrigger=true;
	}


	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Collision");
		if (hasHit==false)
		{
			hasHit=true;
			StartCoroutine(EndProjectile());
		}
		if (LastTarget != other.gameObject.name)
		{//only get hit once.
			LastTarget=other.gameObject.name;
			if (other.gameObject.GetComponent<NPC>()!=null)
			{
				other.gameObject.GetComponent<NPC>().ApplyAttack(Damage);
			}
			else
			{
				if (other.gameObject.GetComponent<UWCharacter>())
				{
					other.gameObject.GetComponent<UWCharacter>().ApplyDamage(Damage);
				}
				else
				{//reduce damage on ricochets
					Damage=Damage/2;
				}
			}
		}
	}

	IEnumerator EndProjectile()
	{
		yield return new WaitForSeconds(1.0f);
		Destroy(this.gameObject);
	}
}

