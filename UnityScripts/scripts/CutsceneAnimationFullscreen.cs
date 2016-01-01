using UnityEngine;
using System.Collections;

public class CutsceneAnimationFullscreen : HudAnimation {
	public bool StillPlaying;//Set to false when playing the last animation in a sequence!
	private bool isFullScreen;
	public void PreAnimPlay()
	{//Called by events in certain animations when starting playing
		playerUW.playerCam.cullingMask=0;//Stops the camera from rendering.
		chains.ActiveControl=5;
		chains.Refresh();
		isFullScreen= playerUW.playerHud.window.FullScreen;
		if (!isFullScreen)
		{
			playerUW.playerHud.window.SetFullScreen();
		}

		return;
	} 

	public void PostAnimPlay()
	{
		if (StillPlaying==false)
		{
			if (!isFullScreen)
			{
				playerUW.playerHud.window.UnSetFullScreen();
			}
			playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			chains.ActiveControl=0;
			chains.Refresh();
			SetAnimation= "Anim_Base";//Clears out the animation.
		}
	}

}
