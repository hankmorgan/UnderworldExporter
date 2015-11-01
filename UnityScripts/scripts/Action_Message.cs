using UnityEngine;
using System.Collections;

public class Action_Message : MonoBehaviour {

	public int SuccessMessage;
	public int FailMessage;
	public bool state=false;

	public void PerformAction()
	{
		AudioClip Message =  Resources.Load("sfx/shock_barks/bark" + FailMessage) as AudioClip;
		AudioSource aus = this.GetComponent<AudioSource>();
		if (aus!=null)
		{
			aus.clip=Message;
			aus.Play();
		}
		Debug.Log ("Action Message");
	}
}
