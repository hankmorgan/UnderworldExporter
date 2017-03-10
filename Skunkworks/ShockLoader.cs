using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// old version! Do not use!
/// </summary>
public class ShockLoader : MonoBehaviour {
  const int fSELF =128;
  const int fCEIL= 64;
  const int fNORTH =32;
  const int fSOUTH =16;
  const int fEAST= 8;
  const int fWEST= 4;
  const int fTOP =2;
  const int fBOTTOM= 1;

  public const int TILE_SOLID= 0;
  public const int TILE_OPEN= 1;
  /*
Note the order of these 4 tiles are actually different in SHOCK. I swap them around in BuildTileMapShock for consistancy
*/

  public const int  TILE_DIAG_SE= 2;
  public const int  TILE_DIAG_SW =3;
  public  const int  TILE_DIAG_NE= 4;
  public const int  TILE_DIAG_NW =5;

  public const int  TILE_SLOPE_N =6;
  public const int  TILE_SLOPE_S =7;
  public const int  TILE_SLOPE_E =8;
  public const int  TILE_SLOPE_W =9;
  public const int  TILE_VALLEY_NW =10;
  public const int  TILE_VALLEY_NE= 11;
  public const int TILE_VALLEY_SE =12;
  public const int  TILE_VALLEY_SW= 13;
  public const int  TILE_RIDGE_SE= 14;
  public const int  TILE_RIDGE_SW= 15;
  public const int  TILE_RIDGE_NW= 16;
  public const int  TILE_RIDGE_NE =17;


  const int SLOPE_BOTH_PARALLEL= 0;
  const int SLOPE_BOTH_OPPOSITE= 1;
  const int SLOPE_FLOOR_ONLY =2;
  const int  SLOPE_CEILING_ONLY= 3;

  public Text Output;


  public TileInfo[,] LevelInfo=new TileInfo[64,64];
  public int[] texture_map = new int[256];
  public int SHOCK_CEILING_HEIGHT;


  public string path = "c:\\games\\systemshock\\res\\data\\archive.dat";
  public int LevelToLoad=1;

  public void TestStringLoader()
  {
    StringController sc= new StringController();
    sc.LoadShockStrings("c:\\games\\systemshock\\res\\data\\CYBSTRNG.RES");

  }


  public void hopethisworks()
  {
    BuildTileMapShock(path,LevelToLoad) ;

    string result="";
    for (int y=63; y>=0;y--)
    {
      for (int x=0; x<64;x++)
      {
        if (LevelInfo[x,y].tileType==0)
        {
          result+= "_";
        }
        else
        {
          result+= LevelInfo[x,y].tileType;
        }
      }
      result +="\n";
    }
    Output.text=result;


  }


