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

$Id: hacking.h,v 1.7 2003/02/11 13:38:32 vividos Exp $

*/
// common hacking include stuff

#ifndef __uwadv_hacking_h_
#define __uwadv_hacking_h_

# pragma warning( disable : 4786 ) // identifier was truncated to '255' characters in the debug information

#include <stdio.h>
#include <string.h>
#include <time.h>
#include <io.h>

#include <string>
#include <vector>
#include <map>

#define UWPATH "e:\\uw1\\"
//#define UWPATH "e:\\uw2\\"

#undef HAVE_UW2
//#define HAVE_UW2

int DecodeUWFont();

//! game string container class
class ua_gamestrings
	{
	public:
		//! ctor
		ua_gamestrings(){}

		//! loads all game strings from a file
		void load(const char *filename);

		//! returns a game string
		std::string get_string(unsigned int block, unsigned int string_nr);

	protected:
		//! game string container
		std::map<int, std::vector<std::string> > allstrings;
	};


inline void tga_writeheader(FILE *fd, int width, int height, int type = 2, int colmap = 0, bool bottomup = false)
	{
#pragma pack(push,1)

	// tga header struct
	struct tgaheader
		{
		unsigned char idlength;     // length of id field after header
		unsigned char colormaptype; // 1 if a color map is present
		unsigned char tgatype;      // tga type

		// colormap not used
		unsigned short colormaporigin;
		unsigned short colormaplength;
		unsigned char colormapdepth;

		// x and y origin
		unsigned short xorigin, yorigin;
		// width and height
		unsigned short width, height;

		// bits per pixel, either 16, 24 or 32
		unsigned char bitsperpixel;
		unsigned char imagedescriptor;
		} tgaheader =
		{
		0, colmap, type, 0, (colmap == 1 ? 256 : 0), (colmap == 1 ? 24 : 0),
		0, 0, width, height, colmap == 1 ? 8 : 32, bottomup ? 0x00 : 0x20
			};
#pragma pack(pop)

		fwrite(&tgaheader, 1, 18, fd);
	}

#endif
