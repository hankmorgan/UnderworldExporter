using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnderworldEditor
{
    class TileMapUI
    {
        public static void PopulateWorldNode(TreeNode node, int index, objects.ObjectInfo[] objList)
        {
            while (index != 0)
            {
                TreeNode newnode = node.Nodes.Add(index + ". " + objects.ObjectName(objList[index].item_id, main.curgame));
                newnode.Tag = index;
                if (objects.isContainer(objList[index].item_id))
                {
                    PlayerDatUI.PopulateLinkedInventoryNode(newnode, objList[index].link, objList);
                }
                index = objList[index].next;
                //else
                //{
                //    PopulateInventoryMagicLink(newnode, index, objList);
                //}
            }
        }

        public static void LoadTileMap(int blockno, main MAIN)
        {
            MAIN.tilemap = new TileMap();
            MAIN.tilemap.InitTileMap(MAIN.uwblocks[blockno].Data, 0, blockno);
            if (main.curgame == 1)
            {
                MAIN.tilemap.BuildTextureMap(MAIN.uwblocks[blockno + 18].Data, ref MAIN.tilemap.ceilingtexture);
            }
            //Temporarily output to treeview for testing.
            MAIN.TreeTiles.Nodes.Clear();
            for (int x = 0; x <= 63; x++)
            {
                TreeNode xnode = MAIN.TreeTiles.Nodes.Add("X=" + x);
                for (int y = 0; y <= 63; y++)
                {
                    TreeNode ynode = xnode.Nodes.Add("Y=" + y);
                    ynode.Tag = x + "," + y;
                }
            }

            MAIN.worldObjects = new objects();
            MAIN.worldObjects.InitWorldObjectList(MAIN.uwblocks[blockno].Data, 64 * 64 * 4);
            MAIN.TreeWorldObjects.Nodes.Clear();
            for (int i = 0; i <= MAIN.worldObjects.objList.GetUpperBound(0); i++)
            {
                TreeNode newnode = MAIN.TreeWorldObjects.Nodes.Add(i + ". " + objects.ObjectName(MAIN.worldObjects.objList[i].item_id, main.curgame));
                newnode.Tag = i;
            }

            MAIN.TreeWorldByTile.Nodes.Clear();
            for (int x = 0; x <= 63; x++)
            {
                for (int y = 0; y <= 63; y++)
                {
                    if (MAIN.tilemap.Tiles[x, y].indexObjectList != 0)
                    {
                        TreeNode xynode = MAIN.TreeWorldByTile.Nodes.Add(x + "," + y);
                        TileMapUI.PopulateWorldNode(xynode, MAIN.tilemap.Tiles[x, y].indexObjectList, MAIN.worldObjects.objList);
                    }
                }
            }
        }


        public static void LoadTileInfoFromSelectedNode(main MAIN)
        {
            if (MAIN.TreeTiles.SelectedNode.Tag != null)
            {
                //Load tile info for tagged value.
                string X = MAIN.TreeTiles.SelectedNode.Tag.ToString().Split(',')[0];
                string Y = MAIN.TreeTiles.SelectedNode.Tag.ToString().Split(',')[1];
                int x; int y;
                if (int.TryParse(X, out x))
                {
                    if (int.TryParse(Y, out y))
                    {
                        MAIN.lblCurrentTile.Text = "Current Tile " + x + "," + y + " " + MAIN.TreeTiles.SelectedNode.Tag.ToString();
                        MAIN.CmbTileType.Text = TileMap.GetTileTypeText(MAIN.tilemap.Tiles[x, y].tileType);
                        MAIN.NumFloorHeight.Value = MAIN.tilemap.Tiles[x, y].floorHeight;
                        MAIN.NumFloorTexture.Value = MAIN.tilemap.Tiles[x, y].floorTexture;
                        MAIN.NumWallTexture.Value = MAIN.tilemap.Tiles[x, y].wallTexture;
                        MAIN.NumIndexObjectList.Value = MAIN.tilemap.Tiles[x, y].indexObjectList;
                        int actualtexture = MAIN.tilemap.GetMappedFloorTexture(TileMap.fSELF, MAIN.tilemap.Tiles[x, y]);
                        MAIN.LblMappedFloorTexture.Text = actualtexture.ToString()
                            + " " + MAIN.UWGameStrings.GetTextureName(actualtexture, main.curgame);
                    }
                }
            }
        }


        public static void PopulateWorldObjects(int index, main MAIN)
        {
            objects.ObjectInfo obj = MAIN.worldObjects.objList[index];
            MAIN.PopulateObjectUI(obj,
                MAIN.CmbWorldItem_ID, MAIN.ChkWorldEnchanted,
                MAIN.ChkWorldIsQuant, MAIN.ChkWorldDoorDir,
                MAIN.ChkWorldInvis, MAIN.NumWorldXPos,
                MAIN.NumWorldYPos, MAIN.NumWorldZpos,
                MAIN.NumWorldHeading, MAIN.NumWorldFlags,
                MAIN.NumWorldQuality, MAIN.NumWorldOwner,
                MAIN.NumWorldNext, MAIN.NumWorldLink);
        }


    }
}
