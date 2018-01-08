using UnityEngine;
using System.Collections;
using System.Linq;

public class Barrel : Container {
		
	protected override void Start ()
	{
		base.Start ();

		this.gameObject.layer = LayerMask.NameToLayer("MapMesh");
		Rigidbody rgd = this.GetComponent<Rigidbody>();
		if (rgd!=null)
		{
			DestroyImmediate (rgd);
		}
		BoxCollider box = this.GetComponent<BoxCollider>();
		if (box!=null)
		{
			DestroyImmediate (box);
		}

		MeshFilter meshF = this.gameObject.AddComponent<MeshFilter>();
		MeshRenderer mr = this.gameObject.AddComponent<MeshRenderer>();
		
		Mesh mesh = new Mesh();


		mesh.vertices = BarrelVertices();

		Vector2[] uvs = BarrelUVs(mesh.vertices);

		mesh.SetTriangles(BarrelTriangles(0),0);	

		if (uvs.GetUpperBound(0)>0)
		{
			mesh.uv= uvs;
		}

		switch (_RES)
		{
			case GAME_UW2:
				mr.material=GameWorldController.instance.MaterialObj[34];//uw2
				break;
			default:
				mr.material=GameWorldController.instance.MaterialObj[30];
				break;	
		}


		meshF.mesh = mesh;
		mesh.RecalculateNormals(); 
		mesh.RecalculateBounds();

		MeshCollider mc = this.gameObject.	AddComponent<MeshCollider>();
		mc.sharedMesh=null;
		mc.sharedMesh=mesh;	
	}


	int[] BarrelTriangles(int meshNo)
	{
		return new int[]{2,1,0,3,2,0,4,2,3,5,4,3,6,4,5,7,6,5,1,9,8,0,1,8,11,10,1,2,11,1,12,11,2,4,12,2,13,12,4,6,13,4,10,14,9,1,10,9,16,15,10,11,16,10,17,16,11,12,17,11,18,17,12,13,18,12,19,14,10,15,19,10,14,19,21,20,14,21,21,22,23,20,21,23,14,20,24,9,14,24,20,23,25,24,20,25,9,24,26,8,9,26,24,25,27,26,24,27,29,18,13,28,29,13,22,29,28,23,22,28,28,13,6,30,28,6,23,28,30,25,23,30,30,6,7,31,30,7,25,30,31,27,25,31,22,21,19,29,22,19,18,29,19,17,18,19,16,17,19,15,16,19,5,3,0,7,5,0,31,7,0,27,31,0,26,27,0,8,26,0}.Reverse().ToArray();
	}
	

	Vector3[] BarrelVertices()
	{
		Vector3[] ModelVerts = new Vector3[32];
		ModelVerts[0] = new Vector3(-0.0390625f,0f,-0.09375f);
		ModelVerts[1] = new Vector3(-0.05859375f,0.1171875f,-0.1210938f);
		ModelVerts[2] = new Vector3(0.046875f,0.1171875f,-0.1289063f);
		ModelVerts[3] = new Vector3(0.03515625f,0f,-0.09765625f);
		ModelVerts[4] = new Vector3(0.125f,0.1171875f,-0.05859375f);
		ModelVerts[5] = new Vector3(0.09375f,0f,-0.0390625f);
		ModelVerts[6] = new Vector3(0.1289063f,0.1171875f,0.046875f);
		ModelVerts[7] = new Vector3(0.1015625f,0f,0.03515625f);
		ModelVerts[8] = new Vector3(-0.09765625f,0f,-0.03515625f);
		ModelVerts[9] = new Vector3(-0.1289063f,0.1171875f,-0.046875f);
		ModelVerts[10] = new Vector3(-0.05859375f,0.234375f,-0.1210938f);
		ModelVerts[11] = new Vector3(0.046875f,0.234375f,-0.1289063f);
		ModelVerts[12] = new Vector3(0.125f,0.234375f,-0.05859375f);
		ModelVerts[13] = new Vector3(0.1289063f,0.234375f,0.046875f);
		ModelVerts[14] = new Vector3(-0.1289063f,0.234375f,-0.046875f);
		ModelVerts[15] = new Vector3(-0.0390625f,0.3515625f,-0.09375f);
		ModelVerts[16] = new Vector3(0.03515625f,0.3515625f,-0.09765625f);
		ModelVerts[17] = new Vector3(0.09375f,0.3515625f,-0.0390625f);
		ModelVerts[18] = new Vector3(0.1015625f,0.3515625f,0.03515625f);
		ModelVerts[19] = new Vector3(-0.09765625f,0.3515625f,-0.03515625f);
		ModelVerts[20] = new Vector3(-0.1210938f,0.234375f,0.05859375f);
		ModelVerts[21] = new Vector3(-0.09375f,0.3515625f,0.04296875f);
		ModelVerts[22] = new Vector3(-0.03515625f,0.3515625f,0.1015625f);
		ModelVerts[23] = new Vector3(-0.046875f,0.234375f,0.1289063f);
		ModelVerts[24] = new Vector3(-0.1210938f,0.1171875f,0.05859375f);
		ModelVerts[25] = new Vector3(-0.046875f,0.1171875f,0.1289063f);
		ModelVerts[26] = new Vector3(-0.09375f,0f,0.04296875f);
		ModelVerts[27] = new Vector3(-0.03515625f,0f,0.1015625f);
		ModelVerts[28] = new Vector3(0.05859375f,0.234375f,0.125f);
		ModelVerts[29] = new Vector3(0.04296875f,0.3515625f,0.09375f);
		ModelVerts[30] = new Vector3(0.05859375f,0.1171875f,0.125f);
		ModelVerts[31] = new Vector3(0.04296875f,0f,0.09375f);
		return ModelVerts;
	}


	public virtual Vector2[] BarrelUVs(Vector3[] verts)
	{
			//return new Vector2[]{Vector2.zero};
			Vector2[] customUVs = new Vector2[verts.Length];
			for (int i = 0; i <  customUVs.Length; i++)
			{
					customUVs[i] = new Vector2(verts[i].x, verts[i].z);
					customUVs[i]=customUVs[i] * 4;
			}
			return customUVs;
	}

}
