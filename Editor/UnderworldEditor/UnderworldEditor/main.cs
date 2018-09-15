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
        bool isLoading = false;
        const int InventoryOffsetUW1 = 0x138;
        const int InventoryOffsetUW2 = 0x3E3;
        const int InventorySlotOffsetUW1 = 0xf8;
        const int InventorySlotOffsetUW2 = 0x3A3;

        int curgame;

        public main()
        {
            InitializeComponent();
            GrdPlayerDat.RowHeadersWidth = 100;
        }

        private void btnLoadPDatUW1_Click(object sender, EventArgs e)
        {
            isLoading = true;
            curgame = 1;
            char[] buffer = playerdat.LoadPlayerDatUW1("c:\\games\\uw1\\save1\\player.dat");
            PopulateValuesToGrid(buffer, curgame);
            objects.InitObjectList(buffer, InventoryOffsetUW1);
            PopulateItemIDList(curgame);
            PopulateUI(buffer, curgame);            
            PopulateInventorySelectButtons(InventoryOffsetUW1);
            isLoading = false;
        }

        void PopulateItemIDList(int game)
        {
        for (int i =0; i<=464;i++)
            {
                CmbItem_ID.Items.Add(i + "-" + objects.ObjectName(i,game));
            }

        }

        private void btnLoadPDatUW2_Click(object sender, EventArgs e)
        {
            isLoading = true;
            curgame = 2;
            char[] buffer = playerdat.LoadPlayerDatUW2("c:\\games\\uw2\\save1\\player.dat");
            PopulateValuesToGrid(buffer, curgame);
            PopulateItemIDList(curgame);
            objects.InitObjectList(buffer, InventoryOffsetUW2);
            PopulateUI(buffer, curgame);            
            PopulateInventorySelectButtons(InventoryOffsetUW2);
            isLoading = false;
        }

        /// <summary>
        /// Write the info in the raw grid back to the player dat file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWritePDatUW1_Click(object sender, EventArgs e)
        {
            char[] buffer = GetValuesFromGrid();
            playerdat.EncryptDecryptUW1(buffer, buffer[0]);
            Util.WriteStreamFile("c:\\games\\uw1\\save1\\PLAYER.DAT", buffer);
        }



        private void btnWritePDatUW2_Click(object sender, EventArgs e)
        {
            char[] buffer = GetValuesFromGrid();
            buffer = playerdat.EncryptDecryptUW2(buffer, (byte)buffer[0]);
            Util.WriteStreamFile("c:\\games\\uw2\\save1\\PLAYER.DAT", buffer);
        }

        private void PopulateUI(char[] buffer,int game)
        {
            PopulateCharName(buffer);
            PopulateStats(buffer, game);
            PopulateInventory(buffer, game);
        }

        private void PopulateInventory(char[] buffer, int game)
        {
            int offset = InventorySlotOffsetUW1;
            TreeInventory.Nodes.Clear();
            if (game==2)
            { offset = InventorySlotOffsetUW2; }
           
            TreeNode tvn = TreeInventory.Nodes.Add("Helm");
            int objIndex = (int)Util.getValAtAddress(buffer, offset+0, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Chest");
            objIndex = (int)Util.getValAtAddress(buffer, offset +2, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Gloves");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 4, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Leggings");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 6, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Boots");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 8, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Right Shoulder");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 10, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Left Shoulder");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 12, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Right Hand");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 14, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Left Hand");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 16, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Right Ring");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 18, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("Left Ring");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 20, 16) >> 6;
            PopulateNode(tvn, objIndex);

            tvn = TreeInventory.Nodes.Add("BackPack0");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 22, 16) >> 6;
            PopulateNode(tvn, objIndex);
            tvn = TreeInventory.Nodes.Add("BackPack1");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 24, 16) >> 6;
            PopulateNode(tvn, objIndex);
            tvn = TreeInventory.Nodes.Add("BackPack2");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 26, 16) >> 6;
            PopulateNode(tvn, objIndex);
            tvn = TreeInventory.Nodes.Add("BackPack3");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 28, 16) >> 6;
            PopulateNode(tvn, objIndex);
            tvn = TreeInventory.Nodes.Add("BackPack4");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 30, 16) >> 6;
            PopulateNode(tvn, objIndex);
            tvn = TreeInventory.Nodes.Add("BackPack5");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 32, 16) >> 6;
            PopulateNode(tvn, objIndex);
            tvn = TreeInventory.Nodes.Add("BackPack6");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 34, 16) >> 6;
            PopulateNode(tvn, objIndex);
            tvn = TreeInventory.Nodes.Add("BackPack7");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 36, 16) >> 6;
            PopulateNode(tvn, objIndex);
        }

        void PopulateNode(TreeNode node, int index)
        {
            if (index!=0)
            {
                TreeNode newnode = node.Nodes.Add(objects.ObjectName(objects.objList[index].item_id, curgame));
                newnode.Tag = index;
                if (objects.isContainer(objects.objList[index].item_id))
                {
                    PopulateLinkedNode(newnode, objects.objList[index].link);
                }
            }
        }

        void PopulateLinkedNode(TreeNode node, int index)
        {
            while (index!=0)
            {
                TreeNode newnode = node.Nodes.Add(objects.ObjectName(objects.objList[index].item_id, curgame));
                newnode.Tag = index;
                if (objects.isContainer(objects.objList[index].item_id))
                {
                    PopulateLinkedNode(newnode, objects.objList[index].link);
                }
                index = objects.objList[index].next;
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
            switch (game)
            {
                case 1://uw1
                    {
                        NumEXP.Value = Util.getValAtAddress(buffer, 0x4F, 32)/10;
                        break;
                    }//end switch uw1
                case 2:
                    {

                        break;
                    }//end switch uw2

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
                    PopulateUI(GetValuesFromGrid(), curgame);
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
                    objects.ObjectInfo obj = objects.objList[index];
                    CmbItem_ID.Text = obj.item_id + "-" + objects.ObjectName(obj.item_id,curgame);

                    ChkEnchanted.Checked = (obj.enchantment == 1);
                    ChkIsQuant.Checked = (obj.is_quant == 1);
                    ChkDoorDir.Checked = (obj.doordir == 1);
                    ChkInvis.Checked = (obj.invis == 1);

                    NumFlags.Value = obj.flags;
                    NumQuality.Value = obj.quality;
                    NumOwner.Value = obj.owner;
                    NumNext.Value = obj.next;
                    NumLink.Value = obj.link;
                }
            }
        }
    }
}
