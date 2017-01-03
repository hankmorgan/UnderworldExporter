using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// Class for storing critter info from Objects.dat
/// </summary>
/// Critter info is stored in an external file critters.txt
public class Critters : Props {


		public int[] Level = new int[64];
		public int[] AvgHit = new int[64];//Is this defence?????
		public int[] AttackPower = new int[64];
		public int[] Remains = new int[64];
		public int[] Blood = new int[64];
		public int[] GeneralType = new int[64];
		public int[] Passive = new int[64];
		public int[] Speed = new int[64];
		public int[] Poison = new int[64];
		public int[] Category = new int[64];
		public int[] EquipDamage = new int[64];
		public int[] ProbValue = new int[64];
		public int[] ProbPercent = new int[64];
		public int[] Exp=new int[64];

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
										string[] entries = line.Split(' ');
										if (entries.Length > 0)
										{
												Level[i] = int.Parse(entries[0]);
												AvgHit[i] = int.Parse(entries[1]);
												AttackPower[i] = int.Parse(entries[2]);
												Remains[i] = int.Parse(entries[3]);
												Blood[i] = int.Parse(entries[4]);
												GeneralType[i] = int.Parse(entries[5]);
												Passive[i] = int.Parse(entries[6]);
												Speed[i] = int.Parse(entries[7]);
												Poison[i] = int.Parse(entries[8]);
												Category[i] = int.Parse(entries[9]);
												EquipDamage[i] = int.Parse(entries[10]);
												ProbValue[i] = int.Parse(entries[11]);
												ProbPercent[i] = int.Parse(entries[12]);
												Exp[i] = int.Parse(entries[13]);
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
