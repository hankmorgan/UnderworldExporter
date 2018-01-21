using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompassPoint : GuiBase {

	public int index;
	
	public override void Start ()
	{
		this.GetComponent<RawImage>().texture=GameWorldController.instance.grCompass.LoadImageAt(index);
	}
}
