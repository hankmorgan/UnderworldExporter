using UnityEngine;
using System.Collections;
using System.Linq;

/// <summary>
/// Generic model 3d models have have only decorative uses.
/// </summary>
public class GenericModel3D : Model3D {


		public override int[] ModelTriangles (int meshNo)
		{
			switch (item_id)
			{
			case 336://Bench
				{
					return BenchTriangles().Reverse().ToArray();
				}
			case 344://table
				{
					return TableTriangles().Reverse().ToArray();	
				}
			case 345://beam
				{
					return BeamTriangles().Reverse().ToArray();	
				}
			case 348://chair
				{
					return ChairTriangles(meshNo).Reverse().ToArray();
				}
			case 350://Nightstand
				{
					return NightStandTriangles().Reverse().ToArray();	
				}
			case 361:
				{
					return ShelfTriangles().Reverse().ToArray();
				}
			}
			return base.ModelTriangles(meshNo);
		}

		public override Vector3[] ModelVertices ()
		{
				//		return new int[]{4,7,6,4,6,5,6,7,2,7,3,2,5,2,1,5,6,2,7,0,3,7,4,0,4,1,0,4,5,1,0,1,2,0,2,3,8,18,21,8,19,18,8,21,19,19,21,18,15,25,24,15,24,27,15,24,25,15,27,24,26,15,25,15,26,14,14,13,15,13,12,15,13,26,25,13,25,12,9,8,10,10,8,11,9,20,19,9,19,8,11,8,15,12,11,15,22,23,24,22,24,27,31,22,27,31,27,30,31,30,23,23,30,24,17,21,18,17,16,21,16,28,29,16,29,21,30,27,21,30,21,29,28,17,29,17,18,29,20,10,19,10,11,19}.Reverse().ToArray();
				switch (item_id)
				{
				case 336://Bench
						{
							return BenchVertices();
						}
				case 344://table
						{
							return TableVertices();	
						}
				case 345://Beam
						{
								return BeamVertices();
						}
				case 348://chair
						{
							return ChairVertices();
						}
				case 350://Nightstand
						{
							return NightStandVertices();	
						}
				case 361:
						{
							return ShelfVertices();
						}
				}
				return base.ModelVertices();
		}

		public override Color ModelColour (int meshNo)
		{
				return Color.grey;
		}



		public override Material ModelMaterials (int meshNo)
		{
				int woodMaterial;
				//return BenchVertices();
				if (_RES==GAME_UW2)
				{
						woodMaterial =34;			
				}
				else
				{
						woodMaterial =30;			
				}	
				switch (item_id)
				{
				case 336://Bench
				case 344://Table			
						{
							return GameWorldController.instance.MaterialObj[woodMaterial];								
						}
						//case 345://Beam
						//{

						//}
				case 348://chair
						{
								switch(meshNo)		
								{
								case 0://Frame
										return GameWorldController.instance.MaterialObj[woodMaterial];			
								default://cushion
										if (_RES==GAME_UW2)
										{
											return GameWorldController.instance.MaterialObj[38];		
										}
										else
										{
										return GameWorldController.instance.MaterialObj[woodMaterial];					
										}										
								}
						}
				case 350://Nightstand
						{
								return GameWorldController.instance.MaterialObj[woodMaterial];				
						}
				case 361://shelf
						{
								return GameWorldController.instance.MaterialObj[38];
						}
				}
				return base.ModelMaterials (meshNo);
		}

		public override float TextureScaling ()
		{
				switch (item_id)
				{
				case 336://Bench
				case 344://table
				case 348://chair
				case 350://Nightstand
				case 361://shelf		
						{
								return 4;
						}
						//case 345://Beam
						//{

						//}
				}
				return base.TextureScaling ();
		}


		public override int NoOfMeshes ()
		{
				switch (item_id)
				{
				case 348://chair
						return 2;
				default:
						return base.NoOfMeshes();
				}
		}





