using UnityEngine;
using System.Collections;
using System.Linq;

public class Chest : Model3D {

    public override int NoOfMeshes ()
	{
		return 2;
	}
	
	public override int[] ModelTriangles (int meshNo)
	{
		switch(meshNo)
		{
		case 0://detail trim
			return new int[]{18,56,21,18,13,56,13,54,56,13,53,54,53,50,54,53,49,50,49,46,50,49,47,46,47,48,45,47,45,46,48,52,51,48,51,45,51,12,55,51,52,12,55,15,26,55,12,15,20,5,6,5,20,38,5,37,30,5,38,37,30,37,39,30,39,29,29,39,40,29,40,28,28,40,41,28,41,2,2,41,43,2,43,42,42,43,44,42,44,1,1,44,25,1,25,0,0,25,15,25,26,15,21,6,18,21,20,6,19,56,38,22,56,19,65,67,66,65,64,67,44,55,24,55,23,24}.Reverse().ToArray();
		case 1://main body
			return new int[]{25,24,23,25,23,26,21,22,19,21,19,20,15,12,13,15,13,18,6,5,0,5,1,0,37,38,65,37,65,66,67,56,54,67,64,56,37,67,54,67,37,66,39,37,54,39,54,50,50,46,40,50,40,39,46,45,41,46,41,40,45,51,43,45,43,41,51,44,43,51,55,44,1,5,30,1,30,29,1,29,28,1,5,28,1,28,2,1,2,42,12,53,13,12,49,53,12,47,49,12,48,47,12,57,48}.Reverse().ToArray();
		}
		return new int[]{0,0,0};
	}


