using UnityEngine;
using System.Collections;

public class TradeIndicator : GuiBase {

	public TradeSlot ts;


	void OnClick()
	{
		Debug.Log ("Click");
		ts.Selected=!ts.Selected;
	}

}


