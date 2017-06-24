using UnityEngine;
using System.Collections;

public class a_do_trap_camera : trap_base {
/*
A variant of the do trap.
This is mainly used by crystal balls to show a vision of an area on a map.

Usage example
The vision of the moonstone room on Level2. Activated by the orb in the marble room.
*/

	private Camera cam;
	private Light lt;

	protected override void Start ()
	{
		base.Start ();

		cam = this.gameObject.AddComponent<Camera>();
		cam.tag="MainCamera";
		cam.rect=new Rect(0.163f,0.335f,0.54f,0.572f);
		cam.depth=100;
		cam.enabled=false;
		lt=this.gameObject.AddComponent<Light>();
		lt.range=8;
		lt.enabled=false;

	}

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log (this.name);
		StartCoroutine (ActivateCamera());
	}

	IEnumerator ActivateCamera()
	{
		GameWorldController.instance.playerUW.playerCam.tag="Untagged";
		GameWorldController.instance.playerUW.playerCam.enabled=false;
		cam.enabled=true;
		lt.enabled=true;
		yield return new WaitForSeconds(5.0f);
		cam.enabled=false;
		lt.enabled=false;
		GameWorldController.instance.playerUW.playerCam.tag="MainCamera";
		GameWorldController.instance.playerUW.playerCam.enabled=true;
	}

	public override void PostActivate ()
	{
		//Stop camera from destroying itself
	}
}
