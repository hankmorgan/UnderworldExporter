using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;





public class GuiBase_Draggable : GuiBase {
//Allows Dragging of UI elements.
	public RectTransform[] rectT= new RectTransform[1];//The ui elements that move with this drag


	public bool Dragging;

	public override void Start ()
	{
		base.Start ();
		//rectT= this.gameObject.GetComponent<RectTransform>();
	}

	public void DragStart()
	{
		if (GameWorldController.instance.playerUW.playerHud.window.FullScreen==true)
		{
			Dragging=true;					
		}			
	}

	public void OnDrag(BaseEventData evnt)
	{
		if (GameWorldController.instance.playerUW.playerHud.window.FullScreen==true)
		{					
			PointerEventData pntr = (PointerEventData)evnt;
			for (int i=0; i<=rectT.GetUpperBound(0);i++)
			{
				if (rectT[i]!=null)
				{
						rectT[i].position = new Vector3 (rectT[i].position.x+pntr.delta.x,rectT[i].position.y+pntr.delta.y, rectT[i].position.z);									
				}			
			}	
		}
	}

	public void DragEnd()
	{
				if (GameWorldController.instance.playerUW.playerHud.window.FullScreen==true)
				{
						GameWorldController.instance.playerUW.playerHud.window.updatePositions();	
				}
		Dragging=false;		
	}
}
