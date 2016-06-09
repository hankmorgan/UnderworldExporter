using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class StringController : MonoBehaviour {
	public int game; //Which game is this. 0=uwdemo, 1=uw1, 2=uw2, 3=shock
	private Hashtable GameStrings;
	private string StringFilePath;

	//Temporary array until I'm wide awake
	private string[] UW1_TextureNames ={"a stone wall",
		"a mossy stone wall",
		"a cracked stone wall",
		"a drain",
		"a vine-covered stone wall",
		"a tapestry",
		"the Banner of Cabirus",
		"a stone wall",
		"a stone wall",
		"the Standard of the Mountainfolk",
		"the Standard of the Knights",
		"a grating",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a mossy irregular stone wall",
		"the Standard of the Silver Serpent",
		"a cracked irregular stone wall",
		"a drain",
		"a vine-covered irregular stone wall",
		"a tapestry",
		"a grating",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a natural stone wall",
		"a natural stone wall",
		"a mossy natural stone wall",
		"a mossy natural stone wall",
		"a waterfall",
		"a grating",
		"a natural stone wall",
		"a natural stone wall",
		"the locked doors of the Abyss",
		"the locked doors of the Abyss",
		"a drain",
		"a tapestry",
		"a vine-covered natural stone wall",
		"a massive stone door",
		"a massive stone door",
		"a massive stone door",
		"a massive stone door",
		"a stone slab with a three-pronged indentation",
		"a stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a drain",
		"a cracked irregular stone wall",
		"a vine-covered irregular stone wall",
		"a grating",
		"a moss-covered irregular stone wall",
		"the Banner of Cabirus",
		"an irregular stone wall",
		"an irregular stone wall",
		"the Standard of the Silver Sapling",
		"an irregular stone wall",
		"nothing",
		"a massive stone door",
		"a natural stone wall",
		"a natural stone wall",
		"a moss-covered natural stone wall",
		"a moss-covered natural stone wall",
		"a pipe",
		"a drain",
		"a natural stone wall",
		"a natural stone wall",
		"nothing",
		"nothing",
		"a grating",
		"a tapestry",
		"a stucco wall",
		"a stucco wall",
		"a peeling stucco wall",
		"a tapestry",
		"a peeling stucco wall",
		"a small rusty pipe",
		"a brick wall",
		"a brick wall",
		"a stucco wall",
		"a stucco wall",
		"a stucco wall",
		"a brick wall",
		"a grating",
		"a Standard of the Silver Serpent",
		"a drain",
		"a peeling stucco wall",
		"a stucco wall",
		"nothing",
		"a brick wall",
		"a brick wall",
		"a brick wall",
		"a brick wall",
		"nothing",
		"nothing",
		"a grating",
		"a tapestry",
		"a pipe",
		"a mossy brick wall",
		"a cracked brick wall",
		"a drain",
		"a finished oak wall",
		"a finished oak wall",
		"a finished oak wall",
		"a finished oak wall",
		"a grating",
		"a pipe",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a tapestry",
		"a drain",
		"a pipe",
		"the Standard of the Silver Serpent",
		"the Standard of the Seers",
		"the Standard of the Seers",
		"a rough hewn wall",
		"a window",
		"a gold-veined rough hewn wall",
		"a rough hewn wall",
		"a rough hewn wall",
		"a mossy rough hewn wall",
		"a drain",
		"a tapestry",
		"a drain",
		"a brick wall",
		"a brick wall",
		"a stairway leading down",
		"a moss-covered wall",
		"a stairway leading up",
		"a stairway leading up",
		"a stairway leading down",
		"a window",
		"a princess chained to a brick wall",
		"a stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a drain",
		"a cracked irregular stone wall",
		"a vine-covered irregular stone wall",
		"a grating",
		"a mossy irregular stone wall",
		"the Banner of Cabirus",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"the Standard of the Knights",
		"a caved-in stairway",
		"a caved-in passageway",
		"a stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a mossy stone wall",
		"a cracked irregular stone wall",
		"a drain",
		"a vine-covered irregular stone wall",
		"a tapestry",
		"a grating",
		"a moss-covered irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"an ankh",
		"a marble wall",
		"a marble wall",
		"a stone wall",
		"a stone wall",
		"a stone wall",
		"a stone wall",
		"a massive stone door",
		"a marble wall",
		"a waterfall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a lavafall",
		"a rough hewn wall",
		"a rough hewn wall",
		"a pipe",
		"a stone floor",
		"a stone floor",
		"a puddle",
		"a puddle",
		"a stone floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a marble floor",
		"a marble floor",
		"a marble floor",
		"a marble floor",
		"water",
		"water",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"rivulets of lava",
		"lava",
		"lava",
		"nothing",
		"a rough floor",
		"a rough floor",
		"a rough floor",
		"a rough floor",
		"a rough floor",
		"water",
		"water",
		"water",
		"a dirt floor",
		"a rough floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"rivulets of lava",
		"a straw bed",
		"a glowing green pathway",
		"a glowing green pathway",
		"a glowing green pathway",
		"a glowing red pathway",
		"a glowing red pathway",
		"a glowing red pathway",
		"a glowing blue pathway",
		"a glowing blue pathway",
		"a glowing blue pathway"
	};

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

		if ((objInt.isQuant ==true) && (objInt.isEnchanted==false))
		{

			if (output.Contains("&"))
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
				if (objInt.Link>1)
				{
					output = output.Replace("a_",objInt.Link + "_");
					output = output.Replace("an_",objInt.Link + "_");
					output =output + "s";
				}
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
		
		if ((objInt.isQuant ==true) && (objInt.isEnchanted==false))
		{
			if (output.Contains("&"))
			{//string is split into a singular and plural
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
				output = output.Replace("a_",Quantity + "_");
				output = output.Replace("an_",Quantity + "_");
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
		if (output==null)
		{
			output="";
		}
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
		return (GetString(1,260)  + GetString (10,index));
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

	public string GetTextureName(int index)
	{
		if (index <= UW1_TextureNames.Length)
		{
			return UW1_TextureNames[index];
		}
		else
		{
			return "UNKNOWN TEXTURE";
		}
	}
}