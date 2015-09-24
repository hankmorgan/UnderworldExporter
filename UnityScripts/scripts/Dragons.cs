using UnityEngine;
using System.Collections;

public class Dragons : MonoBehaviour {


	public UITexture[] Tail=new UITexture[4];
	public UITexture[] Arm=new UITexture[4];
	public UITexture[] Base=new UITexture[5];
	public UITexture[] Head=new UITexture[4];

	public int SetBase=0;
	public int SetTail=0;
	public int SetArm=0;
	public int SetHead=0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i<=  Base.GetUpperBound(0);i++)
		{
			Base[i].enabled=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDragons(Base,SetBase);
		UpdateDragons(Tail,SetTail);
		UpdateDragons(Arm,SetArm);
		UpdateDragons(Head,SetHead);
	}


	void UpdateDragons(UITexture[]parts, int EnabledIndex)
	{
		for (int i = 0; i<= parts.GetUpperBound(0);i++)
		{
			parts[i].enabled= (i==EnabledIndex);
		}
	}

}
