using UnityEngine;
using System.Collections;
/// <summary>
/// Boots.
/// </summary>
/// Wearable boots
public class Boots : Armour {


	public static void CreateBoots(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{//For creating boots at runtime. Needed for Dragon Skin boots
		Boots newcomp =myObj.AddComponent<Boots>();
		/*newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;*/
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;		
	}


}