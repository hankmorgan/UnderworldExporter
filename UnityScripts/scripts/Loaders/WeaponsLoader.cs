using UnityEngine;
using System.Collections;

public class WeaponsLoader : ArtLoader {
		const int  repeat_record_start =0;
		const int   repeat_record= 1;
		const int   run_record= 2;

	//int NoOfImages=0;


	protected Texture2D[] ImageCache=new Texture2D[1];

	public WeaponsLoader(int AuxPal)
	{
		switch(_RES)
		{
		case GAME_UW1:
		case GAME_UW2:
				ReadAnimData(AuxPal);break;				
		}
		
	}


	public void ReadAnimData(int auxPalIndex)
	{

	int[] AnimX=new int[390];
	int[] AnimY=new int[390];
	int[] AnimXY=new int[776];//For UW2
	int[] UW2_X = { 35, 36, 37, -1, 39, 40, 41, 42, -1, 44, 45, 46, -1, 48, 49, 50, 51, -1, -1, -1, -1, -1, 57, 58, 59, -1, -1, 62, 63, 64, -1, 132, 133, 134, -1, 136, 137, 138, 139, -1, 141, 142, 143, -1, 145, 146, 147, 148, -1, -1, -1, -1, -1, 154, 155, 156, -1, -1, 159, 160, 161, -1, 229, 230, 231, -1, 233, 234, 235, 236, -1, 238, 239, 240, -1, 242, 243, 244, 245, -1, -1, -1, -1, -1, 251, 252, 253, -1, -1, 256, 257, 258, -1, -1, -1, -1, -1, 330, 331, 332, -1, -1, 335, -1, 337, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 423, 424, 425, -1, 427, 428, 429, 430, -1, 432, 433, 434, -1, 436, 437, 438, 439, -1, -1, -1, -1, -1, 446, 447, 448, -1, -1, -1, 450, 451, 452, 520, 521, 522, -1, 524, 525, 526, 527, -1, 529, 530, 531, -1, 533, 534, 535, 536, -1, -1, -1, -1, -1, 542, 543, 544, -1, -1, 547, 548, 549, -1, 617, 618, 619, -1, 621, 622, 623, 624, -1, 626, 627, 628, -1, 630, 631, 632, 633, -1, -1, -1, -1, -1, 639, 640, 641, -1, -1, 644, 645, 646, -1, -1, -1, -1, -1, 718, 719, 720, -1, 723, -1, 725, -1, -1 };
	int[] UW2_Y = { 66, 67, 68, -1, 70, 71, 72, 73, -1, 75, 76, 77, -1, 79, 80, 81, 82, -1, -1, -1, -1, -1, 88, 89, 90, -1, -1, 93, 94, 95, -1, 163, 164, 165, -1, 167, 168, 169, 170, -1, 172, 173, 174, -1, 176, 177, 178, 179, -1, -1, -1, -1, -1, 185, 186, 187, -1, -1, 190, 191, 192, -1, 260, 261, 262, -1, 264, 265, 266, 267, -1, 269, 270, 271, -1, 273, 274, 275, 276, -1, -1, -1, -1, -1, 282, 283, 284, -1, -1, 287, 288, 289, -1, -1, -1, -1, -1, 361, 362, 363, -1, -1, 366, -1, 368, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 454, 455, 456, -1, 458, 459, 460, 461, -1, 463, 464, 465, -1, 467, 468, 469, 470, -1, -1, -1, -1, -1, 476, 477, 478, -1, -1, -1, 482, 482, 483, 551, 552, 553, -1, 555, 556, 557, 558, -1, 560, 561, 562, -1, 564, 565, 566, 567, -1, -1, -1, -1, -1, 573, 574, 575, -1, -1, 578, 579, 580, -1, 648, 649, 650, -1, 652, 653, 654, 655, -1, 657, 658, 659, -1, 661, 662, 663, 664, -1, -1, -1, -1, -1, 670, 671, 672, -1, -1, 675, 676, 677, -1, -1, -1, -1, -1, 749, 750, 751, -1, 754, -1, 756, -1, -1 };


		string datfile="DATA"+ sep + "WEAPONS.DAT";
		string cmfile="DATA" + sep + "WEAPONS.CM";
		string grfile="DATA" + sep + "WEAPONS.GR";
		if (_RES==GAME_UW2)
		{
			datfile="DATA" + sep + "WEAP.DAT";
			cmfile="DATA" + sep + "WEAP.CM";
			grfile="DATA" + sep + "WEAP.GR";	
		}
		char[] AnimData;
		char[] textureFile;
		int offset=0;
		int GroupSize=28; //28 for uw1

		int MaxHeight = 112;
		int MaxWidth = 172;
		if (_RES== GAME_UW2)
		{
			MaxHeight = 128;
			MaxWidth = 208;
		}
		int add_ptr=0;
		int alpha=0;
		DataLoader.ReadStreamFile(BasePath+datfile, out AnimData);
		DataLoader.ReadStreamFile(BasePath+grfile, out textureFile);
		if (_RES != GAME_UW2)
		{
			GroupSize = 28;

			for (int i = 0; i<8; i++)
			{
				for (int j = 0; j<GroupSize; j++)
				{
					AnimX[j + offset] = (int)DataLoader.getValAtAddress(AnimData, add_ptr++, 8);
				}
				for (int j = 0; j<GroupSize; j++)
				{
					AnimY[j + offset] = (int)DataLoader.getValAtAddress(AnimData, add_ptr++, 8);
				}
				offset = offset + GroupSize;
			}
		}
		else
		{//In UW2 I just read the values into one array
			for (int i = 0; i <= AnimData.GetUpperBound(0); i++)
			{
				AnimXY[i] = (int)DataLoader.getValAtAddress(AnimData, add_ptr++, 8);
			}
		}


		add_ptr=0;

		int NoOfTextures = textureFile[2] << 8 | textureFile[1];
		if (_RES==GAME_UW2)
		{
			NoOfTextures=230;
		}
		ImageCache=new Texture2D[NoOfTextures+1];

		for (int i = 0; i < NoOfTextures; i++)
		{
			long textureOffset = DataLoader.getValAtAddress(textureFile, (i * 4) + 3, 32);
			int BitMapWidth = (int)DataLoader.getValAtAddress(textureFile, textureOffset + 1, 8);
			int BitMapHeight = (int)DataLoader.getValAtAddress(textureFile, textureOffset + 2, 8);
			int datalen;
			Palette auxpal =PaletteLoader.LoadAuxilaryPal(Loader.BasePath + cmfile,GameWorldController.instance.palLoader.Palettes[PaletteNo],auxPalIndex);
			char[] imgNibbles;
			char[] outputImg;
			char[] srcImg;

			datalen =  (int)DataLoader.getValAtAddress(textureFile, textureOffset + 4, 16);
			imgNibbles = new char[Mathf.Max(BitMapWidth*BitMapHeight*2,datalen*2)];
			textureOffset = textureOffset + 6;	//Start of raw data.
		
			copyNibbles(textureFile, ref imgNibbles, datalen, textureOffset);
			//LoadAuxilaryPal(auxPalPath, auxpal, pal, auxPalIndex);
			srcImg = new char[BitMapWidth*BitMapHeight];
			outputImg = new char[MaxWidth*MaxHeight];
			//Debug.Log("i= " + i + " datalen= " + datalen);
			if (datalen>=6)
				{
				srcImg= DecodeRLEBitmap(imgNibbles, datalen, BitMapWidth, BitMapHeight, 4);	
				}


			//Paste source image into output image.
			int ColCounter = 0; int RowCounter = 0;
			int cornerX;// = AnimX[i];
			int cornerY;// = AnimY[i];
			if (_RES !=GAME_UW2)
			{
				cornerX = AnimX[i];
				cornerY = AnimY[i];
			}
			else
			{//Read from XY
				if (UW2_X[i] != -1)
				{
					cornerX = AnimXY[UW2_X[i]];
					cornerY = AnimXY[UW2_Y[i]];
				}
				else
				{
					cornerX=0;
					cornerY=BitMapHeight;
				}
			}

			if ((_RES ==GAME_UW1) || ((_RES ==GAME_UW2) && (UW2_X[i] != -1)))//Only create if UW1 image or a valid uw2 one
			{
				bool ImgStarted = false;
				for (int y = 0; y < MaxHeight; y++)
				{
					for (int x = 0; x < MaxWidth; x++)
					{
						if ((cornerX + ColCounter == x) && (MaxHeight - cornerY + RowCounter == y) && (ColCounter<BitMapWidth) && (RowCounter<BitMapHeight))
						{//the pixel from the source image is here 
							ImgStarted = true;
							outputImg[x + (y*MaxWidth)] = srcImg[ColCounter + (RowCounter*BitMapWidth)];
							ColCounter++;
						}
						else
						{
							alpha=0;//0
							outputImg[x + (y*MaxWidth)] = (char)alpha;
						}
					}
					if (ImgStarted == true)
					{//New Row on the src image
						RowCounter++;
						ColCounter = 0;
					}
				}

				ImageCache[i]= Image(outputImg,0, MaxWidth, MaxHeight,"name_goes_here",auxpal,true);

			}
		}
	}



		//****************Copied functions


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

				//NoOfNibbles=NoOfNibbles*2;
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

				while ((curr_pxl<imageWidth*imageHeight) || (add_ptr<datalen))
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


	public override Texture2D LoadImageAt (int index)
	{
		if (ImageCache[index]!=null)
		{
				return ImageCache[index];	
		}
		else
		{
			return base.LoadImageAt (index);	
		}		
	}
}