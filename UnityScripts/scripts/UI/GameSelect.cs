using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSelect : GuiBase {

	public string RES;

	public void OnClick()
	{
				switch (RES)
				{
				case GAME_SHOCK:
					GameObject selectObj = GameObject.Find("SSLevelSelect");
					if (selectObj!=null)
					{
						Dropdown selLevel = selectObj.GetComponent<Dropdown>();
						if (selLevel!=null)
						{
							GameWorldController.instance.startLevel=(short)selLevel.value;
						}
					}
					break;
				}
		GameWorldController.instance.Begin(RES);
	}

	public void onHoverEnter()
	{
		RawImage img = this.GetComponent<RawImage>();
		if	(img!=null)
		{
			img.color = Color.white;
		}
	}

	public void onHoverExit()
	{
		RawImage img = this.GetComponent<RawImage>();
		if	(img!=null)
		{
			img.color = Color.grey;
		}
	}
	
}
