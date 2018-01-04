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
		mr.material = GameWorldController.instance.modelMaterial;
		mesh.subMeshCount = NoOfMeshes();
		mesh.vertices =ModelVertices();
		Vector2[] uvs = ModelUVs();
		//uvs[0]=new Vector2(0f,0f);
		//uvs[1]=new Vector2(0f,1f);
		//uvs[2]=new Vector2(1f,1f);
		//uvs[3]=new Vector2(1f,0f);
		//int UvCounter=0;
		for (int i=0; i<NoOfMeshes();i++)
		{
			mesh.SetTriangles(ModelTriangles(i),i);	
			//uvs[UvCounter+0]=new Vector2(0f,0f);	
			//uvs[UvCounter+1]=new Vector2(0f,1f);	
			//uvs[UvCounter+2]=new Vector2(1f,1f);
			//uvs[UvCounter+3]=new Vector2(1f,0f);
			//UvCounter+=4;
		}	
		if (uvs.GetUpperBound(0)>0)
		{
				mesh.uv= uvs;
		}

		mr.material.SetColor("_Color",ModelColour(0));
		mesh.triangles=	mesh.triangles;
		meshF.mesh = mesh;
		//meshF.mesh.uv=uvs;
		mesh.RecalculateNormals(); 
		mesh.RecalculateBounds();
		MeshCollider mc = this.gameObject.	AddComponent<MeshCollider>();
		mc.sharedMesh=null;
		mc.sharedMesh=mesh;	
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

	public virtual Vector2[] ModelUVs()
	{
		return new Vector2[]{Vector2.zero};
	}

}
