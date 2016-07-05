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
	public WeaponAnimation wpa;

	public CutsceneAnimationFullscreen CutScenesFull;
	public ScrollController MessageScroll;
	public InputField InputControl;
	public RawImage main_window;
	public RawImage MapDisplay;

}
