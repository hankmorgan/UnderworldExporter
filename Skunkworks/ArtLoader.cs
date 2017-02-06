using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ArtLoader : MonoBehaviour {

	const int  repeat_record_start =0;
	const int   repeat_record= 1;
	const int   run_record= 2;


	public string path="C:\\Games\\Uw1\\DATA\\MAIN.BYT";
	public string pathTexW="C:\\Games\\Uw1\\DATA\\W64.TR";
	public string pathTexF="C:\\Games\\Uw1\\DATA\\F32.TR";
	public string pathGR="C:\\Games\\Uw1\\DATA\\OBJECTS.GR";
	public string auxPalPath="c:\\games\\uw1\\data\\allpals.dat";
	public RawImage rawOut;
	//private Texture2D imageOut;
	public SpriteRenderer sprt;
	public int pal;
	public int textureIndex;
	public int grIndex;
	public PaletteLoader palLoader;
	char[] texturebufferW;
	char[] texturebufferF;
	char[] grBuffer;
	public bool texturesWLoaded;
	public bool texturesFLoaded;
	public bool grBufferLoaded;

	public void Start()
		{
		palLoader.LoadPalettes();
		}

	public void RunArtLoaderByt()
		{
		char[] buffer;
		if (DataLoader.ReadStreamFile(path, out buffer))
			{//data read
			rawOut.texture= Image(buffer,0,320,200,"name_goes_here",palLoader.Palettes[pal],true);
			}
		}

	public void RunArtLoaderTexture()
		{
		if (textureIndex<=209)
			{//Wall textures
			if (texturesWLoaded==false)
				{
				if (!DataLoader.ReadStreamFile(pathTexW, out texturebufferW))
					{
					return;
					}
				else
					{
					texturesWLoaded=true;
					}
				}	
			long textureOffset = DataLoader.getValAtAddress(texturebufferW, (textureIndex * 4) + 4, 32);
			rawOut.texture= Image(texturebufferW,textureOffset, 64, 64,"name_goes_here",palLoader.Palettes[0],false);
			}
		else
			{//Floor textures (to match my list of textures)
			if (texturesFLoaded==false)
				{
				if (!DataLoader.ReadStreamFile(pathTexF, out texturebufferF))
					{
					return;
					}
				else
					{
					texturesFLoaded=true;
					}
				}
			long textureOffset = DataLoader.getValAtAddress(texturebufferF, ((textureIndex-210) * 4) + 4, 32);
			rawOut.texture= Image(texturebufferF,textureOffset, 32, 32,"name_goes_here",palLoader.Palettes[0],false);
			}
		}


	public void RunArtLoaderGR()
		{

		if (grBufferLoaded==false)
			{
			if (!DataLoader.ReadStreamFile(pathGR, out grBuffer))
				{
				return;
				}
			else
				{
				grBufferLoaded=true;
				}
			}
		
		long imageOffset = DataLoader.getValAtAddress(grBuffer, (grIndex * 4) + 3, 32);
		int BitMapWidth = (int)DataLoader.getValAtAddress(grBuffer,imageOffset+1, 8);
		int BitMapHeight = (int)DataLoader.getValAtAddress(grBuffer, imageOffset+2, 8);
		int datalen;
		Palette auxpal;
		int auxPalIndex;
		char[] imgNibbles;
		char[] outputImg;


		switch (DataLoader.getValAtAddress(grBuffer, imageOffset, 8))//File type
			{
				case 0x4://8 bit uncompressed
					{
					imageOffset = imageOffset + 5;
					sprt.sprite= Sprite.Create(Image(grBuffer,imageOffset, BitMapWidth, BitMapHeight,"name_goes_here",palLoader.Palettes[0],true),new Rect(0f,0f,BitMapWidth,BitMapHeight),new Vector2 (0.5f,0.5f));
					break;
					}
				case 0x8://4 bit run-length
					{
					auxPalIndex = (int)DataLoader.getValAtAddress(grBuffer, imageOffset + 3, 8);
					datalen = (int)DataLoader.getValAtAddress(grBuffer,imageOffset+4,16);
					imgNibbles = new char[BitMapWidth*BitMapHeight*2];
					imageOffset = imageOffset + 6;	//Start of raw data.
					copyNibbles(grBuffer, ref imgNibbles, datalen, imageOffset);
					auxpal =PaletteLoader.LoadAuxilaryPal(auxPalPath,palLoader.Palettes[0],auxPalIndex);
					outputImg = DecodeRLEBitmap(imgNibbles, datalen, BitMapWidth, BitMapHeight,4);
					//rawOut.texture= Image(outputImg,0, BitMapWidth, BitMapHeight,"name_goes_here",auxpal,true);
					sprt.sprite= Sprite.Create(Image(outputImg,0, BitMapWidth, BitMapHeight,"name_goes_here",auxpal,true),new Rect(0f,0f,BitMapWidth,BitMapHeight),new Vector2 (0.5f,0.5f));
					break;
					}
				case 0xA://4 bit uncompressed//Same as above???
					{
					auxPalIndex = (int)DataLoader.getValAtAddress(grBuffer, imageOffset + 3, 8);
					datalen = (int)DataLoader.getValAtAddress(grBuffer, imageOffset + 4, 16);
					imgNibbles = new char[BitMapWidth*BitMapHeight*2];
					imageOffset = imageOffset + 6;	//Start of raw data.
					copyNibbles(grBuffer, ref imgNibbles, datalen, imageOffset);
					auxpal =PaletteLoader.LoadAuxilaryPal(auxPalPath,palLoader.Palettes[0],auxPalIndex);

					sprt.sprite= Sprite.Create(Image(imgNibbles,0, BitMapWidth, BitMapHeight,"name_goes_here",auxpal,true),new Rect(0f,0f,BitMapWidth,BitMapHeight),new Vector2 (0.5f,0.5f));
					break;				
					}
				break;
		default:
			//Check to see if the file is panels.gr
			if (pathGR.ToUpper().EndsWith("PANELS.GR"))
				{
				BitMapWidth = 83;  //getValAtAddress(textureFile, textureOffset + 1, 8);
				BitMapHeight = 114; // getValAtAddress(textureFile, textureOffset + 2, 8);
				//if ( _RES== UW2)
				//	{
				//	BitMapWidth=79;
				//	BitMapHeight = 112;
				//	}
				imageOffset = DataLoader.getValAtAddress(grBuffer, (grIndex * 4) + 3, 32);
				sprt.sprite= Sprite.Create(Image(grBuffer,imageOffset, BitMapWidth, BitMapHeight,"name_goes_here",palLoader.Palettes[0],true),new Rect(0f,0f,BitMapWidth,BitMapHeight),new Vector2 (0.5f,0.5f));

				}

			return;
			}


		}



	void copyNibbles(char[] InputData, ref char[] OutputData, int NoOfNibbles, long add_ptr)
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

	char getNibble(char[] nibbles, ref int addr_ptr)
		{
		char n1 = nibbles[addr_ptr];
		addr_ptr = addr_ptr + 1;
		return n1;
		}


	private Texture2D Image(char[] databuffer,long dataOffSet, int width, int height, string imageName, Palette pal , bool Alpha )
		{
		int pixelcount=0;
		Texture2D image = new Texture2D(width, height);
		Color32[] imageColors = new Color32[width * height];
		long counter=0;
		for (int iRow = height - 1; iRow >= 0; iRow--)
			{
			for (int j = (iRow *width); j <(iRow*width) + width; j++)
				{
				byte pixel = (byte)DataLoader.getValAtAddress(databuffer, dataOffSet + (long)j, 8);
				imageColors [counter++] = pal.ColorAtPixel(pixel,Alpha); //new Color32(blue, green, red, alpha);
				}
			}
		image.filterMode=FilterMode.Point;
		image.alphaIsTransparency=Alpha;
		image.SetPixels32(imageColors);
		image.Apply();
		return image;
		}

	public void extractUW2Bitmaps()
		{
		char[] textureFile;          // Pointer to our buffered data (little endian format)
		int i;
		long NoOfTextures;

		if (!DataLoader.ReadStreamFile(path, out textureFile))
			{return;}

		//if (DataLoader.ReadStreamFile(path, out buffer))
		//	{//data read
		//	rawOut.texture= Image(buffer,0,320,200,"name_goes_here",palLoader.Palettes[pal],true);
		//	}

		// Get the size of the file in bytes

		NoOfTextures = DataLoader.getValAtAddress(textureFile,0,8);
		long textureOffset = (int)DataLoader.getValAtAddress(textureFile, (grIndex * 4) + 6, 32);
			if (textureOffset !=0)
				{
				int compressionFlag=(int)DataLoader.getValAtAddress(textureFile,((grIndex * 4) + 6)+(NoOfTextures*4),32);
				int isCompressed =(compressionFlag>>1) & 0x01;
				if (isCompressed==1)	
					{
					int datalen=0;
					rawOut.texture = Image(MapLoader.unpackUW2(textureFile,textureOffset,ref datalen),0,320,200,"namehere",palLoader.Palettes[pal],true);
					}
				else
					{
					rawOut.texture= Image(textureFile,textureOffset,320,200,"name_goes_here",palLoader.Palettes[pal],true);	
					}
				}

		}



}
