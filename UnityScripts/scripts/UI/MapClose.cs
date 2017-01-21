using UnityEngine;
using System.Collections;

public class MapClose : MonoBehaviour {

	public void OnClick()
	{
				
		WindowDetect.InMap=false;

		if  (GameWorldController.instance.getMus()!=null)
		{
			GameWorldController.instance.getMus().InMap=false;
		}
		UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);

	}
}
