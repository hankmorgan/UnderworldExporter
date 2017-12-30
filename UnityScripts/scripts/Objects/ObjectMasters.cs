using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class ObjectMasters {
	//An implementation of the similar system for the exporter
	//public string PathToConfig;
		public int[] index= new int[500];
		public int[] objClass= new int[500];	//For Shock
		public int[] objSubClass= new int[500];
		public int[] objSubClassIndex= new int[500];
		public int[] type = new int[500];	//from above
		public string[] desc= new string[500];
		public int[] WorldIndex= new int[500];
		public int[] isUseable= new int[500];
		public int[] isMoveable= new int[500];
		public int[] InventoryIndex=new int[500];
		public int[] startFrame= new int[500];//Start frame for animated objects.
		public int[] useSprite= new int[500];//Uses a sprite and also the no of anim frames for animated objects.

	public ObjectMasters()
	{
		switch(Loader._RES)
		{
		case Loader.GAME_UWDEMO:
		case Loader.GAME_UW1:
			Load(Application.dataPath + "//..//uw1_object_settings.txt");//Shared settings
			break;

		default:
			Load(Application.dataPath + "//..//" + UWEBase._RES + "_object_settings.txt");
			break;
		}			
	}

	private bool Load(string fileName)
	{
		int i=0;
		string line;
		StreamReader fileReader = new StreamReader(fileName, Encoding.Default);
		//string PreviousKey="";
		//string PreviousValue="";
		using (fileReader)
		{
			// While there's lines left in the text file, do this:
			do
			{
				line = fileReader.ReadLine();
				if (line != null)
				{
					string[] entries = line.Split('\t');
					if (entries.Length > 0)
					{
						index[i] = int.Parse(entries[0]);
						objClass[i]= int.Parse(entries[1]);	//For Shock
						objSubClass[i]= int.Parse(entries[2]);
						objSubClassIndex[i]= int.Parse(entries[3]);
						type[i] =  int.Parse (entries[4]);	
						desc[i]= entries[5];
						WorldIndex[i]= int.Parse (entries[6]);
						InventoryIndex[i]= int.Parse (entries[7]);
						isUseable[i]= int.Parse(entries[8]);
						isMoveable[i]= int.Parse(entries[9]);
						startFrame[i]= int.Parse(entries[10]);
						useSprite[i]= int.Parse(entries[11]);
						i++;
					}
				}
			}
			while (line != null);
			fileReader.Close();
			return true;
		}
	}
}