using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class NovaLevelSelect : GuiBase {
	public Dropdown Select;
	public static string MapSelected;
	string[] pFiles;

	public override void Start ()
	{

		base.Start ();
		if (File.Exists(Application.dataPath + "//..//tnova_path.txt"))
		{			
			string fileName = Application.dataPath + "//..//tnova_path.txt";
			StreamReader fileReader = new StreamReader(fileName, Encoding.Default);
			string NovaPath=fileReader.ReadLine().TrimEnd() + "Maps";	
			pFiles=Directory.GetFiles(NovaPath);
			for (int i=0; i<=pFiles.GetUpperBound(0);i++)
			{
				Select.options.Add(new Dropdown.OptionData(pFiles[i].Replace(NovaPath+"\\","")));
			}
		}
		
	}

	public void SelectOption()
	{
		MapSelected=pFiles[Select.value];
	}

}
