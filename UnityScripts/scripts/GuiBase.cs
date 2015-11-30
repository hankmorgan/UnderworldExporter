using UnityEngine;
using System.Collections;

public class GuiBase : MonoBehaviour {
//Base class for UI components.
	public static UWCharacter playerUW;

	public virtual void start()
	{
		if (playerUW==null)
		{
			playerUW=GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		}
	}

	public void MoveControlOffset(float offX, float offY)
	{//Moves a control by the specified distance on the gui
		UIAnchor uia = this.GetComponent<UIAnchor>();
		if (uia !=null)
		{
			uia.relativeOffset =  uia.relativeOffset+ new Vector2(offX,offY);
		}
	}


}