		Vector3[] BenchVertices()
		{
				Vector3[] ModelVerts = new Vector3[32];
				ModelVerts[0] = new Vector3(0.015625f,0.1875f,0.2890625f);
				ModelVerts[1] = new Vector3(0.015625f,0.1875f,-0.2890625f);
				ModelVerts[2] = new Vector3(-0.1757813f,0.1875f,-0.2890625f);
				ModelVerts[3] = new Vector3(-0.1757813f,0.1875f,0.2890625f);
				ModelVerts[4] = new Vector3(0.015625f,0.203125f,0.2890625f);
				ModelVerts[5] = new Vector3(0.015625f,0.203125f,-0.2890625f);
				ModelVerts[6] = new Vector3(-0.1757813f,0.203125f,-0.2890625f);
				ModelVerts[7] = new Vector3(-0.1757813f,0.203125f,0.2890625f);
				ModelVerts[8] = new Vector3(0f,0.1875f,0.2421875f);
				ModelVerts[9] = new Vector3(0.0078125f,0f,0.2421875f);
				ModelVerts[10] = new Vector3(0.0078125f,0f,0.2109375f);
				ModelVerts[11] = new Vector3(0f,0.1523438f,0.1757813f);
				ModelVerts[12] = new Vector3(0f,0.1523438f,-0.1757813f);
				ModelVerts[13] = new Vector3(0.0078125f,0f,-0.2109375f);
				ModelVerts[14] = new Vector3(0.0078125f,0f,-0.2421875f);
				ModelVerts[15] = new Vector3(0f,0.1875f,-0.2421875f);
				ModelVerts[16] = new Vector3(-0.1679688f,0f,0.2421875f);
				ModelVerts[17] = new Vector3(-0.1445313f,0f,0.2421875f);
				ModelVerts[18] = new Vector3(-0.125f,0.1523438f,0.2421875f);
				ModelVerts[19] = new Vector3(-0.03515625f,0.1523438f,0.2421875f);
				ModelVerts[20] = new Vector3(-0.015625f,0f,0.2421875f);
				ModelVerts[21] = new Vector3(-0.1601563f,0.1875f,0.2421875f);
				ModelVerts[22] = new Vector3(-0.1679688f,0f,-0.2421875f);
				ModelVerts[23] = new Vector3(-0.1445313f,0f,-0.2421875f);
				ModelVerts[24] = new Vector3(-0.125f,0.1523438f,-0.2421875f);
				ModelVerts[25] = new Vector3(-0.03515625f,0.1523438f,-0.2421875f);
				ModelVerts[26] = new Vector3(-0.015625f,0f,-0.2421875f);
				ModelVerts[27] = new Vector3(-0.1601563f,0.1875f,-0.2421875f);
				ModelVerts[28] = new Vector3(-0.1679688f,0f,0.2109375f);
				ModelVerts[29] = new Vector3(-0.1601563f,0.1523438f,0.1757813f);
				ModelVerts[30] = new Vector3(-0.1601563f,0.1523438f,-0.1757813f);
				ModelVerts[31] = new Vector3(-0.1679688f,0f,-0.2109375f);

				return ModelVerts;	
		}

		int[] BenchTriangles()
		{
				return new int[]{4,7,6,4,6,5,6,7,2,7,3,2,5,2,1,5,6,2,7,0,3,7,4,0,4,1,0,4,5,1,0,1,2,0,2,3,8,18,21,8,19,18,8,21,19,19,21,18,15,25,24,15,24,27,15,24,25,15,27,24,26,15,25,15,26,14,14,13,15,13,12,15,13,26,25,13,25,12,9,8,10,10,8,11,9,20,19,9,19,8,11,8,15,12,11,15,22,23,24,22,24,27,31,22,27,31,27,30,31,30,23,23,30,24,17,21,18,17,16,21,16,28,29,16,29,21,30,27,21,30,21,29,28,17,29,17,18,29,20,10,19,10,11,19};
		}

