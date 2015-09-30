/*
Underworld Adventures - an Ultima Underworld hacking project
Copyright (c) 2002 Michael Fink

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

$Id: fontdecode.cpp,v 1.4 2002/08/21 12:48:04 vividos Exp $

*/
// font decoding

#include "hacking.h"
#include "gamegraphics.h"

int DecodeUWFont()
	{
	char fname[256];

	/*
	// get 256 colors palette
	char palette[256 * 3];
		{
		FILE *pal = fopen("c:\\games\\uw1\\data\\pals.dat", "rb");
		
		fread(palette, 1, 256 * 3, pal);

		for (int j = 0; j<256 * 3; j++) palette[j] <<= 2;

		for (int k = 0; k<256; k++)
			{
			char h = palette[k * 3 + 0];
			palette[k * 3 + 0] = palette[k * 3 + 2];
			palette[k * 3 + 2] = h;
			}

		fclose(pal);
		}
*/
	palette *pal;
	pal = new palette[256];
	getPalette("c:\\games\\uw1\\data\\pals.dat", pal,0);



	_finddata_t find;
	long hnd = _findfirst("c:\\games\\uw1\\data\\font*.sys", &find);

	if (hnd == -1)
		{
		printf("no files found!\n");
		return 0;
		}

	do
		{
		char basename[64];

		// get basename
		strcpy(basename, find.name);

		char *pos = strrchr(basename, '.');
		if (pos != NULL)
			*pos = 0;


		// construct name
		sprintf(fname, "c:\\games\\uw1\\data\\%s.sys", basename);

		FILE *fd = fopen(fname, "rb");

		if (fd == NULL)
			{
			printf("could not open file\n");
			return 0;
			}

		fseek(fd, 0, SEEK_END);
		unsigned long flen = ftell(fd);
		fseek(fd, 0, SEEK_SET);

		unsigned short dummy, charsize, spacewidth, charheight, rowwidth, maxwidth;
		fread(&dummy, 1, 2, fd);
		fread(&charsize, 1, 2, fd);
		fread(&spacewidth, 1, 2, fd);
		fread(&charheight, 1, 2, fd);
		fread(&rowwidth, 1, 2, fd);
		fread(&maxwidth, 1, 2, fd);

		int entries = (flen - 12) / (charsize + 1);

		printf("file %s.sys: %u characters\n", basename, entries);

		printf(" height: %u, maxwidth: %u, spacewidth: %u\n",
			charheight, maxwidth, spacewidth);

		printf(" rowwidth: %u, charsize: %u bytes\n", rowwidth, charsize);

		if ((flen - 12) % (charsize + 1) != 0)
			printf("odd number of chars!\n");

		// load bitmap patterns

		unsigned int *allcharsizes = new unsigned int[entries];
		unsigned char *allpatterns = new unsigned char[entries*charsize];

		for (int i = 0; i<entries; i++)
			{
			// read bit pattern
			fread(&allpatterns[i*charsize], 1, charsize, fd);

			// read length of character
			unsigned char onecharsize;
			fread(&onecharsize, 1, 1, fd);
			allcharsizes[i] = onecharsize;
			}

		unsigned char *allindices = new unsigned char[entries*charheight*maxwidth];

		// convert bit pattern to byte palette indices
		for (int j = 0; j<entries; j++)
			{
			unsigned char *curbits = &allpatterns[j*charsize];
			unsigned char *curindices = &allindices[j*charheight*maxwidth];
			int raw = *curbits;
			int bits = 8;

			for (unsigned int b = 0; b<charheight; b++)
				{
				for (unsigned int k = 0; k<maxwidth; k++)
					{
					if (bits == 0)
						{
						curbits++;
						bits = 8;
						raw = *curbits;
						}

					if ((raw & 0x80) == 0)
						{
						// background
						if (k >= allcharsizes[j])
							*curindices = 0;//253; // for 'outside' bits, draw in other color
						else
							*curindices = 0;//11;
						}
					else
						{
						*curindices = 1;//0;
						}
					curindices++;
					raw <<= 1;
					bits--;
					}
				bits = 0; // reset bit reservoir every line
				}

			sprintf(fname, "%s", basename);

///			FILE *tga = fopen(fname, "wb");

////			tga_writeheader(tga, maxwidth, charheight, 1, 1);

			// write palette
/////			fwrite(palette, 1, 256 * 3, tga);

			/*   for(int n=0; n<charheight; n++)
			{
			for(int z=0; z<maxwidth; z++)
			{
			int index = charheight*maxwidth + z +
			n*maxwidth;

			fputc(curindices[index],tga);
			}

			}*/
			curindices = &allindices[j*charheight*maxwidth];
//////			for (int n = 0; n< charheight*maxwidth; n++)
///	//			{
////				fputc(curindices[n], tga);
/////				}

/////			fclose(tga);
			writeTGA(curindices, 0, maxwidth, charheight, j, pal, fname, 1);

			}

			{
			// now open and write a tga file
			/*
			sprintf(fname, "%s.tga", basename);

			FILE *tga = fopen(fname, "wb");

			tga_writeheader(tga, entries*maxwidth, charheight, 1, 1);

			// write palette
			fwrite(palette, 1, 256 * 3, tga);

			for (int n = 0; n<charheight; n++)
				{
				for (int m = 0; m<entries; m++)
					{
					for (int z = 0; z<maxwidth; z++)
						{
						int index = m*charheight*maxwidth + z +
							n*maxwidth;

						fputc(allindices[index], tga);
						}
					}
				}

			fclose(tga);
			*/
				}
	
		delete[] allindices;
		delete[] allcharsizes;
		delete[] allpatterns;

		fclose(fd);


		} while (0 == _findnext(hnd, &find));

		_findclose(hnd);

		return 0;
	}
