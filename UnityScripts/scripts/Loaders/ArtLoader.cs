using UnityEngine;
using System.Collections;


/// <summary>
/// Base class for loading artwork
/// </summary>
public class ArtLoader : Loader {

	/// <summary>
	/// If modded data is detected try and load that first.
	/// </summary>
	protected bool LoadMod; 

	public	const int BitMapHeaderSize=28;

	/// <summary>
	/// The complete image file 
	/// </summary>
	protected char[] ImageFileData;

		/// <summary>
		/// The palette no to use with this file.
		/// </summary>
	public int PaletteNo=0;

	/// <summary>
	/// Loads the image file into the buffer
	/// </summary>
	/// <returns><c>true</c>, if image file was loaded, <c>false</c> otherwise.</returns>
	public virtual bool LoadImageFile()
	{					
		if (DataLoader.ReadStreamFile(BasePath + Path, out ImageFileData))
		{//data read
			DataLoaded=true;
		}
		else
		{
			DataLoaded=false;
		}
		return DataLoaded;
	}
				
	/// <summary>
	/// Loads the image at index.
	/// </summary>
	/// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
	/// <param name="index">Index.</param>
	public virtual Texture2D LoadImageAt(int index)
	{
		return new Texture2D(1,1);
	}

	/// <summary>
	/// Loads the image at index.
	/// </summary>
	/// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
	/// <param name="index">Index.</param>
	public virtual Texture2D LoadImageAt(int index, bool Alpha)
	{
		return new Texture2D(1,1);
	}


	/// <summary>
	/// Generates the image from the specified data buffer position
	/// </summary>
	/// <param name="databuffer">Databuffer.</param>
	/// <param name="dataOffSet">Data off set.</param>
	/// <param name="width">Width.</param>
	/// <param name="height">Height.</param>
	/// <param name="imageName">Image name.</param>
	/// <param name="pal">Pal.</param>
	/// <param name="Alpha">If set to <c>true</c> alpha.</param>
	public static Texture2D Image(char[] databuffer,long dataOffSet, int width, int height, string imageName, Palette pal , bool Alpha )
	{
		//int pixelcount=0;
		Texture2D image = new Texture2D(width, height,TextureFormat.ARGB32,false);
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
		//image.alphaIsTransparency=Alpha;
		image.SetPixels32(imageColors);
		image.Apply();
		return image;
	}