  bool BuildTileMapShock(string filePath, int LevelNo)
  {
    LevelInfo=new TileInfo[64,64];

   char[] archive_ark; 
    char[] lev_ark; 
    /*  unsigned char *tmp_ark; 
  unsigned char *sub_ark;*/ 
    char[] tex_ark;
    char[] inf_ark;
    long AddressOfBlockStart=0;
    long address_pointer=4;
    long blockAddress =0;

    //  int chunkId;
    long chunkUnpackedLength=0;
    int chunkType=0;//compression type
    long chunkPackedLength=0;
    //  long chunkContentType;

    //Read in the archive.
    if (!DataLoader.ReadStreamFile(filePath, out archive_ark))
    {
      return false;
    }




    //get the level info data from the archive
    blockAddress =getShockBlockAddress(LevelNo*100+4004,archive_ark, ref chunkPackedLength, ref chunkUnpackedLength, ref chunkType); 
    if (blockAddress == -1) {return false;}
    inf_ark=new char[chunkUnpackedLength];
    LoadShockChunk(blockAddress, chunkType, archive_ark, ref inf_ark, chunkPackedLength,chunkUnpackedLength);  
    //Process level properties (height c-space)
    int HeightUnits = (int) DataLoader.getValAtAddress(inf_ark,16,32);  //Log2 value. The higher the value the lower the level height.
    if (HeightUnits > 3)  //Any higher we lose data, 
    {
      HeightUnits=3;
    }
    int cSpace = (int)DataLoader.getValAtAddress(inf_ark,24,32);  //Per docs should return 1 on cyberspace. Does'nt appear to work.
    SHOCK_CEILING_HEIGHT = ((256 >> HeightUnits) * 8 >>3);  //Shifts the scale of the level.
    //long sizeV = getValAtAddress(inf_ark,0,32);
    //long sizeH = getValAtAddress(inf_ark,4,32);
    //long always6_1 = getValAtAddress(inf_ark,8,32);
    //long always6_2 = getValAtAddress(inf_ark,12,32);  

    //Read the main level data in
    blockAddress =getShockBlockAddress(LevelNo*100+4005,archive_ark, ref chunkPackedLength,ref chunkUnpackedLength,ref chunkType); 
    if (blockAddress == -1) {return false;}
    lev_ark=new char[chunkUnpackedLength]; //or 64*64*16
    LoadShockChunk(blockAddress, chunkType, archive_ark, ref lev_ark,chunkPackedLength,chunkUnpackedLength);
    AddressOfBlockStart=0;
    address_pointer=0;  



    //get the texture data from the archive.is never compressed?
    AddressOfBlockStart = getShockBlockAddress(4007+ LevelNo*100, archive_ark, ref chunkPackedLength, ref chunkUnpackedLength,ref chunkType);
    tex_ark = new char[chunkUnpackedLength]; 
    for (long k=0; k< chunkUnpackedLength; k++)
    {
      texture_map[k] =  (int)DataLoader.getValAtAddress(archive_ark,AddressOfBlockStart + address_pointer,16);
      address_pointer =address_pointer+2;   //tmp_ark[AddressOfBlockStart+k];
    }
    AddressOfBlockStart=0;
    address_pointer=0;  


    //Reactor   Map 0  (chunk 40xx)
    //Levels 1-9  Map L  (chunk 4Lxx)
    //SHODAN c/space  Map 10 (chunk 50xx)
    //Delta grove Map 11 (chunk 51xx)
    //Alpha grove Map 12 (chunk 52xx)
    //Beta grove  Map 13 (chunk 53xx)
    //C/space L1-2    Map 14 (chunk 54xx)
    //C/space other Map 15 (chunk 55xx)
    for (int y=0; y<64;y++)
    {
      for (int x = 0; x < 64; x++)
      {
        //Read in the tile data 
        LevelInfo[x,y]=new TileInfo();
        LevelInfo[x,y].tileX = (short)x;
        LevelInfo[x,y].tileY = (short)y;
        LevelInfo[x,y].tileType = lev_ark[address_pointer];
        switch (LevelInfo[x,y].tileType)
        {//Need to swap some tile types around so that they conform to uw naming standards.
          case 4: {LevelInfo[x,y].tileType = 5; break; }
          case 5: {LevelInfo[x,y].tileType = 4; break; }
          case 7: {LevelInfo[x,y].tileType = 8; break; }
          case 8: {LevelInfo[x,y].tileType = 7; break; }
        }
        LevelInfo[x,y].ActualType = (short)LevelInfo[x,y].tileType;
        LevelInfo[x,y].indexObjectList = 0;
        LevelInfo[x,y].Render = 1;
        LevelInfo[x,y].DimX = 1;
        LevelInfo[x,y].DimY = 1;
        LevelInfo[x,y].Grouped = 0;
        LevelInfo[x,y].BullFrog=0;
        for (int v = 0; v < 6; v++)
        {
          LevelInfo[x,y].VisibleFaces[v] = 1;
        }
        /* word 6 contains
        0-5 Wall texture (index into texture list)
        6-10  Ceiling texture
        11-15 Floor texture
        */
        LevelInfo[x,y].wallTexture = texture_map[(int)DataLoader.getValAtAddress(lev_ark, address_pointer + 6, 16) & 0x3F];
        LevelInfo[x,y].shockCeilingTexture = texture_map[((int)DataLoader.getValAtAddress(lev_ark, address_pointer + 6, 16) >> 6) & 0x1F];
        LevelInfo[x,y].floorTexture = texture_map[((int)DataLoader.getValAtAddress(lev_ark, address_pointer + 6, 16) >> 11) & 0x1F];

        //LevelInfo[x,y].wallTexture = 270;//debug
        //LevelInfo[x,y].shockCeilingTexture = 273;
        LevelInfo[x,y].North = LevelInfo[x,y].wallTexture;
        LevelInfo[x,y].South = LevelInfo[x,y].wallTexture;
        LevelInfo[x,y].East = LevelInfo[x,y].wallTexture;
        LevelInfo[x,y].West = LevelInfo[x,y].wallTexture;

        LevelInfo[x,y].isWater = 0;  //No swimming in shock.
        LevelInfo[x,y].landRegion=0;
        LevelInfo[x,y].lavaRegion = 0;
        LevelInfo[x,y].waterRegion = 0;
        LevelInfo[x,y].floorHeight = ((lev_ark[address_pointer + 1]) & 0x1F);
        LevelInfo[x,y].floorHeight = ((LevelInfo[x,y].floorHeight << 3) >> HeightUnits) * 8 >> 3; //Shift it for varying height scales

        LevelInfo[x,y].ceilingHeight = ((lev_ark[address_pointer + 2]) & 0x1F);
        LevelInfo[x,y].ceilingHeight = ((LevelInfo[x,y].ceilingHeight << 3) >> HeightUnits) * 8 >> 3; //Shift it for varying height scales

        LevelInfo[x,y].shockFloorOrientation = (short)(((lev_ark[address_pointer + 1]) >> 5) & 0x3);
        LevelInfo[x,y].shockCeilOrientation =(short)(((lev_ark[address_pointer + 2]) >> 5) & 0x3);

        //Need to know heights in various directions for alignments.
        //Will set these properly after loading levels.
        LevelInfo[x,y].shockNorthCeilHeight = LevelInfo[x,y].ceilingHeight;
        LevelInfo[x,y].shockSouthCeilHeight = LevelInfo[x,y].ceilingHeight;
        LevelInfo[x,y].shockEastCeilHeight = LevelInfo[x,y].ceilingHeight;
        LevelInfo[x,y].shockWestCeilHeight = LevelInfo[x,y].ceilingHeight;

        LevelInfo[x,y].shockSteep = (lev_ark[address_pointer + 3] & 0x0f);
        LevelInfo[x,y].shockSteep = ((LevelInfo[x,y].shockSteep << 3) >> HeightUnits) * 8 >> 3; //Shift it for varying height scales

        if ((LevelInfo[x,y].shockSteep == 0) && (LevelInfo[x,y].tileType >= 6))//If a sloped tile has no slope then it's a open tile.
        {
          LevelInfo[x,y].tileType = 1;
        }
        if ((LevelInfo[x,y].tileType == 1) && (LevelInfo[x,y].shockSteep > 0))  //similarly an open tile can't have a slope at all
        {
          LevelInfo[x,y].shockSteep = 0;
        }
        LevelInfo[x,y].indexObjectList = (int)DataLoader.getValAtAddress(lev_ark, address_pointer + 4, 16);


        //if(LevelInfo[x,y].indexObjectList!=0)
        //  {
        //  fprintf(LOGFILE,"At %d %d we have: %d\n", x,y,LevelInfo[x,y].indexObjectList);
        //  }

        /*
        xxxxx0xx  Floor & ceiling, same direction
        xxxxx4xx  Floor & ceiling, ceiling opposite dir to tile type
        xxxxx8xx  Floor only
        xxxxxCxx  Ceiling only
        */
        LevelInfo[x,y].shockSlopeFlag =(short)((DataLoader.getValAtAddress(lev_ark, address_pointer + 8, 32) >> 10) & 0x03);
        LevelInfo[x,y].UseAdjacentTextures = ((int)DataLoader.getValAtAddress(lev_ark, address_pointer + 8, 32) >> 8) & 0x01;
        LevelInfo[x,y].shockTextureOffset = (int)DataLoader.getValAtAddress(lev_ark, address_pointer + 8, 32) & 0xF;
        //unknownflags
        //70E000E0
        //  fprintf(LOGFILE,"\nUnknownflags @ %d %d= %d",x,y, getValAtAddress(lev_ark,address_pointer+8,32) & 0x70E000E0);
        LevelInfo[x,y].shockShadeLower = (short)(((int)DataLoader.getValAtAddress(lev_ark, address_pointer + 8, 32) >> 16) & 0x0F);
        LevelInfo[x,y].shockShadeUpper = (short)(((int)DataLoader.getValAtAddress(lev_ark, address_pointer + 8, 32) >> 24) & 0x0F);
       //LevelInfo[x,y].shadeUpperGlobal = 0;
       // LevelInfo[x,y].shadeLowerGlobal = 0;
        LevelInfo[x,y].shockNorthOffset = LevelInfo[x,y].shockTextureOffset;
        LevelInfo[x,y].shockSouthOffset = LevelInfo[x,y].shockTextureOffset;
        LevelInfo[x,y].shockEastOffset = LevelInfo[x,y].shockTextureOffset;
        LevelInfo[x,y].shockWestOffset = LevelInfo[x,y].shockTextureOffset;

        LevelInfo[x,y].SHOCKSTATE[0] = (int)DataLoader.getValAtAddress(lev_ark, address_pointer + 0xC, 8);
        LevelInfo[x,y].SHOCKSTATE[1] = (int)DataLoader.getValAtAddress(lev_ark, address_pointer + 0xD, 8);
        LevelInfo[x,y].SHOCKSTATE[2] = (int)DataLoader.getValAtAddress(lev_ark, address_pointer + 0xE, 8);
        LevelInfo[x,y].SHOCKSTATE[3] = (int)DataLoader.getValAtAddress(lev_ark, address_pointer + 0xF, 8);

        //LevelInfo[x,y].indexObjectList=0;
        //if (y == 0)
        //{
        //  LevelInfo[x,y].tileType = TILE_SLOPE_N;
        //  LevelInfo[x,y].shockSlopeFlag=SLOPE_FLOOR_ONLY;
        //  LevelInfo[x,y].floorHeight=x;
        //  LevelInfo[x,y].shockSteep=11;
        //}
        address_pointer=address_pointer+16;
      }
    }

    for (int y=1; y<63;y++) //skip the outer textures.
    {
      for (int x=1; x<63;x++)
      {
        //if (
        //  (LevelInfo[x,y].tileType  != TILE_OPEN) 
        //  ||  ((LevelInfo[x,y].tileType  != TILE_OPEN) && (LevelInfo[x,y].UseAdjacentTextures == 1))
        //  )
        //  {
        //if (LevelInfo[x,y].UseAdjacentTextures != 1)
        //  {
        if (LevelInfo[x+1,y].UseAdjacentTextures != 1)
        {
          LevelInfo[x,y].East = LevelInfo[x+1,y].wallTexture   ;
          LevelInfo[x,y].shockEastOffset =LevelInfo[x+1,y].shockTextureOffset;
          //LevelInfo[x,y].shockEastCeilHeight =LevelInfo[x+1,y].ceilingHeight - LevelInfo[x+1,y].shockSteep ;

        }
        if (LevelInfo[x-1,y].UseAdjacentTextures != 1)
        {         
          LevelInfo[x,y].West = LevelInfo[x-1,y].wallTexture   ;
          LevelInfo[x,y].shockWestOffset =LevelInfo[x-1,y].shockTextureOffset;
          //LevelInfo[x,y].shockWestCeilHeight =LevelInfo[x-1,y].ceilingHeight - LevelInfo[x-1,y].shockSteep ;

        }
        if (LevelInfo[x,y+1].UseAdjacentTextures != 1)
        {
          LevelInfo[x,y].North = LevelInfo[x,y+1].wallTexture   ;
          LevelInfo[x,y].shockNorthOffset =LevelInfo[x,y+1].shockTextureOffset;
          //LevelInfo[x,y].shockNorthCeilHeight =LevelInfo[x,y+1].ceilingHeight - LevelInfo[x,y+1].shockSteep ;

        }
        if (LevelInfo[x,y-1].UseAdjacentTextures != 1)
        {
          LevelInfo[x,y].South  = LevelInfo[x,y-1].wallTexture   ;
          LevelInfo[x,y].shockSouthOffset =LevelInfo[x,y-1].shockTextureOffset;
          //LevelInfo[x,y].shockSouthCeilHeight =LevelInfo[x,y-1].ceilingHeight - LevelInfo[x,y-1].shockSteep ;

        }
        //Need to calculate the adjustment here with the steepness and the direction of the slope.
        LevelInfo[x,y].shockEastCeilHeight= CalcNeighbourCeilHeight(LevelInfo[x,y],LevelInfo[x+1,y],fEAST);
        LevelInfo[x,y].shockWestCeilHeight= CalcNeighbourCeilHeight(LevelInfo[x,y],LevelInfo[x-1,y],fWEST);
        LevelInfo[x,y].shockNorthCeilHeight= CalcNeighbourCeilHeight(LevelInfo[x,y],LevelInfo[x,y+1],fNORTH);
        LevelInfo[x,y].shockSouthCeilHeight= CalcNeighbourCeilHeight(LevelInfo[x,y],LevelInfo[x,y-1],fSOUTH);
        /*        LevelInfo[x,y].shockEastCeilHeight =LevelInfo[x+1,y].ceilingHeight - LevelInfo[x+1,y].shockSteep ;
        LevelInfo[x,y].shockWestCeilHeight =LevelInfo[x-1,y].ceilingHeight - LevelInfo[x-1,y].shockSteep ;
        LevelInfo[x,y].shockNorthCeilHeight =LevelInfo[x,y+1].ceilingHeight - LevelInfo[x,y+1].shockSteep ;
        LevelInfo[x,y].shockSouthCeilHeight =LevelInfo[x,y-1].ceilingHeight - LevelInfo[x,y-1].shockSteep ;*/  
        //}

        LevelInfo[x,y].UpperEast = LevelInfo[x,y].East;
        LevelInfo[x,y].UpperWest = LevelInfo[x,y].West;
        LevelInfo[x,y].UpperNorth = LevelInfo[x,y].North;
        LevelInfo[x,y].UpperSouth = LevelInfo[x,y].South;
        LevelInfo[x,y].LowerEast = LevelInfo[x,y].East;
        LevelInfo[x,y].LowerWest = LevelInfo[x,y].West;
        LevelInfo[x,y].LowerNorth = LevelInfo[x,y].North;
        LevelInfo[x,y].LowerSouth = LevelInfo[x,y].South;
      }
    }
    return true;
  }



