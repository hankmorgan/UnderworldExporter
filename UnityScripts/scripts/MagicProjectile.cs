using UnityEngine;
using System.Collections;

public class MagicProjectile : MonoBehaviour {

	public int damage;
	//public string HitImage;
	public bool HasHit;
	public string caster; //who has cast the project. It will ignore them.

	void OnCollisionEnter(Collision collision)
	{
	if(collision.gameObject.name== caster)
		{
			return;
		}
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
				Impact imp= this.gameObject.AddComponent<Impact>();
				imp.FrameNo=objInt.GetHitFrameStart();
				imp.EndFrame=objInt.GetHitFrameEnd();
				StartCoroutine(imp.Animate());			
			}
			else
			{
				//test if this is a player.
				if (collision.gameObject.GetComponent<UWCharacter>()!=null)
				{
					collision.gameObject.GetComponent<UWCharacter>().ApplyDamage(damage);
				}
				else
				{
					//do a miss impact 
					Impact imp= this.gameObject.AddComponent<Impact>();
					imp.FrameNo=46;
					imp.EndFrame=50;
					StartCoroutine( imp.Animate());
				}

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
