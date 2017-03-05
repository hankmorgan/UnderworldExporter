using UnityEngine;
using System.Collections;

public class TNovaLoader : MonoBehaviour {

  public string path = "c:\\games\\terra nova\\tnova\\data\\RESPLNT0.RES";
  long[,] height = new long[513,513];
  int[,] texture = new int[513,513];
  public int[] textureCount=new int[64];

  GameObject MapParent;
  public Material mat;
  public Material[] MatsToUse=new Material[64];
  public int chunkToLoad=48;

  void Start()
  {
    for (int i =0; i<=MatsToUse.GetUpperBound(0);i++)
    {
      MatsToUse[i]=(Material)Resources.Load("UW1/Maps/Materials/uw1_" + i.ToString("d3"));
    }
  }

  public void HopeThisWorks()
  {
    MapParent = this.gameObject;
    BuildTNovaMap();
  }

  private bool BuildTNovaMap()
  {
    float brushSize=12f;
    char[] archive_ark;
    if (DataLoader.ReadStreamFile(path, out archive_ark))
    {
      long AddressOfBlockStart=0;
      long address_pointer=4;
      long blockAddress =0; 
      long chunkUnpackedLength=0;
      int chunkType=0;//compression type
      long chunkPackedLength=0;
      char[] inf_ark;

      //get the level info data from the archive
      blockAddress =getShockBlockAddress(chunkToLoad,archive_ark, ref chunkPackedLength, ref chunkUnpackedLength, ref chunkType); 
      if (blockAddress == -1) {return false;}
      inf_ark=new char[chunkUnpackedLength];
      LoadShockChunk(blockAddress, chunkType, archive_ark, ref inf_ark, chunkPackedLength,chunkUnpackedLength);  
      if (blockAddress == -1) {return false;}
      char[] lev_ark;
      lev_ark=new char[chunkUnpackedLength]; //or 64*64*16
      LoadShockChunk(blockAddress, chunkType, archive_ark, ref lev_ark,chunkPackedLength,chunkUnpackedLength);
      AddressOfBlockStart=0;
      address_pointer=0;  
      int meshcount=1;
      long maxHeight=0;long minHeight=0;
      for (int x=0; x<=height.GetUpperBound(0);x++)
      {
        for (int y=0; y<=height.GetUpperBound(1);y++)
        {
          meshcount++;
          int byte0=(int)DataLoader.getValAtAddress(lev_ark,address_pointer++,8);//Texture
          int byte1=(int)DataLoader.getValAtAddress(lev_ark,address_pointer++,8);//Rotation and part of height
          int byte2=(int)DataLoader.getValAtAddress(lev_ark,address_pointer++,8);//Object object list index?

          if (byte0 > 191)
            byte0=byte0-64;
          if (byte0 > 127)
            byte0=byte0-128;
          if (byte0 > 63)
            byte0=byte0-64;

          texture[x,y]=byte0;
         
          byte1 =byte1 & 0xF0;         //AND with 11110000b: remove shadow+rotation in lower half of byte
          height[x,y] = (byte2 <<4) | (byte1 >> 4);
          if (byte2 > 0x7F)            //negative height
            {height[x,y] = height[x,y] - 4096;}
          //height[x,y] =height[x,y] + 2048;
          if ((x==0) && (y==0))
          {
            maxHeight=height[x,y];
            minHeight=height[x,y];
          }
          if (height[x,y]>maxHeight)
          {
            maxHeight=height[x,y];
          }
          if (height[x,y]<minHeight)
          {
            minHeight=height[x,y];
          }
        }
      }
      Debug.Log("max=" + maxHeight + " min=" + minHeight);
      for (int sectionX=0; sectionX< 8; sectionX++)
      {
        for (int sectionY=0; sectionY< 8; sectionY++)
        {
        GameObject Tile = new GameObject("TNOVAMAP_"+sectionX+ "_" + sectionY);
        Tile.transform.parent=this.gameObject.transform;
        Tile.transform.position = Vector3.zero;
        Tile.transform.localRotation=Quaternion.Euler(0f,0f,0f);

        MeshFilter mf = Tile.AddComponent<MeshFilter>();
        MeshRenderer mr =Tile.AddComponent<MeshRenderer>();
        //  MeshCollider mc = Tile.AddComponent<MeshCollider>();
        // mc.sharedMesh=null;
        Mesh mesh = new Mesh();
        meshcount=64*64;
        mesh.subMeshCount=64;//meshcount;//Should be no of visible faces

        Vector3[] verts =new Vector3[meshcount*4];
        Vector2[] uvs =new Vector2[meshcount*4];
        int FaceCounter=0;
        for (int x=sectionX*64; x<(sectionX+1)*64;x++)
        {
          for (int y=sectionY*64; y<(sectionY+1)*64;y++)
          {
            textureCount[texture[x,y]]++;//Tracks how many of each texture there is
            float[] heights= new float[4];
            heights[0]=(float) -height[x,y];
            heights[1]=(float) -height[x,y+1];
            heights[2]=(float) -height[x+1,y+1];
            heights[3]=(float) -height[x+1,y];

            //Allocate enough verticea and UVs for the faces

            float cornerX= (float)x*brushSize;
            float cornerY= (float)y*brushSize;
            verts[0+ (4*FaceCounter)]=  new Vector3(cornerX+0.0f, cornerY+0.0f, heights[0]);
            verts[1+ (4*FaceCounter)]=  new Vector3(cornerX+0.0f, cornerY+brushSize, heights[1]);
            verts[2+ (4*FaceCounter)]=  new Vector3(cornerX +brushSize,cornerY+brushSize, heights[2]);
            verts[3+ (4*FaceCounter)]=  new Vector3(cornerX +brushSize,cornerY+0.0f, heights[3]);

            //Allocate UVs
            uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,0.0f);
            uvs[1+ (4*FaceCounter)]=new Vector2(0.0f,1.0f);
            uvs[2+ (4*FaceCounter)]=new Vector2(1.0f,1.0f);
            uvs[3+ (4*FaceCounter)]=new Vector2(1.0f,0.0f);  

            FaceCounter++;

            // RenderNovaTile(MapParent,x,y,heights,"tile_" + x + "_" + y );
          }

        }

        mesh.vertices = verts;
        mesh.uv = uvs;


          //for each texture
          for (int t=0; t<=textureCount.GetUpperBound(0);t++)
          {
            if (textureCount[t]>0)
            {//This texture is in use. -> pass it's uvs/verts to the submesh.
              int [] tris = new int[textureCount[t]*6];
              FaceCounter=0;
              int triCounter=0;
              for (int x=sectionX*64; x<(sectionX+1)*64;x++)
              {
                for (int y=sectionY*64; y<(sectionY+1)*64;y++)
                {
                  if (texture[x,y]==t)
                  {//This mesh uses the texture.
                    tris[0+ (6*triCounter)]=0+(4*FaceCounter);
                    tris[1+ (6*triCounter)]=1+(4*FaceCounter);
                    tris[2+ (6*triCounter)]=2+(4*FaceCounter);
                    tris[3+ (6*triCounter)]=0+(4*FaceCounter);
                    tris[4+ (6*triCounter)]=2+(4*FaceCounter);
                    tris[5+ (6*triCounter)]=3+(4*FaceCounter); 
                    triCounter++;
                  }
                  FaceCounter++;
                }
              }
              //Apply the tris to the submesh
              mesh.SetTriangles(tris,t);
            }
          }

          /*
        int [] tris = new int[meshcount*6];
        FaceCounter=0;
        for (int i=0;i<meshcount;i++)
        {
          tris[0+ (6*FaceCounter)]=0+(4*FaceCounter);
          tris[1+ (6*FaceCounter)]=1+(4*FaceCounter);
          tris[2+ (6*FaceCounter)]=2+(4*FaceCounter);
          tris[3+ (6*FaceCounter)]=0+(4*FaceCounter);
          tris[4+ (6*FaceCounter)]=2+(4*FaceCounter);
          tris[5+ (6*FaceCounter)]=3+(4*FaceCounter);           
          FaceCounter++;
        }
        mesh.SetTriangles(tris,0);
        //mr.material=mat;// MatsToUse;//mats;
        mr.sharedMaterial=mat;
        */
        mr.materials=MatsToUse;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mf.mesh=mesh;
        }
      }


      return true;

    }
    else
    {
      return false;
    }
  }





  void RenderNovaTile(GameObject parent, int x, int y, float[] heights, string TileName)
  {
    return;


    //Now create the mesh
   // GameObject Tile = new GameObject(TileName);
  //  Tile.transform.parent=parent.transform;
  //  Tile.transform.position = new Vector3(x*1.2f,0.0f, y*1.2f);



   // Material[] MatsToUse=new Material[1];
              //Set the verts 

            //  MatsToUse[FaceCounter]=MaterialMasterList[FloorTexture(fSELF, t)];





  //  mc.sharedMesh=mesh;
  }









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

     // Debug.Log (k + " chunkid = "+ chunkId + " of size " +chunkUnpackedLength + " of " +chunkPackedLength + " at " + AddressOfBlockStart);
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