  //*********************



  long getShockBlockAddress(long BlockNo, char[] tmp_ark , ref long chunkPackedLength, ref long chunkUnpackedLength, ref int chunkType)
  {
    //Finds the address of the block based on the directory block no.
    //Justs loops through until it finds a match.
    int blnLevelFound =0;
    long DirectoryAddress=DataLoader.getValAtAddress(tmp_ark,124,32);
    //printf("\nThe directory is at %d\n", DirectoryAddress);

    int NoOfChunks = (int)DataLoader.getValAtAddress(tmp_ark,DirectoryAddress,16);
    //printf("there are %d chunks\n",NoOfChunks);
    long firstChunkAddress = DataLoader.getValAtAddress(tmp_ark,DirectoryAddress+2,32);
    //printf("The first chunk is at %d\n", firstChunkAddress);
    long address_pointer=DirectoryAddress+6;
    long AddressOfBlockStart= firstChunkAddress;
    for (int k=0; k< NoOfChunks; k++)
    {
      int chunkId = (int)DataLoader.getValAtAddress(tmp_ark,address_pointer,16);
      chunkUnpackedLength =DataLoader.getValAtAddress(tmp_ark,address_pointer+2,24);
      chunkType = (int)DataLoader.getValAtAddress(tmp_ark,address_pointer+5,8);  //Compression.
      chunkPackedLength = DataLoader.getValAtAddress(tmp_ark,address_pointer+6,24);
      short chunkContentType =(short)DataLoader.getValAtAddress(tmp_ark,address_pointer+9,8);
      //printf("Index: %d, Chunk %d, Unpack size %d, compression %d, packed size %d, content type %d\t",
      //  k,chunkId, *chunkUnpackedLength, *chunkType,*chunkPackedLength,chunkContentType);
      //printf("Absolute address is %d\n",AddressOfBlockStart);

      //target chunk id is 4005 + level no * 100 for levels
      if (chunkId== BlockNo)    //4005+ LevelNo*100
      {
        blnLevelFound=1;
        address_pointer=0;
        break;
      }


      AddressOfBlockStart=AddressOfBlockStart+ chunkPackedLength;
      if ((AddressOfBlockStart % 4) != 0)
        AddressOfBlockStart = AddressOfBlockStart + 4 - (AddressOfBlockStart % 4); // chunk offsets always fall on 4-byte boundaries


      address_pointer=address_pointer+10;     
    }

    if (blnLevelFound == 0)
    {
      //printf("Level not found"); 
      return -1;
    }
    else
    {
      return AddressOfBlockStart;
    }
  }