		/// <summary>
		/// For decoding RLE encoded critter animations.
		/// </summary>
		/// <param name="FileIn">File in.</param>
		/// <param name="pixels">Pixels.</param>
		/// <param name="bits">Bits.</param>
		/// <param name="datalen">Datalen.</param>
		/// <param name="maxpix">Maxpix.</param>
		/// <param name="addr_ptr">Address ptr.</param>
		/// <param name="auxpal">Auxpal.</param>
		public static void ua_image_decode_rle(char[] FileIn, char[] pixels, int bits, int datalen, int maxpix, int addr_ptr,char[] auxpal)
		{
				//Code lifted from Underworld adventures.
				// bit extraction variables
				int bits_avail = 0;
				int rawbits = 0;
				int bitmask = ((1 << bits) - 1) << (8 - bits);
				int nibble;

				// rle decoding vars
				int pixcount = 0;
				int stage = 0; // we start in stage 0
				int count = 0;
				int record = 0; // we start with record 0=repeat (3=run)
				int repeatcount = 0;

				while (datalen>0 && pixcount<maxpix)
				{
						// get new bits
						if (bits_avail<bits)
						{
								// not enough bits available
								if (bits_avail>0)
								{
										nibble = ((rawbits & bitmask) >> (8 - bits_avail));
										nibble <<= (bits - bits_avail);
								}
								else
										nibble = 0;

								//rawbits = ( int)fgetc(fd);
								rawbits = ( int)DataLoader.getValAtAddress(FileIn,addr_ptr,8);
								addr_ptr++;
								if ((int)rawbits == -1)  //EOF
										return;

								//         fprintf(LOGFILE,"fgetc: %02x\n",rawbits);

								int shiftval = 8 - (bits - bits_avail);

								nibble |= (rawbits >> shiftval);

								rawbits = (rawbits << (8 - shiftval)) & 0xFF;

								bits_avail = shiftval;
						}
						else
						{
								// we still have enough bits
								nibble = (rawbits & bitmask) >> (8 - bits);
								bits_avail -= bits;
								rawbits <<= bits;
						}

						//      fprintf(LOGFILE,"nibble: %02x\n",nibble);

						// now that we have a nibble
						datalen--;

						switch (stage)
						{
						case 0: // we retrieve a new count
								if (nibble == 0)
										stage++;
								else
								{
										count = nibble;
										stage = 6;
								}
								break;
						case 1:
								count = nibble;
								stage++;
								break;

						case 2:
								count = (count << 4) | nibble;
								if (count == 0)
										stage++;
								else
										stage = 6;
								break;

						case 3:
						case 4:
						case 5:
								count = (count << 4) | nibble;
								stage++;
								break;
						}

						if (stage<6) continue;

						switch (record)
						{
						case 0:
								// repeat record stage 1
								//         fprintf(LOGFILE,"repeat: new count: %x\n",count);

								if (count == 1)
								{
										record = 3; // skip this record; a run follows
										break;
								}

								if (count == 2)
								{
										record = 2; // multiple run records
										break;
								}

								record = 1; // read next nibble; it's the color to repeat
								continue;

						case 1:
								// repeat record stage 2

								{
										// repeat 'nibble' color 'count' times
										for ( int n = 0; n<count; n++)
										{
												pixels[pixcount++] = auxpal[nibble];
												if (pixcount >= maxpix)
														break;
										}
								}

								//         fprintf(LOGFILE,"repeat: wrote %x times a '%x'\n",count,nibble);

								if (repeatcount == 0)
								{
										record = 3; // next one is a run record
								}
								else
								{
										repeatcount--;
										record = 0; // continue with repeat records
								}
								break;

						case 2:
								// multiple repeat stage

								// 'count' specifies the number of repeat record to appear
								//         fprintf(LOGFILE,"multiple repeat: %u\n",count);
								repeatcount = count - 1;
								record = 0;
								break;

						case 3:
								// run record stage 1
								// copy 'count' nibbles

								//         fprintf(LOGFILE,"run: count: %x\n",count);

								record = 4; // retrieve next nibble
								continue;

						case 4:
								// run record stage 2

								// now we have a nibble to write
								pixels[pixcount++] = auxpal[nibble];

								if (--count == 0)
								{
										//            fprintf(LOGFILE,"run: finished\n");
										record = 0; // next one is a repeat again
								}
								else
										continue;
								break;
						}

						stage = 0;
						// end of while loop
				}
		}



		// UncompressBitmap(art_ark.data,textureOffset+BitMapHeaderSize, out outputImg,Height*Width);
		// This one is also almost directly from Jim Cameron's code.
		public void UncompressBitmap(char[] chunk_bits, long chunk_ptr, out char[] outbits, int numbits) {
				//int j=0;
				int i;
				int xc;
				// unsigned char *bits_end;
				int outbits_ptr=0;
				//  bits_end = bits + numbits;
				// int bits_end= numbits;
				//  memset(bits,0,numbits);
				outbits=new char[numbits];
				//while (bits < bits_end)
				while(outbits_ptr<numbits)
				{
						//xc = *chunk_bits++;
						xc= chunk_bits[chunk_ptr++];
						//  Debug.Log(j++ + " = " + xc);
						if (xc == 0)
						{
								//xc = *chunk_bits++;
								xc= (int)chunk_bits[chunk_ptr++];
								for (i = 0; ((i < xc) && (outbits_ptr < numbits)); ++i)
								{
										//*bits++ = *chunk_bits;
										outbits[outbits_ptr++] = chunk_bits[chunk_ptr];
								}
								++chunk_ptr;
						}
						else if (xc < 0x81)
						{
								if (xc == 0x80)
								{
										//xc = *chunk_bits++;
										xc= chunk_bits[chunk_ptr++];
										if (xc == 0)
										{
												break;
										}
										if (chunk_bits[chunk_ptr] < 0x80)
										{
												// bits += xc + (*chunk_bits << 8);
												//Skip
												// outbits_ptr += xc + (*chunk_bits << 8);
												outbits_ptr += xc + (chunk_bits[chunk_ptr] << 8);
												xc = 0;
										}
										/*      xc = *chunk_bits++; */
										++chunk_ptr;
								}
								for (i = 0; ((i < xc) && (outbits_ptr < numbits)); ++i)
								{
										//*bits++ = *chunk_bits;
										outbits[outbits_ptr++] = chunk_bits[chunk_ptr++];
								}
						}
						else
						{//Skip
								// bits += (xc & 0x7f);
								outbits_ptr +=  (xc & 0x7f);
						}
				}

		}



}
