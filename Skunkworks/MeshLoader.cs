using UnityEngine;
using System.Collections;

public class MeshLoader : MonoBehaviour {

	public Vector3[] newVertices;
	public Vector2[] newUV;

	public int[] SecondTriangles;

	public Mesh mesh;


	public int[] newTriangles;

	void Start()
		{
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		}
	
		void Update() {
		if(mesh==null)
			{
			mesh = new Mesh();
			GetComponent<MeshFilter>().mesh = mesh;
			}	
		mesh.subMeshCount=2;
		mesh.vertices = newVertices;
		mesh.uv = newUV;

		mesh.SetTriangles(newTriangles,0);
		mesh.SetTriangles(SecondTriangles,1);
		//mesh.triangles = newTriangles;


		mesh.RecalculateNormals();
		}
}
