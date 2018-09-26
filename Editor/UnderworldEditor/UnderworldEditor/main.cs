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
        public const int GAME_UW1 = 1;
        public const int GAME_UW2 = 2;
        public static bool isLoading = false;
        public const int InventoryOffsetUW1 = 0x138;
        public const int InventoryOffsetUW2 = 0x3E3;
        public const int InventorySlotOffsetUW1 = 0xf8;
        public const int InventorySlotOffsetUW2 = 0x3A3;
        public const int SkillsOffsetUW1 = 0x1F;
        public const int SkillsOffsetUW2 = 31;

        public Util.UWBlock[] uwblocks;
        public char[] levarkbuffer;
        public static int curgame;
        public static string basepath;
        public static int curslot=-1;

        //RenderForm form3d;
        public objects pdatObjects;
        public TileMap tilemap;
        public int curTileX; public int curTileY;
        public int CurPDatObject;
        public int CurWorldObject;

        public objects worldObjects;
        public UWStrings UWGameStrings;

        TextureLoader tex = new TextureLoader();
        private int CurrentImageNo;
        private int CurrentPalettePixel=0;

        public main()
        {
            InitializeComponent();    
        }

        public static void PopulateItemIDList(ComboBox cmb)
        {
        for (int i =0; i<=464;i++)
            {
                cmb.Items.Add(i + "-" + objects.ObjectName(i, curgame));
            }
        }     

        private void txtCharName_TextChanged(object sender, EventArgs e)
        {
            PlayerDatUI.ChangeCharName(this);
        } 
        
        private void GrdPlayerDat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isLoading)
            {
                DataGridView senderGrid = (DataGridView)sender;
                if (e.RowIndex >= 0)
                {
                    isLoading = true;
                    PlayerDatUI.PopulateUI(PlayerDatUI.GetValuesFromPDatGrid(this), pdatObjects.objList, this);
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
                    isLoading = true;
                    CurPDatObject = index;
                    objects.ObjectInfo obj = pdatObjects.objList[index];
                    PopulateObjectUI(obj, CmbPdatItem_ID, ChkPdatEnchanted, ChkPdatIsQuant, ChkPdatDoorDir,ChkPdatInvis, NumPInvXpos, NumPInvYPos,NumPInvZpos,NumPInvHeading,NumPdatFlags,NumPdatQuality,NumPdatOwner,NumPdatNext,NumPdatLink  );
                    isLoading = false;
                }
            }
        }


        public void UpdateObjectUIChange(char[] TileMapData, objects.ObjectInfo obj,
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
            //Update the object with the selected info
            obj.item_id = cmbItem_ID.SelectedIndex;
            cmbItem_ID.Text = obj.item_id + "-" + objects.ObjectName(obj.item_id, curgame);

            if (chkEnchanted.Checked) { obj.enchantment = 1; } else { obj.enchantment = 0; }
            if (chkIsQuant.Checked) { obj.is_quant = 1; } else { obj.is_quant = 0; };
            if (chkDoorDir.Checked) { obj.doordir = 1; } else { obj.doordir = 0; };
            if (chkInvis.Checked) { obj.invis = 1; } else { obj.invis = 0; };

            obj.xpos = (short)numXpos.Value ;
            obj.ypos = (short)numYpos.Value ;
            obj.zpos= (short)numZpos.Value;
            obj.heading= (short)numHeading.Value;

            obj.flags= (short)numFlags.Value;
            obj.quality= (short)numQuality.Value;
            obj.owner= (short)numOwner.Value;
            obj.next= (short)numNext.Value;
            obj.link= (short)numLink.Value  ;
            long addptr = obj.FileAddress;
            int ByteToWrite = (obj.is_quant << 15) |
                (obj.invis << 14) |
                (obj.doordir << 13) |
                (obj.enchantment << 12) |
                ((obj.flags & 0x07) << 9) |
                (obj.item_id & 0x1FF);

            TileMapData[addptr] = (char)(ByteToWrite & 0xFF);
            TileMapData[addptr + 1] = (char)((ByteToWrite >> 8) & 0xFF);

            ByteToWrite = ((obj.xpos & 0x7) << 13) |
                    ((obj.ypos & 0x7) << 10) |
                    ((obj.heading & 0x7) << 7) |
                    ((obj.zpos & 0x7F));
            TileMapData[addptr + 2] = (char)(ByteToWrite & 0xFF);
            TileMapData[addptr + 3] = (char)((ByteToWrite >> 8) & 0xFF);

            ByteToWrite = (((int)obj.next & 0x3FF) << 6) |
                    (obj.quality & 0x3F);
            TileMapData[addptr + 4] = (char)(ByteToWrite & 0xFF);
            TileMapData[addptr + 5] = (char)((ByteToWrite >> 8) & 0xFF);

            ByteToWrite = ((obj.link & 0x3FF) << 6) |
                    (obj.owner & 0x3F);
            TileMapData[addptr + 6] = (char)(ByteToWrite & 0xFF);
            TileMapData[addptr + 7] = (char)((ByteToWrite >> 8) & 0xFF);
        }

        public void PopulateObjectUI(objects.ObjectInfo obj, 
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



        private void TreeUWBlocks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }
            int blockno = int.Parse(e.Node.Tag.ToString());
            GrdLevArkRaw.Rows.Clear();            
            switch (uwblocks[blockno].ContentType)
            {
                case Util.ContentTypes.TileMap:                    
                    TileMapUI.LoadTileMap(blockno,this);
                    break;
                default:
                    FillRawDataForLevArk(blockno);//no raw data loaded for tilemap due to slow loading speed
                    break;
            }            
        }

        private void FillRawDataForLevArk(int blockno)
        {
            for (int i = 0; i <= uwblocks[blockno].Data.GetUpperBound(0); i++)
            {
                int rowId = GrdLevArkRaw.Rows.Add();
                DataGridViewRow row = GrdLevArkRaw.Rows[rowId];
                row.Cells[0].Value = (int)uwblocks[blockno].Data[i];
            }
        }

        private void TreeTiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TileMapUI.LoadTileInfoFromSelectedNode(this);
        }

        private void writePlayerDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] buffer = PlayerDatUI.GetValuesFromPDatGrid(this);
            playerdat.EncryptDecryptUW1(buffer, buffer[0]);
            Util.WriteStreamFile(main.basepath + "\\save"+ curslot + "\\PLAYER.DAT", buffer);
        }

        
        private void writePlayerDatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            char[] buffer = PlayerDatUI.GetValuesFromPDatGrid(this);
            buffer = playerdat.EncryptDecryptUW2(buffer, (byte)buffer[0]);
            Util.WriteStreamFile(main.basepath + "\\save" + curslot + "\\PLAYER.DAT", buffer);
        }

        private void LoadUWLevArk(int option)
        {
            string filename = "\\save" + option + "\\lev.ark";
            switch (option)
            {
                case 0:
                default:
                    filename = "\\data\\lev.ark";
                    break;
            }

            if (UWGameStrings == null)
            {
                UWGameStrings = new UWStrings();
                UWGameStrings.LoadStringsPak(main.basepath + "\\data\\strings.pak", 1, GrdStrings);
            }
            if (Util.ReadStreamFile(main.basepath + filename, out levarkbuffer))
            {
                int NoOfBlocks = (int)Util.getValAtAddress(levarkbuffer, 0, 16);
                uwblocks = new Util.UWBlock[NoOfBlocks];
                TreeUWBlocks.Nodes.Clear();
                TreeNode TileMapNodes = TreeUWBlocks.Nodes.Add("Tilemaps");
                TreeNode OverlayMapNodes = TreeUWBlocks.Nodes.Add("Overlays");
                TreeNode TextureMapNodes = TreeUWBlocks.Nodes.Add("TextureMaps");
                TreeNode AutoMapNodes = TreeUWBlocks.Nodes.Add("AutoMaps");
                TreeNode AutoMapNotesNodes = TreeUWBlocks.Nodes.Add("AutoMapNotes");//These are variable sizes
                for (int i = 0; i <= uwblocks.GetUpperBound(0); i++)
                {
                    if (Util.LoadUWBlock(levarkbuffer, i, Util.UWBlockSizes(i), out uwblocks[i]))
                    {
                        uwblocks[i].ContentType = Util.GetUWLevArkContentType(i);
                        TreeNode node;
                        switch (uwblocks[i].ContentType)
                        {
                            case Util.ContentTypes.AnimationOverlay:
                                node = OverlayMapNodes.Nodes.Add("Block #" + i); break;
                            case Util.ContentTypes.AutoMap:
                                node = AutoMapNodes.Nodes.Add("Block #" + i); break;
                            case Util.ContentTypes.AutoMapNotes:
                                node = AutoMapNotesNodes.Nodes.Add("Block #" + i); break;
                            case Util.ContentTypes.TextureMap:
                                node = TextureMapNodes.Nodes.Add("Block #" + i); break;
                            case Util.ContentTypes.TileMap:
                            default:
                                node = TileMapNodes.Nodes.Add("Block #" + i); break;
                        }
                        node.Tag = i;
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
                    TileMapUI.PopulateWorldObjects(index,this);
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
                    TileMapUI.PopulateWorldObjects(index, this);
                }
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            FrmSelect frm = new FrmSelect();
            frm.ShowDialog();
            PaletteLoader.LoadPalettes(main.basepath + "\\data\\pals.dat");
            PicPalette.Image = ArtLoader.Palette(PaletteLoader.Palettes[0]);
            PopulateTextureTree();

        }


        private void TreeArt_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = TreeArt.SelectedNode;
            CurrentImageNo = -1;
            int index;
            if (node.Tag == null) { return; }
            if (int.TryParse(node.Tag.ToString(), out index))
            {
               ImgOut.Image = tex.LoadImageAt(index);
               CurrentImageNo = index;
            }
        }

        private void PopulateTextureTree()
        {
            TreeArt.Nodes.Clear();
            switch (curgame)
            {
                case GAME_UW1:
                    {
                        TreeNode texnode = TreeArt.Nodes.Add("Textures");
                        TreeNode walltex = texnode.Nodes.Add("Wall Textures");
                        int noofwalltex = 210;
                        for (int i = 0; i < noofwalltex; i++)
                        {
                            TreeNode newnode = walltex.Nodes.Add("#" + i);
                            newnode.Tag = i;
                        }
                        TreeNode floortex = texnode.Nodes.Add("Floor Textures");
                        for (int i = 210; i <= 260; i++)
                        {
                            TreeNode newnode = floortex.Nodes.Add("#" + i);
                            newnode.Tag = i;
                        }
                        break;
                    }
                case GAME_UW2:
                    {
                        TreeNode texnode = TreeArt.Nodes.Add("Textures");
                        int noofwalltex = 256;
                        for (int i = 0; i < noofwalltex; i++)
                        {
                            TreeNode newnode = texnode.Nodes.Add("#" + i);
                            newnode.Tag = i;
                        }
                        break;
                    }
            }

        }

        private void ImgOut_MouseClick(object sender, MouseEventArgs e)
        {
            int factor = 4;
            if (CurrentImageNo!=-1)
            {
                if (main.curgame==GAME_UW1)
                {
                    if (CurrentImageNo>=210)
                    {//Editing a 32x32 floor texture
                        factor = 8;
                    }
                }
                // MessageBox.Show(e.Location.X / 4 +","+ (ImgOut.Height-e.Location.Y) / 4);
                int x = e.Location.X / factor;
                int y = ( e.Location.Y) / factor;
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y, CurrentPalettePixel);
            }
        }

        private void BtnImgSave_Click(object sender, EventArgs e)
        {
            switch (main.curgame)
            {
                case GAME_UW1:
                    ArtUI.SaveTextureData(tex.texturebufferW,true);
                    ArtUI.SaveTextureData(tex.texturebufferF,false);
                    break;
                case GAME_UW2:
                    ArtUI.SaveTextureData(tex.texturebufferW,false);
                    break;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Turns the selected image int a representation of the palette
            int x = 0;int y = 0;
            for (int counter = 0; counter < 256; counter++)
            {
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y+1, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y+2, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y+3, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 4, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 5, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 6, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 7, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y+8, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 9, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 10, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 11, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 12, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 13, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 14, counter);
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y + 15, counter);

                x++;
                if (x >= 64)
                {
                    x = 0;
                    y = y +16;
                }
            }
        }

        private void PicPalette_MouseClick(object sender, MouseEventArgs e)
        {
           // int x = e.Location.X / 4;
            //int y = (e.Location.Y) / 4;
            CurrentPalettePixel = e.Location.X / 2;
        }


        private void BtnSaveTileMap_Click(object sender, EventArgs e)
        {
            Util.WriteStreamFile("c:\\games\\uw1\\save1\\lev.ark", levarkbuffer);
        }

        private void BtnApplyTileChanges_Click(object sender, EventArgs e)
        {
            TileMapUI.ApplyTileChanges(curTileX, curTileY, this);
        }

        private void loadStringsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (UWGameStrings == null)
            {
                UWGameStrings = new UWStrings();
                UWGameStrings.LoadStringsPak("c:\\games\\uw2\\data\\strings.pak", 1, GrdStrings);
            }
        }

        private void PInvValueChanged(object sender, EventArgs e)
        {
            if (isLoading) { return; }
            //Update object at address
            char[] buffer= PlayerDatUI.GetValuesFromPDatGrid(this);
            UpdateObjectUIChange(buffer, pdatObjects.objList[CurPDatObject], CmbPdatItem_ID, ChkPdatEnchanted, ChkPdatIsQuant, ChkPdatDoorDir, ChkPdatInvis, NumPInvXpos, NumPInvYPos, NumPInvZpos, NumPInvHeading, NumPdatFlags, NumPdatQuality, NumPdatOwner, NumPdatNext, NumPdatLink);
            isLoading = true;
            PlayerDatUI.PopulatePDatValuesToGrid(buffer, this);
            isLoading = false;
        }

        private void slot1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curgame==GAME_UW1)
            {
                PlayerDatUI.LoadUW1PDat(this, 1);
            }
            else
            {
                PlayerDatUI.LoadUW2PDat(this, 1);
            }           
        }

        private void slot2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curgame == GAME_UW1)
            {
                PlayerDatUI.LoadUW1PDat(this, 2);
            }
            else
            {
                PlayerDatUI.LoadUW2PDat(this, 2);
            }
        }

        private void slot3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curgame == GAME_UW1)
            {
                PlayerDatUI.LoadUW1PDat(this, 3);
            }
            else
            {
                PlayerDatUI.LoadUW2PDat(this, 3);
            }
        }

        private void slot4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curgame == GAME_UW1)
            {
                PlayerDatUI.LoadUW1PDat(this, 4);
            }
            else
            {
                PlayerDatUI.LoadUW2PDat(this, 4);
            }
        }

 
        private void stringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UWGameStrings = new UWStrings();
            UWGameStrings.LoadStringsPak(main.basepath + "\\data\\strings.pak", curgame, GrdStrings);
        }

        private void dataLevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(0);
        }

        private void save1LevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(1);
        }

        private void save2LevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(2);
        }

        private void save3LevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(3);
        }

        private void save4LevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(4);
        }

        private void repackUW2DataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (main.curgame==GAME_UW2)
            {
                //TODO: port file repacker utililty.
                //Create a new uwblocks array of size 320
                //Uncompress the first 80 and store appropiate flags
                //Copy the remaining 240 blocks.
                //Recalculate the block addresses for all blocks
                //Write all data to file.
                //Sounds easy doesn't it.
            }
        }
    }
}