  long LoadShockChunk(long AddressOfBlockStart, int chunkType, char[] archive_ark, ref char[] OutputChunk,long chunkPackedLength,long chunkUnpackedLength)
  {
    //Util to return an uncompressed shock block. Will use this for all future lookups and replace old ones


    int chunkId;
    //  long chunkUnpackedLength;
    //int chunkType=Compressed;//compression type
    //long chunkPackedLength;
    //long chunkContentType;
    long filepos;
    //  long AddressOfBlockStart=0;
    long address_pointer=4;
    //int blnLevelFound=0;    



    //Find the address of the block. This will also return the file size.
    //AddressOfBlockStart = getShockBlockAddress(ChunkNo,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);   
    if (AddressOfBlockStart == -1)  {return -1;}

    //if (chunkType ==1)
    switch (chunkType)
    {
      case 0:
        {//Flat uncompressed
          for (long k=0; k< chunkUnpackedLength; k++)
          {
            OutputChunk[k] = archive_ark[AddressOfBlockStart+k];
          }   
          return chunkUnpackedLength;
          break;
        }
      case 1: 
        {//flat Compressed
          //printf("\nCompressed chunk");
          char[] temp_ark = new char[chunkPackedLength]; 
          for (long k=0; k< chunkPackedLength; k++)
          {
            temp_ark[k] = archive_ark[AddressOfBlockStart+k];
          }

          unpack_data(temp_ark,ref OutputChunk,chunkUnpackedLength);
          return chunkUnpackedLength;
          break;
        }

      case 3://Subdir compressed  //Just return the compressed data and unpack the sub chunks individually?
        {
          //uncompressed the sub chunks
          int NoOfEntries=(int)DataLoader.getValAtAddress(archive_ark,AddressOfBlockStart,16);
          int SubDirLength=(NoOfEntries+1) * 4 + 2;
          char[] temp_ark = new char[chunkPackedLength]; 
          char[] tmpchunk = new char[chunkUnpackedLength]; 
          for (long k=0; k< chunkPackedLength; k++)
          {
            temp_ark[k] = archive_ark[AddressOfBlockStart+k+SubDirLength];
          }
          unpack_data(temp_ark, ref tmpchunk,chunkUnpackedLength);
          //Merge my subdir and uncompressed subdir data back together.
          for (long k=0;k<SubDirLength;k++)
          {//Subdir
            OutputChunk[k]=archive_ark[AddressOfBlockStart+k];
          }
          for (long k=SubDirLength;k<chunkUnpackedLength;k++)
          {//Subdir
            OutputChunk[k]=tmpchunk[k-SubDirLength];
          }
          return chunkUnpackedLength;         
          break;
        }
      case 2://Subdir uncompressed
        //{
        //printf("Uncompressed subdir!");
        //}
      default:
        {//Uncompressed. 
          //printf("\nUncompressed chunk");
          //OutputChunk =  new unsigned char[chunkUnpackedLength];
          for (long k=0; k< chunkUnpackedLength; k++)
          {
            OutputChunk[k] = archive_ark[AddressOfBlockStart+k];
          }   
          return chunkUnpackedLength;
          break;
        }
    }
  }




