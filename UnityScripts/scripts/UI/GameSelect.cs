using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class GameSelect : GuiBase {

	public string RES;
	public bool Game_Found;
	public Text PathStatus;

	public override void Start ()
	{
		base.Start ();
		CheckPath();
	}

	void CheckPath()
	{
		string Path="";
		switch(RES)
		{
		case GAME_UWDEMO: Path=GameWorldController.instance.path_uw0;break;
		case GAME_UW1: Path=GameWorldController.instance.path_uw1;break;
		case GAME_UW2:Path=GameWorldController.instance.path_uw2;break;
		case GAME_SHOCK:Path=GameWorldController.instance.path_shock;break;
		case GAME_TNOVA:Path=GameWorldController.instance.path_tnova;break;
			break;
		}

		//string fileName = Application.dataPath + "//..//" + RES + "_path.txt";
		//StreamReader fileReader = new StreamReader(fileName, Encoding.Default);
		//string Path= fileReader.ReadLine().TrimEnd();
		Game_Found=(Directory.Exists(Path)) ;
		if (Game_Found)
		{
			PathStatus.text=RES + " folder found at " + Path; 
		}
		else
		{
			PathStatus.text=RES + " folder not found at " + Path; 	
		}
	}

	public void OnClick()
	{
		if (!Game_Found){return;}
		switch (RES)
		{
		case GAME_SHOCK:
			GameObject selectObj = GameObject.Find("SSLevelSelect");
			if (selectObj!=null)
			{
				Dropdown selLevel = selectObj.GetComponent<Dropdown>();
				if (selLevel!=null)
				{
					GameWorldController.instance.startLevel=(short)selLevel.value;
				}
			}
			break;
		}
		GameWorldController.instance.Begin(RES);
	}

	public void onHoverEnter()
	{
		if (!Game_Found){return;}
		RawImage img = this.GetComponent<RawImage>();
		if	(img!=null)
		{
			img.color = Color.white;
		}
	}

	public void onHoverExit()
	{
		if (!Game_Found){return;}				
		RawImage img = this.GetComponent<RawImage>();
		if	(img!=null)
		{
			img.color = Color.grey;
		}
	}
	
}
