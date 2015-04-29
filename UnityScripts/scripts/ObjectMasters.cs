using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class ObjectMasters : MonoBehaviour {
	//An implementation of the similar system for the exporter
	public string PathToConfig;

	int[] index = new int[500];//no
	int[] objClass= new int[500];	//For Shock
	int[] objSubClass= new int[500];
	int[] objSubClassIndex= new int[500];
	string[] cat = new string[500];
	int[] type = new int[500];	//from above
	string[] desc= new string[500];
	string[] path= new string[500]; //to object model
	string[] particle= new string[500];
	string[] sound= new string[500];
	int[] isEntity= new int[500]; // 1 for entity. 0 for model. -1 for ignored entries
	int[] isSet= new int[500];

	int[] extraInfo= new int[500];	//For stuff like door texture info.
	int[] renderType= new int[500];
	int[] frame1= new int[500];	//Frame no
	int[] DeathWatch= new int[500];
	int[] hasParticle= new int[500];
	int[] hasSound= new int[500];
	string[] baseModel= new string[500];
	int[] isSolid= new int[500];
	int[] isMoveable= new int[500];
	int[] isInventory= new int[500];
	string[] InvIcon= new string[500];


	// Use this for initialization
	void Start () {
		Load(PathToConfig);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private bool Load(string fileName)
	{
		int i=0;
		string line;
		StreamReader fileReader = new StreamReader(fileName, Encoding.Default);
		string PreviousKey="";
		string PreviousValue="";
		using (fileReader)
		{
			// While there's lines left in the text file, do this:
			do
			{
				line = fileReader.ReadLine();
				if (line != null)
				{
					string[] entries = line.Split(' ');
					if (entries.Length > 0)
					{
						Debug.Log(line);
						index[i] = int.Parse(entries[0]);
						objClass[i]= int.Parse(entries[1]);	//For Shock
						objSubClass[i]= int.Parse(entries[2]);
						objSubClassIndex[i]= int.Parse(entries[3]);
						cat[i]=entries[4];
						type[i] =  int.Parse (entries[5]);	
						desc[i]= entries[6];
						path[i]= entries[7];
						hasParticle[i]=int.Parse (entries[8]);
						particle[i]= entries[9];
						hasSound[i]=int.Parse (entries[10]);
						sound[i]= entries[11];
						//isEntity[i]= int.Parse(entries[12]); // 1 for entity. 0 for model. -1 for ignored entries
						//isSet[i]= int.Parse(entries[13]);
						baseModel[i]= entries[12];
						isSolid[i]= int.Parse(entries[13]);
						isMoveable[i]= int.Parse(entries[14]);
						isInventory[i]= int.Parse(entries[15]);
						InvIcon[i]= entries[16];
						/*extraInfo[i]= int.Parse(entries[11]);
						renderType[i]= int.Parse(entries[12]);
						frame1[i]= int.Parse(entries[13]);
						DeathWatch[i]= int.Parse(entries[14]);
						hasParticle[i]= int.Parse(entries[15]);
						hasSound[i]= int.Parse(entries[16]);*/



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
