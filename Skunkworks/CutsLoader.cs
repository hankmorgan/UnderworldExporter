using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CutsLoader : MonoBehaviour {

	public RawImage output;
	public Texture2D[] outputImages;
	public int ImageToView;

	char[] dstImage; //repeating buffer

	struct lpHeader{
		public int NoOfPages;
		public int NoOfRecords;
		public int width;
		public int height;
		public int nFrames;
	};

	struct lp_descriptor {
		public int baseRecord;  /* Number of first record in this large page. */
		public int nRecords;  /* Number of records in lp.
					  bit 15 of "nRecords" == "has continuation from previous lp".
					  bit 14 of "nRecords" == "final record continues on next lp". */
		public int nBytes;    /* Total number of bytes of contents, excluding header. */
	} ;

	public string pathToCutsFile = "c:\\games\\uw1\\cuts\\cs001.n01";

	public void Start()
		{
		char[] cutsDataFile;
		if (DataLoader.ReadStreamFile(pathToCutsFile, out cutsDataFile))
			{
			ReadCutsFile(cutsDataFile);
			}
		}


	public void ReadCutsFile(char[] cutsFile)
		{
		long addptr=0;
		int imagecount=0;
		Palette pal=new Palette();
		//Read in lp header. Size is 128
		/*
		    The file starts with a "large page file header":

      0000   Int32   file ID, always contains "LPF "
      ...
      0006   Int16   number of large pages in the file
      0008   Int32   number of records in the file
      ...
      0010   Int32   content type, always contains "ANIM"
      0014   Int16   width in pixels
      0016   Int16   height in pixels

   The whole header is 128 bytes long. After the header color cycling info
   follows (which also is 128 bytes long), which is not used in uw1. Then
   comes the color palette:*/
		lpHeader lpH ;
		lpH.NoOfPages=(int)DataLoader.getValAtAddress(cutsFile,0x6,16);
		lpH.NoOfRecords=(int)DataLoader.getValAtAddress(cutsFile,0x8,32);
		lpH.width=(int)DataLoader.getValAtAddress(cutsFile,0x14,16);
		lpH.height=(int)DataLoader.getValAtAddress(cutsFile,0x16,16);
		lpH.nFrames=(int)DataLoader.getValAtAddress(cutsFile,0x40,16);
		addptr+=128;//past header.
		addptr+=128;//colour cycling info.

		//Init the buffer
		dstImage= new char[lpH.height*lpH.width+ 4000];

		//Read in the palette
		for (int i = 0; i<256; i++)
			{
			pal.blue[i] = (byte)DataLoader.getValAtAddress(cutsFile,addptr++,8);
			pal.green[i] =(byte)DataLoader.getValAtAddress(cutsFile,addptr++,8);
			pal.red[i] =(byte)DataLoader.getValAtAddress(cutsFile,addptr++,8);
			addptr++;//skip reserved.
			//pal.reserved = fgetc(fd);
			}

		//Read in 256 lp descriptors
		lp_descriptor[] lpd = new lp_descriptor[256];
		for (int i=0; i<lpd.GetUpperBound(0);i++)
			{
			lpd[i].baseRecord=(int)DataLoader.getValAtAddress(cutsFile,addptr,16);
			lpd[i].nRecords=(int)DataLoader.getValAtAddress(cutsFile,addptr+2,16);
			lpd[i].nBytes=(int)DataLoader.getValAtAddress(cutsFile,addptr+4,16);
			addptr=addptr+6;
			}
		char[] pages = new char[cutsFile.GetUpperBound(0)-2816+1];
		for(int i=0;i<=pages.GetUpperBound(0);i++)
			{
			pages[i]=cutsFile[i+2816];
			}
		outputImages = new Texture2D[lpH.nFrames];
		for (int framenumber = 0; framenumber < lpH.nFrames; framenumber++)
			{
			int i = 0;
			for (; i<lpH.NoOfPages; i++)
				if ((lpd[i].baseRecord <= framenumber) && (lpd[i].baseRecord + lpd[i].nRecords > framenumber))
					break;
			addptr= (0x10000*i);
			long curlp = addptr;
			//long page= addptr;
			lp_descriptor curl; 
			curl.baseRecord=(int)DataLoader.getValAtAddress(pages,curlp+0,16);
			curl.nRecords=(int)DataLoader.getValAtAddress(pages,curlp+2,16);
			curl.nBytes=(int)DataLoader.getValAtAddress(pages,curlp+4,16);
			long thepage = curlp+ 6+2;//reinterpret_cast<Uint8*>(curlp)+sizeof(lp_descriptor)+2 ;
			//long thepage = curlp;
			int destframe = framenumber - curl.baseRecord;

			int offset = 0;
			long pagepointer =thepage;
			for (int k = 0; k < destframe; k++)				
				{
				offset+=(int)DataLoader.getValAtAddress(pages,pagepointer+ (k*2),16);
				}
				//offset+= (int)cutsFile[k+pagepointer];//offset += pagepointer[i];
				//offset += (int)DataLoader.getValAtAddress(cutsFile,thepage,16);

			long ppointer = thepage + (curl.nRecords * 2) + offset;

			//Uint16 *ppointer16 = (Uint16*)(ppointer);
			if (cutsFile[ppointer+1] == 1)
				{
				ppointer += (4 + (cutsFile[ppointer+1] + (cutsFile[ppointer+1] & 1)));
				}
			else
				{
				ppointer += 4;
				}
			char[] imgOut ;//= //new char[lpH.height*lpH.width+ 4000];
			myPlayRunSkipDump(ppointer, pages);//Stores in the global memory
			//output.texture= 
			outputImages[imagecount++]= ArtLoader.Image(dstImage,0,lpH.width,lpH.height,"name here", pal,false);

			}
		}








	void myPlayRunSkipDump(long inptr, char[] srcData)
		{//From an implemtation by Underworld Adventures (hacking tools)
		long outPtr=0;
		//dstImage = new char[size];
		while (true)
			{
			int sgn = (srcData[inptr] & 0x80) >> 7;//try and get the sign.
			if (sgn==1)
				{
				sgn=-1;
				}
			else
				{
				sgn=1;
				}
			int cnt = srcData[inptr++]; //(Sint8)*srcP++;
			//cnt=cnt*sgn;
			if (cnt*sgn>0)
				{
				// dump
				while (cnt>0)
					{
					//*dstP++ = *srcP++;
					dstImage[outPtr++] = srcData[inptr++];
					cnt--;
					}
				}
			else if (cnt == 0)
				{
				// run
				//Uint8 wordCnt = *srcP++;
				int wordCnt = srcData[inptr++];
				//Uint8 pixel = *srcP++;
				char pixel = srcData[inptr++];
				while (wordCnt>0)
					{
					//*dstP++ = pixel;
					dstImage[outPtr++]=pixel;
					wordCnt--;
					}
				}
			else
				{
				cnt &= 0x7f; // cnt -= 0x80;
				if (cnt != 0)
					{
					// shortSkip
					//dstP += cnt;
					outPtr+=cnt;
					}
				else
					{
					// longOp
					//Uint16 wordCnt = *((Uint16*)srcP);
					int wordCnt =  (int)DataLoader.getValAtAddress(srcData,inptr,16);//srcData[inptr];
					//srcP += 2;
					inptr+=2;
					int wordcntSign =  ( wordCnt & 0x8000) >> 15;//try and get the sign.
					if (wordcntSign==1)
						{
						wordcntSign=-1;
						}
					else
						{
						wordcntSign=1;
						}
					if (wordCnt * wordcntSign <= 0)
						{
						// notLongSkip
						if (wordCnt == 0)
							{
							break; // end loop
							}

						wordCnt &= 0x7fff; // wordCnt -= 0x8000; // Remove sign bit.
						if (wordCnt >= 0x4000)
							{
							// longRun
							wordCnt -= 0x4000; // Clear "longRun" bit
							//Uint8 pixel = *srcP++;
							char pixel = srcData[inptr++];
							while (wordCnt>0)
								{
								//*dstP++ = pixel;
								dstImage[outPtr++] = pixel;
								wordCnt--;
								}
							//                  dstP += wordCnt;
							}
						else
							{
							// longDump
							while (wordCnt>0)
								{
								//*dstP++ = *srcP++;
								dstImage[outPtr++] = srcData[inptr++];
								wordCnt--;
								}

							//                  dstP += wordCnt;
							//                  srcP += wordCnt;
							}
						}
					else
						{
						// longSkip
						//dstP += wordCnt;
						outPtr+=wordCnt;
						}
					}
				}
			}
		}
	




	public void View()
		{
		output.texture=outputImages[ImageToView++];
		if (ImageToView> outputImages.GetUpperBound(0))
			{
			ImageToView=0;
			}
		}




}
