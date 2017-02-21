using UnityEngine;
using System.Collections;

public class TerrainDatLoader : Loader {


		//public const int x;

		public const int Normal =0; // (solid) wall or floor
		public const int Ankh =2;//mural (shrines)
		public const int Stairsup = 3;
		public const int Stairsdown=4;
		public const int Pipe=5;
		public const int Grating=6;
		public const int Drain=7;
		public const int ChainedPrincess=8;
		public const int Window=9;
		public const int Tapestry=0xa;
		public const int Textured_door= 0xb ;//(used for the lock to the Key of Infinity)
		public const int Water = 0x10;//(not waterfall)
		public const int Lava =0x20;//(not lavafall)
		public const int Waterfall  =0x40;//     - UW2
		public const int  Ice_wall =0xC0; //     - UW2
		//00D8
		public const int Ice_walls= 0xE8;// (crumbling?)
		public const int  Lavafall  = 0x80;   //  - UW2
		public const int  Ice     =0xF8  ; //   - UW2

		public int[] Terrain;

		public TerrainDatLoader()
		{
			Terrain = new int[256+256];//wall and floor
			char[] terrain_dat;
			int add_ptr=0;
			if (DataLoader.ReadStreamFile(BasePath+"\\data\\terrain.dat",out terrain_dat))
			{
				for (int i=0; i<256;i++)	
				{
					Terrain[i]=(int)DataLoader.getValAtAddress(terrain_dat,add_ptr,16);
					add_ptr+=2;
				}
				add_ptr=0x200;
				for (int i=256; i<512;i++)	
				{
					Terrain[i]=(int)DataLoader.getValAtAddress(terrain_dat,add_ptr,16);
					add_ptr+=2;
				}
			}
		}

}
