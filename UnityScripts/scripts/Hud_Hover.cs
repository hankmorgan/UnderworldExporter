using UnityEngine;
using System.Collections;

public class Hud_Hover : MonoBehaviour {
	private UILabel MessageLog;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		MessageLog.text=name +"entered";
	}

	void OnTriggerEnter()
	{
		//counter++;
		MessageLog.text=name +"triggered";
	}

	void OnHover( bool isOver )
	{
		if( isOver )
			MessageLog.text=name + "Hovered over";
		//else
		//	MessageLog.text="unHover";
	}

	void OnClick()
	{
		MessageLog.text=name + "Clicked";
	}
}
