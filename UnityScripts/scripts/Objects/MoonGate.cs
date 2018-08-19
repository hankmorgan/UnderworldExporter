using UnityEngine;
using System.Collections;
using System.Linq;

public class MoonGate : Model3D {

	public override Vector3[] ModelVertices ()
	{
		Vector3[] ModelVerts=new Vector3[8];
		ModelVerts[0] = new Vector3(-0.375f,0f,0f);
		ModelVerts[1] = new Vector3(0.375f,0f,0f);
		ModelVerts[2] = new Vector3(0.375f,1.25f,0f);
		ModelVerts[3] = new Vector3(-0.375f,1.25f,0f);
		ModelVerts[4] = new Vector3(-0.375f,0f,0.025f);
		ModelVerts[5] = new Vector3(0.375f,0f,0.025f);
		ModelVerts[6] = new Vector3(0.375f,1.25f,0.025f);
		ModelVerts[7] = new Vector3(-0.375f,1.25f,0.025f);
		return ModelVerts;
	}


	public override int[] ModelTriangles (int meshNo)
	{
		return new int[]{1,2,3,1,3,0,4,7,6,4,6,5}.Reverse().ToArray();
	}

	public override Color ModelColour (int meshNo)
	{
		return GameWorldController.instance.palLoader.Palettes[0].ColorAtPixel((byte)(link-512),false);
	}

	public override Vector2[] ModelUVs (Vector3[] verts)
	{
		Vector2[]ModelUVs=new Vector2[8];
		ModelUVs[0] = new Vector2(0f,0f);
		ModelUVs[1] = new Vector2(0f,1f);
		ModelUVs[2] = new Vector2(1f,1f);
		ModelUVs[3] = new Vector2(1f,0f);
		ModelUVs[4] = new Vector2(0f,0f);
		ModelUVs[5] = new Vector2(0f,1f);
		ModelUVs[6] = new Vector2(1f,1f);
		ModelUVs[7] = new Vector2(1f,0f);
		return ModelUVs;
	}

	public override bool isSolidModel ()
	{
		return false;
	}
}
