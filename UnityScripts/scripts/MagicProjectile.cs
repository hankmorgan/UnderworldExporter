using UnityEngine;
using System.Collections;

public class MagicProjectile : MonoBehaviour {

	public float damage;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Projectile hits " + collision.gameObject.name + " via collision");
		collision.gameObject.transform.SendMessage("ApplyDamage");
		DestroyObject(this.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Projectile hits " + other.gameObject.name + " via trigger");
		other.gameObject.transform.SendMessage("ApplyDamage");
		DestroyObject(this.gameObject);
	}
}
