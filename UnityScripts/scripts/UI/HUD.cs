using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : UWEBase {
		
	//The cursor to display on the gui
	[Header("Cursor Icons")]
	public RawImage MouseLookCursor;
	public Texture2D CursorIcon;
	public Texture2D CursorIconDefault;
	public Texture2D CursorIconBlank;
	public Texture2D CursorIconTarget; //Default Cursor for ranged spells and combat.


	public Text LoadingProgress;

}
