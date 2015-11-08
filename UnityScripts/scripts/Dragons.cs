using UnityEngine;
using System.Collections;

public class Dragons : GuiBase {


	public UITexture[] Tail=new UITexture[4];
	public UITexture[] Arm=new UITexture[4];
	public UITexture[] Base=new UITexture[5];
	public UITexture[] Head=new UITexture[4];

	public int SetBase=0; int PrevBase=-1;
	public int SetTail=0; int PrevTail=-1;
	public int SetArm=0;  int PrevArm=-1;
	public int SetHead=0; int PrevHead=-1;

	// Use this for initialization
	void Start () {
		for (int i = 0; i<=  Base.GetUpperBound(0);i++)
		{
			Base[i].enabled=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (PrevBase!=SetBase)
		{
			UpdateDragons(Base,SetBase);
			PrevBase=SetBase;
		}

		if (PrevTail!=SetTail)
		{
			UpdateDragons(Tail,SetTail);
			PrevTail=SetTail;
		}
	
		if (PrevArm!=SetArm)
		{
			UpdateDragons(Arm,SetArm);
			PrevArm=SetArm;
		}
		if (PrevHead!=SetHead)
		{
			UpdateDragons(Head,SetHead);
			PrevHead=SetHead;
		}
	}


	void UpdateDragons(UITexture[]parts, int EnabledIndex)
	{
		for (int i = 0; i<= parts.GetUpperBound(0);i++)
		{
			parts[i].enabled= (i==EnabledIndex);
		}
	}

}
