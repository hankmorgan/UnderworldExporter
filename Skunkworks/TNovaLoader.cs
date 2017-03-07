using UnityEngine;
using System.Collections;

public class TNovaLoader : MonoBehaviour {

  public string path = "c:\\games\\terra nova\\tnova\\data\\RESPLNT0.RES";
  long[,] height = new long[513,513];
  int[,] texture = new int[513,513];
  public int[] textureCount=new int[64];
  public int[] textureUsage=new int[64];
  GameObject MapParent;
  public Material mat;
  //public Material[] MatsToUse=new Material[64];
  public int chunkToLoad=48;

  void Start()
  {
    //for (int i =0; i<=MatsToUse.GetUpperBound(0);i++)
   // {
   //   MatsToUse[i]=(Material)Resources.Load("UW1/Maps/Materials/uw1_" + i.ToString("d3"));
   //}
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
      long address_pointer=0;
      MapLoader.Chunk lev_ark;
      if (!MapLoader.LoadChunk(archive_ark, chunkToLoad, out lev_ark ))
      {
        return false;
      }

      address_pointer=0;  
      int meshcount=1;
      long maxHeight=0;long minHeight=0;
      for (int x=0; x<=height.GetUpperBound(0);x++)
      {
        for (int y=0; y<=height.GetUpperBound(1);y++)
        {
          meshcount++;
          int byte0=(int)DataLoader.getValAtAddress(lev_ark.data,address_pointer++,8);//Texture
          int byte1=(int)DataLoader.getValAtAddress(lev_ark.data,address_pointer++,8);//Rotation and part of height
          int byte2=(int)DataLoader.getValAtAddress(lev_ark.data,address_pointer++,8);//Object object list index?

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


          for (int x=sectionX*64; x<(sectionX+1)*64;x++)
          {//Count my textures
            for (int y=sectionY*64; y<(sectionY+1)*64;y++)
            {
              textureCount[texture[x,y]]++;//Tracks how many of each texture there is
            }
          }

          int textureUsageCounter=0;
          //Clean up my textures
          for (int i=0; i<=textureUsage.GetUpperBound(0);i++)
          {
            if (textureCount[i]!=0)
            {
              textureUsage[i] = textureUsageCounter++;
            }
          }

          Material[] mats = new Material[textureUsageCounter];
          int matcounter=0;
          for (int i=0; i<=textureUsage.GetUpperBound(0);i++)
          {
            if (textureCount[i]!=0)
            {
              mats[matcounter++] =(Material)Resources.Load("Nova/Materials/nova" + i);
            }
          }

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
       // mesh.subMeshCount=64;//meshcount;//Should be no of visible faces
        mesh.subMeshCount=textureUsageCounter;
        Vector3[] verts =new Vector3[meshcount*4];
        Vector2[] uvs =new Vector2[meshcount*4];
        
        int FaceCounter=0;
        for (int x=sectionX*64; x<(sectionX+1)*64;x++)
        {
          for (int y=sectionY*64; y<(sectionY+1)*64;y++)
          {
           // textureCount[texture[x,y]]++;//Tracks how many of each texture there is
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
              mesh.SetTriangles(tris,textureUsage[t]);
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


        mr.materials=mats;//MatsToUse;
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

}
