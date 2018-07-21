using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class ObjectMasters {
	//An implementation of the similar system for the exporter
	//public string PathToConfig;
    public struct ObjectProperties
    {
        public int index;// = new int[500];
        public int objClass;// = new int[500];   //For Shock
        public int objSubClass;// = new int[500];
        public int objSubClassIndex;// = new int[500];
        public int type;// = new int[500];   //from above
        public string desc;// = new string[500];
        public int WorldIndex;// = new int[500];
        public int isUseable;// = new int[500];
        public int isMoveable;// = new int[500];
        public int InventoryIndex;// = new int[500];
        public int startFrame;// = new int[500];//Start frame for animated objects.
        public int useSprite;// = new int[500];//Uses a sprite and also the no of anim frames for animated objects.
    };

    public ObjectProperties[] objProp;


	public ObjectMasters()
	{
        objProp = new ObjectProperties[500];

        switch (Loader._RES)
		{
		case Loader.GAME_UWDEMO:
		case Loader.GAME_UW1:
			Load(Application.dataPath + "//..//uw1_object_settings.txt");//Shared settings
			break;

		default:
			Load(Application.dataPath + "//..//" + UWEBase._RES.ToLower() + "_object_settings.txt");
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
						objProp[i].index = int.Parse(entries[0]);
                        objProp[i].objClass= int.Parse(entries[1]);  //For Shock
                        objProp[i].objSubClass= int.Parse(entries[2]);
                        objProp[i].objSubClassIndex= int.Parse(entries[3]);
                        objProp[i].type =  int.Parse (entries[4]);
                        objProp[i].desc= entries[5];
                        objProp[i].WorldIndex= int.Parse (entries[6]);
                        objProp[i].InventoryIndex= int.Parse (entries[7]);
                        objProp[i].isUseable= int.Parse(entries[8]);
                        objProp[i].isMoveable= int.Parse(entries[9]);
                        objProp[i].startFrame= int.Parse(entries[10]);
                        objProp[i].useSprite= int.Parse(entries[11]);
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