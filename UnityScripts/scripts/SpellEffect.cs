using UnityEngine;
using System.Collections;

public class SpellEffect : MonoBehaviour {
	/*Base class for status effects that occur over time*/

	public const int SpellEffect_VasInLor=20;
	public const int SpellEffect_InLor=17;

	public int counter;
	public int EffectId;//What image index should be used for the spell effect.
	public int Value;//The value for the spell effect. Eg light intensity. The Damage over time etc
	public bool Active;
	public UWCharacter playerUW;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void  Update () {
	
	}

	public virtual void ApplyEffect()
	{
		//Code to apply whatever effect is occuring
		//Debug.Log ("Applying Effect");
		Active=true;
	}

	public virtual void EffectOverTime()
	{
		Debug.Log ("DOT on base");
		//code to apply the periodic changes to the effect. Eg poison drains health etc.
	}

	public virtual void CancelEffect()
	{//End the effect. By default it will destroy the object.
		//Debug.Log ("Cancelling Effect");
		Active=false;
		//this.StopCoroutine(timer ());
		//this.StopAllCoroutines();
		Destroy (this);
	}

	public virtual IEnumerator timer() {
		//bool Finished=false;

		while (Active==true)
		{
			yield return new WaitForSeconds(10);
			counter--;
			Debug.Log (counter);
			if (counter<=0)
			{
				Active=false;
			}
			else
			{
				if (Active)
				{
					EffectOverTime ();
				}
			}
		}
		CancelEffect();
	}

	public virtual string Status()
		{//The description of the effect.
			return "The spell effect has "+ counter + " remaining";
		}
}
