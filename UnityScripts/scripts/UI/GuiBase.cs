using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// GUI base.
/// 
/// Base class for UI components. Allows moving of elements and sets up common references.
/// </summary>
public class GuiBase : UWEBase {
		public Vector3 anchorPos;
	public virtual void Start()
	{

	}


	public virtual void Update()
	{
		if (this.GetComponent<RectTransform>()!=null)
		{
			anchorPos =this.GetComponent<RectTransform>().anchoredPosition;
		}
	}
}