		Vector3[] BeamVertices()
		{
				Vector3[] ModelVerts = new Vector3[32];
				ModelVerts[0] = new Vector3(0f,0f,0f);
				ModelVerts[1] = new Vector3(0f,0.0625f,0f);
				ModelVerts[2] = new Vector3(0.0625f,0.0625f,0f);
				ModelVerts[3] = new Vector3(0.0625f,0f,0f);
				ModelVerts[4] = new Vector3(0f,0f,0.5f);
				ModelVerts[5] = new Vector3(0f,0.0625f,0.5f);
				ModelVerts[6] = new Vector3(0.0625f,0.0625f,0.5f);
				ModelVerts[7] = new Vector3(0.0625f,0f,0.5f);
				return ModelVerts;
		}

		int[] BeamTriangles()
		{
				return new int[]{2,1,0,3,2,0,5,6,7,4,5,7,1,5,4,0,1,4,2,6,5,1,2,5,6,2,3,7,6,3,7,3,0,4,7,0};
		}


		Vector3[] ShelfVertices()
		{
			Vector3[] ModelVerts = new Vector3[14];	
			ModelVerts[0] = new Vector3(-0.25f,0.1289063f,-0.125f);
			ModelVerts[1] = new Vector3(-0.25f,0.1601563f,-0.125f);
			ModelVerts[2] = new Vector3(0.25f,0.1601563f,-0.125f);
			ModelVerts[3] = new Vector3(0.25f,0.1289063f,-0.125f);
			ModelVerts[4] = new Vector3(-0.25f,0.1289063f,0.125f);
			ModelVerts[5] = new Vector3(-0.25f,0.1601563f,0.125f);
			ModelVerts[6] = new Vector3(0.25f,0.1601563f,0.125f);
			ModelVerts[7] = new Vector3(0.25f,0.1289063f,0.125f);
			ModelVerts[8] = new Vector3(0.1640625f,0.1289063f,0.125f);
			ModelVerts[9] = new Vector3(0.1640625f,0f,0.125f);
			ModelVerts[10] = new Vector3(0.1640625f,0.1289063f,-0.00390625f);
			ModelVerts[11] = new Vector3(-0.1640625f,0.1289063f,0.125f);
			ModelVerts[12] = new Vector3(-0.1640625f,0.1289063f,-0.00390625f);
			ModelVerts[13] = new Vector3(-0.1640625f,0f,0.125f);
			return ModelVerts;
		}

		int [] ShelfTriangles()
		{
			return new int[]{4,7,3,0,4,3,10,9,8,9,10,8,13,12,11,12,13,11,2,1,0,3,2,0,5,6,7,4,5,7,5,4,0,1,5,0,6,5,1,2,6,1,7,6,2,3,7,2};	
		}


		int[] TableTriangles()
		{
			return new int[]{9,5,6,12,9,6,15,12,6,17,15,6,50,17,6,53,50,6,36,35,34,37,36,34,29,31,30,28,29,30,66,64,65,67,66,65,86,84,85,87,86,85,58,57,56,59,58,56,57,70,71,56,57,71,60,58,59,61,60,59,76,74,75,77,76,75,78,76,77,79,78,77,80,78,79,81,80,79,44,42,43,45,44,43,42,40,41,43,42,41,20,2,19,21,20,19,2,23,22,19,2,22,46,44,45,47,46,45,23,25,24,22,23,24,3,1,0,4,3,0,6,5,4,0,6,4,7,3,4,8,7,4,1,55,54,0,1,54,5,9,8,4,5,8,53,6,0,54,53,0,10,7,8,11,10,8,55,52,51,54,55,51,9,12,11,8,9,11,50,53,54,51,50,54,13,10,11,14,13,11,52,18,16,51,52,16,14,11,12,15,14,12,51,16,17,50,51,17,16,14,15,17,16,15,18,13,14,16,18,14,52,55,1,18,52,1,13,18,1,10,13,1,7,10,1,3,7,1,35,48,49,34,35,49,73,86,87,72,73,87,31,33,32,30,31,32,33,20,21,32,33,21,62,60,61,63,62,61,64,62,63,65,64,63,68,66,67,69,68,67,70,68,69,71,70,69,25,27,26,24,25,26,27,29,28,26,27,28,58,57,56,59,58,56,57,70,71,56,57,71,60,58,59,61,60,59,76,74,75,77,76,75,78,76,77,79,78,77,80,78,79,81,80,79,44,42,43,45,44,43,42,40,41,43,42,41,20,2,19,21,20,19,2,23,22,19,2,22,46,44,45,47,46,45,23,25,24,22,23,24,3,1,0,4,3,0,6,5,4,0,6,4,7,3,4,8,7,4,1,55,54,0,1,54,5,9,8,4,5,8,53,6,0,54,53,0,10,7,8,11,10,8,55,52,51,54,55,51,9,12,11,8,9,11,50,53,54,51,50,54,13,10,11,14,13,11,52,18,16,51,52,16,14,11,12,15,14,12,51,16,17,50,51,17,16,14,15,17,16,15,18,13,14,16,18,14,52,55,1,18,52,1,13,18,1,10,13,1,7,10,1,3,7,1};
		}

