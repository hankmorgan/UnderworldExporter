using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Draggable UI Elements
/// </summary>
public class GuiBase_Draggable : GuiBase {
		/// <summary>
		/// List of RectTransforms that move with this element. Includes this UI element.
		/// </summary>
	public RectTransform[] rectT= new RectTransform[1];//The ui elements that move with this drag

		/// <summary>
		/// Is the control currently being dragged.
		/// </summary>
	public bool Dragging;

	public override void Start ()
	{
		base.Start ();
		//rectT= this.gameObject.GetComponent<RectTransform>();
	}

		/// <summary>
		/// Starts the Drag
		/// </summary>
	public void DragStart()
	{
		if (UWHUD.instance.window.FullScreen==true)
		{
			Dragging=true;					
		}			
	}

		/// <summary>
		/// Updates the position of the UI Elements in the list based on the mouse movement.
		/// </summary>
		/// <param name="evnt">Evnt.</param>
	public void OnDrag(BaseEventData evnt)
	{
		if (UWHUD.instance.window.FullScreen==true)
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

	/// <summary>
	/// End the dragging of the element
	/// </summary>
	public void DragEnd()
	{
		if (UWHUD.instance.window.FullScreen==true)
		{
			UWHUD.instance.window.updateUIPositions();	
		}
		Dragging=false;		
	}
}
