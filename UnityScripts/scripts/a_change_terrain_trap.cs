using UnityEngine;
using System.Collections;

public class a_change_terrain_trap : trap_base {
	
	//private GameObject triggerObj;
	//private ObjectVariables Var;
	//private UILabel MessageLog;
	public int TileX;//The tile from which the change terrain trap begins.
	public int TileY;
	//public int X;//The range of tiles to be changed.
	//public int Y;


	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		Vector3 Dist = new Vector3(-64*1.2f,0,0);
		playerUW.GetMessageLog ().text= name + " activated\n";
		for (int i = 0; i<=triggerX;i++)
		{
			for (int j=0; j<=triggerY;j++)
			{
				//Find the tile at the location.
				GameObject ExistingTile = GameWorldController.FindTile(TileX+i,TileY+j,1);
				string Tilename = GameWorldController.GetTileName(TileX+i,TileY+j,1); //Var.GetTileName (TileX+i,TileY+j,1); //ExistingTile.name;
				//Find the tile that becomes the tile at that location.
				GameObject CTTile =GameWorldController.FindTileByName(this.name + "_" + (i).ToString ("D2") + "_" + (j).ToString ("D2"));   //Var.FindTileByName(this.name + "_" + (i).ToString ("D2") + "_" + (j).ToString ("D2"));
				GameObject ReplacementTile =Instantiate(CTTile,CTTile.transform.position,CTTile.transform.rotation) as GameObject;
				ReplacementTile.transform.parent=CTTile.transform.parent;
				if (ExistingTile != null)
				{
					Debug.Log ("Destroying " + ExistingTile.name );
					Destroy(ExistingTile);
				}
				if (ReplacementTile!=null)
				{
					Debug.Log ("Moving " + ReplacementTile.name );
					ReplacementTile.name = Tilename;
					Vector3 StartPos = ReplacementTile.transform.position;
					Vector3 EndPos = StartPos + Dist;
					ReplacementTile.transform.position = Vector3.Lerp (StartPos,EndPos,1.0f);
				}
			}
		}
	}
}
