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

}