		Vector3[] TableVertices()
		{
			Vector3[] ModelVerts = new Vector3[88];
			ModelVerts[0] = new Vector3(-0.2109375f,0.328125f,-0.2109375f);
			ModelVerts[1] = new Vector3(-0.203125f,0.3398438f,-0.1953125f);
			ModelVerts[2] = new Vector3(0.15625f,0f,-0.15625f);
			ModelVerts[3] = new Vector3(0.203125f,0.3398438f,-0.1953125f);
			ModelVerts[4] = new Vector3(0.2109375f,0.328125f,-0.2109375f);
			ModelVerts[5] = new Vector3(0.2109375f,0.2851563f,-0.2109375f);
			ModelVerts[6] = new Vector3(-0.2109375f,0.2851563f,-0.2109375f);
			ModelVerts[7] = new Vector3(0.265625f,0.3398438f,-0.1328125f);
			ModelVerts[8] = new Vector3(0.28125f,0.328125f,-0.140625f);
			ModelVerts[9] = new Vector3(0.28125f,0.2851563f,-0.140625f);
			ModelVerts[10] = new Vector3(0.265625f,0.3398438f,0.1328125f);
			ModelVerts[11] = new Vector3(0.28125f,0.328125f,0.140625f);
			ModelVerts[12] = new Vector3(0.28125f,0.2851563f,0.140625f);
			ModelVerts[13] = new Vector3(0.203125f,0.3398438f,0.1953125f);
			ModelVerts[14] = new Vector3(0.2109375f,0.328125f,0.2109375f);
			ModelVerts[15] = new Vector3(0.2109375f,0.2851563f,0.2109375f);
			ModelVerts[16] = new Vector3(-0.2109375f,0.328125f,0.2109375f);
			ModelVerts[17] = new Vector3(-0.2109375f,0.2851563f,0.2109375f);
			ModelVerts[18] = new Vector3(-0.203125f,0.3398438f,0.1953125f);
			ModelVerts[19] = new Vector3(0.1601563f,0.2851563f,-0.1601563f);
			ModelVerts[20] = new Vector3(0.1484375f,0f,-0.15625f);
			ModelVerts[21] = new Vector3(0.140625f,0.2851563f,-0.1601563f);
			ModelVerts[22] = new Vector3(0.1757813f,0.2851563f,-0.15625f);
			ModelVerts[23] = new Vector3(0.1679688f,0f,-0.1484375f);
			ModelVerts[24] = new Vector3(0.1757813f,0.2851563f,-0.125f);
			ModelVerts[25] = new Vector3(0.1679688f,0f,-0.1328125f);
			ModelVerts[26] = new Vector3(0.1601563f,0.2851563f,-0.1210938f);
			ModelVerts[27] = new Vector3(0.15625f,0f,-0.125f);
			ModelVerts[28] = new Vector3(0.140625f,0.2851563f,-0.1210938f);
			ModelVerts[29] = new Vector3(0.1484375f,0f,-0.125f);
			ModelVerts[30] = new Vector3(0.125f,0.2851563f,-0.125f);
			ModelVerts[31] = new Vector3(0.1328125f,0f,-0.1328125f);
			ModelVerts[32] = new Vector3(0.125f,0.2851563f,-0.15625f);
			ModelVerts[33] = new Vector3(0.1328125f,0f,-0.1484375f);
			ModelVerts[34] = new Vector3(0.140625f,0.2851563f,0.1210938f);
			ModelVerts[35] = new Vector3(0.1484375f,0f,0.125f);
			ModelVerts[36] = new Vector3(0.1328125f,0f,0.1328125f);
			ModelVerts[37] = new Vector3(0.125f,0.2851563f,0.125f);
			ModelVerts[38] = new Vector3(0.1328125f,0f,0.1484375f);
			ModelVerts[39] = new Vector3(0.125f,0.2851563f,0.15625f);
			ModelVerts[40] = new Vector3(0.1484375f,0f,0.15625f);
			ModelVerts[41] = new Vector3(0.140625f,0.2851563f,0.1601563f);
			ModelVerts[42] = new Vector3(0.15625f,0f,0.15625f);
			ModelVerts[43] = new Vector3(0.1601563f,0.2851563f,0.1601563f);
			ModelVerts[44] = new Vector3(0.1679688f,0f,0.1484375f);
			ModelVerts[45] = new Vector3(0.1757813f,0.2851563f,0.15625f);
			ModelVerts[46] = new Vector3(0.1679688f,0f,0.1328125f);
			ModelVerts[47] = new Vector3(0.1757813f,0.2851563f,0.125f);
			ModelVerts[48] = new Vector3(0.15625f,0f,0.125f);
			ModelVerts[49] = new Vector3(0.1601563f,0.2851563f,0.1210938f);
			ModelVerts[50] = new Vector3(-0.28125f,0.2851563f,0.140625f);
			ModelVerts[51] = new Vector3(-0.28125f,0.328125f,0.140625f);
			ModelVerts[52] = new Vector3(-0.265625f,0.3398438f,0.1328125f);
			ModelVerts[53] = new Vector3(-0.28125f,0.2851563f,-0.140625f);
			ModelVerts[54] = new Vector3(-0.28125f,0.328125f,-0.140625f);
			ModelVerts[55] = new Vector3(-0.265625f,0.3398438f,-0.1328125f);
			ModelVerts[56] = new Vector3(-0.1601563f,0.2851563f,-0.1601563f);
			ModelVerts[57] = new Vector3(-0.15625f,0f,-0.15625f);
			ModelVerts[58] = new Vector3(-0.1679688f,0f,-0.1484375f);
			ModelVerts[59] = new Vector3(-0.1757813f,0.2851563f,-0.15625f);
			ModelVerts[60] = new Vector3(-0.1679688f,0f,-0.1328125f);
			ModelVerts[61] = new Vector3(-0.1757813f,0.2851563f,-0.125f);
			ModelVerts[62] = new Vector3(-0.15625f,0f,-0.125f);
			ModelVerts[63] = new Vector3(-0.1601563f,0.2851563f,-0.1210938f);
			ModelVerts[64] = new Vector3(-0.1484375f,0f,-0.125f);
			ModelVerts[65] = new Vector3(-0.140625f,0.2851563f,-0.1210938f);
			ModelVerts[66] = new Vector3(-0.1328125f,0f,-0.1328125f);
			ModelVerts[67] = new Vector3(-0.125f,0.2851563f,-0.125f);
			ModelVerts[68] = new Vector3(-0.1328125f,0f,-0.1484375f);
			ModelVerts[69] = new Vector3(-0.125f,0.2851563f,-0.15625f);
			ModelVerts[70] = new Vector3(-0.1484375f,0f,-0.15625f);
			ModelVerts[71] = new Vector3(-0.140625f,0.2851563f,-0.1601563f);
			ModelVerts[72] = new Vector3(-0.1601563f,0.2851563f,0.1210938f);
			ModelVerts[73] = new Vector3(-0.15625f,0f,0.125f);
			ModelVerts[74] = new Vector3(-0.1679688f,0f,0.1328125f);
			ModelVerts[75] = new Vector3(-0.1757813f,0.2851563f,0.125f);
			ModelVerts[76] = new Vector3(-0.1679688f,0f,0.1484375f);
			ModelVerts[77] = new Vector3(-0.1757813f,0.2851563f,0.15625f);
			ModelVerts[78] = new Vector3(-0.15625f,0f,0.15625f);
			ModelVerts[79] = new Vector3(-0.1601563f,0.2851563f,0.1601563f);
			ModelVerts[80] = new Vector3(-0.1484375f,0f,0.15625f);
			ModelVerts[81] = new Vector3(-0.140625f,0.2851563f,0.1601563f);
			ModelVerts[82] = new Vector3(-0.1328125f,0f,0.1484375f);
			ModelVerts[83] = new Vector3(-0.125f,0.2851563f,0.15625f);
			ModelVerts[84] = new Vector3(-0.1328125f,0f,0.1328125f);
			ModelVerts[85] = new Vector3(-0.125f,0.2851563f,0.125f);
			ModelVerts[86] = new Vector3(-0.1484375f,0f,0.125f);
			ModelVerts[87] = new Vector3(-0.140625f,0.2851563f,0.1210938f);
			return ModelVerts;
		}


