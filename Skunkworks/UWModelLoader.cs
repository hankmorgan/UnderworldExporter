using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class UWModelLoader : MonoBehaviour {

  public int modelToLoad;
  public string outputname;
  public Vector3[] verts;
  public int[] trisToRender;
  public bool rendernow;
  public bool rendermarkers;
  public bool usePreloadedTris=false;

  //Shrine
  int[] PreLoadedTris={44,31,28,44,58,31,42,28,27,40,27,25,38,25,23,36,23,21,34,21,11,48,57,58,47,61,57,51,63,61,53,65,63,55,8,65,8,55,33,8,33,11,11,33,34,65,53,55,53,63,51,51,51,51,51,61,47,47,57,48,48,58,44,44,28,42,42,27,40,40,25,38,38,23,36,36,21,34,8,5,6,8,72,5,11,12,14,11,14,18,72,8,18,18,8,11,3,72,18,19,3,18,1,3,19,66,1,19,69,2,1,69,1,66,45,30,59,49,59,56,46,56,60,50,60,62,52,62,64,54,64,9,45,29,30,43,24,26,39,22,24,37,20,22,35,10,20,9,10,32,9,7,4,9,4,73,10,15,13,10,17,15,9,73,10,10,73,17,17,73,76,17,76,77,76,0,77,77,0,16,0,67,16,16,67,68,67,70,68,68,70,71,32,10,35,35,20,37,37,22,39,39,24,43,43,29,45,45,59,49,46,49,56,50,46,60,52,50,62,54,52,64,32,54,9,2,70,1,70,67,1,67,0,1,1,0,3,3,0,73,3,73,72,72,73,4,72,4,5,5,4,6,6,4,7,8,6,7,8,7,9,65,8,9,65,9,64,63,65,64,63,64,62,61,63,62,61,62,60,57,61,60,57,60,56,58,57,56,58,56,59,31,58,59,31,59,30,28,31,30,28,30,29,27,28,29,27,29,26,25,27,26,25,26,24,23,25,24,23,24,22,21,23,22,21,22,20,11,21,20,11,20,10,12,11,10,12,10,13,14,12,13,14,13,15,18,14,15,18,15,17,19,18,17,19,17,16,66,19,16,66,16,68,69,66,68,69,68,71,2,69,71,2,71,70,45,44,42,43,42,40,41,40,38,39,38,36,37,36,34,35,34,33,32,33,55,54,55,53,52,53,51,50,51,47,46,47,48,49,48,44,42,43,45,40,41,43,38,39,41,36,37,39,34,35,37,33,32,35,55,54,32,53,52,54,51,50,52,47,46,50,48,49,46,44,45,49,26,29,43};


    //{44,31,28,44,58,31,42,28,27,40,27,25,38,25,23,36,23,21,34,21,11,48,57,58,47,61,57,51,63,61,53,65,63,55,8,65,8,55,33,8,33,11,11,33,34,65,53,55,53,63,51,51,51,51,51,61,47,47,57,48,48,58,44,44,28,42,42,27,40,40,25,38,38,23,36,36,21,34,8,5,6,8,72,5,11,12,14,11,14,18,72,8,18,18,8,11,3,72,18,19,3,18,1,3,19,66,1,19,69,2,1,69,1,66,45,30,59,49,59,56,46,56,60,50,60,62,52,62,64,54,64,9,45,29,30,43,24,29,39,22,24,37,20,22,35,10,20,9,10,32,9,7,4,9,4,73,10,15,13,10,17,15,9,73,10,10,73,17,17,73,76,17,76,77,76,0,77,77,0,16,0,67,16,16,67,68,67,70,68,68,70,71,32,10,35,35,20,37,37,22,39,39,24,43,43,29,45,45,59,49,46,49,56,50,46,60,52,50,62,54,52,64,32,54,9,2,70,1,70,67,1,67,0,1,1,0,3,3,0,73,3,73,72,72,73,4,72,4,5,5,4,6,6,4,7,8,6,7,8,7,9,65,8,9,65,9,64,63,65,64,63,64,62,61,63,62,61,62,60,57,61,60,57,60,56,58,57,56,58,56,59,31,58,59,31,59,30,28,31,30,28,30,29,27,28,29,27,29,26,25,27,26,25,26,24,23,25,24,23,24,22,21,23,22,21,22,20,11,21,20,11,20,10,12,11,10,12,10,13,14,12,13,14,13,15,18,14,15,18,15,17,19,18,17,19,17,16,66,19,16,66,16,68,69,66,68,69,68,71,2,69,71,2,71,70,45,44,42,43,42,40,41,40,38,39,38,36,37,36,34,35,34,33,32,33,55,54,55,53,52,53,51,50,51,47,46,47,48,49,48,44,42,43,45,40,41,43,38,39,41,36,37,39,34,35,37,33,32,35,55,54,32,53,52,54,51,50,52,47,46,50,48,49,46,44,45,49};



    //{1,2,3};

  enum nodecmd
  {
    M3_UW_ENDNODE =       0x0000,
    M3_UW_SORT_PLANE =    0x0006,
    M3_UW_SORT_PLANE_ZY = 0x000C,
    M3_UW_SORT_PLANE_XY = 0x000E,
    M3_UW_SORT_PLANE_XZ = 0x0010,
    M3_UW_COLOR_DEF =     0x0014, //???
    M3_UW_FACE_UNK16 =    0x0016, //???
    M3_UW_FACE_UNK40 =    0x0040,
    M3_UW_FACE_PLANE =    0x0058,
    M3_UW_FACE_PLANE_ZY = 0x005E,
    M3_UW_FACE_PLANE_XY = 0x0060,
    M3_UW_FACE_PLANE_XZ = 0x0062,
    M3_UW_FACE_PLANE_X =  0x0064,
    M3_UW_FACE_PLANE_Z =  0x0066,
    M3_UW_FACE_PLANE_Y =  0x0068,
    M3_UW_ORIGIN =        0x0078,
    M3_UW_VERTEX =        0x007A,
    M3_UW_FACE_VERTICES = 0x007E,
    M3_UW_VERTICES =      0x0082,
    M3_UW_VERTEX_X =      0x0086,
    M3_UW_VERTEX_Z =      0x0088,
    M3_UW_VERTEX_Y =      0x008A,
    M3_UW_VERTEX_CEIL =   0x008C,
    M3_UW_VERTEX_XZ =     0x0090,
    M3_UW_VERTEX_XY =     0x0092,
    M3_UW_VERTEX_YZ =     0x0094,
    M3_UW_FACE_SHORT =    0x00A0,
    M3_UW_TEXTURE_FACE  = 0x00A8,
    M3_UW_TMAP_VERTICES = 0x00B4,
    M3_UW_FACE_SHADE =    0x00BC,
    M3_UW_FACE_TWOSHADES= 0x00BE,
    M3_UW_VERTEX_DARK =   0x00D4,
    M3_UW_FACE_GOURAUD =  0x00D6,
  };


  struct UWModel
  {
    public List<Vector3> verts ;//= new List<Vector3>();
    public List<int> tris; //=;// new List<int>();
    public List<float> u ;
    public List<float> v ;
    public Vector3 origin;
    public string modelname;
    public int NoOfVerts;
  };


  struct ua_model_offset_table
  {
    public long table_offset;
    public long value;          /* 4 bytes at table_offset */
    public long base_offset;
  }; // [] =

  ua_model_offset_table[] modeltable = new ua_model_offset_table[6];

  /*  {
      //{ 0x0004e910, 0x40064ab6, 0x0004e99e },
     // { 0x0004ccd0, 0x40064ab6, 0x0004cd5e }, /* same models, different place */
  //    { 0x0004e370, 0x40064ab6, 0x0004e3fe }, /* ditto (reported Gerd Bitzer) */
     // { 0x0004ec70, 0x40064ab6, 0x0004ecfe }, /* uw_demo models */
    //  { 0x00054cf0, 0x59aa64d4, 0x00054d8a }, /* UW2 */
     // { 0x000550e0, 0x59aa64d4, 0x0005517a }, /* another UW2 build            */
   // };

  string[] ua_model_name =
    {
      "-",//0
      "door frame",//1
      "bridge",//2
      "bench",//3
      "Lotus Turbo Esprit (no, really!)",//4
      "small boulder",//5
      "medium boulder",//6
      "large boulder",//7
      "arrow",//8
      "beam",//9
      "pillar",//10
      "shrine",//11
      "?",//12
      "painting [uw2]",//13
      "?",//14
      "?",//15
      "texture map (8-way lever)",//16
      "texture map (8-way switch)",//17
      "texture map (writing)",//18
      "gravestone",//19
      "texture map (0x016e)",//20
      "-",//21
      "?texture map (0x016f)",//22
      "moongate",//23
      "table",//24
      "chest",//25
      "nightstand",//26
      "barrel",//27
      "chair",//28
      "bed [uw2]",//29
      "blackrock gem [uw2]",//30
      "shelf [uw2]"//31
    };

  public string exepath="c:\\games\\uw1\\uw.exe";
  StreamWriter writer;
	// Use this for initialization
	void Start () {	  
    modeltable[0].table_offset=0x0004e910;modeltable[0].value=0x40064ab6;modeltable[0].base_offset=0x0004e99e;
    modeltable[1].table_offset=0x0004ccd0;modeltable[1].value=0x40064ab6;modeltable[1].base_offset=0x0004cd5e;
    modeltable[2].table_offset=0x0004e370;modeltable[2].value=0x40064ab6;modeltable[2].base_offset=0x0004e3fe;
    modeltable[3].table_offset=0x0004ec70;modeltable[3].value=0x40064ab6;modeltable[3].base_offset=0x0004ecfe;
    modeltable[4].table_offset=0x00054cf0;modeltable[4].value=0x59aa64d4;modeltable[4].base_offset=0x00054d8a;
    modeltable[5].table_offset=0x000550e0;modeltable[5].value=0x59aa64d4;modeltable[5].base_offset=0x0005517a;

    writer=new StreamWriter( Application.dataPath + "//..//model.txt", false); 

    DecodeModel(exepath);

    writer.Close();
	}
	

  void DecodeModel(string filePath)
  {
    char[] modelfile;
    if (!DataLoader.ReadStreamFile(filePath, out modelfile))
    {
      return;
    }
    long baseOffset = 0; // models list base address
    long addressptr = 0;

    // search all offsets for model table begin
   // long max =; //SDL_TABLESIZE(ua_model_offset_table);
    for(int i=0; i<= modeltable.GetUpperBound(0); i++)
    {
      // check value on file position
      //fseek(fd,ua_model_offset_table[i].table_offset,SEEK_SET);
     // Uint32 file_value = fread32(fd);
      long file_value = DataLoader.getValAtAddress(modelfile,modeltable[i].table_offset,32);
      if (file_value == modeltable[i].value)
      {
        // found position
        baseOffset= modeltable[i].base_offset;
       // fseek(fd,ua_model_offset_table[i].table_offset,SEEK_SET);
        addressptr=  modeltable[i].table_offset;
        //ua_trace("found models in %s at 0x%08x\n",filename,base);
        //Debug.Log("Found models at " + baseOffset);
        break;
      }
    }

    if (baseOffset == 0)
    {
      Debug.Log("didn't find models in file\n");
      return; // didn't find list
    }




    // read in offsets
    long[] offsets = new long[32];

    for(int j=0; j<=offsets.GetUpperBound(0); j++)
    {
      offsets[j] = DataLoader.getValAtAddress(modelfile, addressptr,16);//fread16(fd);
      addressptr+=2;
    }    
      
    UWModel[] models=new UWModel[32];

    // parse all models
    for(int n=0; n<=offsets.GetUpperBound(0); n++)
    {
      // seek to model
      //fseek(fd,base + offsets[n],SEEK_SET);
     
      addressptr = baseOffset+ offsets[n];
      // read header
      //Uint32 unk1 = fread32(fd);
      long unk1 = DataLoader.getValAtAddress(modelfile,addressptr,32);
      addressptr+=4;
      // extents
      float ex = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;
      float ey = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;
      float ez = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;

      Vector3 extents = new Vector3((float)ex,(float)ez,(float)ey);
      //ua_vector3d extents(ex,ez,ey);

     // ua_mdl_trace("dumping builtin model %u (%s)\noffset=0x%08x [unk1=0x%04x, extents=(%f,%f,%f) ]\n",
      //  n,ua_model_name[n],base + offsets[n],unk1,ex,ey,ez);

      //ua_model3d_builtin* model = new ua_model3d_builtin;
     
      models[n].tris=new List<int>();
      models[n].verts=new List<Vector3>();
      models[n].modelname= ua_model_name[n];
     // Debug.Log(models[n].modelname);
      for (int i=0; i<=128;i++)
      {
        models[n].verts.Add(Vector3.zero);
      }

      // temporary variables
     // ua_vector3d origin;

      //std::vector<ua_vector3d> vertex_list;

      // parse root node
      //ua_model_parse_node(fd, origin, vertex_list, model->triangles, dump);
      if (n==modelToLoad)
      {
        writer.WriteLine("Loading model " + ua_model_name[n] +  " at " + addressptr);
        ua_model_parse_node(modelfile,addressptr,ref models[n], true);  
      }


   //x   ua_mdl_trace("\n");

      //x /*model->*/origin.z -= extents.z/2.0;
      //x   model->extents = extents;

      // insert model
      //x ua_model3d_ptr model_ptr(model);
      //x allmodels.push_back(model_ptr);
    }
    RenderModel(models[modelToLoad]);

  }

  void Update()
  {
    if (rendernow)
    {
      rendernow=false;
      Mesh mesh = new Mesh();
      GetComponent<MeshFilter>().mesh = mesh;

      mesh.vertices =verts;
      // mesh.uv = newUV;
      if (usePreloadedTris)
      {
        mesh.SetTriangles(PreLoadedTris,0);
        trisToRender = new int[PreLoadedTris.GetUpperBound(0)+1];
        for (int i=0; i<=PreLoadedTris.GetUpperBound(0);i++)
        {
          trisToRender[i]=PreLoadedTris[i];
        }
      }
      else
      {
        mesh.SetTriangles(trisToRender,0);  
      }

      mesh.RecalculateNormals();     
    }
    if (rendermarkers)
    {
      rendermarkers=false;
      for (int i=0; i<=verts.GetUpperBound(0);i++)
      {
        GameObject vertToDisplay = new GameObject();
        TextMesh tm = vertToDisplay.AddComponent<TextMesh>();
        tm.text= i.ToString();
        tm.characterSize=0.01f;
        vertToDisplay.transform.parent=this.transform;
        vertToDisplay.transform.localPosition= verts[i];
        vertToDisplay.name = "Vert_" + i.ToString();
      }
    }
  }


  void RenderModel(UWModel mod)
  {
    outputname=mod.modelname;
    verts = new Vector3[mod.NoOfVerts+1];
    for (int i=0; i<=verts.GetUpperBound(0);i++)
    {
      verts[i]=mod.verts[i];
    }

    trisToRender= new int[mod.tris.Count];
    for (int i=0; i<= trisToRender.GetUpperBound(0);i++)
    {
      if(mod.tris.Count>i)
      {
        trisToRender[i]=mod.tris[i];  
      }
    }
  }


  float ua_mdl_read_fixed(char[] fileData, long addressPtr)
  {
    short val = (short)DataLoader.getValAtAddress(fileData,addressPtr,16) ;//static_cast<Sint16>(fread16(fd));
   /* int sign = (val>>15) & 0x1;
    if (sign==1)
    {
      val = val & 0x7FFF;
      val = val * -1;
    }    */ 

    return ((float)(val)) / (256f); //256.0f;
  }

  int ua_mdl_read_vertno(char[] fileData, long addressPtr)
  {
    int val = (int)DataLoader.getValAtAddress(fileData,addressPtr,16); //fread16(fd);
    return val / 8;
  }

  void ua_mdl_store_vertex(Vector3 vertex, int vertno,ref UWModel mod)
  {
    if (vertno>=mod.verts.Capacity)
    {
      mod.verts.Capacity=vertno+1;
    }
    mod.verts[vertno]=vertex;
    if (mod.NoOfVerts< vertno)
    {
      mod.NoOfVerts=vertno;
    }
    writer.WriteLine("\tStoring Vertex " + vertno + " at " + vertex);
  }



  //Ported from underworld adventures
  void ua_model_parse_node(char[] modelfile, long addressptr, ref UWModel mod,   bool dump)
  {
    // parse node until end node
    bool loop = true;
    int instr=-1;
    while(loop)
    {
      // read next command
      int cmd = (int)(DataLoader.getValAtAddress(modelfile,addressptr,16));addressptr+=2;
      instr++;
      switch((nodecmd)cmd)
      {
        // misc. nodes
        case nodecmd.M3_UW_ENDNODE: // 0000 end node
          {
            // ua_mdl_trace("[end]");
            writer.WriteLine("instr " + instr + "end");
            loop = false;
            break;
          }
        case nodecmd.M3_UW_ORIGIN: // 0078 define model center
          {
            writer.WriteLine ("\nInstr " + instr + " origin");
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;//ua_mdl_read_vertno(fd);
            mod.origin = mod.verts[vertno];// mod.verts[vertno] ;

            float vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

            writer.WriteLine("\tOrigin at " + mod.origin);

            int unk1 =  (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2; //fread16(fd);
            // ua_mdl_trace("[origin] vertno=%u unk1=%04x origin=(%f,%f,%f)",
            //  vertno,unk1,vx,vy,vz);
            break;
          }


          // vertex definition nodes
        case nodecmd.M3_UW_VERTEX: // 007a define initial vertex
          {
            writer.WriteLine ("\nInstr " + instr + " M3_UW_VERTEX");
            float vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;//ua_mdl_read_vertno(fd);

            Vector3 refvect = new Vector3((float)vx,(float)vy,(float)vz);
            ua_mdl_store_vertex(refvect,vertno,ref mod);
            //Debug.Log("\nInstr " + instr + "Vertex #" + vertno + "="  + refvect);
            // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f)",
            // vertno,vx,vy,vz);
            break;
          }


        case nodecmd.M3_UW_VERTICES: // 0082 define initial vertices
          {
            writer.WriteLine ("\nInstr " + instr + " M3_UW_VERTICES");
            int nvert =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);
            int vertno =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);
            for(int n=0; n<nvert; n++)
            {
              float vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
              float vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
              float vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

              Vector3 refvect = new Vector3((float)vx,(float)vy,(float)vz);
              ua_mdl_store_vertex(refvect,vertno+n,ref mod);
              //Debug.Log("\nInstr " + instr + "Vertex #" + vertno + "="  + refvect);
              //ua_mdl_trace("%s[vertex] vertno=%u vertex=(%f,%f,%f)",
               // n==0 ? "" : "\n      ",vertno+n,vx,vy,vz);
            }
          }
          break;

        case nodecmd.M3_UW_VERTEX_X: // 0086 define vertex offset X
          {
            writer.WriteLine ("\nInstr " + instr + " offsetX");
            int refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            float vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

            Vector3 refvect =mod.verts[refvert];
            //  refvect.x += vx;
            //refvect  = new Vector3(refvect.x+(float)vx,refvect.y,refvect.z);
            Vector3 adj = new Vector3(vx,0f,0f);
            ua_mdl_store_vertex(refvect+adj,vertno,ref mod);
           //// Debug.Log("Vertex offsetX #" +(vertno) + "="  + (refvect+adj) + " from " + refvect + "(" + refvert + ")" + " adj = " +adj);
            //ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) x from=%u",
            //  vertno,refvect.x,refvect.y,refvect.z,refvert);
            break;
          }

        case nodecmd.M3_UW_VERTEX_Z: // 0088 define vertex offset Z
          {
            writer.WriteLine ("\nInstr " + instr + " offsetZ");
            int refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            float vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

            Vector3 refvect = mod.verts[refvert];
            Vector3 adj = new Vector3(0f,0f,vz);
            ua_mdl_store_vertex(refvect+adj,vertno,ref mod);
           // Debug.Log("Vertex offsetZ #" +(vertno) + "="  + (refvect+adj) + " from " + refvect + "(" + refvert + ")" + " adj = " +adj);
            //ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) z from=%u",
            //  vertno,refvect.x,refvect.y,refvect.z,refvert);
            break;
          }


        case nodecmd.M3_UW_VERTEX_Y: // 008a define vertex offset Y
          {
            writer.WriteLine ("\nInstr " + instr + " offsetY");
            int refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            float vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

            Vector3 refvect = mod.verts[refvert];
            //refvect.y += vy;
            //refvect  = new Vector3(refvect.x,refvect.y+(float)vy,refvect.z);
            Vector3 adj = new Vector3(0f,vy,0f);
            ua_mdl_store_vertex(refvect+adj,vertno,ref mod);
           // Debug.Log("Vertex offsetY #" +(vertno) + "="  + (refvect+adj) + " from " + refvect + "(" + refvert + ")" + " adj = " +adj);
            // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) y from=%u",
            //   vertno,refvect.x,refvect.y,refvect.z,refvert);
            break;
          }


        case nodecmd.M3_UW_VERTEX_XZ: // 0090 define vertex offset X,Z
          {
            writer.WriteLine ("\nInstr " + instr + " offsetXZ");
            float vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            int refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

            Vector3 refvect = mod.verts[refvert];
            //refvect.x += vx;
            //refvect.z += vz;
           // refvect  = new Vector3(refvect.x+(float)vx,refvect.y,refvect.z+(float)vz);
            Vector3 adj = new Vector3(vx,0f,vz);
            ua_mdl_store_vertex(refvect+adj,vertno,ref mod);
           // Debug.Log("Vertex offsetXZ #" +(vertno) + "="  + (refvect+adj) + " from " + refvect + "(" + refvert + ")" + " adj = " +adj);
            // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) xz from=%u",
            //    vertno,refvect.x,refvect.y,refvect.z,refvert);
            break;
          }


        case nodecmd.M3_UW_VERTEX_XY: // 0092 define vertex offset X,Y
          {
            writer.WriteLine ("\nInstr " + instr + " offsetXY");
            float vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            int refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

            Vector3 refvect = mod.verts[refvert];
            // refvect.x += vx;
            //  refvect.y += vy;
            //refvect  = new Vector3(refvect.x+(float)vx,refvect.y+(float)vy,refvect.z);
           // ua_mdl_store_vertex(refvect,vertno,ref mod);
            Vector3 adj = new Vector3(vx,vy,0f);
            ua_mdl_store_vertex(refvect+adj,vertno,ref mod);
           // Debug.Log("Vertex offsetXY #" +(vertno) + "="  + (refvect+adj) + " from " + refvect + "(" + refvert + ")" + " adj = " +adj);
            // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) xy from=%u",
            //   vertno,refvect.x,refvect.y,refvect.z,refvert);
            break;
          }


        case nodecmd.M3_UW_VERTEX_YZ: // 0094 define vertex offset Y,Z
          {
            writer.WriteLine ("\nInstr " + instr + " offsetYZ");
            float vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            int refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

            Vector3 refvect = mod.verts[refvert];
            //refvect.y += vy;
            // refvect.z += vz;
            //refvect  = new Vector3(refvect.x,refvect.y+(float)vy,refvect.z+(float)vz);
           // ua_mdl_store_vertex(refvect,vertno,ref mod);
            Vector3 adj = new Vector3(0f,vy,vz);
            ua_mdl_store_vertex(refvect+adj,vertno,ref mod);
           // Debug.Log("Vertex offsetYZ #" +(vertno) + "="  + (refvect+adj) + " from " + refvect + "(" + refvert + ")" + " adj = " +adj);

            // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) yz from=%u",
            //    vertno,refvect.x,refvect.y,refvect.z,refvert);
            break;
          }


        case nodecmd.M3_UW_VERTEX_CEIL: // 008c define vertex variable height
          {
            writer.WriteLine ("\nInstr " + instr + " UW_VERTEX_CEIL");
            int refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            int unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

            Vector3 refvect = mod.verts[refvert];
           // refvect.z = 32.0f; // todo: ceiling value
            //refvect  = new Vector3(refvect.x,refvect.y,32f);
            Vector3 adj = new Vector3(0f,0f,32f);
            ua_mdl_store_vertex(refvect+adj,vertno,ref mod);
          //  writer.WriteLine("\tVertex Ceil #" +(vertno) + "="  + (refvect+adj) + " from " + refvect + "(" + refvert + ")" + " adj = " +adj);
            //  ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,ceil) ceil from=%u unk1=%04x",
            //   vertno,refvect.x,refvect.y,refvert,unk1);
            break;
          }

          // face plane checks
        case nodecmd.M3_UW_FACE_PLANE: // 0058 define face plane, arbitrary heading
          {
            writer.WriteLine ("\nInstr " + instr + " UW_FACE_PLANE");
            int unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            float nx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float  vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float ny = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float nz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            writer.Write("\t Normal (" + nx+","+ny+","+nz +") dist (" + vx+","+vy+","+vz+")\n");
            //  ua_mdl_trace("[planecheck] skip=%04x normal=(%f,%f,%f) dist=(%f,%f,%f)",
            //    unk1,nx,ny,nz,vx,vy,vz);
            break;
          }


        case nodecmd.M3_UW_FACE_PLANE_X: // 0064 define face plane X
        case nodecmd.M3_UW_FACE_PLANE_Z: // 0066 define face plane Z
        case nodecmd.M3_UW_FACE_PLANE_Y: // 0068 define face plane Y
          {
            writer.WriteLine ("\nInstr " + instr + " UW_FACE_PLANE (x/z/y)");
            int unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            float nx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float  vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            writer.Write("\t Normal (" + nx+ ") dist (" + vx + ")\n");

            // ua_mdl_trace("[planecheck] skip=%04x normal=(%f,%f,%f) dist=(%f,%f,%f) %c",
            // unk1,
            //cmd == nodecmd.M3_UW_FACE_PLANE_X ? nx : 0.0,
            // cmd == nodecmd.M3_UW_FACE_PLANE_Y ? nx : 0.0,
            //cmd == nodecmd.M3_UW_FACE_PLANE_Z ? nx : 0.0,
            //cmd == nodecmd.M3_UW_FACE_PLANE_X ? vx : 0.0,
            //cmd == nodecmd.M3_UW_FACE_PLANE_Y ? vx : 0.0,
            //cmd == nodecmd.M3_UW_FACE_PLANE_Z ? vx : 0.0,

            // cmd == M3_UW_FACE_PLANE_X ? 'x' : cmd == M3_UW_FACE_PLANE_Y ? 'y' : 'z'
            //);
            break; 
          }
   

        case nodecmd.M3_UW_FACE_PLANE_ZY: // 005e define face plane Z/Y
        case nodecmd.M3_UW_FACE_PLANE_XY: // 0060 define face plane X/Y
        case nodecmd.M3_UW_FACE_PLANE_XZ: // 0062 define face plane X/Z
          {
            writer.WriteLine ("\nInstr " + instr + " UW_FACE_PLANE (zy/xy/xz)");
            int unk1 =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);
            float nx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;// ua_mdl_read_fixed(fd);
            float ny = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            writer.Write("\t Normal (" + nx+","+ny+") dist (" + vx+","+vy+")\n");
            //ua_mdl_trace("[planecheck] skip=%04x ",unk1);
            /*if (dump)
            switch(cmd)
          {
            case nodecmd.M3_UW_FACE_PLANE_ZY:
             // ua_mdl_trace("normal=(%f,%f,%f) dist=(%f,%f,%f) zy",0.0,ny,nx,0.0,vy,vx);
              break;
            case nodecmd.M3_UW_FACE_PLANE_XY:
             // ua_mdl_trace("normal=(%f,%f,%f) dist=(%f,%f,%f) xy",nx,ny,0.0,vx,vy,0.0);
              break;
            case nodecmd.M3_UW_FACE_PLANE_XZ:
            //  ua_mdl_trace("normal=(%f,%f,%f) dist=(%f,%f,%f) xz",nx,0.0,ny,vx,0.0,vy);
              break;
          }*/
            break;
          }


          // face info nodes
        case nodecmd.M3_UW_FACE_VERTICES: // 007e define face vertices
          {
            writer.WriteLine ("\nInstr " + instr + " UW_FACE_VERTICES");
            int nvert = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            //Xua_poly_tessellator tess;
            string output="\tFace Verts are :";
           // ua_mdl_trace("[face] nvert=%u vertlist=",nvert);
            int[] faceverts = new int[nvert];
            for(int i=0; i<nvert; i++)
            {
             // Uint16 
              int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

             // mod.tris.Add(vertno);//moved
              faceverts[i] = vertno;
              //Xua_vertex3d vert;
              output = output + vertno + ",";
             //
             //X vert.pos = mod.verts[vertno];
             //X tess.add_poly_vertex(vert);

             //ua_mdl_trace("%u",vertno);
              //if (i<=nvert-1) ua_mdl_trace(" ");
            }

          //X  const std::vector<ua_triangle3d_textured>& tri = tess.tessellate(0x0001);
            //triangles.insert(triangles.begin(),tri.begin(),tri.end());
            //mod.tris.Add(vertno);
            writer.WriteLine(output);
            convertVertToTris(faceverts,ref mod);
           
          }
          break;

        case nodecmd.M3_UW_TEXTURE_FACE: // 00a8 define texture-mapped face
        case nodecmd.M3_UW_TMAP_VERTICES: // 00b4 define face vertices with u,v information
          {
            writer.WriteLine ("\nInstr " + instr + " UW_TEXTURE_FACE or UW_TMAP_VERTICES");
           // ua_mdl_trace("[face] %s ",cmd==M3_UW_TEXTURE_FACE ? "tex" : "tmap");
            string output="\tFace Verts are :";
            // read texture number
            if ((nodecmd)cmd== nodecmd.M3_UW_TEXTURE_FACE)
            {
              int unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd); // texture number?
              //ua_mdl_trace("texnum=%04x ",unk1);
            }

            int nvert = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
           //X ua_poly_tessellator tess;

            //ua_mdl_trace("nvert=%u vertlist=",nvert);
            int[] faceverts = new int[nvert];
            for(int i=0; i<nvert; i++)
            {
             // Uint16 
              int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
              output = output + vertno + ",";
              float u0 = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
              float v0 = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

             // mod.tris.Add(vertno);//moved
              faceverts[i] = vertno;
              //X ua_vertex3d vert;
              //X vert.pos = mod.verts[vertno];
              //X vert.u = u0;
              //X vert.v = v0;
              //X tess.add_poly_vertex(vert);

              //ua_mdl_trace("%u (%f/%f)",vertno,u0,v0);
             // if (i<=nvert-1) ua_mdl_trace(" ");
            }
            writer.WriteLine(output);
            convertVertToTris(faceverts,ref mod);
            //X const std::vector<ua_triangle3d_textured>& tri = tess.tessellate(0x0002);
            //X triangles.insert(triangles.begin(),tri.begin(),tri.end());
          }
          break;

          // sort nodes
        case nodecmd.M3_UW_SORT_PLANE: // 0006 define sort node, arbitrary heading
         
          // fall-through

        case nodecmd.M3_UW_SORT_PLANE_ZY: // 000C define sort node, ZY plane
        case nodecmd.M3_UW_SORT_PLANE_XY: // 000E define sort node, XY plane
        case nodecmd.M3_UW_SORT_PLANE_XZ: // 0010 define sort node, XZ plane
          {
            writer.WriteLine ("\nInstr " + instr + " SORT PLANES");
            if((nodecmd)(cmd)==nodecmd.M3_UW_SORT_PLANE)
            {
              float nx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
              float vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            }

            float ny = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float nz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            float  vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

            long left = DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            left += addressptr;// ftell(fd);

            long right = DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            right += addressptr;// ftell(fd);

            long here = addressptr;//ftell(fd);

            // parse left nodes
            //fseek(fd,left,SEEK_SET);
            addressptr=here;
            ua_model_parse_node(modelfile, addressptr,ref mod,dump);
            //ua_model_parse_node(fd,origin,vertex_list,triangles,dump);

           // ua_mdl_trace("      [sort] end left node/start right node\n");

            // parse right nodes
          //  fseek(fd,right,SEEK_SET);
            addressptr=right;
            ua_model_parse_node(modelfile, addressptr,ref mod,dump);
            //ua_model_parse_node(fd,origin,vertex_list,triangles,dump);

            // return to "here"
          //  fseek(fd,here,SEEK_SET);
            addressptr=here;

           // ua_mdl_trace("      [sort] end");
          }
          break;

          // unknown nodes
        case nodecmd.M3_UW_COLOR_DEF: // 0014 ??? colour definition
          {
            writer.WriteLine ("\nInstr " + instr + " UW_COLOR_DEF");
            int refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            int unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            // ua_mdl_trace("[shade] color refvert=%u unk1=%04x vertno=%u",refvert,unk1,vertno);
            break;
          }


        case nodecmd.M3_UW_FACE_SHADE: // 00BC define face shade
          {
            writer.WriteLine ("\nInstr " + instr + " UW_FACE_SHADE");
            int unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            int vertno = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            //ua_mdl_trace("[shade] shade unk1=%02x unk2=%02x",unk1,vertno);
            break; 
          }


        case nodecmd.M3_UW_FACE_TWOSHADES: // 00BE ??? seems to define 2 shades
          {
            writer.WriteLine ("\nInstr " + instr + " UW_FACE_TWOSHADES");
            int vertno =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            int unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            //ua_mdl_trace("[shade] twoshade unk1=%02x unk2=%02x ",vertno,unk1);
            break;
          }


        case nodecmd.M3_UW_VERTEX_DARK: // 00D4 define dark vertex face (?)
          {
            writer.WriteLine ("\nInstr " + instr + " UW_VERTEX_DARK");
            int nvert =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);
            int unk1 =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);

            //ua_mdl_trace("[shade] color nvert=%u, unk1=%04x vertlist=",
            //  nvert,unk1);

           for(int n=0; n<nvert; n++)
            {
              int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
             // unk1 = fgetc(fd);
              addressptr++;

             // ua_mdl_trace("%u (%02x) ",vertno,unk1);
            }


            if ((nvert & 1) == 1)
            {
             // fgetc(fd); // read alignment padding
              addressptr++;
            }
          }
          break;

        case nodecmd.M3_UW_FACE_GOURAUD: // 00D6 define gouraud shading
         // ua_mdl_trace("[shade] gouraud");
          writer.WriteLine ("\nInstr " + instr + " UW_FACE_GOURAUD");
          break;

        case nodecmd.M3_UW_FACE_UNK40: // 0040 ???
          writer.WriteLine ("\nInstr " + instr + " UW_FACE_UNK40");
         // ua_mdl_trace("[shade] unknown");
          break;

        case nodecmd.M3_UW_FACE_SHORT: // 00A0 ??? shorthand face definition
          {
            writer.WriteLine ("\nInstr " + instr + " UW_FACE_SHORT");
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
           //X ua_poly_tessellator tess;
            string output = "\t";
            //ua_mdl_trace("[face] shorthand unk1=%u vertlist=",vertno);
            int[] faceverts = new int[4];
            for(int i=0; i<4; i++)
            {
              vertno = (int)DataLoader.getValAtAddress(modelfile,addressptr,8);addressptr++; //fgetc(fd);
              output = output + vertno +  ",";
              faceverts[i] = vertno;
            }
            writer.WriteLine(output);
            convertVertToTris(faceverts,ref mod);
            //X const std::vector<ua_triangle3d_textured>& tri = tess.tessellate(0x0003);
            //triangles.insert(triangles.begin(),tri.begin(),tri.end());
          }
          break;

        case (nodecmd)0x00d2: // 00D2 ??? shorthand face definition
          {
            writer.WriteLine ("\nInstr " + instr + " UW_SHORTHAND_FACE_DEFINITION");
            int vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            //X            ua_poly_tessellator tess;
            string output = "\t";
            //ua_mdl_trace("[face] vertno=%u vertlist=",vertno);
            int[] faceverts = new int[4];
            for(int i=0; i<4; i++)
            {
              vertno = (int)DataLoader.getValAtAddress(modelfile,addressptr,8);addressptr++; //fgetc(fd);
              output = output + vertno + ",";
              faceverts[i] = vertno;
            }
            writer.WriteLine(output);
            convertVertToTris(faceverts,ref mod);
            //X const std::vector<ua_triangle3d_textured>& tri = tess.tessellate(0x0004);
           // triangles.insert(triangles.begin(),tri.begin(),tri.end());

            //ua_mdl_trace("shorthand");
          }
          break;

        case nodecmd.M3_UW_FACE_UNK16: // 0016 ???
          {
            writer.WriteLine ("\nInstr " + instr + " UW_FACE_UNK16");
            long pos = addressptr;//(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr++;//ftell(fd);

            int nvert =  ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;//ua_mdl_read_vertno(fd);
            int unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);

            for(int n=0; n<nvert; n++)
            {
             // unk1 = fgetc(fd);
              addressptr++;
            }

            if ((nvert & 1) ==1)
            {
              addressptr++;
            }
              //fgetc(fd); // read alignment padding
          }
          break;

        case (nodecmd)0x0012:
          {
            writer.WriteLine ("\nInstr " + instr + " UNK 12");
            int unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            break;

          }

        default:
          //ua_mdl_trace("unknown command at offset 0x%08x\n",ftell(fd)-2);
          writer.WriteLine ("\nInstr " + instr + " UNKNOWN CMD returning");         
          return;
      }
     // ua_mdl_trace("\n");
    }
  }


 /* void convertVertToTris(int[] vertices,ref UWModel mod)
  {
     switch (vertices.GetUpperBound(0))
    {   
      case 2:
        mod.tris.Add(vertices[2]);
        mod.tris.Add(vertices[1]);
        mod.tris.Add(vertices[0]);
        break;
      case 3://square
        mod.tris.Add(vertices[2]);
        mod.tris.Add(vertices[1]);
        mod.tris.Add(vertices[0]);
        mod.tris.Add(vertices[2]);
        mod.tris.Add(vertices[0]);
        mod.tris.Add(vertices[3]);
        break;
      default:
        {
          Debug.Log("What do I do here!! " + vertices.GetUpperBound(0));
          break;
        }
    }
  }*/

 /*  void convertVertToTris(int[] vertices, ref UWModel mod)
  {
    Vector2[] vertices2D =  new Vector2[vertices.GetUpperBound(0)+1];
    for (int i=0; i<=vertices2D.GetUpperBound(0);i++)
    {
      float u = mod.verts[vertices[i]].x/ mod.verts[vertices[i]].z;
      float v = mod.verts[vertices[i]].y/ mod.verts[vertices[i]].z;
      vertices2D[vertices2D.GetUpperBound(0)-i] = new Vector2(u,v);//mod.verts[vertices[i]];
    }
    Triangulator tr = new Triangulator(vertices2D);
    int[] indices = tr.Triangulate();

    for (int i=0; i<=indices.GetUpperBound(0);i++)
    {
      //find the original vertex ref and add it to the tri's
      for (int j=0; j<=mod.verts.Count;j++)
      {

        if (mod.verts[j]==mod.verts[vertices[indices[i]]])
        {
          mod.tris.Add(j);
          break;
        }
      }
    }

  }*/
 
  void convertVertToTris(int[] vertices,ref UWModel mod)
  {//This is sort of wrong.

    int startvert=0;
    int lastvert=1;
    int NoOfVerts = vertices.GetUpperBound(0);
   
    string output = "\t";
    for (int i=0; i<=vertices.GetUpperBound(0)-2;i++)
    {
      mod.tris.Add(vertices[lastvert+1]);
      mod.tris.Add(vertices[lastvert]);
      mod.tris.Add(vertices[startvert]);
      output = output +  "(" + (vertices[lastvert+1]) + "," + vertices[lastvert] + "," + vertices[startvert] +")" ;
      lastvert=lastvert+1;  
    }
    writer.Write (output + "\n");

  }




  public void exportTris()
  {
    StreamWriter Exportwriter=new StreamWriter( Application.dataPath + "//..//tris.txt", false);
    string output = "";
    for (int i =0; i<=trisToRender.GetUpperBound(0);i++)
    {
      output = output + trisToRender[i].ToString() + ",";
    }
    Exportwriter.Write(output);
    Exportwriter.Close();


    Exportwriter=new StreamWriter( Application.dataPath + "//..//verts.txt", false);
    output = "";
    for (int i =0; i<=verts.GetUpperBound(0);i++)
    {
      output = output + " ModelVerts[" + i + "] = new Vector3(" + verts[i].x + "f,"  + verts[i].z + "f,"  + verts[i].y + "f);\n";
    }
    Exportwriter.Write(output);
    Exportwriter.Close();

  }
 
}
