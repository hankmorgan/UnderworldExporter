using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// GUI base.
/// 
/// Base class for UI components. Allows moving of elements and sets up common references.
/// </summary>
public class GuiBase : MonoBehaviour {

	//public static UWCharacter playerUW;///Reference to the player character.

	public virtual void Start()
	{
		/*if (playerUW==null)
		{
			//playerUW=GameObject.Find ("Gronk").GetComponent<UWCharacter>();
			playerUW=GameWorldController.instance.playerUW;
		}*/
	}

	public void MoveControlOffset(float offX, float offY)
	{//Moves a control by the specified distance on the gui
		//UIAnchor uia = this.GetComponent<UIAnchor>();
		//if (uia !=null)
		//{
		//	uia.relativeOffset =  uia.relativeOffset+ new Vector2(offX,offY);
		//}
	}

	public void SetAnchorX(float offX)
	{
		//UIAnchor uia = this.GetComponent<UIAnchor>();
		//if (uia !=null)
		//{
		//	uia.relativeOffset = new Vector2(offX, uia.relativeOffset.y);
		//}
	}

	public void SetAnchorY(float offY)
	{
		//UIAnchor uia = this.GetComponent<UIAnchor>();
		//if (uia !=null)
		//{
		//	uia.relativeOffset = new Vector2(uia.relativeOffset.x, offY);
		//}
	}
}
