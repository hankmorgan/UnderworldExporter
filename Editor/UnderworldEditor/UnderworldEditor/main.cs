using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UnderworldEditor
{
    public partial class main : Form
    {
        const int GAME_UW1 = 1;
        const int GAME_UW2 = 2;
        bool isLoading = false;
        const int InventoryOffsetUW1 = 0x138;
        const int InventoryOffsetUW2 = 0x3E3;
        const int InventorySlotOffsetUW1 = 0xf8;
        const int InventorySlotOffsetUW2 = 0x3A3;
        const int SkillsOffsetUW1 = 0x1F;
        const int SkillsOffsetUW2 = 31;

        Util.UWBlock[] uwblocks;
        char[] levarkbuffer;
        int curgame;
        //RenderForm form3d;
        private objects pdatObjects;
        private TileMap tilemap;
        private objects worldObjects;

        public main()
        {
            //form3d = new RenderForm("SharpDX - MiniCube Direct3D11");
            //form3d.ClientSize = new Size(1024, 1024);
            InitializeComponent();           

        }




        void PopulateItemIDList(int game)
        {
        for (int i =0; i<=464;i++)
            {
                CmbPdatItem_ID.Items.Add(i + "-" + objects.ObjectName(i,game));
            }

        }

        private void PopulateUI(char[] buffer,int game, objects.ObjectInfo[] objList)
        {
            PopulateCharName(buffer);
            PopulateStats(buffer, game);
            PopulateInventory(buffer, game, objList);
        }

        private void PopulateInventory(char[] buffer, int game, objects.ObjectInfo[] objList)
        {
            int offset = InventorySlotOffsetUW1;
            TreeInventory.Nodes.Clear();
            if (game==GAME_UW2)
            { offset = InventorySlotOffsetUW2; }
           
            TreeNode tvn = TreeInventory.Nodes.Add("Helm");
            int objIndex = (int)Util.getValAtAddress(buffer, offset+0, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Chest");
            objIndex = (int)Util.getValAtAddress(buffer, offset +2, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Gloves");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 4, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Leggings");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 6, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Boots");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 8, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Right Shoulder");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 10, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Left Shoulder");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 12, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Right Hand");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 14, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Left Hand");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 16, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Right Ring");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 18, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("Left Ring");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 20, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = TreeInventory.Nodes.Add("BackPack0");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 22, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = TreeInventory.Nodes.Add("BackPack1");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 24, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = TreeInventory.Nodes.Add("BackPack2");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 26, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = TreeInventory.Nodes.Add("BackPack3");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 28, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = TreeInventory.Nodes.Add("BackPack4");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 30, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = TreeInventory.Nodes.Add("BackPack5");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 32, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = TreeInventory.Nodes.Add("BackPack6");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 34, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = TreeInventory.Nodes.Add("BackPack7");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 36, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
        }

        void PopulateInventoryNode(TreeNode node, int index, objects.ObjectInfo[] objList)
        {
            if (index!=0)
            {
                TreeNode newnode = node.Nodes.Add(objects.ObjectName(objList[index].item_id, curgame));
                newnode.Tag = index;
                if (objects.isContainer(objList[index].item_id))
                {
                    PopulateLinkedInventoryNode(newnode, objList[index].link, objList);
                }
                else
                {
                    PopulateInventoryMagicLink(newnode, index,objList);
                }
            }
        }

        void PopulateWorldNode(TreeNode node, int index, objects.ObjectInfo[] objList)
        {           
            while (index!=0)
            {
                TreeNode newnode = node.Nodes.Add(index + ". " +objects.ObjectName(objList[index].item_id, curgame));
                newnode.Tag = index;
                if (objects.isContainer(objList[index].item_id))
                {
                    PopulateLinkedInventoryNode(newnode, objList[index].link, objList);
                }
                index = objList[index].next;
                //else
                //{
                //    PopulateInventoryMagicLink(newnode, index, objList);
                //}
            }
        }


        void PopulateLinkedInventoryNode(TreeNode node, int index, objects.ObjectInfo[] objList)
        {
            while (index!=0)
            {
                TreeNode newnode = node.Nodes.Add(objects.ObjectName(objList[index].item_id, curgame));
                newnode.Tag = index;
                if (objects.isContainer(objList[index].item_id))
                {
                    PopulateLinkedInventoryNode(newnode, objList[index].link,objList);
                }
                else
                {
                    PopulateInventoryMagicLink(newnode, index, objList);
                }
                index = objList[index].next;
            }
        }

        private void PopulateInventoryMagicLink(TreeNode node, int index, objects.ObjectInfo[] objList)
        {
            //if (objects.objList[index].enchantment == 1 && objects.objList[index].is_quant == 0)
            if ((objList[index].is_quant == 0) && (objList[index].link > 0))
            {
                int linked = objList[index].link;
                if (linked <= objList.GetUpperBound(0))
                {
                    TreeNode newnode =node.Nodes.Add(objects.ObjectName(objList[linked].item_id, curgame));
                    newnode.Tag = index;
                }
            }
        }

        private void PopulateCharName(char[] buffer)
        {
            TxtCharName.Text = "";
            for (int i = 1; i < 14; i++)
            {
            TxtCharName.Text = TxtCharName.Text + buffer[i].ToString();
            }
        }

        private void PopulateStats(char[] buffer,int game)
        {
            int charclassdetails = 0;
            switch (game)
            {
                //Unique values
                case GAME_UW1://uw1
                    {
                        charclassdetails = (int)Util.getValAtAddress(buffer, 0x65, 8);
                        PopulateSkillsGrid(game, SkillsOffsetUW1);
                        ChkDifficulty.Checked = ((int)Util.getValAtAddress(buffer, 0xB5, 8) & 0x1) == 1;
                        break;
                    }//end switch uw1
                case GAME_UW2:
                    {
                        charclassdetails = (int)Util.getValAtAddress(buffer, 0x66, 8);
                        PopulateSkillsGrid(game, SkillsOffsetUW2);
                        ChkDifficulty.Checked = ((int)Util.getValAtAddress(buffer, 0x302, 8)  & 0x1) == 1;
                        break;
                    }//end switch uw2
            }
            //Common values
            NumEXP.Value = Util.getValAtAddress(buffer, 0x4F, 32) / 10;
            NumCurHP.Value = Util.getValAtAddress(buffer, 0x36, 8);
            NumMaxHP.Value = Util.getValAtAddress(buffer, 0x37, 8);
            NumCurMana.Value = Util.getValAtAddress(buffer, 0x38, 8);
            NumMaxMana.Value = Util.getValAtAddress(buffer, 0x39, 8);
            NumFatigue.Value = Util.getValAtAddress(buffer, 0x3A, 8);
            NumHunger.Value= Util.getValAtAddress(buffer, 0x3B, 8);
            NumCharLevel.Value = Util.getValAtAddress(buffer, 0x3E, 8);
            NumSkillPoints.Value = Util.getValAtAddress(buffer, 0x53, 8);
            NumPDatXPos.Value = Util.getValAtAddress(buffer, 0x56, 16);
            NumPDatYPos.Value = Util.getValAtAddress(buffer, 0x58, 16);
            NumPDatZPos.Value = Util.getValAtAddress(buffer, 0x5A, 16);
            NumPDatHeading.Value = Util.getValAtAddress(buffer, 0x5C, 8);
            NumDungeonLevel.Value = Util.getValAtAddress(buffer, 0x5D, 8);
            PopulateCharClass(charclassdetails);            
        }

        void PopulateCharClass(int classdetails)
        {
            //bit 1 = hand left/right
            //bit 2-5 = gender & body
            //bit 6-8 = class
            ChkLeftHanded.Checked = ((classdetails & 0x1) == 0);
            int bodyval = ((int)classdetails >> 1) & 0xf;
            if (bodyval % 2 == 0)
            {
                //male 0,2,4,6,8
                ChkIsFemale.Checked = false;
                //Body
                NumBody.Value = bodyval / 2;
            }
            else
            {
                //female=1,3,5,7,9
                ChkIsFemale.Checked = true;
                NumBody.Value = (bodyval - 1) / 2;
            }
            //class
          switch( classdetails >> 5)
            {
                case 0:
                    CmbCharClass.Text = "Fighter"; break;
                case 1:
                    CmbCharClass.Text = "Mage"; break;
                case 2:
                    CmbCharClass.Text = "Bard"; break;
                case 3:
                    CmbCharClass.Text = "Tinker"; break;
                case 4:
                    CmbCharClass.Text = "Druid"; break;
                case 5:
                    CmbCharClass.Text = "Paladin"; break;
                case 6:
                    CmbCharClass.Text = "Ranger"; break;
                case 7:
                    CmbCharClass.Text = "Shepard"; break;
            }

        }

        private void PopulateSkillsGrid(int game, int offset)
        {
            GrdSkills.Rows.Clear();
            for (int i = 0; i <= 22; i++)
            {
                //add rows
                int rowId = GrdSkills.Rows.Add();
                DataGridViewRow row = GrdSkills.Rows[rowId];
                if (game==GAME_UW1)
                {
                    row.Cells[0].Value = PlayerDatNames.UW1FieldName(offset + i);
                }
                else
                {
                    row.Cells[0].Value = PlayerDatNames.UW2FieldName(offset + i);
                }                
                row.Cells[1].Value = GrdPlayerDat.Rows[offset + i].Cells[0].Value;
            }
        }

        private void PopulateValuesToGrid(char[] buffer, int game)
        {            
            GrdPlayerDat.Rows.Clear();           
            for (int i = 0; i <= buffer.GetUpperBound(0); i++)
            {
                int rowId = GrdPlayerDat.Rows.Add();
                DataGridViewRow row = GrdPlayerDat.Rows[rowId];
                row.Cells[0].Value = (int)buffer[i];
                row.HeaderCell.Value = playerdat.FieldName(i, game);
            }              
        }

        private void PopulateInventorySelectButtons(int Offset)
        {
            if (GrdPlayerDat.Rows.Count>Offset)
            {
                int objectCount = 1;
                for (int i = Offset; i< GrdPlayerDat.Rows.Count;i++)
                {
                    if ((i-Offset) % 8 == 0)
                    {
                        GrdPlayerDat.Rows[i].Cells[1] = new DataGridViewButtonCell();
                        DataGridViewButtonCell btn = (DataGridViewButtonCell)(GrdPlayerDat.Rows[i].Cells[1]);
                        btn.Value = objectCount++;
                        btn.Tag = i;
                    }
                }
            }
        }


        /// <summary>
        /// Get the list of values in the grid and store in a char array.
        /// </summary>
        /// <returns></returns>
        private char[] GetValuesFromGrid()
        {
            char[] buffer = new char[GrdPlayerDat.Rows.Count];
            for (int i = 0; i <= buffer.GetUpperBound(0); i++)
            {
                int val;
                if (int.TryParse(GrdPlayerDat.Rows[i].Cells[0].Value.ToString(), out val))
                {
                    val = val & 0xff;
                    buffer[i] = (char)val;
                }
                else
                {
                    buffer[i] = (char)0;
                }
            }
            return buffer;
        }

        private void txtCharName_TextChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                Debug.Print(TxtCharName.Text);
                char[] namechars = TxtCharName.Text.ToCharArray();
                for (int i =0; i<13;i++)
                {
                    if (namechars.GetUpperBound(0)>=i)
                    {
                        GrdPlayerDat.Rows[i + 1].Cells[0].Value =(int)namechars[i] ;
                    }
                    else
                    {
                        GrdPlayerDat.Rows[i + 1].Cells[0].Value= 0;

                    }
                }
            }           
        }

        private void grdPlayerDat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            if (e.RowIndex < 0) { return; }
            if (senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                DataGridViewButtonCell btn = (DataGridViewButtonCell)senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                MessageBox.Show(btn.Tag.ToString());
            }
        }

        private void GrdPlayerDat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isLoading)
            {
                DataGridView senderGrid = (DataGridView)sender;
                if (e.RowIndex >= 0)
                {
                    isLoading = true;
                    PopulateUI(GetValuesFromGrid(), curgame, pdatObjects.objList);
                    isLoading = false;
                }
            }
        }

        private void TreeInventory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = TreeInventory.SelectedNode;
            int index;
            if (node.Tag == null) { return; }
            if (int.TryParse(node.Tag.ToString(), out index))
            {                
                if (index>0)
                {
                    objects.ObjectInfo obj = pdatObjects.objList[index];
                    PopulateObjectUI(obj, CmbPdatItem_ID, ChkPdatEnchanted, ChkPdatIsQuant, ChkPdatDoorDir,ChkPdatInvis, NumPInvXpos, NumPInvYPos,NumPInvZpos,NumPInvHeading,NumPdatFlags,NumPdatQuality,NumPdatOwner,NumPdatNext,NumPdatLink  );
                }
            }
        }

        private void PopulateObjectUI(objects.ObjectInfo obj, 
            ComboBox cmbItem_ID, 
            CheckBox chkEnchanted,
            CheckBox chkIsQuant,
            CheckBox chkDoorDir,
            CheckBox chkInvis,
            NumericUpDown numXpos,
            NumericUpDown numYpos,
            NumericUpDown numZpos,
            NumericUpDown numHeading,
            NumericUpDown numFlags,
            NumericUpDown numQuality,
            NumericUpDown numOwner,
            NumericUpDown numNext,
            NumericUpDown numLink
            )
        {
            cmbItem_ID.Text = obj.item_id + "-" + objects.ObjectName(obj.item_id, curgame);

            chkEnchanted.Checked = (obj.enchantment == 1);
            chkIsQuant.Checked = (obj.is_quant == 1);
            chkDoorDir.Checked = (obj.doordir == 1);
            chkInvis.Checked = (obj.invis == 1);

            numXpos.Value = obj.xpos;
            numYpos.Value = obj.ypos;
            numZpos.Value = obj.zpos;
            numHeading.Value = obj.heading;

            numFlags.Value = obj.flags;
            numQuality.Value = obj.quality;
            numOwner.Value = obj.owner;
            numNext.Value = obj.next;
            numLink.Value = obj.link;
        }

         int UWBlockSizes(int blockNo)
        {
            if (blockNo<=8)
            {
                return 0x7c06;
            }
            else
            { return 0; }
        }

        private void TreeUWBlocks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int blockno = int.Parse(e.Node.Tag.ToString());
            GrdLevArkRaw.Rows.Clear();
            tilemap = new TileMap();            
            tilemap.InitTileMap(uwblocks[blockno].Data, 0);
            //////for (int i = 0; i <= uwblocks[blockno].Data.GetUpperBound(0); i++)
            //////{
            //////    int rowId = GrdLevArkRaw.Rows.Add();
            //////    DataGridViewRow row = GrdLevArkRaw.Rows[rowId];
            //////    row.Cells[0].Value = (int)uwblocks[blockno].Data[i];
            //////}
            //Temporarily output to treeview for testing.
            TreeTiles.Nodes.Clear();
            for (int x=0; x<=63;x++)
            {
                TreeNode xnode = TreeTiles.Nodes.Add("X=" + x);
                for (int y = 0; y <= 63; y++)
                {
                    TreeNode ynode = xnode.Nodes.Add("Y=" + y);
                    ynode.Tag = x + "," + y;
                }
            }

            worldObjects = new objects();
            worldObjects.InitWorldObjectList(uwblocks[blockno].Data, 64*64*4);
            TreeWorldObjects.Nodes.Clear();
            for (int i=0; i<=worldObjects.objList.GetUpperBound(0);i++)
            {
                TreeNode newnode = TreeWorldObjects.Nodes.Add(i + ". " + objects.ObjectName(worldObjects.objList[i].item_id,curgame));
                 newnode.Tag = i;
            }

            TreeWorldByTile.Nodes.Clear();
            for (int x = 0; x <= 63; x++)
            {
                
                for (int y = 0; y <= 63; y++)
                {
                    if (tilemap.Tiles[x,y].indexObjectList!=0)
                    {
                        TreeNode xynode = TreeWorldByTile.Nodes.Add(x + "," + y);
                        PopulateWorldNode(xynode, tilemap.Tiles[x, y].indexObjectList, worldObjects.objList);
                    }
                }
            }
        }

        private void TreeTiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TreeTiles.SelectedNode.Tag !=null)
            {
                //Load tile info for tagged value.
                string X = TreeTiles.SelectedNode.Tag.ToString().Split(',')[0];
                string Y = TreeTiles.SelectedNode.Tag.ToString().Split(',')[1];
                int x; int y;
                if (int.TryParse(X,out x))
                {
                    if (int.TryParse(Y, out y))
                    {
                        lblCurrentTile.Text = "Current Tile " + x + "," + y + " " + TreeTiles.SelectedNode.Tag.ToString();
                        CmbTileType.Text = TileMap.GetTileTypeText(tilemap.Tiles[x, y].tileType);
                        NumFloorHeight.Value = tilemap.Tiles[x, y].floorHeight;
                        NumFloorTexture.Value = tilemap.Tiles[x, y].floorTexture;
                        NumWallTexture.Value = tilemap.Tiles[x, y].wallTexture;
                        NumIndexObjectList.Value = tilemap.Tiles[x, y].indexObjectList;
                    }
                }
            }
        }

        private void loadPlayerDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isLoading = true;
            curgame = GAME_UW1;
            char[] buffer = playerdat.LoadPlayerDatUW1("c:\\games\\uw1\\save1\\player.dat");
            PopulateValuesToGrid(buffer, curgame);
            pdatObjects = new objects();
            pdatObjects.InitInventoryObjectList(buffer, InventoryOffsetUW1);
            PopulateItemIDList(curgame);
            PopulateUI(buffer, curgame, pdatObjects.objList);
            isLoading = false;
        }

        private void writePlayerDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] buffer = GetValuesFromGrid();
            playerdat.EncryptDecryptUW1(buffer, buffer[0]);
            Util.WriteStreamFile("c:\\games\\uw1\\save1\\PLAYER.DAT", buffer);
        }

        private void loadPlayerDatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isLoading = true;
            curgame = GAME_UW2;
            char[] buffer = playerdat.LoadPlayerDatUW2("c:\\games\\uw2\\save1\\player.dat");
            PopulateValuesToGrid(buffer, curgame);
            PopulateItemIDList(curgame);
            pdatObjects = new objects();
            pdatObjects.InitInventoryObjectList(buffer, InventoryOffsetUW2);
            PopulateUI(buffer, curgame, pdatObjects.objList);
            //PopulateInventorySelectButtons(InventoryOffsetUW2);
            isLoading = false;
        }

        private void writePlayerDatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            char[] buffer = GetValuesFromGrid();
            buffer = playerdat.EncryptDecryptUW2(buffer, (byte)buffer[0]);
            Util.WriteStreamFile("c:\\games\\uw2\\save1\\PLAYER.DAT", buffer);
        }

        private void LoadLevArkUW1_Click(object sender, EventArgs e)
        {
            if (Util.ReadStreamFile("c:\\games\\uw1\\data\\lev.ark", out levarkbuffer))
            {
                int NoOfBlocks = (int)Util.getValAtAddress(levarkbuffer, 0, 16);
                uwblocks = new Util.UWBlock[NoOfBlocks];
                TreeUWBlocks.Nodes.Clear();
                for (int i = 0; i <= uwblocks.GetUpperBound(0); i++)
                {
                    if (i <= 8)
                    {
                        if (Util.LoadUWBlock(levarkbuffer, i, UWBlockSizes(i), out uwblocks[i], 1))
                        {
                            if (uwblocks[i].DataLen > 0)
                            {
                                TreeNode node = TreeUWBlocks.Nodes.Add("Block #" + i);
                                node.Tag = i;
                            }
                        }
                    }

                }
            }//end readstreamfile
        }

        private void TreeWorldObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = TreeWorldObjects.SelectedNode;
            int index;
            if (node.Tag == null) { return; }
            if (int.TryParse(node.Tag.ToString(), out index))
            {
                if (index > 0)
                {
                    objects.ObjectInfo obj = worldObjects.objList[index];
                    PopulateObjectUI(obj, 
                        CmbWorldItem_ID, ChkWorldEnchanted, 
                        ChkWorldIsQuant, ChkWorldDoorDir, 
                        ChkWorldInvis, NumWorldXPos,
                        NumWorldYPos, NumWorldZpos, 
                        NumWorldHeading, NumWorldFlags, 
                        NumWorldQuality, NumWorldOwner, 
                        NumWorldNext, NumWorldLink);
                }
            }
        }

        private void TreeWorldByTile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = TreeWorldByTile.SelectedNode;
            int index;
            if (node.Tag == null) { return; }
            if (int.TryParse(node.Tag.ToString(), out index))
            {
                if (index > 0)
                {
                    objects.ObjectInfo obj = worldObjects.objList[index];
                    PopulateObjectUI(obj,
                        CmbWorldItem_ID, ChkWorldEnchanted,
                        ChkWorldIsQuant, ChkWorldDoorDir,
                        ChkWorldInvis, NumWorldXPos,
                        NumWorldYPos, NumWorldZpos,
                        NumWorldHeading, NumWorldFlags,
                        NumWorldQuality, NumWorldOwner,
                        NumWorldNext, NumWorldLink);
                }
            }
        }
    }
}
