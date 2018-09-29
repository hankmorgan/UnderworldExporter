using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace UnderworldEditor
{
    public class ArtLoader
    {
        public bool DataLoaded;
        public bool Modified = false;
        public BitmapUW[] ImageCache;
        public const byte BitMapHeaderSize = 28;
        public BitmapUW.ImageTypes ImageType;//The primary image type of this file.

        /// <summary>
        /// The complete image file 
        /// </summary>
        public char[] ImageFileData;

        /// <summary>
        /// The palette no to use with this file.
        /// </summary>
        public short PaletteNo = 0;


        /// <summary>
        /// Loads the image at index.
        /// </summary>
        /// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
        /// <param name="index">Index.</param>
        public virtual BitmapUW LoadImageAt(int index)
        {
            BitmapUW newimg = new BitmapUW();
            newimg.image = new Bitmap(2, 2);
            newimg.ImagePalette = PaletteLoader.Palettes[0];
            ImageCache[index] = newimg;
            ImageCache[index].UncompressedData = new char[4];
            return ImageCache[index];
        }

        /// <summary>
        /// Loads the image at index.
        /// </summary>
        /// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
        /// <param name="index">Index.</param>
        public virtual BitmapUW LoadImageAt(int index, bool Alpha)
        {
            BitmapUW newimg = new BitmapUW();
            newimg.image = new Bitmap(2, 2);
            return newimg;
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
        public static BitmapUW Image(ArtLoader instance, char[] databuffer, long dataOffSet, int index, int width, int height, string imageName, Palette pal, bool Alpha, BitmapUW.ImageTypes imgType)
        {
            return Image(instance, databuffer, dataOffSet, index, width, height, imageName, pal, Alpha, false, imgType);
        }


        /// <summary>
        /// Generates the image from the specified data buffer position and also use the xfer look up table
        /// </summary>
        /// <param name="databuffer">Databuffer.</param>
        /// <param name="dataOffSet">Data off set.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <param name="imageName">Image name.</param>
        /// <param name="pal">Pal.</param>
        /// <param name="Alpha">If set to <c>true</c> alpha.</param>
        public static BitmapUW Image(ArtLoader instance, char[] databuffer, long dataOffSet, int index, int width, int height, string imageName, Palette pal, bool Alpha, bool useXFER, BitmapUW.ImageTypes imgType)
        {
            BitmapUW imgUW = new BitmapUW();
            imgUW.artdata = instance;
            imgUW.FileOffset = dataOffSet;
            imgUW.ImageType = imgType;
            imgUW.ImagePalette = pal;
            imgUW.ImageNo = index;
            if (instance != null)
            {
                instance.ImageType = imgType;
            }
            Bitmap image = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Byte[] imageColors = new Byte[width * height * 4];

            long counter = 0;
            for (int iRow = 0; iRow < height; iRow++)
            {
               for (int j = (iRow * width); j < (iRow * width) + width; j++)
               {
                    byte pixel = (byte)Util.getValAtAddress(databuffer, dataOffSet + (long)j, 8);
                    Color col = pal.ColorAtPixel(pixel, Alpha);
                    //imageColors[counter++] = pal.ColorAtPixel(pixel, Alpha);
                    imageColors[counter++] = col.B;
                    imageColors[counter++] = col.G;
                    imageColors[counter++] = col.R;
                    imageColors[counter++] = col.A;
                    //image.SetPixel(j- (iRow * width), iRow, pal.ColorAtPixel(pixel, Alpha));
                }
            }
            //image.filterMode = FilterMode.Point;
            // image.SetPixels32(imageColors);
            //image.Apply();
            //return image;
            imgUW.image = CopyDataToBitmap(imageColors, width, height);
            return imgUW;
        }

        /// <summary>
        /// function CopyDataToBitmap
        /// Purpose: Given the pixel data return a bitmap of size [352,288],PixelFormat=24RGB 
        /// </summary>
        /// <param name="data">Byte array with pixel data</param>
        public static Bitmap CopyDataToBitmap(byte[] data, int height, int width)
        {
            //Here create the Bitmap to the know height, width and format
            Bitmap bmp = new Bitmap(height, width, PixelFormat.Format32bppRgb);

            //Create a BitmapData and Lock all pixels to be written 
            BitmapData bmpData = bmp.LockBits(
                                 new Rectangle(0, 0, bmp.Width, bmp.Height),
                                 ImageLockMode.WriteOnly, bmp.PixelFormat);

            //Copy the data from the byte array into BitmapData.Scan0
            Marshal.Copy(data, 0, bmpData.Scan0, data.Length);


            //Unlock the pixels
            bmp.UnlockBits(bmpData);


            //Return the bitmap 
            return bmp;
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
        public static void ua_image_decode_rle(char[] FileIn, char[] pixels, int bits, int datalen, int maxpix, int addr_ptr, char[] auxpal)
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

            while (datalen > 0 && pixcount < maxpix)
            {
                // get new bits
                if (bits_avail < bits)
                {
                    // not enough bits available
                    if (bits_avail > 0)
                    {
                        nibble = ((rawbits & bitmask) >> (8 - bits_avail));
                        nibble <<= (bits - bits_avail);
                    }
                    else
                        nibble = 0;

                    //rawbits = ( int)fgetc(fd);
                    rawbits = (int)Util.getValAtAddress(FileIn, addr_ptr, 8);
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

                if (stage < 6) continue;

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
                            for (int n = 0; n < count; n++)
                            {
                                pixels[pixcount++] = auxpal[nibble];// getActualAuxPalVal(auxpal, nibble);
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
                        pixels[pixcount++] = auxpal[nibble];//getActualAuxPalVal(auxpal, nibble);

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

        /*0x0080      fade to red
            0x0100      fade to green
            0x0180      fade to blue
            0x0200      fade to white
            0x0280      fade to black
            */
        static char getActualAuxPalVal(char[] auxpal, int nibble)
        {
            switch ((int)auxpal[nibble])
            {
                case 0xf0: // fade to red
                    return (char)(256 + 0x80 + nibble);
                case 0xf4: // fade to blue
                    return (char)(256 + 0x180 + nibble);
                case 0xf8:// fade to green 
                    return (char)(256 + 0x200 + nibble);
                case 252:  // fade to white 
                    return (char)(256 + 0x280 + nibble);

                //????   fade to black
                default:
                    return auxpal[nibble];
            }
        }


        public static BitmapUW Palette(Palette pal)
        {
            char[] paldata = new char[256*64];
            for (int j=0; j<64;j++)
            {
                for (int i = 0; i < 256; i++)
                {
                    paldata[j*256 + i] = (char)i;
                }
            }
            return Image(null, paldata, 0, 0, 256, 64, "name", pal, true, BitmapUW.ImageTypes.Palette);
        }

        public static BitmapUW Palette(Palette pal,int[] auxPal)
        {

            int width = (auxPal.GetUpperBound(0) + 1) ;
            char[] paldata = new char[width * 64];
            {
                for (int j = 0; j < 64; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                       paldata[j * width + i] = (char)auxPal[i];                      
                    }
                }
                return Image(null, paldata, 0, 0, width, 64, "name", pal, true, BitmapUW.ImageTypes.Palette);
            }
        }


        public static Bitmap Resize(Bitmap imgToResize, int Width, int Height)
        {
            Bitmap b = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, Width, Height);
            }
            return b;
        }


    }//end class
}
