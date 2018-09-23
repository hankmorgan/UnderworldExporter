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
        //RenderForm form3d;
        public objects pdatObjects;
        public TileMap tilemap;
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
                    objects.ObjectInfo obj = pdatObjects.objList[index];
                    PopulateObjectUI(obj, CmbPdatItem_ID, ChkPdatEnchanted, ChkPdatIsQuant, ChkPdatDoorDir,ChkPdatInvis, NumPInvXpos, NumPInvYPos,NumPInvZpos,NumPInvHeading,NumPdatFlags,NumPdatQuality,NumPdatOwner,NumPdatNext,NumPdatLink  );
                }
            }
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

        private void loadPlayerDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerDatUI.LoadUW1PDat(this);
        }

        private void writePlayerDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] buffer = PlayerDatUI.GetValuesFromPDatGrid(this);
            playerdat.EncryptDecryptUW1(buffer, buffer[0]);
            Util.WriteStreamFile("c:\\games\\uw1\\save1\\PLAYER.DAT", buffer);
        }

        private void loadPlayerDatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PlayerDatUI.LoadUW2PDat(this);
        }
        
        private void writePlayerDatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            char[] buffer = PlayerDatUI.GetValuesFromPDatGrid(this);
            buffer = playerdat.EncryptDecryptUW2(buffer, (byte)buffer[0]);
            Util.WriteStreamFile("c:\\games\\uw2\\save1\\PLAYER.DAT", buffer);
        }

        private void LoadLevArkUW1_Click(object sender, EventArgs e)
        {
            curgame = 1;
            if (Util.ReadStreamFile("c:\\games\\uw1\\data\\lev.ark", out levarkbuffer))
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
                    if (Util.LoadUWBlock(levarkbuffer, i, Util.UWBlockSizes(i), out uwblocks[i], 1))
                    {
                        uwblocks[i].ContentType = Util.GetUW1LevArkContentType(i);
                        TreeNode node;
                        switch (uwblocks[i].ContentType)
                        {
                            case Util.ContentTypes.AnimationOverlay:
                                node = OverlayMapNodes.Nodes.Add("Block #" + i); break;
                            case Util.ContentTypes.AutoMap:
                                node = AutoMapNodes.Nodes.Add("Block #" + i); break;
                            case Util.ContentTypes.AutoMapNotes:
                                node = AutoMapNotesNodes.Nodes.Add("Block #" + i); break;
                            case Util.ContentTypes.TextureMap:;
                                node = TextureMapNodes.Nodes.Add("Block #" + i); break;
                            case Util.ContentTypes.TileMap:
                            default:
                                node = TileMapNodes.Nodes.Add("Block #" + i);break;
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
            curgame = main.GAME_UW1;

            PaletteLoader.LoadPalettes("c:\\games\\uw1\\data\\pals.dat");
            PicPalette.Image = ArtLoader.Palette(PaletteLoader.Palettes[0]);

            PopulateTextureTree();

        }

        private void loadStringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UWGameStrings = new UWStrings();
            UWGameStrings.LoadStringsPak("c:\\games\\uw1\\data\\strings.pak", 1, GrdStrings);
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

            TreeNode texnode = TreeArt.Nodes.Add("Textures");
            TreeNode walltex = texnode.Nodes.Add("Wall Textures");
            int noofwalltex = 210;
            for (int i = 0; i < noofwalltex; i++)
            {
                TreeNode newnode = walltex.Nodes.Add("#" + i);
                newnode.Tag = i;
            }
            TreeNode floortex = texnode.Nodes.Add("Floor Textures");
        }

        private void ImgOut_MouseClick(object sender, MouseEventArgs e)
        {
            if (CurrentImageNo!=-1)
            {
                // MessageBox.Show(e.Location.X / 4 +","+ (ImgOut.Height-e.Location.Y) / 4);
                int x = e.Location.X / 4;
                int y = ( e.Location.Y) / 4;
                ArtUI.setPixelAtLocation(tex, CurrentImageNo, ImgOut, x, y, CurrentPalettePixel);
            }
        }

        private void BtnImgSave_Click(object sender, EventArgs e)
        {
            ArtUI.SaveData(tex.texturebufferW);
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
    }
}
