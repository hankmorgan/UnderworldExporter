using UnityEngine;
using System.Collections;

/// <summary>
/// Generates a 3d model based object.
/// </summary>
/// Vertices and triangles are based on the skunkworks 3d model loader that is 70% correct. Models Fixed up in "post".
public class Model3D : object_base {
		


	
	protected override void Start ()
	{
		base.Start ();
		
		AdjustModelPos();

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
		Material[] mats = new Material[NoOfMeshes()];
		Mesh mesh = new Mesh();


		mesh.subMeshCount = NoOfMeshes();				

		mesh.vertices = ModelVertices();

		Vector2[] uvs = ModelUVs(mesh.vertices);

		for (int i=0; i<NoOfMeshes();i++)
		{
			mesh.SetTriangles(ModelTriangles(i),i);	
			mats[i] = ModelMaterials(i);
			//mr.material.SetColor("_Color",ModelColour(0));
			mats[i].SetColor("_Color",ModelColour(i));
		}	
		if (uvs.GetUpperBound(0)>0)
		{
			mesh.uv= uvs;
		}

		mr.materials=mats;
		for (int i=0; i<NoOfMeshes();i++)
		{
			mr.materials[i].SetColor("_Color",ModelColour(i));
		}

		meshF.mesh = mesh;
		mesh.RecalculateNormals(); 
		mesh.RecalculateBounds();
		if (isSolidModel())
		{
			MeshCollider mc = this.gameObject.	AddComponent<MeshCollider>();
			mc.sharedMesh=null;
			mc.sharedMesh=mesh;							
		}

	}

	public virtual int[] ModelTriangles(int meshNo)
	{
		return new int[]{0,0,0};
	}

	public virtual Vector3[] ModelVertices()
	{
		return new Vector3[]{Vector3.zero,Vector3.zero,Vector3.zero,Vector3.zero};
	}

	public virtual int NoOfMeshes()
	{
		return 1;
	}

	public virtual Color ModelColour(int meshNo)
	{
		return Color.white;
	}

	public virtual bool isSolidModel()
	{
		return true;
	}

	public virtual Vector2[] ModelUVs(Vector3[] verts)
	{
		//return new Vector2[]{Vector2.zero};
		Vector2[] customUVs = new Vector2[verts.Length];
		for (int i = 0; i <  customUVs.Length; i++)
		{
			customUVs[i] = new Vector2(verts[i].x, verts[i].z);
			customUVs[i]=customUVs[i] * TextureScaling();
		}
		return customUVs;
	}

	public virtual Material ModelMaterials(int meshNo)
	{
		return GameWorldController.instance.modelMaterial;
	}


	public virtual Texture2D ModelTexture (int meshNo)
	{
		return null;
	}

	public virtual float TextureScaling()
	{
			return 1f;
	}



	protected void AdjustModelPos ()
	{
		//Line up decals to walls where the decal is set to be on an edge.
		int tileX = objInt ().tileX;
		int tileY = objInt ().tileY;
		int x = objInt ().x;
		int y = objInt ().y;
		int heading = objInt ().heading * 45;
		Vector3 objPos = this.transform.position;
		Vector3 adjustment = Vector3.zero;
		if (TileMap.ValidTile (tileX, tileY)) 
		{
			if ((y == 0)) {
					//Move object Right.
					adjustment += new Vector3 (0, 0, 0.06f);
			}
			if ((y == 7) ) {
					//Move object left.
					adjustment += new Vector3 (0, 0, -0.06f);
			}
			if ((x == 0)) {
					//move object forward
					adjustment += new Vector3 (0.06f, 0, 0);
			}
			if ((x == 7) ) {
					//Move object backward..
					adjustment += new Vector3 (-0.06f, 0, 0);
			}
		}
		this.transform.position = objPos + adjustment;
	}

}
