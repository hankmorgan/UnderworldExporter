using UnityEngine;
using System.Collections;


/// <summary>
/// Loads data from various GR Files.
/// One instance per file type
/// </summary>
public class GRLoader : ArtLoader {
		const int  repeat_record_start =0;
		const int   repeat_record= 1;
		const int   run_record= 2;

		public const int ThreeDWIN_GR = 0;
		public const int ANIMO_GR = 1;
		public const int ARMOR_F_GR = 2;
		public const int ARMOR_M_GR = 3;
		public const int BODIES_GR = 4;
		public const int BUTTONS_GR = 5;
		public const int CHAINS_GR = 6;
		public const int CHARHEAD_GR = 7;
		public const int CHRBTNS_GR = 8;
		public const int COMPASS_GR = 9;
		public const int CONVERSE_GR = 10;
		public const int CURSORS_GR = 11;
		public const int DOORS_GR = 12;
		public const int DRAGONS_GR = 13;
		public const int EYES_GR = 14;
		public const int FLASKS_GR = 15;
		public const int GENHEAD_GR = 16;
		public const int HEADS_GR = 17;
		public const int INV_GR = 18;
		public const int LFTI_GR = 19;
		public const int OBJECTS_GR = 20;
		public const int OPBTN_GR = 21;
		public const int OPTB_GR = 22;
		public const int OPTBTNS_GR = 23;
		public const int PANELS_GR = 24;
		public const int POWER_GR = 25;
		public const int QUEST_GR = 26;
		public const int SCRLEDGE_GR = 27;
		public const int SPELLS_GR = 28;
		public const int TMFLAT_GR = 29;
		public const int TMOBJ_GR = 30;
		public const int WEAPONS_GR = 31;

	private string[] pathGR={
				"Data\\3DWIN.GR",
				"Data\\ANIMO.GR",
				"Data\\ARMOR_F.GR",
				"Data\\ARMOR_M.GR",
				"Data\\BODIES.GR",
				"Data\\BUTTONS.GR",
				"Data\\CHAINS.GR",
				"Data\\CHARHEAD.GR",
				"Data\\CHRBTNS.GR",
				"Data\\COMPASS.GR",
				"Data\\CONVERSE.GR",
				"Data\\CURSORS.GR",
				"Data\\DOORS.GR",
				"Data\\DRAGONS.GR",
				"Data\\EYES.GR",
				"Data\\FLASKS.GR",
				"Data\\GENHEAD.GR",
				"Data\\HEADS.GR",
				"Data\\INV.GR",
				"Data\\LFTI.GR",
				"Data\\OBJECTS.GR",
				"Data\\OPBTN.GR",
				"Data\\OPTB.GR",
				"Data\\OPTBTNS.GR",
				"Data\\PANELS.GR",
				"Data\\POWER.GR",
				"Data\\QUEST.GR",
				"Data\\SCRLEDGE.GR",
				"Data\\SPELLS.GR",
				"Data\\TMFLAT.GR",
				"Data\\TMOBJ.GR",
				"Data\\WEAPONS.GR",
		};

	private string AuxPalPath = "DATA\\allpals.dat";
	bool useOverrideAuxPalIndex=false;
	int OverrideAuxPalIndex=0;

	public int FileToLoad;
	private bool ImageFileDataLoaded;
	public int NoOfImages;

	protected Texture2D[] ImageCache=new Texture2D[1];
	 
	//protected Vector2[] HotSpot= new Vector2[1];

	public GRLoader(int File)
	{
		useOverrideAuxPalIndex=false;
		OverrideAuxPalIndex=0	;
		FileToLoad=File;
		LoadImageFile();
	}

