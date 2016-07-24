using UnityEngine;
using System.Collections;

public class MapClose : MonoBehaviour {

	public void OnClick()
	{
				
		WindowDetect.InMap=false;

		if  (GameWorldController.instance.mus!=null)
		{
			GameWorldController.instance.mus.InMap=false;
		}
		UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);

	}
}
