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
		chains.ActiveControl=0;
		GameWorldController.instance.playerUW.playerHud.ChainsControl.Refresh();
	}
}
