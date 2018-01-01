using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UWModelLoader : MonoBehaviour {

  public int modelToLoad;
  public string outputname;

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
      "-",
      "door frame",
      "bridge",
      "bench",
      "Lotus Turbo Esprit (no, really!)",
      "small boulder",
      "medium boulder",
      "large boulder",
      "arrow",
      "beam",
      "pillar",
      "shrine",
      "?",
      "painting [uw2]",
      "?",
      "?",
      "texture map (8-way lever)",
      "texture map (8-way switch)",
      "texture map (writing)",
      "gravestone",
      "texture map (0x016e)",
      "-",
      "?texture map (0x016f)",
      "moongate",
      "table",
      "chest",
      "nightstand",
      "barrel",
      "chair",
      "bed [uw2]",
      "blackrock gem [uw2]",
      "shelf [uw2]"
    };

 

	// Use this for initialization
	void Start () {	  
    modeltable[0].table_offset=0x0004e910;modeltable[0].value=0x40064ab6;modeltable[0].base_offset=0x0004e99e;
    modeltable[1].table_offset=0x0004ccd0;modeltable[1].value=0x40064ab6;modeltable[1].base_offset=0x0004cd5e;
    modeltable[2].table_offset=0x0004e370;modeltable[2].value=0x40064ab6;modeltable[2].base_offset=0x0004e3fe;
    modeltable[3].table_offset=0x0004ec70;modeltable[3].value=0x40064ab6;modeltable[3].base_offset=0x0004ecfe;
    modeltable[4].table_offset=0x00054cf0;modeltable[4].value=0x59aa64d4;modeltable[4].base_offset=0x00054d8a;
    modeltable[5].table_offset=0x000550e0;modeltable[5].value=0x59aa64d4;modeltable[5].base_offset=0x0005517a;



    DecodeModel("c:\\games\\uw1\\uw.exe");

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

      Vector3 extents = new Vector3(ex,ez,ey);
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


  void RenderModel(UWModel mod)
  {
    outputname=mod.modelname;
    Vector3[] verts = new Vector3[mod.NoOfVerts+1];
    for (int i=0; i<=verts.GetUpperBound(0);i++)
    {
      verts[i]=mod.verts[i];
    }
    //int noOfTris=mod.tris.Count;
    //noOfTris +=  (3- (noOfTris%3) );//round up to a multiple of 3 tris
     
    int[] tris = new int[mod.tris.Count];
    for (int i=0; i<=tris.GetUpperBound(0);i++)
    {
      if(mod.tris.Count>i)
      {
        tris[i]=mod.tris[i];  
      }

    }
    Mesh mesh = new Mesh();
    GetComponent<MeshFilter>().mesh = mesh;

    mesh.vertices =verts;
   // mesh.uv = newUV;

    mesh.SetTriangles(tris,0);
    mesh.RecalculateNormals();

  }


  float ua_mdl_read_fixed(char[] fileData, long addressPtr)
  {
    long val = DataLoader.getValAtAddress(fileData,addressPtr,16) ;//static_cast<Sint16>(fread16(fd));
    return (float)(val)/ 256.0f;
  }

  int ua_mdl_read_vertno(char[] fileData, long addressPtr)
  {
    int val = (int)DataLoader.getValAtAddress(fileData,addressPtr,16); //fread16(fd);
    return val / 8;
  }

  void ua_mdl_store_vertex(Vector3 vertex, int vertno,ref UWModel mod)
  {
   // if (vertex_list.size()<=vertno)
     // vertex_list.resize(vertno+1);
    if (vertno>=mod.verts.Capacity)
    {
      mod.verts.Capacity=vertno+1;
    }
    mod.verts.Insert(vertno,vertex);
    if (mod.NoOfVerts< vertno)
    {
      mod.NoOfVerts=vertno;
    }
   // mod.verts[vertno] = vertex;
  }




  void ua_model_parse_node(char[] modelfile, long addressptr, ref UWModel mod, 
//    std::vector<ua_vector3d>vertex_list,
  //  std::vector<ua_triangle3d_textured>& triangles,
    bool dump)
  {
    // parse node until end node
    bool loop = true;

    while(loop)
    {
      // read next command
     // ua_model_nodecmd cmd = (ua_model_nodecmd)fread16(fd);
      int cmd = (int)(DataLoader.getValAtAddress(modelfile,addressptr,16));addressptr+=2;
      int refvert; int vertno; int unk1;
      float vx;float vy; float vz;
      float nx; float ny; float nz;
      Vector3 refvect;

      //ua_mdl_trace(" %04x ",cmd);
      switch((nodecmd)cmd)
      {
        // misc. nodes
        case nodecmd.M3_UW_ENDNODE: // 0000 end node
         // ua_mdl_trace("[end]");
          loop = false;
          break;

        case nodecmd.M3_UW_ORIGIN: // 0078 define model center
          vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;//ua_mdl_read_vertno(fd);
          mod.origin = mod.verts[vertno];// mod.verts[vertno] ;

          vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

          unk1 =  (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2; //fread16(fd);
         // ua_mdl_trace("[origin] vertno=%u unk1=%04x origin=(%f,%f,%f)",
          //  vertno,unk1,vx,vy,vz);
          break;

          // vertex definition nodes
        case nodecmd.M3_UW_VERTEX: // 007a define initial vertex
          vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;//ua_mdl_read_vertno(fd);

          refvect = new Vector3(vx,vy,vz);
          ua_mdl_store_vertex(refvect,vertno,ref mod);

         // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f)",
           // vertno,vx,vy,vz);
          break;

        case nodecmd.M3_UW_VERTICES: // 0082 define initial vertices
          {
            int nvert =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);
            vertno =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);
            for(int n=0; n<nvert; n++)
            {
              vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
              vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
              vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

              refvect = new Vector3(vx,vy,vz);
              ua_mdl_store_vertex(refvect,vertno+n,ref mod);

              //ua_mdl_trace("%s[vertex] vertno=%u vertex=(%f,%f,%f)",
               // n==0 ? "" : "\n      ",vertno+n,vx,vy,vz);
            }
          }
          break;

        case nodecmd.M3_UW_VERTEX_X: // 0086 define vertex offset X
          refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
          vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

          refvect =mod.verts[refvert];
        //  refvect.x += vx;
          refvect  = new Vector3(refvect.x+vx,refvect.y,refvect.z);
          ua_mdl_store_vertex(refvect,vertno,ref mod);

          //ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) x from=%u",
          //  vertno,refvect.x,refvect.y,refvect.z,refvert);
          break;

        case nodecmd.M3_UW_VERTEX_Z: // 0088 define vertex offset Z
          refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
          vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

          refvect = mod.verts[refvert];
          //refvect.z += vz;
          refvect  = new Vector3(refvect.x,refvect.y,refvect.z+vz);
          ua_mdl_store_vertex(refvect,vertno,ref mod);

          //ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) z from=%u",
          //  vertno,refvect.x,refvect.y,refvect.z,refvert);
          break;

        case nodecmd.M3_UW_VERTEX_Y: // 008a define vertex offset Y
          refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
          vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

          refvect = mod.verts[refvert];
          //refvect.y += vy;
          refvect  = new Vector3(refvect.x,refvect.y+vy,refvect.z);
          ua_mdl_store_vertex(refvect,vertno,ref mod);

         // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) y from=%u",
         //   vertno,refvect.x,refvect.y,refvect.z,refvert);
          break;

        case nodecmd.M3_UW_VERTEX_XZ: // 0090 define vertex offset X,Z
          vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
          vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

          refvect = mod.verts[refvert];
          //refvect.x += vx;
          //refvect.z += vz;
          refvect  = new Vector3(refvect.x+vx,refvect.y,refvect.z+vz);
          ua_mdl_store_vertex(refvect,vertno,ref mod);

         // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) xz from=%u",
        //    vertno,refvect.x,refvect.y,refvect.z,refvert);
          break;

        case nodecmd.M3_UW_VERTEX_XY: // 0092 define vertex offset X,Y
          vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
          vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

          refvect = mod.verts[refvert];
          refvect.x += vx;
          refvect.y += vy;
          refvect  = new Vector3(refvect.x+vx,refvect.y+vy,refvect.z);
          ua_mdl_store_vertex(refvect,vertno,ref mod);

         // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) xy from=%u",
         //   vertno,refvect.x,refvect.y,refvect.z,refvert);
          break;

        case nodecmd.M3_UW_VERTEX_YZ: // 0094 define vertex offset Y,Z
          vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
          vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

          refvect = mod.verts[refvert];
          //refvect.y += vy;
         // refvect.z += vz;
          refvect  = new Vector3(refvect.x,refvect.y+vy,refvect.z+vz);
          ua_mdl_store_vertex(refvect,vertno,ref mod);

         // ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,%f) yz from=%u",
        //    vertno,refvect.x,refvect.y,refvect.z,refvert);
          break;

        case nodecmd.M3_UW_VERTEX_CEIL: // 008c define vertex variable height
          {
            refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

            refvect = mod.verts[refvert];
            refvect.z = 32.0f; // todo: ceiling value
            ua_mdl_store_vertex(refvect,vertno,ref mod);

            //  ua_mdl_trace("[vertex] vertno=%u vertex=(%f,%f,ceil) ceil from=%u unk1=%04x",
            //   vertno,refvect.x,refvect.y,refvert,unk1);
            break;
          }

          // face plane checks
        case nodecmd.M3_UW_FACE_PLANE: // 0058 define face plane, arbitrary heading
          unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
          nx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          ny = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          nz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

        //  ua_mdl_trace("[planecheck] skip=%04x normal=(%f,%f,%f) dist=(%f,%f,%f)",
        //    unk1,nx,ny,nz,vx,vy,vz);
          break;

        case nodecmd.M3_UW_FACE_PLANE_X: // 0064 define face plane X
        case nodecmd.M3_UW_FACE_PLANE_Z: // 0066 define face plane Z
        case nodecmd.M3_UW_FACE_PLANE_Y: // 0068 define face plane Y
          unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
          nx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

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

        case nodecmd.M3_UW_FACE_PLANE_ZY: // 005e define face plane Z/Y
        case nodecmd.M3_UW_FACE_PLANE_XY: // 0060 define face plane X/Y
        case nodecmd.M3_UW_FACE_PLANE_XZ: // 0062 define face plane X/Z
          unk1 =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);
          nx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;// ua_mdl_read_fixed(fd);
          ny = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
          vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

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

          // face info nodes
        case nodecmd.M3_UW_FACE_VERTICES: // 007e define face vertices
          {
            int nvert = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            //Xua_poly_tessellator tess;

           // ua_mdl_trace("[face] nvert=%u vertlist=",nvert);
            int[] faceverts = new int[nvert];
            for(int i=0; i<nvert; i++)
            {
             // Uint16 
              vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

             // mod.tris.Add(vertno);//moved
              faceverts[i] = vertno;
              //Xua_vertex3d vert;

             //
             //X vert.pos = mod.verts[vertno];
             //X tess.add_poly_vertex(vert);

             //ua_mdl_trace("%u",vertno);
              //if (i<=nvert-1) ua_mdl_trace(" ");
            }

          //X  const std::vector<ua_triangle3d_textured>& tri = tess.tessellate(0x0001);
            //triangles.insert(triangles.begin(),tri.begin(),tri.end());
            //mod.tris.Add(vertno);
            convertVertToTris(faceverts,ref mod);
          }
          break;

        case nodecmd.M3_UW_TEXTURE_FACE: // 00a8 define texture-mapped face
        case nodecmd.M3_UW_TMAP_VERTICES: // 00b4 define face vertices with u,v information
          {
           // ua_mdl_trace("[face] %s ",cmd==M3_UW_TEXTURE_FACE ? "tex" : "tmap");

            // read texture number
            if ((nodecmd)cmd== nodecmd.M3_UW_TEXTURE_FACE)
            {
              unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd); // texture number?
              //ua_mdl_trace("texnum=%04x ",unk1);
            }

            int nvert = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
           //X ua_poly_tessellator tess;

            //ua_mdl_trace("nvert=%u vertlist=",nvert);
            int[] faceverts = new int[nvert];
            for(int i=0; i<nvert; i++)
            {
             // Uint16 
              vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;

              double u0 = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
              double v0 = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

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
            if((nodecmd)(cmd)==nodecmd.M3_UW_SORT_PLANE)
            {
              nx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
              vx = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            }

            ny = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            vy = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            nz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);
            vz = ua_mdl_read_fixed(modelfile,addressptr);addressptr+=2;//ua_mdl_read_fixed(fd);

          /*  if (dump)
            {
              ua_mdl_trace("[sort] ");
              switch(cmd)
              {
                case nodecmd.M3_UW_SORT_PLANE:
                  ua_mdl_trace("normal=(%f,%f,%f) dist=(%f,%f,%f)",nx,ny,nz,vx,vy,vz);
                  break;
                case nodecmd.M3_UW_SORT_PLANE_ZY:
                  ua_mdl_trace("normal=(%f,%f,%f) dist=(%f,%f,%f)",0.0,nz,ny,0.0,vz,vy);
                  break;
                case nodecmd.M3_UW_SORT_PLANE_XY:   
                  ua_mdl_trace("normal=(%f,%f,%f) dist=(%f,%f,%f)",ny,nz,0.0,vy,vz,0.0);
                  break;
                case nodecmd.M3_UW_SORT_PLANE_XZ:
                  ua_mdl_trace("normal=(%f,%f,%f) dist=(%f,%f,%f)",ny,0.0,nz,vy,0.0,vz);
                  break;
              }
            }*/

            long left = DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            left += addressptr;// ftell(fd);

            long right = DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
            right += addressptr;// ftell(fd);

            //ua_mdl_trace(" left=%08x right=%08x\n      [sort] start left node\n",left,right);

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
          refvert = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
          unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
          vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
         // ua_mdl_trace("[shade] color refvert=%u unk1=%04x vertno=%u",refvert,unk1,vertno);
          break;

        case nodecmd.M3_UW_FACE_SHADE: // 00BC define face shade
          unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
          vertno = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
          //ua_mdl_trace("[shade] shade unk1=%02x unk2=%02x",unk1,vertno);
          break;

        case nodecmd.M3_UW_FACE_TWOSHADES: // 00BE ??? seems to define 2 shades
          vertno =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
          unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
          //ua_mdl_trace("[shade] twoshade unk1=%02x unk2=%02x ",vertno,unk1);
          break;

        case nodecmd.M3_UW_VERTEX_DARK: // 00D4 define dark vertex face (?)
          {
            int nvert =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);
            unk1 =(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;// fread16(fd);

            //ua_mdl_trace("[shade] color nvert=%u, unk1=%04x vertlist=",
            //  nvert,unk1);

            for(int n=0; n<nvert; n++)
            {
              vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
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
          break;

        case nodecmd.M3_UW_FACE_UNK40: // 0040 ???
         // ua_mdl_trace("[shade] unknown");
          break;

        case nodecmd.M3_UW_FACE_SHORT: // 00A0 ??? shorthand face definition
          {
            vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
           //X ua_poly_tessellator tess;

            //ua_mdl_trace("[face] shorthand unk1=%u vertlist=",vertno);
            int[] faceverts = new int[4];
            for(int i=0; i<4; i++)
            {
             //Uint8 
              vertno = (int)DataLoader.getValAtAddress(modelfile,addressptr,8);addressptr++; //fgetc(fd);

              //X ua_vertex3d vert;
              //X vert.pos = mod.verts[vertno];
              //X tess.add_poly_vertex(vert);

             // ua_mdl_trace("%u ",vertno);
              //mod.tris.Add(vertno);//moved
              faceverts[i] = vertno;
            }
            convertVertToTris(faceverts,ref mod);
            //X const std::vector<ua_triangle3d_textured>& tri = tess.tessellate(0x0003);
            //triangles.insert(triangles.begin(),tri.begin(),tri.end());
          }
          break;

        case (nodecmd)0x00d2: // 00D2 ??? shorthand face definition
          {
            vertno = ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;
            //X            ua_poly_tessellator tess;

            //ua_mdl_trace("[face] vertno=%u vertlist=",vertno);
            int[] faceverts = new int[4];
            for(int i=0; i<4; i++)
            {
             //Uint8
              vertno = (int)DataLoader.getValAtAddress(modelfile,addressptr,8);addressptr++; //fgetc(fd);

              //X  ua_vertex3d vert;
              //X  vert.pos = mod.verts[vertno];
              //X  tess.add_poly_vertex(vert);

              //ua_mdl_trace("%u ",vertno);

              //mod.tris.Add(vertno);//moved
              faceverts[i] = vertno;
            }
            convertVertToTris(faceverts,ref mod);
            //X const std::vector<ua_triangle3d_textured>& tri = tess.tessellate(0x0004);
           // triangles.insert(triangles.begin(),tri.begin(),tri.end());

            //ua_mdl_trace("shorthand");
          }
          break;

        case nodecmd.M3_UW_FACE_UNK16: // 0016 ???
          {
            long pos = addressptr;//(int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr++;//ftell(fd);

            int nvert =  ua_mdl_read_vertno(modelfile,addressptr); addressptr+=2;//ua_mdl_read_vertno(fd);
            unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);

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
          unk1 = (int)DataLoader.getValAtAddress(modelfile,addressptr,16);addressptr+=2;//fread16(fd);
          break;

        default:
          //ua_mdl_trace("unknown command at offset 0x%08x\n",ftell(fd)-2);
          return;
      }
     // ua_mdl_trace("\n");
    }
  }


  void convertVertToTris(int[] vertices,ref UWModel mod)
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
  }
 /* void convertVertToTris(int[] vertices,ref UWModel mod)
  {

    int startvert=0;
    int lastvert=1;
    int NoOfVerts = vertices.GetUpperBound(0);

    for (int i=0; i<=vertices.GetUpperBound(0)-2;i++)
    {
      mod.tris.Add(vertices[startvert]);
      mod.tris.Add(vertices[lastvert]);
      mod.tris.Add(vertices[lastvert+1]);
      lastvert=lastvert+1;  
    }
  }*/

 
}