		int[] ChairTriangles(int MeshNo)
		{
			switch (MeshNo)
			{
			case 0:
					return new int[]{1,0,2,0,3,2,1,24,23,1,23,0,5,7,6,5,4,7,6,7,32,33,6,32,20,22,21,20,20,25,20,25,29,20,14,22,20,29,14,26,28,27,26,19,28,26,30,19,30,31,19,3,7,4,3,0,7,23,22,0,0,22,14,7,31,32,7,19,31,28,19,29,29,19,14,14,13,10,14,15,13,13,13,13,19,8,18,8,11,18,14,19,15,15,19,18,18,11,13,18,13,15};
			case 1:
					return new int[]{0,10,8,0,8,7,10,13,11,10,11,8};
			}
			return base.ModelTriangles(MeshNo);
		}


		Vector3[] ChairVertices()
		{
			Vector3[] ModelVerts = new Vector3[36];
			ModelVerts[0] = new Vector3(0.15625f,0.296875f,0.1367188f);
			ModelVerts[1] = new Vector3(0.1679688f,0f,0.1367188f);
			ModelVerts[2] = new Vector3(0.1679688f,0f,0.1054688f);
			ModelVerts[3] = new Vector3(0.15625f,0.2421875f,0.0703125f);
			ModelVerts[4] = new Vector3(0.15625f,0.2421875f,-0.0703125f);
			ModelVerts[5] = new Vector3(0.1679688f,0f,-0.1054688f);
			ModelVerts[6] = new Vector3(0.1679688f,0f,-0.1367188f);
			ModelVerts[7] = new Vector3(0.15625f,0.296875f,-0.1367188f);
			ModelVerts[8] = new Vector3(-0.04296875f,0.296875f,-0.1367188f);
			ModelVerts[9] = new Vector3(-0.0703125f,0.296875f,0f);
			ModelVerts[10] = new Vector3(-0.04296875f,0.296875f,0.1367188f);
			ModelVerts[11] = new Vector3(-0.1171875f,0.671875f,-0.1367188f);
			ModelVerts[12] = new Vector3(-0.1445313f,0.671875f,0f);
			ModelVerts[13] = new Vector3(-0.1171875f,0.671875f,0.1367188f);
			ModelVerts[14] = new Vector3(-0.09375f,0.296875f,0.1367188f);
			ModelVerts[15] = new Vector3(-0.1445313f,0.671875f,0.1367188f);
			ModelVerts[16] = new Vector3(-0.1679688f,0.671875f,0f);
			ModelVerts[17] = new Vector3(-0.1171875f,0.296875f,0f);
			ModelVerts[18] = new Vector3(-0.1445313f,0.671875f,-0.1367188f);
			ModelVerts[19] = new Vector3(-0.09375f,0.296875f,-0.1367188f);
			ModelVerts[20] = new Vector3(-0.15625f,0f,0.1367188f);
			ModelVerts[21] = new Vector3(-0.1054688f,0f,0.1367188f);
			ModelVerts[22] = new Vector3(-0.04296875f,0.2421875f,0.1367188f);
			ModelVerts[23] = new Vector3(0.1015625f,0.2421875f,0.1367188f);
			ModelVerts[24] = new Vector3(0.1328125f,0f,0.1367188f);
			ModelVerts[25] = new Vector3(-0.15625f,0f,0.1054688f);
			ModelVerts[26] = new Vector3(-0.15625f,0f,-0.1367188f);
			ModelVerts[27] = new Vector3(-0.15625f,0f,-0.1054688f);
			ModelVerts[28] = new Vector3(-0.1054688f,0.234375f,-0.0703125f);
			ModelVerts[29] = new Vector3(-0.1054688f,0.234375f,0.0703125f);
			ModelVerts[30] = new Vector3(-0.1054688f,0f,-0.1367188f);
			ModelVerts[31] = new Vector3(-0.04296875f,0.2421875f,-0.1367188f);
			ModelVerts[32] = new Vector3(0.1015625f,0.2421875f,-0.1367188f);
			ModelVerts[33] = new Vector3(0.1328125f,0f,-0.1367188f);
			ModelVerts[34] = new Vector3(-0.1054688f,0.2421875f,0.0703125f);
			ModelVerts[35] = new Vector3(-0.1054688f,0.2421875f,-0.0703125f);
			return ModelVerts;
		}



