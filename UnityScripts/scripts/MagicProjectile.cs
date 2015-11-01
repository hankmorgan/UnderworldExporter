using UnityEngine;
using System.Collections;

public class MagicProjectile : MonoBehaviour {

	public int damage;
	//public string HitImage;
	public bool HasHit;

	void OnCollisionEnter(Collision collision)
	{

		if (HasHit==true)
		{//Only impact once.
			return;
		}
		else

		{
			HasHit=true;
			SpriteRenderer sprt=this.GetComponentInChildren<SpriteRenderer>();
			sprt.enabled=false;
			BoxCollider box =this.GetComponent<BoxCollider>();
			box.enabled=false;
			WindowDetect.FreezeMovement(this.gameObject);

			ObjectInteraction objInt = collision.gameObject.GetComponent<ObjectInteraction>();

			if (objInt!=null)
			{
				objInt.Attack(damage);
				//Create a blood splatter at this point
				//GameObject hitimpact = new GameObject(collision.gameObject.name + "_impact");
				//hitimpact.transform.position=this.gameObject.transform.position;//ray.GetPoint(weaponRange/0.7f);
				Impact imp= this.gameObject.AddComponent<Impact>();
				imp.FrameNo=objInt.GetHitFrameStart();
				imp.EndFrame=objInt.GetHitFrameEnd();
				StartCoroutine(imp.Animate());			
			}
			else
			{
				//do a miss impact 
				Impact imp= this.gameObject.AddComponent<Impact>();
				imp.FrameNo=46;
				imp.EndFrame=50;
				StartCoroutine( imp.Animate());
			}
			
			DestroyObject(this.gameObject,1);



		}

	}

	//void OnTriggerEnter(Collider other)
	//{
	//	Debug.Log ("Projectile hits " + other.gameObject.name + " via trigger");
	//	other.gameObject.transform.SendMessage("ApplyDamage");
	//	DestroyObject(this.gameObject);
	//}
}