  int CalcNeighbourCeilHeight(TileInfo t1, TileInfo t2,int Direction)
  {//TODO:Test me. I'm terrible.
    // fNORTH 32
    // fSOUTH 16
    // fEAST 8
    // fWEST 4
    if  ((t2.tileType <=1) ||(t2.shockSlopeFlag == SLOPE_FLOOR_ONLY))
    {//Don't need to do anything since it has a flat ceiling.
      return t2.ceilingHeight;
    }
    else
    {
      //return t2.ceilingHeight;
      switch (Direction)
      {
        case fNORTH:
          { 
            switch (t2.tileType)
            {
              case TILE_SLOPE_N:
              case TILE_SLOPE_S:
                if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
                {
                  return t2.ceilingHeight+t2.shockSteep ;
                }
                else
                {
                  return t2.ceilingHeight;
                }
                break;
              default:
                return t2.ceilingHeight;
                break;
            }
          } 
        case fSOUTH:
          {
            switch (t2.tileType)
            {
              case TILE_SLOPE_S:
              case TILE_SLOPE_N:
                if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
                {
                  return t2.ceilingHeight+t2.shockSteep ;
                }
                else
                {
                  return t2.ceilingHeight;
                }
                break;
              default:
                return t2.ceilingHeight;
                break;
            }
            //if (t2.tileType == TILE_SLOPE_S)
            //  {
            //  if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
            //    {
            //    return t2.ceilingHeight+t2.shockSteep ;
            //    }
            //  else
            //    {
            //    return t2.ceilingHeight;
            //    }
            //  }
            break;
          } 
        case fEAST:
          {
            switch (t2.tileType)
            {
              case TILE_SLOPE_E:
              case TILE_SLOPE_W:
                if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
                {
                  return t2.ceilingHeight+t2.shockSteep ;
                }
                else
                {
                  return t2.ceilingHeight;
                }
                break;
              default:
                return t2.ceilingHeight;
                break;
            }
          } 
        case fWEST:
          {
            switch (t2.tileType)
            {
              case TILE_SLOPE_W:
              case TILE_SLOPE_E:
                if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
                {
                  return t2.ceilingHeight+t2.shockSteep ;
                }
                else
                {
                  return t2.ceilingHeight;
                }
                break;
              default:
                return t2.ceilingHeight;
                break;
            }
          }
      }
    }
    return t2.ceilingHeight;
  }