		int[] NightStandTriangles()
		{
			return new int[]{0,2,3,4,0,3,35,39,38,34,35,38,39,37,36,38,39,36,28,26,27,29,28,27,26,25,24,27,26,24,19,23,22,18,19,22,23,21,20,22,23,20,12,10,11,13,12,11,10,9,1,11,10,1,3,2,0,4,3,0,4,0,5,6,4,5,3,4,6,7,3,6,2,3,7,8,2,7,0,2,8,5,0,8,32,33,36,37,32,36,14,15,12,13,14,12,30,24,25,31,30,25,16,17,20,21,16,20,18,17,16,19,18,16,30,31,28,29,30,28,35,39,38,34,35,38,39,37,36,38,39,36,28,26,27,29,28,27,26,25,24,27,26,24,19,23,22,18,19,22,23,21,20,22,23,20,12,10,11,13,12,11,10,9,1,11,10,1,3,2,0,4,3,0,4,0,5,6,4,5,3,4,6,7,3,6,2,3,7,8,2,7,0,2,8,5,0,8};
		}

		Vector3[] NightStandVertices()
		{
			Vector3[] ModelVerts = new Vector3[40];
			ModelVerts[0] = new Vector3(0.1171875f,0.1835938f,-0.1171875f);
			ModelVerts[1] = new Vector3(-0.09375f,-0.00390625f,-0.07421875f);
			ModelVerts[2] = new Vector3(-0.1171875f,0.1835938f,-0.1171875f);
			ModelVerts[3] = new Vector3(-0.1171875f,0.1835938f,0.1679688f);
			ModelVerts[4] = new Vector3(0.1171875f,0.1835938f,0.1679688f);
			ModelVerts[5] = new Vector3(0.1171875f,0.1679688f,-0.1171875f);
			ModelVerts[6] = new Vector3(0.1171875f,0.1679688f,0.1679688f);
			ModelVerts[7] = new Vector3(-0.1171875f,0.1679688f,0.1679688f);
			ModelVerts[8] = new Vector3(-0.1171875f,0.1679688f,-0.1171875f);
			ModelVerts[9] = new Vector3(-0.09375f,0.1679688f,-0.0625f);
			ModelVerts[10] = new Vector3(-0.09375f,0.1679688f,-0.0859375f);
			ModelVerts[11] = new Vector3(-0.09375f,-0.00390625f,-0.0859375f);
			ModelVerts[12] = new Vector3(-0.0703125f,0.1679688f,-0.0859375f);
			ModelVerts[13] = new Vector3(-0.08203125f,-0.00390625f,-0.0859375f);
			ModelVerts[14] = new Vector3(-0.08203125f,-0.00390625f,-0.07421875f);
			ModelVerts[15] = new Vector3(-0.0703125f,0.1679688f,-0.0625f);
			ModelVerts[16] = new Vector3(0.0703125f,0.1679688f,-0.0625f);
			ModelVerts[17] = new Vector3(0.08203125f,-0.00390625f,-0.07421875f);
			ModelVerts[18] = new Vector3(0.09375f,-0.00390625f,-0.07421875f);
			ModelVerts[19] = new Vector3(0.09375f,0.1679688f,-0.0625f);
			ModelVerts[20] = new Vector3(0.08203125f,-0.00390625f,-0.0859375f);
			ModelVerts[21] = new Vector3(0.0703125f,0.1679688f,-0.0859375f);
			ModelVerts[22] = new Vector3(0.09375f,-0.00390625f,-0.0859375f);
			ModelVerts[23] = new Vector3(0.09375f,0.1679688f,-0.0859375f);
			ModelVerts[24] = new Vector3(0.09375f,-0.00390625f,0.125f);
			ModelVerts[25] = new Vector3(0.09375f,0.1679688f,0.1132813f);
			ModelVerts[26] = new Vector3(0.09375f,0.1679688f,0.1367188f);
			ModelVerts[27] = new Vector3(0.09375f,-0.00390625f,0.1367188f);
			ModelVerts[28] = new Vector3(0.0703125f,0.1679688f,0.1367188f);
			ModelVerts[29] = new Vector3(0.08203125f,-0.00390625f,0.1367188f);
			ModelVerts[30] = new Vector3(0.08203125f,-0.00390625f,0.125f);
			ModelVerts[31] = new Vector3(0.0703125f,0.1679688f,0.1132813f);
			ModelVerts[32] = new Vector3(-0.0703125f,0.1679688f,0.1132813f);
			ModelVerts[33] = new Vector3(-0.08203125f,-0.00390625f,0.125f);
			ModelVerts[34] = new Vector3(-0.09375f,-0.00390625f,0.125f);
			ModelVerts[35] = new Vector3(-0.09375f,0.1679688f,0.1132813f);
			ModelVerts[36] = new Vector3(-0.08203125f,-0.00390625f,0.1367188f);
			ModelVerts[37] = new Vector3(-0.0703125f,0.1679688f,0.1367188f);
			ModelVerts[38] = new Vector3(-0.09375f,-0.00390625f,0.1367188f);
			ModelVerts[39] = new Vector3(-0.09375f,0.1679688f,0.1367188f);
			return ModelVerts;
		}


