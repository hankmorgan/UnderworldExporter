using UnityEngine;
using System.Collections;
/// <summary>
/// For Storing Tile Info for each level.
/// </summary>
public class TileInfo : MonoBehaviour {
	

		public int[,] tileType = new int[64,64];
		public int[,] Render = new int[64,64];
		public int[,] CeilingHeight = new int[64,64];
		public int[,] FloorHeight = new int[64,64];

		public bool[,] tileVisited = new bool[64,64];
		public bool[,] isWater = new bool[64,64];
		public bool[,] isLava = new bool[64,64];

}