  //****************************************************************************

  /* The following procedure comes straight from Jim Cameron
   http://madeira.physiol.ucl.ac.uk/people/jim
   Specifically, this procedure can be found on his "Unofficial System Shock
   Specifications" page at
   http://madeira.physiol.ucl.ac.uk/people/jim/games/ss-res.txt
*/
  void unpack_data (char[] pack,    ref char[] unpack, long unpacksize)
  {

    //unsigned char *byteptr;
    long byteptr=0;
    //unsigned char *exptr;
    long exptr=0;
    int word = 0;  /* initialise to stop "might be used before set" */
    int nbits;
    /*    int type; */
    int val;

    int ntokens = 0;
    long[] offs_token = new long [16384];
    int[] len_token = new int [16384];
    int[] org_token = new int [16384];

    int i;

    for (i = 0; i < 16384; ++i)
    {
      len_token [i] = 1;
      org_token [i] = -1;
    }
    //memset (unpack, 0, unpacksize); Probably not needed here. Initialises the unpacked array with zeros.


    byteptr =0; //pack;
    exptr   = 0;//unpack;
    nbits = 0;

   // while (exptr - unpack < unpacksize)
    while (exptr<unpacksize)
    {

      while (nbits < 14)
      {
        word = (word << 8) + pack[byteptr++]; //   *byteptr++;
        nbits += 8;
      }

      nbits -= 14;
      val = (word >> nbits) & 0x3FFF;
      if (val == 0x3FFF)
      {
        break;
      }

      if (val == 0x3FFE)
      {
        for (i = 0; i < 16384; ++i)
        {
          len_token [i] = 1;
          org_token [i] = -1;
        }
        ntokens = 0;
        continue;
      }

      if (ntokens < 16384)
      {
        //offs_token [ntokens] = exptr - unpack;
        offs_token [ntokens] = exptr;// - unpack;
        if (val >= 0x100)
        {
          org_token [ntokens] = val - 0x100;
        }
      }
      ++ntokens;

      if (val < 0x100)
      {
       // *exptr++ = val;
        unpack[exptr++]= (char)val;
      }
      else
      {
        val -= 0x100;

        if (len_token [val] == 1)
        {   
          if (org_token [val] != -1)
          {
            len_token [val] += len_token [org_token [val]];
          }
          else
          {
            len_token [val] += 1;
          }
        }
        for (i = 0; i < len_token [val]; ++i)
        {
          if (i + offs_token[val]<unpacksize)
          {
           // *exptr++ = unpack[i + offs_token[val]];
            unpack[exptr++] = unpack[i + offs_token[val]];
          }
          else
          {
            Debug.Log("Oh shit");
          }

        }

      }

    }

  }

  // End of Jim Cameron's procedure



  //****************************************************************************






}
