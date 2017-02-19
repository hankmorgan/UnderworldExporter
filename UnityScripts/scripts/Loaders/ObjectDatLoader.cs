using UnityEngine;
using System.Collections;

public class ObjectDatLoader : Loader {

		public struct MeleeData
		{
				//0000   Int8   damage modifier for Slash attack
				//0001   Int8   damage modifier for Bash attack
				//0002   Int8   damage modifier for Stab attack
				//0003   3      unknown
				//0006   Int8   skill type (3: sword, 4: axe, 5: mace, 6: unarmed)
				//0007   Int8   durability	
			public int Slash;
			public int Bash;
			public int Stab;
			public int Skill;
			public int Durability;
		};

		public struct RangedData
		{

				//0000   Int16  unknown
				//bits 9-15: ammunition needed (+0x10)
				//0002   Int8   durability	
			public int ammo;
			public int durability;
		}

		public struct ArmourData
		{
				/*0000   Int8   protection
				0001   Int8   durability
				0002   Int8   unknown
				0003   Int8   category:
				00: shield
				01: body armour
				03: leggings
				04: gloves
				05: boots
				08: hat
				09: ring*/
				public int protection;
				public int durability;
				public int category;
		}

		public struct ContainerData
		{
				/** Containers table (0x0080-0x008f)

				0000   Int8   capacity in 0.1 stones
				0001   Int8   objects accepted; 0: runes, 1: arrows, 2: scrolls, 3: edibles, 0xFF: any
				0002   Int8   number of slots available?; 2: , -1: any
				*/

				public int capacity;
				public int objectsMask;
				public int slots;
		}

		public struct LightSourceData
		{
				//* Light source table (0x0090-0x009f)
				public int brightness;
				public int duration;
				//0000   Int8   light brightness (max. is 4; 0 means unlit)
				//0001   Int8   duration (00: doesn't go out, e.g. taper of sacrifice)
		}


		public MeleeData[] weaponStats=new MeleeData[16];
		public RangedData[] rangedStats=new RangedData[16];
		public ArmourData[] armourStats=new ArmourData[32];
		public ContainerData[] containerStats=new ContainerData[16];
		public LightSourceData[] lightSourceStats=new LightSourceData[8];

		public ObjectDatLoader()
		{
			char[] obj_dat;
			int add_ptr;
			if (DataLoader.ReadStreamFile(BasePath+"\\data\\objects.dat",out obj_dat))
			{
				add_ptr=2;
				int j=0;
				for (int i=0; i<16;i++)
				{
					weaponStats[j].Slash = (int)DataLoader.getValAtAddress(obj_dat, add_ptr, 8);
					weaponStats[j].Bash = (int)DataLoader.getValAtAddress(obj_dat, add_ptr+1, 8);
					weaponStats[j].Stab = (int)DataLoader.getValAtAddress(obj_dat, add_ptr+2, 8);
					weaponStats[j].Skill = (int)DataLoader.getValAtAddress(obj_dat, add_ptr+6, 8);
					weaponStats[j].Durability = (int)DataLoader.getValAtAddress(obj_dat, add_ptr+7, 8);
					add_ptr=add_ptr+8;	
					j++;
				}


				add_ptr=0x82;
				j=0;
				for (int i = 0; i < 16; i++)
				{//Ranged weapons
				//This is probably wrong!!
					rangedStats[j].ammo=0x10 + ((((int)DataLoader.getValAtAddress(obj_dat,  add_ptr, 16) >> 9) & 0x7F));
					rangedStats[j].durability= (int)DataLoader.getValAtAddress(obj_dat,  add_ptr + 2, 8);
					add_ptr = add_ptr + 3;
					j++;
				}

				add_ptr=0xb2;
				j=0;
				for (int i = 0; i < 32; i++)
				{
					armourStats[j].protection= (int)DataLoader.getValAtAddress(obj_dat, add_ptr, 8);
					armourStats[j].durability= (int)DataLoader.getValAtAddress(obj_dat, add_ptr + 1, 8);
					armourStats[j].category=(int)DataLoader.getValAtAddress(obj_dat, add_ptr + 3, 8);
					add_ptr = add_ptr + 4;
					j++;
				}


				add_ptr=0xd32;
				j=0;
				for (int i = 0; i < 16; i++)
				{
					containerStats[i].capacity =(int)DataLoader.getValAtAddress(obj_dat, add_ptr, 8);
					containerStats[i].objectsMask=(int)DataLoader.getValAtAddress(obj_dat, add_ptr+1, 8);
					containerStats[i].slots =(int)DataLoader.getValAtAddress(obj_dat, add_ptr+2, 8);
					add_ptr = add_ptr + 3;
					j++;
				}


				add_ptr=0xd62;
				j=0;
				for (int i = 0; i < 8; i++)
				{//Light sources
					lightSourceStats[j].duration = (int)DataLoader.getValAtAddress(obj_dat, add_ptr, 8);
					lightSourceStats[j].brightness =(int)DataLoader.getValAtAddress(obj_dat, add_ptr + 1, 8);
					add_ptr = add_ptr + 2;
					j++;
				}
			}
		}
}
