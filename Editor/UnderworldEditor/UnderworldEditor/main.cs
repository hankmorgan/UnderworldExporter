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
using System.IO;

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
        string curlevarkfile;
        public objects worldObjects;
        public UWStrings UWGameStrings;
        public GRLoader[] grfile =new GRLoader[33];
        public BytLoader[] bytfile;
        TextureLoader tex = new TextureLoader();
        public static BitmapUW CurrentImage;
        //private int CurrentImageNo;
        private int CurrentPalettePixel=0;



        public main()
        {
            InitializeComponent();    
        }

        /// <summary>
        /// Load events. Calls the file selection dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_Load(object sender, EventArgs e)
        {
            FrmSelect frm = new FrmSelect();
            frm.ShowDialog();
            PaletteLoader.LoadPalettes(main.basepath + "\\data\\pals.dat");
            PicPalette.Image = ArtLoader.Palette(PaletteLoader.Palettes[0]).image;
            PopulateTextureTree();
        }


        /// <summary>
        /// Initialise the list of object item names 
        /// </summary>
        /// <param name="cmb"></param>
        public static void PopulateItemIDList(ComboBox cmb)
        {
        for (int i =0; i<=464;i++)
            {
                cmb.Items.Add(i + "-" + objects.ObjectName(i, curgame));
            }
        }     

        /// <summary>
        /// Handle the changing of the character nae
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCharName_TextChanged(object sender, EventArgs e)
        {
            PlayerDatUI.ChangeCharName(this);
        } 
        
        /// <summary>
        /// Handles changes of raw data and reflect it back to the ui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Handles selection of an item in the inventory tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handles the change of object properties
        /// </summary>
        /// <param name="TileMapData"></param>
        /// <param name="obj"></param>
        /// <param name="cmbItem_ID"></param>
        /// <param name="chkEnchanted"></param>
        /// <param name="chkIsQuant"></param>
        /// <param name="chkDoorDir"></param>
        /// <param name="chkInvis"></param>
        /// <param name="numXpos"></param>
        /// <param name="numYpos"></param>
        /// <param name="numZpos"></param>
        /// <param name="numHeading"></param>
        /// <param name="numFlags"></param>
        /// <param name="numQuality"></param>
        /// <param name="numOwner"></param>
        /// <param name="numNext"></param>
        /// <param name="numLink"></param>
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

        /// <summary>
        /// Fill in the information for the references object information.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="cmbItem_ID"></param>
        /// <param name="chkEnchanted"></param>
        /// <param name="chkIsQuant"></param>
        /// <param name="chkDoorDir"></param>
        /// <param name="chkInvis"></param>
        /// <param name="numXpos"></param>
        /// <param name="numYpos"></param>
        /// <param name="numZpos"></param>
        /// <param name="numHeading"></param>
        /// <param name="numFlags"></param>
        /// <param name="numQuality"></param>
        /// <param name="numOwner"></param>
        /// <param name="numNext"></param>
        /// <param name="numLink"></param>
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


        /// <summary>
        /// Controls selection of a lev.ark block and view its content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Fills raw data to grid.
        /// </summary>
        /// <param name="blockno"></param>
        private void FillRawDataForLevArk(int blockno)
        {
            for (int i = 0; i <= uwblocks[blockno].Data.GetUpperBound(0); i++)
            {
                int rowId = GrdLevArkRaw.Rows.Add();
                DataGridViewRow row = GrdLevArkRaw.Rows[rowId];
                row.Cells[0].Value = (int)uwblocks[blockno].Data[i];
            }
        }

        /// <summary>
        /// Loads tile info.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeTiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TileMapUI.LoadTileInfoFromSelectedNode(this);
        }

        /// <summary>
        /// Saves the current uw1 save file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writePlayerDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] buffer = PlayerDatUI.GetValuesFromPDatGrid(this);
            playerdat.EncryptDecryptUW1(buffer, buffer[0]);
            Util.WriteStreamFile(main.basepath + "\\save"+ curslot + "\\PLAYER.DAT", buffer);
        }

        /// <summary>
        /// Saves the current uw2 save file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writePlayerDatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            char[] buffer = PlayerDatUI.GetValuesFromPDatGrid(this);
            buffer = playerdat.EncryptDecryptUW2(buffer, (byte)buffer[0]);
            Util.WriteStreamFile(main.basepath + "\\save" + curslot + "\\PLAYER.DAT", buffer);
        }

        /// <summary>
        /// Loads a lev.ark file from the game data or a save file
        /// </summary>
        /// <param name="option"></param>
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
                curlevarkfile = main.basepath + filename;
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
 
        /// <summary>
        /// Handles selection of a world object from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Handles selection of an object by tile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handles selection of an art file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeArt_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = TreeArt.SelectedNode;
            BtnRepack4Bit.Enabled = false;
            if (node.Parent!=null)
            {
                string partext = node.Parent.Text.ToUpper();
                switch(partext)
                {
                    case "TEXTURES":
                    case "WALL TEXTURES":
                    case "FLOOR TEXTURES":
                        {//loading a texture
                            int index;
                            if (node.Tag == null) { return; }
                            if (int.TryParse(node.Tag.ToString(), out index))
                            {
                                CurrentImage = tex.LoadImageAt(index);
                            }
                            break;
                        }
                    case "GRAPHIC RESOURCES":
                        {
                            int index;
                            if (node.Tag == null) { return; }
                            if (int.TryParse(node.Tag.ToString(), out index))
                            {
                                if (grfile[index]==null)
                                {//Load the gr file and populate the tree.
                                    grfile[index] = new GRLoader(main.basepath + "\\data\\" + node.Text);
                                    for (int i=0; i<=grfile[index].ImageCache.GetUpperBound(0);i++)
                                    {
                                        TreeNode img = node.Nodes.Add(i.ToString());
                                        img.Tag = i;
                                    }
                                }
                            }
                            break;
                        }
                    case "BITMAP RESOURCES":
                        {
                            int index;
                            if (node.Tag == null) { return; }
                            if (int.TryParse(node.Tag.ToString(), out index))
                            {
                                if (bytfile[index] == null)
                                {
                                    bytfile[index] = new BytLoader();
                                }
                                CurrentImage = bytfile[index].LoadImageAt(index);
                            }
                            break;
                        }
                    case "BYT.ARK":
                        {
                            int index;
                            if (node.Tag == null) { return; }
                            if (int.TryParse(node.Tag.ToString(), out index))
                            {
                                if (bytfile[0] == null)
                                {
                                    bytfile[0] = new BytLoader();
                                }
                                CurrentImage = bytfile[0].LoadImageAt(index);
                            }
                            break;
                        }
                    default:
                        if (partext.ToUpper().Contains(".GR"))
                        {
                            int parentindex;
                            if (node.Parent.Tag == null) { return; }
                            if (int.TryParse(node.Parent.Tag.ToString(), out parentindex))
                            {
                                int index;
                                if (node.Tag == null) { return; }
                                if (int.TryParse(node.Tag.ToString(), out index))
                                {
                                    //load the gr file
                                    CurrentImage = grfile[parentindex].LoadImageAt(index);
                                    switch (CurrentImage.ImageType)
                                    {
                                        case BitmapUW.ImageTypes.FourBitRunLength:
                                        case BitmapUW.ImageTypes.FourBitUncompress:
                                            BtnRepack4Bit.Enabled = true;
                                            break;
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            if (CurrentImage!=null)
            {
                ImgOut.Image = CurrentImage.image;
                PicPalette.Image = ArtLoader.Palette(CurrentImage.ImagePalette, CurrentImage.PaletteRef).image;
                ImgOut.Width = CurrentImage.image.Width * (int)NumZoom.Value;
                ImgOut.Height = CurrentImage.image.Height * (int)NumZoom.Value;
                LblImageDetails.Text = CurrentImage.image.Height + "x" + CurrentImage.image.Width + "\n" + CurrentImage.ImageType.ToString();
            }
        }

        /// <summary>
        /// Handles loading the selection lists for textures.
        /// </summary>
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
            //Add nodes for all .gr files
            TreeNode grhead = TreeArt.Nodes.Add("Graphic Resources");
            DirectoryInfo dir = new DirectoryInfo(basepath + "\\data");
            if (dir!=null)
            {
                FileInfo[] grFiles= dir.GetFiles("*.gr");
                for (int i = 0; i <= grFiles.GetUpperBound(0); i++)
                {
                    TreeNode gr = grhead.Nodes.Add(grFiles[i].Name);
                    gr.Tag = i;
                }
            }

            //Add nodes for all .byt files
            TreeNode grbyt = TreeArt.Nodes.Add("Bitmap Resources");
            if (main.curgame == main.GAME_UW1)
            {
                int NoOfBytFiles = 0;
                for (int i = 0; i <= BytLoader.FilePaths.GetUpperBound(0); i++)
                {
                    TreeNode gr = grbyt.Nodes.Add(BytLoader.FilePaths[i]);
                    gr.Tag = i;
                    NoOfBytFiles++;
                }
                bytfile = new BytLoader[NoOfBytFiles + 1];
            }
            if (main.curgame == main.GAME_UW2)
            {
                TreeNode gr = grbyt.Nodes.Add("BYT.ARK");
                for (int i=0; i<=9;i++)
                {
                    TreeNode grx = gr.Nodes.Add(i.ToString());
                    grx.Tag = i;
                }
                bytfile = new BytLoader[1];
            }
        }

        /// <summary>
        /// Handles the clicking of a pixel on the image display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgOut_MouseClick(object sender, MouseEventArgs e)
        {

            if (CurrentImage == null) { return; }



            //if (main.curgame==GAME_UW1)
            //{
            //    if (CurrentImageNo>=210)
            //    {//Editing a 32x32 floor texture
            //        factor = 8;
            //    }
            //}
            // MessageBox.Show(e.Location.X / 4 +","+ (ImgOut.Height-e.Location.Y) / 4);
            int x = (int)(e.Location.X / NumZoom.Value);
            int y = (int)(( e.Location.Y) / NumZoom.Value);
            ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y, CurrentPalettePixel);
 
        }


        /// <summary>
        /// Handles saving of changes of the image data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImgSave_Click(object sender, EventArgs e)
        {
            //if (CurrentImage.ImageType != BitmapUW.ImageTypes.Texture) { return; }
            //Loop through all art loaders and see if they need modifiying.

            if (tex!=null)
            {
                if (tex.Modified)
                {
                    switch (main.curgame)
                    {
                        case GAME_UW1:
                            if (tex.texturebufferW != null)
                            {
                                ArtUI.SaveTextureData(tex.texturebufferW, true);
                            }
                            if (tex.texturebufferF != null)
                            {
                                ArtUI.SaveTextureData(tex.texturebufferF, false);
                            }
                            break;
                        case GAME_UW2:
                            ArtUI.SaveTextureData(tex.texturebufferW, false);
                            break;
                    }
                }
            }
            for (int i=0; i<=grfile.GetUpperBound(0);i++)
            {
                if (grfile[i]!=null)
                {
                    if (grfile[i].Modified)
                    {
                        //do saving of a .gr file      
                        switch (grfile[i].ImageType)
                        {
                            case BitmapUW.ImageTypes.EightBitUncompressed:
                                ArtUI.SaveBytDataUW1(grfile[i].ImageFileData, grfile[i].FileName.Replace(main.basepath, ""));
                                break;
                            default://4 bit formats (convert to 8 bits?)
                                break;
                        }                        
                    }
                }
            }

            if (bytfile!=null)
            {
                if (curgame==GAME_UW1)
                {
                    for (int i = 0; i <= bytfile.GetUpperBound(0); i++)
                    {
                        if (bytfile[i] != null)
                        {
                            if (bytfile[i].ImageCache != null)
                            {
                                if (bytfile[i].ImageCache[0].Modified)
                                {
                                    //Save this .byt file
                                    ArtUI.SaveBytDataUW1(bytfile[i].ImageFileData, "\\Data\\" + BytLoader.FilePaths[i]);
                                }
                            }
                        }
                    }
                }
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Turns the selected image int a representation of the palette
            int x = 0;int y = 0;
            for (int counter = 0; counter < 256; counter++)
            {
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y+1, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y+2, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y+3, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 4, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 5, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 6, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 7, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y+8, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 9, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 10, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 11, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 12, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 13, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 14, counter);
                ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y + 15, counter);

                x++;
                if (x >= 64)
                {
                    x = 0;
                    y = y +16;
                }
            }
        }

        /// <summary>
        /// Handles selection of a palette colour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicPalette_MouseClick(object sender, MouseEventArgs e)
        {
            
           // int x = e.Location.X / 4;
            //int y = (e.Location.Y) / 4;
            if (CurrentImage!=null)
            {
                PictureBoxWithInterpolationMode pic = (PictureBoxWithInterpolationMode)sender;
                int ctrlwidth = pic.Size.Width;
                int RefPalSize = CurrentImage.PaletteRef.GetUpperBound(0) + 1;
                int ratio = ctrlwidth / RefPalSize;
                int currentpixel = e.Location.X / ratio;
                CurrentPalettePixel = CurrentImage.PaletteRef[currentpixel];
                 Bitmap selectedbmp = new Bitmap(2, 2);
                for (int x =0; x< selectedbmp.Width; x++)
                {
                    for (int y = 0; y < selectedbmp.Height; y++)
                    {
                        selectedbmp.SetPixel(x, y, CurrentImage.ImagePalette.ColorAtPixel((byte)CurrentPalettePixel, true));                                               
                    }
                }
                PicColour.Image = selectedbmp;
            }            
        }


        /// <summary>
        /// Handles saving of the lev.ark file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveTileMap_Click(object sender, EventArgs e)
        {
            Util.WriteStreamFile(curlevarkfile, levarkbuffer);
        }

        /// <summary>
        /// Store changed tile info to the map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnApplyTileChanges_Click(object sender, EventArgs e)
        {
            TileMapUI.ApplyTileChanges(curTileX, curTileY, this);
        }

        /// <summary>
        /// Handle changing of a value in the player inventory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Loads save 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Loads save 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Loads save 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Loads save 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Loads the current games strings file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UWGameStrings = new UWStrings();
            UWGameStrings.LoadStringsPak(main.basepath + "\\data\\strings.pak", curgame, GrdStrings);
        }

        /// <summary>
        /// Load the lev.ark from gamedata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataLevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(0);
        }

        /// <summary>
        /// Loads the lev.ark from save 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save1LevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(1);
        }

        /// <summary>
        /// Loads the lev.ark from save 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save2LevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(2);
        }

        /// <summary>
        /// Loads the lev.ark from save 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save3LevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(3);
        }

        /// <summary>
        /// Loads the lev.ark from save 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save4LevarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUWLevArk(4);
        }

        /// <summary>
        /// Repacks a UW2 lev.ark file into a new uncompressed file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repackUW2DataToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (main.curgame==GAME_UW2)
            {
               char[] lev_ark;
               if(! Util.ReadStreamFile(basepath + "\\data\\lev.ark", out lev_ark))
               {
                return;
               }
                int BlocksToRepack = 80;//A value of higher than this will crash the dos game.
                //Create a new uwblocks array of size 320
                Util.UWBlock[] blockData = new Util.UWBlock[320];
                //Uncompress the first 80 and store appropiate flags
                long NewAddress=0;
                for (int x=0; x<= blockData.GetUpperBound(0);x++)
                {
                    long currAddress = Util.getValAtAddress(lev_ark, 6 + (x * 4), 32);
                    if (x==0)
                    { NewAddress = currAddress; }
                    int compressionFlag = (int)Util.getValAtAddress(lev_ark, 6 + (1 * (320 * 4)) + (x * 4), 32);
                    int DataSizeVal = (int)Util.getValAtAddress(lev_ark, 6 + (2 * (320 * 4)) + (x * 4), 32);
                    int DataAvail = (int)Util.getValAtAddress(lev_ark, 6 + (3 * (320 * 4)) + (x * 4), 32);
                    int isCompressed = (compressionFlag >> 1) & 0x01;
                    if (x< BlocksToRepack)
                    {//a tile map block
                        blockData[x] = new Util.UWBlock();
                        if (isCompressed == 1)
                        {                           
                            Util.LoadUWBlock(lev_ark, x, 0, out blockData[x]);
                            blockData[x].Address = NewAddress;
                            blockData[x].CompressionFlag = 0;
                            //uwblocks[x].DataLen = DataSizeVal;  
                        }
                        else
                        {
                            //Copy block
                            Util.CopyUWBlock(lev_ark, x, 0, out blockData[x]);
                            blockData[x].Address = NewAddress;                            
                        }
                    }
                    else
                    {
                        //Copy block
                        Util.CopyUWBlock(lev_ark, x, 0, out blockData[x]);
                        blockData[x].Address = NewAddress;
                    }
                    if (blockData[x].DataLen == 0)
                    {
                        blockData[x].Address = 0;
                    }
                    NewAddress = NewAddress + blockData[x].DataLen;
                }
                //Write all data to file.
                FileStream file = File.Open(basepath + "\\Data\\NEW LEV.ARK", FileMode.Create);
                BinaryWriter writer = new BinaryWriter(file);
                long add_ptr = 0;

                add_ptr += Util.WriteInt8(writer, 0x40);
                add_ptr += Util.WriteInt8(writer, 0x01);
                add_ptr += Util.WriteInt8(writer, 0x0);//1
                add_ptr += Util.WriteInt8(writer, 0x0);//2
                add_ptr += Util.WriteInt8(writer, 0x0);//3
                add_ptr += Util.WriteInt8(writer, 0x0);//4

                //Now write block addresses
                for (int i = 0; i < 320; i++)
                {//write block addresses
                    add_ptr += Util.WriteInt32(writer, blockData[i].Address);
                }

                //Now write compression flags
                for (int i = 320; i < 640; i++)
                {//write block compression flags
                    add_ptr += Util.WriteInt32(writer, blockData[i - 320].CompressionFlag);
                }

                //Now write data lengths
                for (int i = 960; i < 1280; i++)
                {//write block data lengths
                    add_ptr += Util.WriteInt32(writer, blockData[i - 960].DataLen);
                }


                for (int i = 1280; i < 1600; i++)
                {//write block data reservations
                    add_ptr += Util.WriteInt32(writer, blockData[i - 1280].ReservedSpace);
                }

                for (long freespace = add_ptr; freespace < blockData[0].Address; freespace++)
                {//write freespace to fill up to the final block.
                    add_ptr += Util.WriteInt8(writer, 0);
                }


                //Now be brave and write all my blocks!!!
                for (int i = 0; i <= blockData.GetUpperBound(0); i++)
                {
                    if (blockData[i].Data != null)//?
                    {
                        if (add_ptr < blockData[i].Address)
                        {
                            while (add_ptr < blockData[i].Address)
                            {//Fill whitespace until next block address.
                                add_ptr += Util.WriteInt8(writer, 0);
                            }
                        }
                        else
                        {
                            if ((add_ptr > blockData[i].Address) && (blockData[i].Address!=0))
                            {
                                MessageBox.Show("Writing block " + i + " at " + add_ptr + " should be " + blockData[i].Address);
                            }
                        }
                       // Debug.Log("Writing block " + i + " datalen " + blockData[i].DataLen + " ubound=" + blockData[i].Data.GetUpperBound(0));
                        //for (long a =0; a<=blockData[i].Data.GetUpperBound(0); a++)
                        int blockUbound = blockData[i].Data.GetUpperBound(0);
                        for (long a = 0; a < blockData[i].DataLen; a++)
                        {
                            if (a <= blockUbound)
                            {
                                add_ptr += Util.WriteInt8(writer, (long)blockData[i].Data[a]);
                            }
                            else
                            {
                                add_ptr += Util.WriteInt8(writer, 0);
                            }
                        }
                    }
                }
                file.Close();
                MessageBox.Show("Underworld 2 lev.ark has been repacked. Use this file at your own risk");
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            
            if (result==DialogResult.OK)
            {
                Bitmap jr = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                Palette FinalPal = CurrentImage.GetFinalPallette();
                if ((jr.Width !=CurrentImage.image.Width) || (jr.Height!= CurrentImage.image.Height))
                {
                    jr = ArtLoader.Resize(jr, CurrentImage.image.Width, CurrentImage.image.Height);
                }
                
                for (int x = 0; x < jr.Width; x++)
                {
                    for (int y = 0; y < jr.Height; y++)
                    {
                        //Get nearest palette to color
                        ArtUI.setPixelAtLocation(CurrentImage, ImgOut, x, y, PaletteLoader.GetNearestColour(jr.GetPixel(x, y), FinalPal));
                    }
                }
                ImgOut.Image = CurrentImage.image;
            } 
        }

        private void NumZoom_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentImage!=null)
            {
                ImgOut.Height = CurrentImage.image.Height * (int)NumZoom.Value;
                ImgOut.Width = CurrentImage.image.Width * (int)NumZoom.Value;
            }
        }

        private void BtnExportImg_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                ImgOut.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }            
        }

        private void BtnRepack4Bit_Click(object sender, EventArgs e)
        {

            if (CurrentImage!=null)
            {
                GRLoader X = (GRLoader)CurrentImage.artdata;
                X.Convert();
            }

        }
    }
}