	int[] BedTriangles(int MeshNo)
	{
		switch(MeshNo)
		{
		case 0://bed frame
			return new int[]{62,56,55,62,55,63,56,45,46,56,46,55,55,47,54,55,46,47,55,54,63,45,56,62,45,62,25,45,61,46,47,48,53,47,53,54,48,41,52,48,52,53,52,42,51,52,41,42,42,43,50,42,50,51,43,49,50,43,44,49,50,49,66,49,57,66,50,66,51,49,44,57,57,44,58,46,61,47,44,43,42,44,42,58,24,23,25,62,61,24,62,24,25,25,23,26,14,12,15,14,13,12,42,13,58,13,14,58,54,53,52,54,52,51,54,51,65,54,65,64,48,77,42,48,42,41,48,47,77,77,47,75,26,27,76,26,4,27,4,26,60,4,60,3,4,5,27,4,3,5,5,3,0,59,12,8,8,12,7,30,12,78,7,12,30,7,30,6,6,30,78,7,6,9,8,7,9,5,11,10,5,10,6,5,76,27,5,6,78,5,78,76,26,76,25,25,76,75,47,61,75,42,77,58,78,12,77,77,12,13,44,13,58,59,9,10,59,10,15,60,23,0,23,11,0};

		}

		return base.ModelTriangles(MeshNo);
	}

		Vector3[] BedVertices()
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
