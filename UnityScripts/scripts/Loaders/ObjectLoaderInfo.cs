using UnityEngine;
using System.Collections;

public class ObjectLoaderInfo {

		public int index;	//it's own index in case I need to find myself.
		public int item_id;	//0-8
		public int flags;	//9-12
		public short enchantment;	//12
		public short doordir;	//13
		public short invis;		//14
		public short is_quant;	//15

		public int texture;	// Note: some objects don't have flags and use the whole lower byte as a texture number
		//(gravestone, picture, lever, switch, shelf, bridge, ..)

		public int zpos;    //  0- 6   7   "zpos"      Object Z position (0-127)
		public int heading;	//        7- 9   3   "heading"   Heading (*45 deg)
		public int x; //   10-12   3   "ypos"      Object Y position (0-7)
		public int y; //  13-15   3   "xpos"      Object X position (0-7)
		//0004 quality / chain
		public 		int quality;	//;     0- 5   6   "quality"   Quality
		public long next; //    6-15   10  "next"      Index of next object in chain

		//0006 link / special
		//     0- 5   6   "owner"     Owner / special

		public int owner;	//Also special
		//     6-15   10  (*)         Quantity / special link / special property

		public int link	;	//also quantity

		//The values stored in the NPC info area (19 bytes) contain infos for
		//critters unique to each object.
		//0008 
		public int npc_hp;	//0-7
		//0009	
		//blank?
		//000a   
		//blank?
		//000b   Int16      
		public short npc_goal;	//0-3
		public short npc_gtarg;    //4-11   
		//000d        
		public short npc_level;	//0-3
		public short npc_talkedto;   //13     
		public short npc_attitude;	//14-15
		//000f    
		public short npc_height ;//6- 12 ?
		//0016  
		public short npc_yhome;	// 4-9    
		public short npc_xhome; // 10-15  
		//0018   0010   Int8   0-4:   npc_heading?
		public short npc_heading;
		//   0019      Int8   0-6:   
		public short npc_hunger; //(?)
		//001a   0012   Int8          
		public int npc_whoami;

		public short npc_health=0;
		public short npc_arms=0;
		public short npc_power = 0;
		public short npc_name = 0;


		//My additions
		public short InUseFlag;
		public short levelno;
		public short tileX;	//Position of the object on the tilemap
		public short tileY;
		public long address;
		public short AlreadyRendered;
		public short DeathWatched;


		public ObjectInteraction instance;

		//Shock specific stuff
		//TODO:Split UW specific and Shock specific out in to subclasses?
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
}