    public override Vector3[] ModelVertices ()
	{
		Vector3[] ModelVerts = new Vector3[68];
		ModelVerts[0] = new Vector3(-0.0625f,0f,-0.1835938f);
		ModelVerts[1] = new Vector3(-0.078125f,0.15625f,-0.1953125f);
		ModelVerts[2] = new Vector3(-0.03125f,0.2070313f,-0.171875f);
		ModelVerts[3] = new Vector3(0.04296875f,0.1835938f,-0.1875f);
		ModelVerts[4] = new Vector3(0.0546875f,0.171875f,0.1875f);
		ModelVerts[5] = new Vector3(0.078125f,0.15625f,-0.1953125f);
		ModelVerts[6] = new Vector3(0.0703125f,0f,-0.1835938f);
		ModelVerts[7] = new Vector3(-0.0625f,0.140625f,-0.1914063f);
		ModelVerts[8] = new Vector3(-0.0546875f,0.01171875f,-0.1835938f);
		ModelVerts[9] = new Vector3(0.0625f,0.01171875f,-0.1835938f);
		ModelVerts[10] = new Vector3(0.0625f,0.140625f,-0.1914063f);
		ModelVerts[11] = new Vector3(-0.0625f,0.140625f,0.1914063f);
		ModelVerts[12] = new Vector3(-0.078125f,0.15625f,0.1953125f);
		ModelVerts[13] = new Vector3(0.078125f,0.15625f,0.1953125f);
		ModelVerts[14] = new Vector3(0.0625f,0.140625f,0.1914063f);
		ModelVerts[15] = new Vector3(-0.0625f,0f,0.1835938f);
		ModelVerts[16] = new Vector3(-0.0546875f,0.01171875f,0.1835938f);
		ModelVerts[17] = new Vector3(0.0625f,0.01171875f,0.1835938f);
		ModelVerts[18] = new Vector3(0.0703125f,0f,0.1835938f);
		ModelVerts[19] = new Vector3(0.078125f,0.1484375f,-0.1796875f);
		ModelVerts[20] = new Vector3(0.0703125f,0.015625f,-0.1679688f);
		ModelVerts[21] = new Vector3(0.0703125f,0.015625f,0.1679688f);
		ModelVerts[22] = new Vector3(0.078125f,0.1484375f,0.1796875f);
		ModelVerts[23] = new Vector3(-0.078125f,0.1484375f,0.1796875f);
		ModelVerts[24] = new Vector3(-0.078125f,0.1484375f,-0.1796875f);
		ModelVerts[25] = new Vector3(-0.0625f,0.015625f,-0.1679688f);
		ModelVerts[26] = new Vector3(-0.0625f,0.015625f,0.1679688f);
		ModelVerts[27] = new Vector3(-0.05859375f,0.1875f,-0.1835938f);
		ModelVerts[28] = new Vector3(0f,0.21875f,-0.1679688f);
		ModelVerts[29] = new Vector3(0.03515625f,0.2070313f,-0.171875f);
		ModelVerts[30] = new Vector3(0.05859375f,0.1875f,-0.1835938f);
		ModelVerts[31] = new Vector3(0.0625f,0.15625f,-0.1953125f);
		ModelVerts[32] = new Vector3(0.03125f,0.1914063f,-0.1796875f);
		ModelVerts[33] = new Vector3(0f,0.203125f,-0.171875f);
		ModelVerts[34] = new Vector3(-0.03125f,0.1914063f,-0.1796875f);
		ModelVerts[35] = new Vector3(-0.05078125f,0.1796875f,-0.1875f);
		ModelVerts[36] = new Vector3(-0.0625f,0.15625f,-0.1953125f);
		ModelVerts[37] = new Vector3(0.05859375f,0.1875f,-0.1640625f);
		ModelVerts[38] = new Vector3(0.078125f,0.15625f,-0.1796875f);
		ModelVerts[39] = new Vector3(0.03515625f,0.2070313f,-0.15625f);
		ModelVerts[40] = new Vector3(0f,0.21875f,-0.1523438f);
		ModelVerts[41] = new Vector3(-0.03125f,0.2070313f,-0.15625f);
		ModelVerts[42] = new Vector3(-0.0546875f,0.1875f,-0.1835938f);
		ModelVerts[43] = new Vector3(-0.0546875f,0.1875f,-0.1640625f);
		ModelVerts[44] = new Vector3(-0.078125f,0.15625f,-0.1796875f);
		ModelVerts[45] = new Vector3(-0.03125f,0.2070313f,0.15625f);
		ModelVerts[46] = new Vector3(0f,0.21875f,0.1523438f);
		ModelVerts[47] = new Vector3(0f,0.21875f,0.1679688f);
		ModelVerts[48] = new Vector3(-0.03125f,0.2070313f,0.171875f);
		ModelVerts[49] = new Vector3(0.03515625f,0.2070313f,0.171875f);
		ModelVerts[50] = new Vector3(0.03515625f,0.2070313f,0.15625f);
		ModelVerts[51] = new Vector3(-0.0546875f,0.1875f,0.1640625f);
		ModelVerts[52] = new Vector3(-0.0546875f,0.1875f,0.1835938f);
		ModelVerts[53] = new Vector3(0.05859375f,0.1875f,0.1835938f);
		ModelVerts[54] = new Vector3(0.05859375f,0.1875f,0.1640625f);
		ModelVerts[55] = new Vector3(-0.078125f,0.15625f,0.1796875f);
		ModelVerts[56] = new Vector3(0.078125f,0.15625f,0.1796875f);
		ModelVerts[57] = new Vector3(-0.05859375f,0.1875f,0.1835938f);
		ModelVerts[58] = new Vector3(0.0625f,0.15625f,0.1953125f);
		ModelVerts[59] = new Vector3(0.03125f,0.1914063f,0.1796875f);
		ModelVerts[60] = new Vector3(0f,0.203125f,0.171875f);
		ModelVerts[61] = new Vector3(-0.03125f,0.1914063f,0.1796875f);
		ModelVerts[62] = new Vector3(-0.05078125f,0.1796875f,0.1875f);
		ModelVerts[63] = new Vector3(-0.0625f,0.15625f,0.1953125f);
		ModelVerts[64] = new Vector3(0.078125f,0.15625f,0.015625f);
		ModelVerts[65] = new Vector3(0.078125f,0.15625f,-0.015625f);
		ModelVerts[66] = new Vector3(0.06640625f,0.171875f,-0.0078125f);
		ModelVerts[67] = new Vector3(0.06640625f,0.171875f,0.0078125f);
		return ModelVerts;
	}

		public override Color ModelColour (int meshNo)
	{
				switch (meshNo)
				{
				case 1:
						return Color.green;
				default:
						return Color.red;
					
				}
	}
}
