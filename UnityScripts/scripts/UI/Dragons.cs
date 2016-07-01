using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dragons : GuiBase {
	//Code to change the animation frames of the dragons.

	public RawImage[] Tail=new RawImage[4];
	public RawImage[] Arm=new RawImage[4];
	public RawImage[] Base=new RawImage[5];
	public RawImage[] Head=new RawImage[4];

	public int SetBase=0; int PrevBase=-1;
	public int SetTail=0; int PrevTail=-1;
	public int SetArm=0;  int PrevArm=-1;
	public int SetHead=0; int PrevHead=-1;

	
	public override void Start()
	{
		base.Start();
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


	void UpdateDragons(RawImage[]parts, int EnabledIndex)
	{
		for (int i = 0; i<= parts.GetUpperBound(0);i++)
		{
			parts[i].enabled= (i==EnabledIndex);
		}
	}

}
