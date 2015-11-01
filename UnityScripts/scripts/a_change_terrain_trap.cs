using UnityEngine;
using System.Collections;

public class a_change_terrain_trap : MonoBehaviour {
	
	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;
	public int TileX;//The tile from which the change terrain trap begins.
	public int TileY;
	public int X;//The range of tiles to be changed.
	public int Y;

	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
		triggerObj=GameObject.Find (Var.trigger);
		//Get the tiles the change_terr
	}

	public void Activate()
	{
		if ((triggerObj == null) && (Var.trigger != ""))
		{//For when objects are added at run time.
			triggerObj=GameObject.Find (Var.trigger);
		}
		Vector3 Dist = new Vector3(-64*1.2f,0,0);
		//Do what it needs to do.
		MessageLog.text=MessageLog.text + name + " activated\n";
		for (int i = 0; i<=X;i++)
			{
			for (int j=0; j<=Y;j++)
				{
				//Find the tile at the location.
				GameObject ExistingTile = Var.FindTile(TileX+i,TileY+j,1);
				string Tilename = Var.GetTileName (TileX+i,TileY+j,1); //ExistingTile.name;
				//Find the tile that becomes the tile at that location.
				GameObject CTTile =Var.FindTileByName(this.name + "_" + (i).ToString ("D2") + "_" + (j).ToString ("D2"));
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
		if (Var.trigger !="")
		{//Trigger the next object in it's chain
			triggerObj.SendMessage ("Activate");
		}
	}
}