	public GRLoader(string FileName, int ChunkNo)//For SS1 chunks of art
	{
		useOverrideAuxPalIndex=false;
		OverrideAuxPalIndex=0	;

		if (!DataLoader.ReadStreamFile(BasePath+FileName, out ImageFileData))
		{
			Debug.Log("Unable to load " + BasePath+pathGR[FileToLoad]);
			return;
		}
		else
		{
			DataLoader.Chunk art_ark;
			DataLoader.LoadChunk(ImageFileData,ChunkNo, out art_ark);

				switch ( art_ark.chunkContentType)
				{
				case 3://font //TODO
						break;
				case 2:
				case 17:
					NoOfImages=(int)DataLoader.getValAtAddress( art_ark.data,0,16);
					ImageCache=new  Texture2D[NoOfImages];
					//HotSpot=new Vector2[NoOfImages];
					ImageFileDataLoaded=true;
					for (int i=0; i<NoOfImages;i++)
					{
						long textureOffset = (int)DataLoader.getValAtAddress(art_ark.data, 2 + (i * 4), 32);
						int CompressionType=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+4,16);
						int Width=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+8,16);
						int Height=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+10,16);
						//int x1=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+0xE,8);
						//int y1=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+0xF,8);
						//x1 = 1<<x1;
						//y1 = 1<<y1;
						//float vX1; float vY1;

								//vX1 = (float)x1/(float)Width;
								//vY1 = (float)y1/(float)Height;
										//vX1 =0.5f;
							//if (y1 == 0) cy =       bmp->height; else cy = bmp->y1;
						//HotSpot[i]=new Vector2(vX1,vY1);
						if ((Width>0) && (Height >0))
						{
							if(CompressionType==4)
							{//compressed
								char[] outputImg;
								//  UncompressBitmap(art_ark+textureOffset+BitMapHeaderSize, outputImg,Height*Width);
								UncompressBitmap(art_ark.data,textureOffset+BitMapHeaderSize, out outputImg,Height*Width);
								ImageCache[i]=ArtLoader.Image(outputImg,0,Width,Height,"namehere",GameWorldController.instance.palLoader.Palettes[0],true);
							}
							else
							{//Uncompressed
								ImageCache[i]= ArtLoader.Image(art_ark.data,textureOffset+BitMapHeaderSize,Width,Height,"namehere",GameWorldController.instance.palLoader.Palettes[0],true);
							}
						}
					}
					break;
				}

			return;
		}
	}

	public GRLoader(int File, string AuxPalToUse, int AuxPalIndex)
	{
		if (AuxPalIndex!=-1)
		{
			useOverrideAuxPalIndex=true;
			//OverrideAuxPalIndex=OverrideAuxPalIndex	;
		}
		AuxPalPath=AuxPalToUse;
		FileToLoad=File;
		LoadImageFile();
	}

	public override bool LoadImageFile ()
	{
		if (!DataLoader.ReadStreamFile(BasePath+pathGR[FileToLoad], out ImageFileData))
		{
			Debug.Log("Unable to load " + BasePath+pathGR[FileToLoad]);
			return false;
		}
		else
		{
			NoOfImages=(int)DataLoader.getValAtAddress(ImageFileData,1,16);
			ImageCache=new  Texture2D[NoOfImages];
			ImageFileDataLoaded=true;
			return true;
		}
	}


	public override Texture2D LoadImageAt (int index)
	{
		return LoadImageAt (index,true);
	}

	public override Texture2D LoadImageAt (int index, bool Alpha)
	{
		if (ImageFileDataLoaded==false)
		{
			if (!LoadImageFile ())
			{
				return base.LoadImageAt(index);	
			}
		}
		else
		{
			if (ImageCache[index] !=null)	
			{
				return ImageCache[index];
			}
		}
		
		
		long imageOffset = DataLoader.getValAtAddress(ImageFileData, (index * 4) + 3, 32);
		if (imageOffset>=ImageFileData.GetUpperBound(0))
			{//Image out of range
				return base.LoadImageAt(index);
			}
		int BitMapWidth = (int)DataLoader.getValAtAddress(ImageFileData,imageOffset+1, 8);
		int BitMapHeight = (int)DataLoader.getValAtAddress(ImageFileData, imageOffset+2, 8);
		int datalen;
		Palette auxpal;
		int auxPalIndex;
		char[] imgNibbles;
		char[] outputImg;


		switch (DataLoader.getValAtAddress(ImageFileData, imageOffset, 8))//File type
		{
		case 0x4://8 bit uncompressed
				{
					imageOffset = imageOffset + 5;
					ImageCache[index] =  Image(ImageFileData,imageOffset, BitMapWidth, BitMapHeight,"name_goes_here",GameWorldController.instance.palLoader.Palettes[PaletteNo],Alpha);				
					return ImageCache[index];
				}
		case 0x8://4 bit run-length
				{
					if (!useOverrideAuxPalIndex)
					{
						auxPalIndex = (int)DataLoader.getValAtAddress(ImageFileData, imageOffset + 3, 8);	
					}
					else
					{
						auxPalIndex=OverrideAuxPalIndex;
					}
					datalen = (int)DataLoader.getValAtAddress(ImageFileData,imageOffset+4,16);
					imgNibbles = new char[Mathf.Max(BitMapWidth*BitMapHeight*2,datalen*2)];
					imageOffset = imageOffset + 6;	//Start of raw data.
					copyNibbles(ImageFileData, ref imgNibbles, datalen, imageOffset);
					auxpal =PaletteLoader.LoadAuxilaryPal(Loader.BasePath+ AuxPalPath,GameWorldController.instance.palLoader.Palettes[PaletteNo],auxPalIndex);
					outputImg = DecodeRLEBitmap(imgNibbles, datalen, BitMapWidth, BitMapHeight,4);
					//rawOut.texture= Image(outputImg,0, BitMapWidth, BitMapHeight,"name_goes_here",auxpal,true);
					ImageCache[index] =  Image(outputImg,0, BitMapWidth, BitMapHeight,"name_goes_here",auxpal,Alpha);
					return ImageCache[index] ;
				}
		case 0xA://4 bit uncompressed//Same as above???
				{
					if (!useOverrideAuxPalIndex)
					{
						auxPalIndex = (int)DataLoader.getValAtAddress(ImageFileData, imageOffset + 3, 8);	
					}
					else
					{
						auxPalIndex=OverrideAuxPalIndex;
					}
					datalen = (int)DataLoader.getValAtAddress(ImageFileData, imageOffset + 4, 16);
					imgNibbles = new char[Mathf.Max(BitMapWidth*BitMapHeight*2,datalen*2)];
					imageOffset = imageOffset + 6;	//Start of raw data.
					copyNibbles(ImageFileData, ref imgNibbles, datalen, imageOffset);
					auxpal =PaletteLoader.LoadAuxilaryPal(BasePath+ AuxPalPath,GameWorldController.instance.palLoader.Palettes[PaletteNo],auxPalIndex);
					ImageCache[index] =  Image(imgNibbles,0, BitMapWidth, BitMapHeight,"name_goes_here",auxpal,Alpha);
					return ImageCache[index];
				}
				//break;
		default:
				//Check to see if the file is panels.gr
				if (pathGR[FileToLoad].ToUpper().EndsWith("PANELS.GR"))
				{
					BitMapWidth = 83;  //getValAtAddress(textureFile, textureOffset + 1, 8);
					BitMapHeight = 114; // getValAtAddress(textureFile, textureOffset + 2, 8);
					if ( _RES== "UW2")
						{
						BitMapWidth=79;
						BitMapHeight = 112;
						}
					imageOffset = DataLoader.getValAtAddress(ImageFileData, (index * 4) + 3, 32);
					ImageCache[index] =  Image(ImageFileData,imageOffset, BitMapWidth, BitMapHeight,"name_goes_here",GameWorldController.instance.palLoader.Palettes[PaletteNo],Alpha);
					return ImageCache[index];
				}
			break;
		}

		return new Texture2D(2,2);
	}

		/// <summary>
		/// Copies the nibbles.
		/// </summary>
		/// <param name="InputData">Input data.</param>
		/// <param name="OutputData">Output data.</param>
		/// <param name="NoOfNibbles">No of nibbles.</param>
		/// <param name="add_ptr">Add ptr.</param>
		/// This code from underworld adventures
		protected void copyNibbles(char[] InputData, ref char[] OutputData, int NoOfNibbles, long add_ptr)
		{
			//Split the data up into it's nibbles.
			int i = 0;
			NoOfNibbles=NoOfNibbles*2;
			while (NoOfNibbles > 1)
			{
				OutputData[i] = (char)((DataLoader.getValAtAddress(InputData, add_ptr, 8) >> 4) & 0x0F);		//High nibble
				OutputData[i + 1] = (char)((DataLoader.getValAtAddress(InputData, add_ptr, 8)) & 0xf);	//Low nibble
				i=i+2;
				add_ptr++;
				NoOfNibbles = NoOfNibbles-2;
			}
			if (NoOfNibbles == 1)
			{	//Odd nibble out.
				OutputData[i] = (char)((DataLoader.getValAtAddress(InputData, add_ptr, 8) >> 4) & 0x0F);
			}
		}


		/// <summary>
		/// Decodes the RLE bitmap.
		/// </summary>
		/// <returns>The RLE bitmap.</returns>
		/// <param name="imageData">Image data.</param>
		/// <param name="datalen">Datalen.</param>
		/// <param name="imageWidth">Image width.</param>
		/// <param name="imageHeight">Image height.</param>
		/// <param name="BitSize">Bit size.</param>
		/// This code from underworld adventures
		char[] DecodeRLEBitmap(char[] imageData, int datalen, int imageWidth, int imageHeight, int BitSize)
		//, palette *auxpal, int index, int BitSize, char OutFileName[255])
		{
			char[] outputImg= new char[imageWidth*imageHeight];
			int state=0; 
			int curr_pxl=0;
			int count=0;
			int repeatcount=0;
			char nibble;

			int add_ptr=0;

			while ((curr_pxl<imageWidth*imageHeight) || (add_ptr<=datalen))
			{
				switch (state)
				{
				case repeat_record_start:
					{
						count = getcount(imageData, ref add_ptr,BitSize);
						if (count == 1)
						{
							state = run_record;
						}
						else if (count == 2)
						{
							repeatcount = getcount(imageData, ref add_ptr, BitSize) - 1;
							state = repeat_record_start;
						}
						else
						{
							state = repeat_record;
						}
						break;
					}
				case repeat_record:
						{
							nibble = getNibble(imageData, ref add_ptr);
							//for count times copy the palette data to the image at the output pointer
							if (imageWidth*imageHeight - curr_pxl < count)
							{
								count = imageWidth*imageHeight - curr_pxl;
							}
							for (int i = 0; i < count; i++)
							{
								outputImg[curr_pxl++] = nibble;
							}
							if (repeatcount == 0 )
							{					
								state = run_record;
							}
							else
							{
								state = repeat_record_start;
								repeatcount--;
							}
							break;
						}


				case 2:	//runrecord
						{
							count = getcount(imageData, ref add_ptr, BitSize);
							if (imageWidth*imageHeight - curr_pxl < count)
							{
								count = imageWidth*imageHeight - curr_pxl;
							}
							for (int i = 0; i < count; i++)
							{
								//get nibble for the palette;
								nibble = getNibble(imageData, ref add_ptr);
								outputImg[curr_pxl++] = nibble;
							}
							state = repeat_record_start;
							break;
						}
				}
			}
			return outputImg;
		}



		/// <summary>
		/// Getcount the specified nibbles, addr_ptr and size.
		/// </summary>
		/// <param name="nibbles">Nibbles.</param>
		/// <param name="addr_ptr">Address ptr.</param>
		/// <param name="size">Size.</param>
		/// This code from underworld adventures
		int getcount(char[] nibbles, ref int addr_ptr , int size)
		{
				int n1;
				int n2;
				int n3;
				int count=0;

				n1 = getNibble(nibbles,ref addr_ptr);
				count = n1;

				if (count==0)
				{
						n1 = getNibble(nibbles, ref addr_ptr);
						n2 = getNibble(nibbles, ref addr_ptr);
						count = (n1 << size) | n2;
				}
				if (count == 0)
				{
						n1 = getNibble(nibbles, ref addr_ptr);
						n2 = getNibble(nibbles, ref addr_ptr);
						n3 = getNibble(nibbles, ref addr_ptr);
						count = (((n1 << size) | n2) << size) | n3;
				}
				return count;		
		}

		/// <summary>
		/// Gets the nibble.
		/// </summary>
		/// <returns>The nibble.</returns>
		/// <param name="nibbles">Nibbles.</param>
		/// <param name="addr_ptr">Address ptr.</param>
		/// This code from underworld adventures
		char getNibble(char[] nibbles, ref int addr_ptr)
		{
				char n1 = nibbles[addr_ptr];
				addr_ptr = addr_ptr + 1;
				return n1;
		}

		/// <summary>
		/// Returns a sprite made from the specified image.
		/// </summary>
		/// <returns>The sprite.</returns>
		/// <param name="index">Index.</param>
		public Sprite RequestSprite(int index)
		{
			if (ImageCache[index]==null)
			{
				LoadImageAt(index);	
				if (ImageCache[index]==null)
				{//Still can't be loaded
					return Resources.Load<Sprite>("Common/null");
				}
			}

			return Sprite.Create(ImageCache[index],new Rect(0,0,ImageCache[index].width,ImageCache[index].height), new Vector2(0.5f, 0.0f));	

		}


		public Sprite RequestSprite(int index, int offset)
		{
				if (ImageCache[index]==null)
				{
						LoadImageAt(index);	
						if (ImageCache[index]==null)
						{//Still can't be loaded
								return Resources.Load<Sprite>("Common/null");
						}
				}

				//float height = (float)ImageCache[index].height;
				//float offsetf= (float)offset;

				//When offset is zero sprite at (0.5, 0)
				//When offset is height sprite at (0.5, 1)
				//float adj=0f;


					//adj = offsetf / height;	


				//adj= GameWorldController.instance.testUVadjust;
				return Sprite.Create(ImageCache[index],new Rect(0,0,ImageCache[index].width,ImageCache[index].height), new Vector2(0.5f,  0f));	
	
		}

}
