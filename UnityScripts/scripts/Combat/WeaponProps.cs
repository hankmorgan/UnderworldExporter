using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// Weapon properties.
/// </summary>
public class WeaponProps : Props {
	
		public int[] Slash = new int[16];
		public int[] Bash = new int[16];	
		public int[] Stab = new int[16];	
		public int[] Skill = new int[16];	
		public int[] Durability = new int[16];


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
							Slash[i] = int.Parse(entries[0]);
							Bash[i] = int.Parse(entries[1]);
							Stab[i] = int.Parse(entries[2]);
							Skill[i] = int.Parse(entries[3]);
							Durability[i] = int.Parse(entries[4]);
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
