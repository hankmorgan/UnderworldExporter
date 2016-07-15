using UnityEngine;
using System.Collections;

public class MapInteraction : GuiBase {
		public static int MapNo;//Current Map being displayed
		public void MapClose()
		{
			WindowDetect.InMap=false;

			if  (GameWorldController.instance.mus!=null)
			{
					GameWorldController.instance.mus.InMap=false;
			}
			chains.ActiveControl=0;
			GameWorldController.instance.playerUW.playerHud.ChainsControl.Refresh();
		}

		public void MapUp()
		{
				if (MapNo>0)	
				{
					MapNo--;
					UpdateMap(MapNo);
				}	
		}

		public void MapDown()
		{//Actually increases the map number!
				if (MapNo<8)	
				{
					MapNo++;
					UpdateMap(MapNo);
				}
		}

		private void UpdateMap(int LevelNo)
		{
			WindowDetect.InMap=true;//turns on blocking collider.
			GameWorldController.instance.playerUW.playerHud.MapDisplay.texture=GameWorldController.instance.Tilemap.TileMapImage(LevelNo);
		}

}
