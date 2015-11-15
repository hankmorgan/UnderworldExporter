using UnityEngine;
using System.Collections;

public class Weapon : Equipment {
	public int Skill;
	//public int Durability;
	public int Slash;
	public int Bash;
	public int Stab;


	public override bool EquipEvent (int slotNo)
	{
		//TODO:Update damage stats.
		/*/*UpdateQuality();*/
		return true;
	}

}
