using UnityEngine;
using System.Collections;

public class MagicProjectile : MonoBehaviour {

	public int damage;
	public string HitImage;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("Projectile hits " + collision.gameObject.name + " via collision");
		if (collision.gameObject.GetComponent<NPC>())
		{
			collision.gameObject.GetComponent<NPC>().ApplyAttack(damage);
		}
		//collision.gameObject.transform.SendMessage("ApplyDamage");
		DestroyObject(this.gameObject);
	}

	//void OnTriggerEnter(Collider other)
	//{
	//	Debug.Log ("Projectile hits " + other.gameObject.name + " via trigger");
	//	other.gameObject.transform.SendMessage("ApplyDamage");
	//	DestroyObject(this.gameObject);
	//}
}
