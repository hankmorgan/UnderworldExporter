using UnityEngine;
using System.Collections;

public class ObjectPropLoader : Loader {
		//Object Prop Loader for Shock

		public struct ShockCommonObjectProperties
		{
				public int Mass;
				public int hp;
				public int armour;
				public int Render;
				public int Unk1;
				public int Unk2;
				public int Unk3;
				public int Offset;
				public int Unk5;
				public int Unk6;
				public int Vulner;
				public int spevul;
				public int defence;
				public int flags;
				public int ThreeDMod;
				public int frames;
				//public int framesbits4_7;
				//public int framesbits0_3;
		}

		public  ShockCommonObjectProperties[] properties;

		public ObjectPropLoader()
		{

				char[] objprop_dat;
				int add_ptr=5099;
				if (DataLoader.ReadStreamFile(BasePath+"\\Res\\data\\objprop.dat",out objprop_dat))
				{
					properties = new ShockCommonObjectProperties[476];
					for (int i=0; i<=properties.GetUpperBound(0);i++)
					{
								properties[i].Mass=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x0, 32);//Mass 
								properties[i].hp=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x04, 16);//hp  
								properties[i].armour=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x06, 8);//armour  
								properties[i].Render=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x07, 8);//Render  

								properties[i].Unk1=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x08, 8);//unk1
								properties[i].Unk2=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x09, 8);//unk2
								properties[i].Unk3=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x0a, 8);//unk3
								properties[i].Offset=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x0b, 8);//unk4
								properties[i].Unk5=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x0c, 8);//unk5
								properties[i].Unk6=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x0d, 8);//unk6

								properties[i].Vulner=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x0e, 8);//Vulner 
								properties[i].spevul=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x0f, 8);//spevul  
								properties[i].defence=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x12, 8);//defence  
								properties[i].flags=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x14, 16);//flags  
								properties[i].ThreeDMod=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x16, 16);//3d mod  
								properties[i].frames=(int)DataLoader.getValAtAddress(objprop_dat, add_ptr + 0x19, 8);//frames  
								//(int)DataLoader.getValAtAddress(obj_ark, add_ptr + 0x19, 8) >> 4) & 0x7;//framesbits 4-7
								//(int)DataLoader.getValAtAddress(obj_ark, add_ptr  + 0x19, 8) & 0x7);//framesbits 0-3 

						add_ptr+=27;
					}
				}

		}

}
