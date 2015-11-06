using UnityEngine;
using System.Collections;

public class a_do_trap_camera : trap_base {
	public Camera cam;
	public Light lt;

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		StartCoroutine (ActivateCamera());
	}

	IEnumerator ActivateCamera()
	{

		playerUW.playerCam.tag="Untagged";
		playerUW.playerCam.enabled=false;
		cam.enabled=true;
		lt.enabled=true;
		yield return new WaitForSeconds(5.0f);
		cam.enabled=false;
		lt.enabled=false;
		playerUW.playerCam.tag="MainCamera";
		playerUW.playerCam.enabled=true;
	}

}
