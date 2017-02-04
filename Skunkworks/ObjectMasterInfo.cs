using UnityEngine;
using System.Collections;

public class ObjectMasterInfo  {

	public int index;
	public short type;	//from above
	public string desc;
	public string path; //to object model
	public string particle;
	public string sound;
	public short isEntity; // 1 for entity. 0 for model. -1 for ignored entries
	public short isSet;
	public short objClass;	//For Shock
	public short objSubClass;
	public short objSubClassIndex;
	public string cat;//What is this???
	public short extraInfo;	//For stuff like door texture info.

	public short renderType;
	public short frame1;	//Frame no
	public short DeathWatch;

	public short hasParticle;
	public short hasSound;
	public string baseModel;//?
	public short isSolid;
	public short isMoveable;
	public short isInventory;
	public short isAnimated;
	public short useSprite;
	public string InvIcon;
	public short ShouldSave;

	public string EquippedIconFemaleLowestQuality;
	public string EquippedIconMaleLowestQuality;//and default
	public 	string EquippedIconFemaleLowQuality;
	public string EquippedIconMaleLowQuality;
	public string EquippedIconFemaleMediumQuality;
	public string EquippedIconMaleMediumQuality;
	public string EquippedIconFemaleBestQuality;
	public string EquippedIconMaleBestQuality;

	//int[] uwProperties[12];

}
