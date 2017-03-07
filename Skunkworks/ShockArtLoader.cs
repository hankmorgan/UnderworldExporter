using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShockArtLoader : MonoBehaviour {

  public RawImage output;

  public Texture2D[] ImageCache;

  public string path;
  public string palettePath;
  public int ChunkToLoad;
  public int PaletteChunk;

  const int BitMapHeaderSize=28;
  public int index;

  void Start()
  {
    LoadShockArtChunk(path,ChunkToLoad);
  }


  public void IHateLookingForPalettes()
  {
    PaletteChunk++;
    LoadShockArtChunk(path,ChunkToLoad);
    output.texture= ImageCache[index++];
    if (index>ImageCache.GetUpperBound(0))
    {
      index=0;
    }
  }

  public void HopeThisWorks()
  {
    output.texture= ImageCache[index++];
    if (index>ImageCache.GetUpperBound(0))
    {
      index=0;
    }
  }




  bool LoadShockArtChunk(string filePath, int chunkToLoad)
  {
    index=0;
    Palette pal= new Palette();
    char[] archive_ark; //file data
    char[] palette_ark;
    MapLoader.Chunk art_ark;
    MapLoader.Chunk pal_ark;
    //Read in the archive.
    if (!DataLoader.ReadStreamFile(filePath, out archive_ark))
    {//read in file
      return false;
    }

    if (!MapLoader.LoadChunk(archive_ark, chunkToLoad, out art_ark))
    {//read in chunk
      return false;
    }


    if (!DataLoader.ReadStreamFile(palettePath, out palette_ark))
    {//read in palette file
      return false;
    }
    if (!MapLoader.LoadChunk(palette_ark, PaletteChunk , out pal_ark))
    {//read in palette chunk
      return false;
    }
    int p=0;
    int palAddr=0;
    for (int j = 0; j < 256; j++) {
      pal.red[p] = (byte)pal_ark.data[palAddr + 0];//<<2;
      pal.green[p] = (byte)pal_ark.data[palAddr + 1];// << 2;
      pal.blue[p] = (byte)pal_ark.data[palAddr + 2];// << 2;
     // pal[i].reserved = 0;
      palAddr = palAddr +3;
      p++;
    }



    switch(art_ark.chunkContentType)
    {
      case 0://tnova texture?
       {         
          ImageCache=new Texture2D[64];
          int offset=0;
          //for (int t=0; t<=ImageCache.GetUpperBound(0);t++)
          for (int t=0; t<=1;t++)
          {
            ImageCache[t]=ArtLoader.Image(art_ark.data,offset,64,64,"namehere",pal,true);
            offset+=(64*64);
          }
         

          break;
        }

       // break;
      case 2:
      case 17:
        {
          //Art
          int NoOfTextures = (int)DataLoader.getValAtAddress(art_ark.data, 0, 16);
          ImageCache=new Texture2D[NoOfTextures];
          for (int i = 0; i<NoOfTextures; i++)
          {
            long textureOffset = (int)DataLoader.getValAtAddress(art_ark.data, 2 + (i * 4), 32);
           
            int CompressionType=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+4,16);
            int Width=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+8,16);
            int Height=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+10,16);
            if ((Width>0) && (Height >0))
            {
              
              if(CompressionType==4)
              {//compressed
                char[] outputImg;
              //  UncompressBitmap(art_ark+textureOffset+BitMapHeaderSize, outputImg,Height*Width);
                UncompressBitmap(art_ark.data,textureOffset+BitMapHeaderSize, out outputImg,Height*Width);
                ImageCache[i]=ArtLoader.Image(outputImg,0,Width,Height,"namehere",pal,true);
              }
              else
              {//Uncompressed
                ImageCache[i]= ArtLoader.Image(art_ark.data,textureOffset+BitMapHeaderSize,Width,Height,"namehere",pal,true);
              }
            }
          }

        }


        break;
      case 3: //font
      default:
        return false;
    }


   // if ((data_ark.chunkContentType==7)|| (data_ark.chunkContentType==17))
    //{


   // }

    return false;
  }



  // UncompressBitmap(art_ark.data,textureOffset+BitMapHeaderSize, out outputImg,Height*Width);
  // This one is also almost directly from Jim Cameron's code.
  void UncompressBitmap(char[] chunk_bits, long chunk_ptr, out char[] outbits, int numbits) {
    int j=0;
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
