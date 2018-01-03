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
		for (int i=0; i<NoOfMeshes();i++)
		{
			mesh.SetTriangles(ModelTriangles(i),i);	
		}	
		mesh.triangles=	mesh.triangles;
		meshF.mesh = mesh;
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
		return new Vector3[]{Vector3.zero};
	}

	public virtual int NoOfMeshes()
	{
		return 1;
	}
}
