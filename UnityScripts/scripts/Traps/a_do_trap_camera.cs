using UnityEngine;
using System.Collections;

public class a_do_trap_camera : a_hack_trap {
/*
A variant of the do trap.
This is mainly used by crystal balls to show a vision of an area on a map.

Usage example
The vision of the moonstone room on Level2. Activated by the orb in the marble room.
*/

	private Camera cam;
	private Light lt;
    private Rect window_uw1 = new Rect(0.163f, 0.335f, 0.54f, 0.572f);
    private Rect window_uw2 = new Rect(0.05f, 0.28f, 0.655f, 0.64f);
    private Rect fullscreen = new Rect(0f, 0f, 1f, 1f);
    protected override void Start ()
	{
		base.Start ();

		cam = this.gameObject.AddComponent<Camera>();
		cam.tag="MainCamera";
        switch (_RES)
        {
            case GAME_UW2:
                cam.rect = window_uw2;break;//new Rect(0.05f, 0.28f, 0.655f, 0.64f);
            default:
                cam.rect = window_uw1;break;//new Rect(0.163f, 0.335f, 0.54f, 0.572f);break;
        }
		
		cam.depth=100;
		cam.enabled=false;
		lt=this.gameObject.AddComponent<Light>();
		lt.range=8;
		lt.enabled=false;
	}

    /// <summary>
    ///Ensure the correct window size is used
    /// </summary>
    private void SetWindowRect()
    {
        if (UWHUD.instance.window.FullScreen == true)
        {
            cam.rect = fullscreen;
        }
        else
        {
            switch (_RES)
            {
                case GAME_UW2:
                    cam.rect = window_uw2; break;
                default:
                    cam.rect = window_uw1; break;
            }
        }


}

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		StartCoroutine (ActivateCamera());
	}

	IEnumerator ActivateCamera()
	{
        SetWindowRect();
		UWCharacter.Instance.playerCam.tag="Untagged";
		UWCharacter.Instance.playerCam.enabled=false;
		cam.enabled=true;
		lt.enabled=true;
		UWCharacter.Instance.isRoaming=true;
		yield return new WaitForSeconds(5.0f);
		UWCharacter.Instance.isRoaming=false;
		cam.enabled=false;
		lt.enabled=false;
		UWCharacter.Instance.playerCam.tag="MainCamera";
		UWCharacter.Instance.playerCam.enabled=true;
	}

	public override void PostActivate (object_base src)
	{
        //Stop camera from destroying itself
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}
