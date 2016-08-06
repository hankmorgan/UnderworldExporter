using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
WindowDetect.cs

 */

/// <summary>
/// Window detect.
/// </summary>
///Functions dealing with the following
///1) Detecting if the mouse cursor is within the bounds of the main player view. (and related effects)
///2) Dropping and throwing objects in the 3d view
/// Any other functions of the 3d win area
public class WindowDetect : UWEBase {

		/// <summary>
		/// The cursor width
		/// </summary>
	protected  int cursorSizeX =64;

		/// <summary>
		/// The cursor height.
		/// </summary>
	protected  int cursorSizeY =64;

		/// <summary>
		/// Is the mouse held down
		/// </summary>
	public bool MouseHeldDown=false;

		/// <summary>
		/// Is the game in fulscreen mode
		/// </summary>
	public bool FullScreen;

		/// <summary>
		/// Is the game waiting for player typed input. Eg when picking up quantities.
		/// </summary>
	public static bool WaitingForInput=false;
	/// <summary>
	/// Is the player looking at the automap
	/// </summary>
	public static bool InMap=false;

	/// <summary>
	/// Is the cursor in the main window.
	/// </summary>
	static public bool CursorInMainWindow;

	/// <summary>
	/// The cursor position.
	/// </summary>
	public Rect CursorPosition;
	
	/// <summary>
	/// The ui elements that have their position stored.
	/// </summary>
	public RectTransform[] UIsToStore = new RectTransform[1];
	/// <summary>
	/// The positions of the UI element when in windowed mode
	/// </summary>
	public Vector3[] UIPositionsWindowed = new Vector3[1];
	/// <summary>
	/// The positions of the UI elements when in fullscreen mode.
	/// </summary>
	public Vector3[] UIPositionsFullScreen= new Vector3[1];

	/// <summary>
	/// Has the window just been clicked
	/// </summary>
	public	bool JustClicked;

	/// <summary>
	/// How long to wait until the player can click the window again.
	/// </summary>
	public float WindowWaitCount=0;

	public virtual void Start()
	{
		CursorPosition = new Rect(
			0.0f,
			0.0f,
			cursorSizeX,
			cursorSizeY);
			if (this.FullScreen==false)
			{//Init the ui positions.
					for (int i = 0; i<=UIsToStore.GetUpperBound(0);i++)
					{
						UIPositionsWindowed[i]= UIsToStore[i].position;
							if (UIPositionsFullScreen[i] == Vector3.zero)
							{
								UIPositionsFullScreen[i]= UIsToStore[i].position;
							}
					}
			}
	}
	
	/// <summary>
	/// Updates the fullscreen ui positions after the player has finished dragging.
	/// </summary>
	public void updateUIPositions()
	{//stores the positions of ui elements in fullscreenmode
		for (int i = 0; i<=UIsToStore.GetUpperBound(0);i++)
		{
			UIPositionsFullScreen[i]= UIsToStore[i].position;
		}
	}

		/// <summary>
		/// Sets the positions of the ui elements based on the current fullscreen mode.
		/// </summary>
	public void setPositions()
	{
		if (this.FullScreen==true)
			{//put ui elements in fullscreen positions
				for (int i = 0; i<=UIsToStore.GetUpperBound(0);i++)
				{
					UIsToStore[i].position= UIPositionsFullScreen[i];
				}
			}
		else
			{//put ui elements in windowed positions.
				for (int i = 0; i<=UIsToStore.GetUpperBound(0);i++)
				{
					UIsToStore[i].position= UIPositionsWindowed[i];
				}	
			}
	}


	/// <summary>
	/// Detect if the mouse cursor is in the main window view
	/// </summary>
	/// <param name="isOver">If set to <c>true</c> is over.</param>
	protected virtual void OnHover( bool isOver )
	{
		CursorInMainWindow=isOver;
	}

		/// <summary>
		/// Detects if the mouse is held down (used in weapon charging)
		/// </summary>
		/// <param name="isDown">If set to <c>true</c> is down.</param>
		/// <param name="ptrID">Ptr I.</param>
	protected virtual void OnPress(bool isDown,int ptrID)
		{
	
			MouseHeldDown=isDown;
		}


/*	protected virtual void UseObjectInHand()
		{
			return;
		}*/


	/// <summary>
	/// Throws the object in hand along a vector in the 3d view.
	/// </summary>
	protected virtual void ThrowObjectInHand()
	{//Obviously throws the object in the players hand along a vector in the 3d view.
		return;
	}
}