using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class StringController : MonoBehaviour {
	public int game; //Which game is this. 0=uwdemo, 1=uw1, 2=uw2, 3=shock
	private Hashtable GameStrings;
	private string StringFilePath;

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


	public string GetObjectNounUW(ObjectInteraction objInt)
	{//The the single noun
	
		return GetObjectNounUW(objInt.item_id);
	}

	public string GetObjectNounUW(int item_id)
	{//The the single noun
		
		string output = GetString (4,item_id);
		if (output.Contains("&"))
		{
			output= output.Split ('&')[0];
		}			
		//Remove the article
		output =output.Replace("a_","");
		output =output.Replace("an_","");
		return output;
	}


	public string GetFormattedObjectNameUW(ObjectInteraction objInt)
	{//Eventually this will return things like proper quants etc.
		string output = GetString (4,objInt.item_id);

		if ((objInt.isQuant ==true) && (output.Contains("&")) && (objInt.isEnchanted==false))
		{
			if (objInt.Link>1)
			{//Plural description
				output= objInt.Link + " " + output.Split ('&')[1];		
			}
			else
			{
				output= output.Split ('&')[0];
			}
		}
		else
			{
			if (output.Contains("&"))
			    {
				output= output.Split ('&')[0];
				}
				
			}
		output =output.Replace("_"," ");
		return GetString(1,260) + output;
	}

	public string GetFormattedObjectNameUW(ObjectInteraction objInt,int Quantity)
	{//Eventually this will return things like proper quants etc.

		string output = GetString (4,objInt.item_id);
		
		if ((objInt.isQuant ==true) && (output.Contains("&")) && (objInt.isEnchanted==false))
		{
			if ((objInt.Link>1) && (Quantity>1))
			{//Plural description
				output= objInt.Link + " " + output.Split ('&')[1];		
			}
			else
			{
				output= output.Split ('&')[0];
			}
		}
		else
		{
			if (output.Contains("&"))
			{
				output= output.Split ('&')[0];
			}
			
		}		
		
		output =output.Replace("_"," ");
		return GetString(1,260) + output;

	}

	public string GetFormattedObjectNameUW(ObjectInteraction objInt, string QualityString)
	{//Eventually this will return things like proper quants etc.
		string output = GetString (4,objInt.item_id);
		
		if ((objInt.isQuant ==true) && (output.Contains("&")) && (objInt.isEnchanted==false) )
		{
			if (objInt.Link>1)
			{//Plural description
				output= objInt.Link + " " + output.Split ('&')[1];		
			}
			else
			{
				output= output.Split ('&')[0];
			}
		}
		else
		{
			if (output.Contains("&"))
			{
				output= output.Split ('&')[0];
			}
		}

		string isThisAVowel=QualityString.Substring(0,1).ToUpper();
		if (
			(isThisAVowel == "A")
			||
			(isThisAVowel == "E")
			||
			(isThisAVowel == "I")			
			||
			(isThisAVowel == "O")			
			||
			(isThisAVowel == "U")
			)
		{
			output = output.Replace("a_","an_");
		}
		else
		{
			output = output.Replace("an_","a_");
		}
		output =output.Replace("_", " " + QualityString + " ");
		return GetString(1,260) + output;
	}

	public string GetSimpleObjectNameUW(int item_id)
	{//Without quants.
		string output = GetString (4,item_id);
		if (output.Contains("&"))
		{
			output= output.Split ('&')[0];
		}

		return (output.Replace ("_"," "));
	}



	public string GetSimpleObjectNameUW(ObjectInteraction objInt)
	{//Without quants.

		return GetSimpleObjectNameUW(objInt.item_id);
	}

	public string TextureDescription(int index)
	{//TODO:fix floor and wall naming
		return (GetString(1,260) + " " + GetString (10,index));
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
					if (line.IndexOf("~")>=0)
					{
						string[] entries = line.Split('~');
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