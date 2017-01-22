using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// Weapon properties.
/// </summary>
public class WeaponProps : Props {
	
	private int[] Slash = new int[16];
	private int[] Bash = new int[16];	
	private int[] Stab = new int[16];	
	private int[] Skill = new int[16];	
	private int[] Durability = new int[16];

	public int getPropSlash(int index)
	{
		return Slash[index];
	}

	public int getPropBash(int index)
	{
		return Bash[index];
	}

	public int getPropStab(int index)
	{
		return Stab[index];
	}

	public int getPropSkill(int index)
	{
		return Skill[index];
	}

	public int getPropDurability(int index)
	{
		return Durability[index];
	}

	/// <summary>
	/// Load the specified fileName.
	/// </summary>
	/// <param name="fileName">File name.</param>
	public bool Load(string fileName)
	{
		int i=0;
		string line;
		StreamReader fileReader = new StreamReader(fileName, Encoding.Default);
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
