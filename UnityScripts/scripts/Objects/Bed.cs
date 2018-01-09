using UnityEngine;
using System.Collections;
using System.Linq;

public class Bed : Model3D {

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			UWCharacter.Instance.Sleep();
			return true;
		}
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
	}

	public override string UseVerb ()
	{
		return "sleep";
	}

	public override int NoOfMeshes ()
	{
		return 4;
	}

	public override int[] ModelTriangles (int MeshNo)
	{
		switch(MeshNo)
		{
		case 0://bed frame
			return new int[]{62,56,55,62,55,63,56,45,46,56,46,55,55,47,54,55,46,47,55,54,63,45,56,62,45,62,25,45,61,46,47,48,53,47,53,54,48,41,52,48,52,53,52,42,51,52,41,42,42,43,50,42,50,51,43,49,50,43,44,49,50,49,66,49,57,66,50,66,51,49,44,57,57,44,58,46,61,47,44,43,42,44,42,58,24,23,25,62,61,24,62,24,25,25,23,26,14,12,15,14,13,12,42,13,58,13,14,58,54,53,52,54,52,51,54,51,65,54,65,64,48,77,42,48,42,41,48,47,77,77,47,75,26,27,76,26,4,27,4,26,60,4,60,3,4,5,27,4,3,5,5,3,0,59,12,8,8,12,7,30,12,78,7,12,30,7,30,6,6,30,78,7,6,9,8,7,9,5,11,10,5,10,6,5,76,27,5,6,78,5,78,76,26,76,25,25,76,75,47,61,75,42,77,58,78,12,77,77,12,13,44,13,58,59,9,10,59,10,15,60,23,0,23,11,0}.Reverse().ToArray();
		case 1://quilt
			return new int[]{76,78,16,76,16,20,16,32,74,16,78,32,76,20,71,71,31,76,20,16,71,16,74,71,31,71,74,31,74,32}.Reverse().ToArray();
		case 2://mattress
			return new int[]{75,76,78,75,78,77}.Reverse().ToArray();
		case 3://Pillow
			return new int[]{34,33,36,34,36,37,33,80,31,33,34,80,36,79,37,79,36,32,36,33,32,33,31,32,80,34,37,80,37,79}.Reverse().ToArray();
		}
		return base.ModelTriangles(MeshNo);
	}

	public override Color ModelColour (int meshNo)
	{
		switch(meshNo)
		{
		case 0://bed frame
			return Color.red;
		case 1://quilt
			return Color.green;
		case 2://mattress
			return Color.white;
		case 3://Pillow			
			return Color.black;
		}
		return base.ModelColour(meshNo);
	}


	public override Vector3[] ModelVertices ()
	{
				Vector3[] ModelVerts=new Vector3[81];
				ModelVerts[0] = new Vector3(-0.2226563f,0f,-0.3828125f);
				ModelVerts[1] = new Vector3(0.234375f,0.1640625f,-0.3632813f);
				ModelVerts[2] = new Vector3(-0.125f,0.3164063f,0.2617188f);
				ModelVerts[3] = new Vector3(-0.25f,0f,-0.3828125f);
				ModelVerts[4] = new Vector3(-0.25f,0.3046875f,-0.3828125f);
				ModelVerts[5] = new Vector3(-0.2148438f,0.2226563f,-0.3828125f);
				ModelVerts[6] = new Vector3(0.2148438f,0.2226563f,-0.3828125f);
				ModelVerts[7] = new Vector3(0.25f,0.3046875f,-0.3828125f);
				ModelVerts[8] = new Vector3(0.25f,0f,-0.3828125f);
				ModelVerts[9] = new Vector3(0.2226563f,0f,-0.3828125f);
				ModelVerts[10] = new Vector3(0.21875f,0.1171875f,-0.3828125f);
				ModelVerts[11] = new Vector3(-0.21875f,0.1171875f,-0.3828125f);
				ModelVerts[12] = new Vector3(0.25f,0.2226563f,-0.3476563f);
				ModelVerts[13] = new Vector3(0.25f,0.2226563f,0.34375f);
				ModelVerts[14] = new Vector3(0.25f,0.1171875f,0.34375f);
				ModelVerts[15] = new Vector3(0.25f,0.1171875f,-0.3515625f);
				ModelVerts[16] = new Vector3(0.2148438f,0.2695313f,-0.3476563f);
				ModelVerts[17] = new Vector3(0.2148438f,0.2695313f,0.328125f);
				ModelVerts[18] = new Vector3(0.234375f,0.1640625f,0.34375f);
				ModelVerts[19] = new Vector3(-0.234375f,0.1640625f,-0.3632813f);
				ModelVerts[20] = new Vector3(-0.2148438f,0.2695313f,-0.3476563f);
				ModelVerts[21] = new Vector3(-0.2148438f,0.2695313f,0.328125f);
				ModelVerts[22] = new Vector3(-0.234375f,0.1640625f,0.34375f);
				ModelVerts[23] = new Vector3(-0.25f,0.1171875f,-0.3515625f);
				ModelVerts[24] = new Vector3(-0.25f,0.1171875f,0.34375f);
				ModelVerts[25] = new Vector3(-0.25f,0.2226563f,0.34375f);
				ModelVerts[26] = new Vector3(-0.25f,0.2226563f,-0.3476563f);
				ModelVerts[27] = new Vector3(-0.2148438f,0.3046875f,-0.3476563f);
				ModelVerts[28] = new Vector3(-0.2148438f,0.3046875f,0.1992188f);
				ModelVerts[29] = new Vector3(0.2148438f,0.3046875f,0.1992188f);
				ModelVerts[30] = new Vector3(0.2148438f,0.3046875f,-0.3476563f);
				ModelVerts[31] = new Vector3(-0.234375f,0.1640625f,0.21875f);
				ModelVerts[32] = new Vector3(0.234375f,0.1640625f,0.21875f);
				ModelVerts[33] = new Vector3(-0.1601563f,0.2695313f,0.234375f);
				ModelVerts[34] = new Vector3(-0.1601563f,0.2695313f,0.3203125f);
				ModelVerts[35] = new Vector3(-0.1367188f,0.3046875f,0.3085938f);
				ModelVerts[36] = new Vector3(0.1601563f,0.2695313f,0.234375f);
				ModelVerts[37] = new Vector3(0.1601563f,0.2695313f,0.3203125f);
				ModelVerts[38] = new Vector3(0.1367188f,0.3046875f,0.3085938f);
				ModelVerts[39] = new Vector3(0.125f,0.3164063f,0.2617188f);
				ModelVerts[40] = new Vector3(0f,0.2226563f,0.34375f);
				ModelVerts[41] = new Vector3(0.140625f,0.5390625f,0.34375f);
				ModelVerts[42] = new Vector3(0.21875f,0.375f,0.34375f);
				ModelVerts[43] = new Vector3(0.2226563f,0.4804688f,0.34375f);
				ModelVerts[44] = new Vector3(0.25f,0.4804688f,0.34375f);
				ModelVerts[45] = new Vector3(-0.25f,0.4804688f,0.34375f);
				ModelVerts[46] = new Vector3(-0.2226563f,0.4804688f,0.34375f);
				ModelVerts[47] = new Vector3(-0.21875f,0.375f,0.34375f);
				ModelVerts[48] = new Vector3(-0.140625f,0.5390625f,0.34375f);
				ModelVerts[49] = new Vector3(0.25f,0.4921875f,0.3828125f);
				ModelVerts[50] = new Vector3(0.2226563f,0.4921875f,0.3828125f);
				ModelVerts[51] = new Vector3(0.21875f,0.3867188f,0.3828125f);
				ModelVerts[52] = new Vector3(0.140625f,0.5507813f,0.3828125f);
				ModelVerts[53] = new Vector3(-0.140625f,0.5507813f,0.3828125f);
				ModelVerts[54] = new Vector3(-0.21875f,0.3867188f,0.3828125f);
				ModelVerts[55] = new Vector3(-0.2226563f,0.4921875f,0.3828125f);
				ModelVerts[56] = new Vector3(-0.25f,0.4921875f,0.3828125f);
				ModelVerts[57] = new Vector3(0.25f,0f,0.3828125f);
				ModelVerts[58] = new Vector3(0.25f,0f,0.3554688f);
				ModelVerts[59] = new Vector3(0.25f,0f,-0.3554688f);
				ModelVerts[60] = new Vector3(-0.25f,0f,-0.3554688f);
				ModelVerts[61] = new Vector3(-0.25f,0f,0.3554688f);
				ModelVerts[62] = new Vector3(-0.25f,0f,0.3828125f);
				ModelVerts[63] = new Vector3(-0.2226563f,0f,0.3828125f);
				ModelVerts[64] = new Vector3(-0.21875f,0.1171875f,0.3828125f);
				ModelVerts[65] = new Vector3(0.21875f,0.1171875f,0.3828125f);
				ModelVerts[66] = new Vector3(0.2226563f,0f,0.3828125f);
				ModelVerts[67] = new Vector3(-0.25f,0.1171875f,0.3554688f);
				ModelVerts[68] = new Vector3(-0.2226563f,0.1171875f,0.3828125f);
				ModelVerts[69] = new Vector3(0.25f,0.1171875f,0.3554688f);
				ModelVerts[70] = new Vector3(0.2226563f,0.1171875f,0.3828125f);
				ModelVerts[71] = new Vector3(-0.21875f,0.2695313f,0.203125f);
				ModelVerts[72] = new Vector3(-0.21875f,0.2695313f,-0.3515625f);
				ModelVerts[73] = new Vector3(0.21875f,0.2695313f,-0.3515625f);
				ModelVerts[74] = new Vector3(0.21875f,0.2695313f,0.203125f);
				ModelVerts[75] = new Vector3(-0.2226563f,0.2226563f,0.34375f);
				ModelVerts[76] = new Vector3(-0.2226563f,0.2226563f,-0.3476563f);
				ModelVerts[77] = new Vector3(0.2226563f,0.2226563f,0.34375f);
				ModelVerts[78] = new Vector3(0.2226563f,0.2226563f,-0.3476563f);
				ModelVerts[79] = new Vector3(0.2226563f,0.2226563f,0.3359375f);
				ModelVerts[80] = new Vector3(-0.2226563f,0.2226563f,0.3359375f);
				return ModelVerts;
	}

}
