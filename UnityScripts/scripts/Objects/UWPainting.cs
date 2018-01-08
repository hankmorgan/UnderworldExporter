using UnityEngine;
using System.Collections;
using System.Linq;

public class UWPainting : Model3D {

	public override int NoOfMeshes ()
	{
		return 2;
	}

	public override int[] ModelTriangles (int meshNo)
	{
		switch (meshNo)
		{
		case 0://Canvas
			return new int[]{4,3,2,0,4,2}.Reverse().ToArray();
		case 1://Frame
			return new int[]{5,1,0,2,5,0,6,5,2,3,6,2,7,6,3,4,7,3,1,7,4,0,1,4,6,7,8,9,6,8,1,5,10,11,1,10,6,9,10,5,6,10,7,1,11,8,7,11}.Reverse().ToArray();;
		}
		return base.ModelTriangles(meshNo);
	}


	public override Vector3[] ModelVertices ()
	{
		Vector3[] ModelVerts = new Vector3[12];
		ModelVerts[0] = new Vector3(-0.25f,0.03515625f,0.05078125f);
		ModelVerts[1] = new Vector3(-0.3046875f,0f,0.03125f);
		ModelVerts[2] = new Vector3(-0.25f,0.2851563f,0.05078125f);
		ModelVerts[3] = new Vector3(0.25f,0.2851563f,0.05078125f);
		ModelVerts[4] = new Vector3(0.25f,0.03515625f,0.05078125f);
		ModelVerts[5] = new Vector3(-0.3046875f,0.3203125f,0.03125f);
		ModelVerts[6] = new Vector3(0.3046875f,0.3203125f,0.03125f);
		ModelVerts[7] = new Vector3(0.3046875f,0f,0.03125f);
		ModelVerts[8] = new Vector3(0.3046875f,0f,0.05859375f);
		ModelVerts[9] = new Vector3(0.3046875f,0.3203125f,0.05859375f);
		ModelVerts[10] = new Vector3(-0.3046875f,0.3203125f,0.05859375f);
		ModelVerts[11] = new Vector3(-0.3046875f,0f,0.05859375f);
		return ModelVerts;
	}


	public override Material ModelMaterials (int meshNo)
	{

		switch (meshNo)
		{
		//GameWorldController.instance.TmObjArt.RequestSprite(SpriteIndex);
		case 0://Canvas
			return GameWorldController.instance.MaterialObj[42 + (objInt().flags & 0x07)];			
		case 1://Frame
			return GameWorldController.instance.MaterialObj[38];
		}
		return base.ModelMaterials (meshNo);
	}


	public override Vector2[] ModelUVs (Vector3[] verts)
	{
		Vector2[] uvs = base.ModelUVs (verts);
				//Uvs to align the painting canvas correctly
		uvs[0] = new Vector2(0f,0f);
		uvs[2] = new Vector2(0f,1f);
		uvs[3] = new Vector2(1f,1f);
		uvs[4] = new Vector2(1f,0f);
		return uvs;
	}

	public override Color ModelColour (int meshNo)
	{
		switch(meshNo)
			{
			case 1://frame
					return Color.yellow;
			}
		return base.ModelColour(meshNo);
	}
}
