using UnityEngine;
using System.Collections;

/// <summary>
/// Object loader info.
/// </summary>
/// Basically what gets written and read to and from lev.ark files.
/// Used to create instances of objectinteractions.
public class ObjectLoaderInfo : UWClass {
		
		public int index;	//it's own index in case I need to find myself.
		public int item_id;	//0-8
		public short flags;	//9-12
		public short enchantment;	//12
		public short doordir;	//13
		public short invis;		//14
		public short is_quant;	//15

		public int texture;	// Note: some objects don't have flags and use the whole lower byte as a texture number
		//(gravestone, picture, lever, switch, shelf, bridge, ..)
		//This variable is uses for shorthand usage of this property

		public short zpos;   
		public short heading;	
		public short x; 
		public short y; 
		public short quality;	
		public int next; 
		public short owner;
		public int link	;

		public short npc_hp;
		public short MissileHeadingMinor;//defection to the right of the missile from the major heading.
		public short MissileHeadingMajor; //Cardinal direction 0 to 7 of the missile. North = 0 turning clockwise to North west = 7
		public short MobileUnk01;
		public short npc_goal;	
		public short npc_gtarg;
		public short MobileUnk02;
		public short npc_level;	
		public short MobileUnk03;
		public short MobileUnk04;
		public short npc_talkedto;       
		public short npc_attitude;	
		public short MobileUnk05;
		public short npc_height;
		public short MobileUnk06;
		public short MobileUnk07;
		public short MobileUnk08;
		public short MobileUnk09;
		public short Projectile_Pitch;
		public short MobileUnk10; //sign bit for pitch = 1 is down. 0 = up?
		public short npc_voidanim; 
		public short MobileUnk11;
		public short MobileUnk12;
		public short npc_yhome;	 
		public short npc_xhome; 
		public short npc_heading;
		public short MobileUnk13;
		public short npc_hunger;
		public short MobileUnk14;
		public short npc_whoami;

		//Where are these values set???
		public short npc_health=0;//Is this poisoning?
		public short npc_arms=0;
		public short npc_power = 0;
		public short npc_name = 0;


		//My additions
		public short InUseFlag;//Based on values and no of values in the mobile and static free lists.
		public short levelno;//Use for unique naming of the object
		public short tileX;	//Position of the object on the tilemap
		public short tileY;
		public long address;


		public ObjectInteraction instance;
		public ObjectLoader parentList;

		//SShock specific stuff
		public int ObjectClass;
		public int ObjectSubClass;
		public int ObjectSubClassIndex;

		public int Angle1;
		public int Angle2;
		public int Angle3;

		public int sprite;
		public int State;
		public int unk1;//Probably a texture index.

		public int[] shockProperties=new int[10]; //Shared properties memory
		public int[] conditions=new int[4];  
		public int TriggerAction;//Needs to be split into a property.
		public int TriggerOnce;

		//public short[] NPC_DATA=new short[19];


		/// <summary>
		/// The GUID of this object instance. To guarantee unique object names.
		/// </summary>
		public System.Guid guid;



		/// <summary>
		/// Gets the type of the item from object masters. UWE object type codes.
		/// </summary>
		/// <returns>The item type.</returns>
		public int GetItemType()
		{
				return GameWorldController.instance.objectMaster.type[item_id];
		}

		/// <summary>
		/// resets all properties to zero to maintain compatability with UW2
		/// </summary>
		public static void CleanUp(ObjectLoaderInfo obj)
		{
			//TODO:test if this is needed for mobile objects as well.

				obj.item_id=0;
				obj.flags=0;
				obj.enchantment=0;
				obj.doordir=0;
				obj.invis=0;
				obj.is_quant=0;
				obj.zpos=0;
				obj.x=0;
				obj.y=0;
				obj.heading=0;
				obj.quality=0;
				obj.next=0;
				obj.owner=0;
				obj.link=0;
		}



		public void Set()
		{
			InUseFlag=1;
		}

		public void Unset()
		{
			InUseFlag=0;	
		}

		public bool isInUse()
		{
			return (InUseFlag==1);
		}
}
