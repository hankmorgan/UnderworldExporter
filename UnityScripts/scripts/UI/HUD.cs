using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : UWEBase {
		//The cursor to display on the gui
		public RawImage MouseLookCursor;
		public Texture2D CursorIcon;
		public Texture2D CursorIconDefault;
		public Texture2D CursorIconBlank;
		public Texture2D CursorIconTarget; //Default Cursor for ranged spells and combat.



	/// Reference to the weapon animation animator.
	public WeaponAnimationPlayer wpa;

	public CutsceneAnimationFullscreen CutScenesFull;
	public ScrollController MessageScroll;
	public InputField InputControl;
	public GameObject main_windowUW1;//The immersive heads up display for UW1
	public GameObject main_windowUW2;//The immersive heads up display for UW2
	public RawImage MapDisplay; //should be in a subclass?

	public Text LoadingProgress;

/*	public GameObject main_window()
	{
		switch(_RES)
		{
		case GAME_UW2:
				return main_windowUW2;
		default:
				return main_windowUW1;
		}
	}*/
}
