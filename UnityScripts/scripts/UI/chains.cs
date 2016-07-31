using UnityEngine;
using System.Collections;

public class chains : GuiBase_Draggable {
	/*GUI Element for switching panel displays but also controls which other GUI elements are displayed.*/
	public static int ActiveControl;
	//public static int setControl=0;

	public void OnClick()
	{
	if (Dragging==true){return;}
	if (UWHUD.instance.isRotating==true){return;}

	 switch (ActiveControl)
		{
		case UWHUD.HUD_MODE_INVENTORY://Inventory -> Stats
			ActiveControl=UWHUD.HUD_MODE_STATS;
			break;
		case UWHUD.HUD_MODE_STATS://Stats -> Inventory
			ActiveControl=UWHUD.HUD_MODE_INVENTORY;
			break;
		case UWHUD.HUD_MODE_RUNES://Magic -> Inventory
			ActiveControl=UWHUD.HUD_MODE_INVENTORY;
			break;
		default://Not a valid state to switch from
			return;
		}
		Refresh();
	}

	public void Refresh()
	{
		UWHUD.instance.RefreshPanels(ActiveControl);
	}
}
