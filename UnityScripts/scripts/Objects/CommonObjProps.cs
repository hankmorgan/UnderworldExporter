using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
/// <summary>
/// Common object properties from UW Common Objects file.
/// </summary>
/// 
public class CommonObjProps : Props {
		//obsolete
		/*
	private int[] Height	 = new int[500];
	private int[] Radius	 = new int[500];
	private int[] Animated	 = new int[500];
	public int[] Mass	 = new int[500];
	private int[] Flags0	 = new int[500];
	private int[] Flags1	 = new int[500];
	private int[] Flags2	 = new int[500];
	private int[] Magical	 = new int[500];
	private int[] Decal = new int[500];
	private int[] Pickable	 = new int[500];
	private int[] Flags6 = new int[500];
	private int[] Container	 = new int[500];
	public int[] Value	 = new int[500];
	private int[] QualClass	 = new int[500];
	private int[] Owned	 = new int[500];
	private int[] QualType	 = new int[500];
	private int[] LookAt = new int[500];

	/// <summary>
	/// Load the specified fileName.
	/// </summary>
	/// <param name="fileName">File name.</param>
	public bool Load(string fileName)
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
					string[] entries = line.Split(',');
					if (entries.Length > 0)
					{
						Height[i] = int.Parse(entries[0]);
						Radius[i] = int.Parse(entries[1]);
						Animated[i] = int.Parse(entries[2]);
						Mass[i] = int.Parse(entries[3]);
						Flags0[i] = int.Parse(entries[4]);
						Flags1[i] = int.Parse(entries[5]);
						Flags2[i] = int.Parse(entries[6]);
						Magical[i] = int.Parse(entries[7]);
						Decal[i] = int.Parse(entries[8]);
						Pickable[i] = int.Parse(entries[9]);
						Flags6[i] = int.Parse(entries[10]);
						Container[i] = int.Parse(entries[11]);
						Value[i] = int.Parse(entries[12]);
						QualClass[i] = int.Parse(entries[13]);
						Owned[i] = int.Parse(entries[14]);
						QualType[i] = int.Parse(entries[15]);
						LookAt[i] = int.Parse(entries[16]);
						i++;
					}
				}
			}
			while (line != null);
			fileReader.Close();
			return true;
		}
	}
	*/
}