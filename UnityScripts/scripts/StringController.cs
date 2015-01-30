using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class StringController : MonoBehaviour {
	public int game; //Which game is this. 0=uwdemo, 1=uw1, 2=uw2, 3=shock
	private Hashtable GameStrings;
	private string StringFilePath;
	// Use this for initialization
	void Start () {

		//Load up the strings from the file and add to the hashtable
		//Load(StringFilePath);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool InitStringController(string newStringFilePath)
	{
		GameStrings=new Hashtable();
		StringFilePath = newStringFilePath;
		return Load(StringFilePath);
	}

	public string GetString(string BlockNo, string StringNo)
	{//output a string at the specified block and string no.
		return (string)GameStrings[BlockNo + "_" + StringNo];
	}

	public string GetString(int BlockNo, int StringNo)
	{//output a string at the specified block and string no.
		return (string)GameStrings[BlockNo.ToString("000") + "_" + StringNo.ToString("000")];
	}

	private bool Load(string fileName)
	{
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
					if (line.IndexOf("€")>=0)
					{
						string[] entries = line.Split('€');
						if (entries.Length > 0)
						{
							GameStrings[entries[1] + "_" + entries[2]] = entries[3];
							PreviousValue=entries[3];
							PreviousKey=entries[1] + "_" + entries[2];

						}
					}
				else
					{//possible new line character. Append text to previous entry.
						GameStrings[PreviousKey]=PreviousValue + "\n" + line;		
						PreviousValue= PreviousValue + "\n" + line;	
						//Debug.Log (PreviousKey+"="+PreviousValue);
					}
				}
			}
			while (line != null);
			fileReader.Close();
			return true;
		}
	}
}