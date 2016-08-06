using UnityEngine;
using System.Collections;
/// <summary>
/// For Storing Tile Info for each level.
/// </summary>
public class TileInfo {
	
		/// <summary>
		/// The type of the tile.
		/// </summary>
		public int[,] tileType = new int[64,64];
		/// <summary>
		/// Is the tile rendered
		/// </summary>
		public int[,] Render = new int[64,64];
		/// <summary>
		/// The height of the ceiling. Always the same in UW
		/// </summary>
		public int[,] CeilingHeight = new int[64,64];
		/// <summary>
		/// The height of the floor.
		/// </summary>
		public int[,] FloorHeight = new int[64,64];
		/// <summary>
		/// Has the tile been visited by the player.
		/// </summary>
		public bool[,] tileVisited = new bool[64,64];
		/// <summary>
		/// Is the tile a water tile
		/// </summary>
		public bool[,] isWater = new bool[64,64];
		/// <summary>
		/// Is the tile a lava tile.
		/// </summary>
		public bool[,] isLava = new bool[64,64];
		/// <summary>
		/// Is there a bridge in this tile
		/// </summary>
		public bool [,] isBridge=new bool[64,64];
}
