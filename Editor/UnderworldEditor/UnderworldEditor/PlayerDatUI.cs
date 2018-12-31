using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnderworldEditor
{
    class PlayerDatUI
    {
        public static void LoadUW1PDat(main MAIN, int slot)
        {
            main.curslot = slot;
            main.isLoading = true;
            main.curgame = main.GAME_UW1;
            char[] buffer = playerdat.LoadPlayerDatUW1(main.basepath + "\\save" + slot + "\\player.dat");//"c:\\games\\uw1\\save1\\player.dat");
            PopulatePDatValuesToGrid(buffer,MAIN);
            MAIN.pdatObjects = new objects();
            MAIN.pdatObjects.InitInventoryObjectList(buffer, main.InventoryOffsetUW1);
            main.PopulateItemIDList(MAIN.CmbPdatItem_ID);
            PopulateUI(buffer, MAIN.pdatObjects.objList, MAIN);
            main.isLoading = false;
        }

        public static void LoadUW2PDat(main MAIN, int slot)
        {
            main.curslot = slot;
            main.isLoading = true;
            main.curgame = main.GAME_UW2;
            char[] buffer = playerdat.LoadPlayerDatUW2(main.basepath + "\\save" + slot + "\\player.dat");
            PopulatePDatValuesToGrid(buffer, MAIN);
            MAIN.pdatObjects = new objects();
            MAIN.pdatObjects.InitInventoryObjectList(buffer, main.InventoryOffsetUW2);
            main.PopulateItemIDList(MAIN.CmbPdatItem_ID);
            PopulateUI(buffer, MAIN.pdatObjects.objList, MAIN);
            main.isLoading = false;
        }

        public static void PopulateUI(char[] buffer, objects.ObjectInfo[] objList, main MAIN)
        {
            PlayerDatUI.PopulateCharName(buffer, MAIN);
            PlayerDatUI.PopulateStats(buffer, MAIN);
            PlayerDatUI.PopulateInventory(buffer, objList, MAIN);
        }

        public static void PopulatePDatValuesToGrid(char[] buffer, main MAIN)
        {
            MAIN.GrdPlayerDat.Rows.Clear();
            for (int i = 0; i <= buffer.GetUpperBound(0); i++)
            {
                int rowId = MAIN.GrdPlayerDat.Rows.Add();
                DataGridViewRow row = MAIN.GrdPlayerDat.Rows[rowId];
                row.Cells[0].Value = (int)buffer[i];
                row.HeaderCell.Value = playerdat.FieldName(i, main.curgame);
            }
        }


        public static void PopulateCharName(char[] buffer, main MAIN)
        {
            MAIN.TxtCharName.Text = "";
            for (int i = 1; i < 14; i++)
            {
                MAIN.TxtCharName.Text = MAIN.TxtCharName.Text + buffer[i].ToString();
            }
        }


        public static void PopulateStats(char[] buffer, main MAIN)
        {
            int charclassdetails = 0;
            switch (main.curgame)
            {
                //Unique values
                case main.GAME_UW1://uw1
                    {
                        charclassdetails = (int)Util.getValAtAddress(buffer, 0x65, 8);
                        PopulateSkillsGrid(main.SkillsOffsetUW1, MAIN);
                        MAIN.ChkDifficulty.Checked = ((int)Util.getValAtAddress(buffer, 0xB5, 8) & 0x1) == 1;
                        break;
                    }//end switch uw1
                case main.GAME_UW2:
                    {
                        charclassdetails = (int)Util.getValAtAddress(buffer, 0x66, 8);
                        PopulateSkillsGrid(main.SkillsOffsetUW2, MAIN);
                        MAIN.ChkDifficulty.Checked = ((int)Util.getValAtAddress(buffer, 0x302, 8) & 0x1) == 1;
                        break;
                    }//end switch uw2
            }
            //Common values
            MAIN.NumEXP.Value = Util.getValAtAddress(buffer, 0x4F, 32) / 10;
            MAIN.NumCurHP.Value = Util.getValAtAddress(buffer, 0x36, 8);
            MAIN.NumMaxHP.Value = Util.getValAtAddress(buffer, 0x37, 8);
            MAIN.NumCurMana.Value = Util.getValAtAddress(buffer, 0x38, 8);
            MAIN.NumMaxMana.Value = Util.getValAtAddress(buffer, 0x39, 8);
            MAIN.NumFatigue.Value = Util.getValAtAddress(buffer, 0x3A, 8);
            MAIN.NumHunger.Value = Util.getValAtAddress(buffer, 0x3B, 8);
            MAIN.NumCharLevel.Value = Util.getValAtAddress(buffer, 0x3E, 8);
            MAIN.NumSkillPoints.Value = Util.getValAtAddress(buffer, 0x53, 8);
            MAIN.NumPDatXPos.Value = Util.getValAtAddress(buffer, 0x56, 16);
            MAIN.NumPDatYPos.Value = Util.getValAtAddress(buffer, 0x58, 16);
            MAIN.NumPDatZPos.Value = Util.getValAtAddress(buffer, 0x5A, 16);
            MAIN.NumPDatHeading.Value = Util.getValAtAddress(buffer, 0x5C, 8);
            MAIN.NumDungeonLevel.Value = Util.getValAtAddress(buffer, 0x5D, 8);
            PopulateCharClass(charclassdetails, MAIN);
        }

        public static void PopulateSkillsGrid(int offset, main MAIN)
        {
            MAIN.GrdSkills.Rows.Clear();
            for (int i = 0; i <= 22; i++)
            {
                //add rows
                int rowId = MAIN.GrdSkills.Rows.Add();
                DataGridViewRow row = MAIN.GrdSkills.Rows[rowId];
                if (main.curgame == main.GAME_UW1)
                {
                    row.Cells[0].Value = PlayerDatNames.UW1FieldName(offset + i);
                }
                else
                {
                    row.Cells[0].Value = PlayerDatNames.UW2FieldName(offset + i);
                }
                row.Cells[1].Value = MAIN.GrdPlayerDat.Rows[offset + i].Cells[0].Value;
            }
        }


        public static void PopulateCharClass(int classdetails, main MAIN)
        {
            //bit 1 = hand left/right
            //bit 2-5 = gender & body
            //bit 6-8 = class
            MAIN.ChkLeftHanded.Checked = ((classdetails & 0x1) == 0);
            int bodyval = ((int)classdetails >> 1) & 0xf;
            if (bodyval % 2 == 0)
            {
                //male 0,2,4,6,8
                MAIN.ChkIsFemale.Checked = false;
                //Body
                MAIN.NumBody.Value = bodyval / 2;
            }
            else
            {
                //female=1,3,5,7,9
                MAIN.ChkIsFemale.Checked = true;
                MAIN.NumBody.Value = (bodyval - 1) / 2;
            }
            //class
            switch (classdetails >> 5)
            {
                case 0:
                    MAIN.CmbCharClass.Text = "Fighter"; break;
                case 1:
                    MAIN.CmbCharClass.Text = "Mage"; break;
                case 2:
                    MAIN.CmbCharClass.Text = "Bard"; break;
                case 3:
                    MAIN.CmbCharClass.Text = "Tinker"; break;
                case 4:
                    MAIN.CmbCharClass.Text = "Druid"; break;
                case 5:
                    MAIN.CmbCharClass.Text = "Paladin"; break;
                case 6:
                    MAIN.CmbCharClass.Text = "Ranger"; break;
                case 7:
                    MAIN.CmbCharClass.Text = "Shepard"; break;
            }

        }

        public static void PopulateInventory(char[] buffer, objects.ObjectInfo[] objList, main MAIN)
        {
            int offset = main.InventorySlotOffsetUW1;
            MAIN.TreeInventory.Nodes.Clear();
            if (main.curgame == main.GAME_UW2)
            { offset = main.InventorySlotOffsetUW2; }

            TreeNode tvn = MAIN.TreeInventory.Nodes.Add("Helm");
            int objIndex = (int)Util.getValAtAddress(buffer, offset + 0, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Chest");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 2, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Gloves");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 4, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Leggings");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 6, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Boots");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 8, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Right Shoulder");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 10, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Left Shoulder");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 12, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Right Hand");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 14, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Left Hand");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 16, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Right Ring");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 18, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("Left Ring");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 20, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);

            tvn = MAIN.TreeInventory.Nodes.Add("BackPack0");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 22, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = MAIN.TreeInventory.Nodes.Add("BackPack1");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 24, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = MAIN.TreeInventory.Nodes.Add("BackPack2");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 26, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = MAIN.TreeInventory.Nodes.Add("BackPack3");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 28, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = MAIN.TreeInventory.Nodes.Add("BackPack4");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 30, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = MAIN.TreeInventory.Nodes.Add("BackPack5");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 32, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = MAIN.TreeInventory.Nodes.Add("BackPack6");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 34, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
            tvn = MAIN.TreeInventory.Nodes.Add("BackPack7");
            objIndex = (int)Util.getValAtAddress(buffer, offset + 36, 16) >> 6;
            PopulateInventoryNode(tvn, objIndex, objList);
        }

        public static void PopulateInventoryNode(TreeNode node, int index, objects.ObjectInfo[] objList)
        {
            if (index != 0)
            {
                TreeNode newnode = node.Nodes.Add(objects.ObjectName(objList[index].item_id, main.curgame));
                newnode.Tag = index;
                if (objects.isContainer(objList[index].item_id))
                {
                    PopulateLinkedInventoryNode(newnode, objList[index].link, objList);
                }
                else
                {
                    PopulateInventoryMagicLink(newnode, index, objList);
                }
            }
        }

        public static void PopulateLinkedInventoryNode(TreeNode node, int index, objects.ObjectInfo[] objList)
        {
            while (index != 0)
            {
                TreeNode newnode = node.Nodes.Add(objects.ObjectName(objList[index].item_id, main.curgame));
                newnode.Tag = index;
                if (objects.isContainer(objList[index].item_id))
                {
                    PopulateLinkedInventoryNode(newnode, objList[index].link, objList);
                }
                else
                {
                    PopulateInventoryMagicLink(newnode, index, objList);
                }
                index = objList[index].next;
            }
        }


        public static void PopulateInventoryMagicLink(TreeNode node, int index, objects.ObjectInfo[] objList)
        {
            if ((objList[index].is_quant == 0) && (objList[index].link > 0))
            {
                int linked = objList[index].link;
                if (linked <= objList.GetUpperBound(0))
                {
                    TreeNode newnode = node.Nodes.Add(objects.ObjectName(objList[linked].item_id, main.curgame));
                    newnode.Tag = index;
                }
            }
        }


        public static void ChangeCharName(main MAIN)
        {
            if (!main.isLoading)
            {
                char[] namechars = MAIN.TxtCharName.Text.ToCharArray();
                for (int i = 0; i < 13; i++)
                {
                    if (namechars.GetUpperBound(0) >= i)
                    {
                        MAIN.GrdPlayerDat.Rows[i + 1].Cells[0].Value = (int)namechars[i];
                    }
                    else
                    {
                        MAIN.GrdPlayerDat.Rows[i + 1].Cells[0].Value = 0;

                    }
                }
            }
        }


        public static void ChangeCurHP(main MAIN)
        {
            if (!main.isLoading)
            {
                if (main.curgame == main.GAME_UW1)
                {//UW1 uses a duplicate value
                    MAIN.GrdPlayerDat.Rows[0xDD].Cells[0].Value = MAIN.NumCurHP.Value;
                }
                MAIN.GrdPlayerDat.Rows[0x36].Cells[0].Value = MAIN.NumCurHP.Value;
            }
        }

        public static void ChangeMaxHP(main MAIN)
        {
            if (!main.isLoading)
            {
                MAIN.GrdPlayerDat.Rows[0x37].Cells[0].Value = MAIN.NumMaxHP.Value;
            }
        }

        public static void ChangeCurMana(main MAIN)
        {
            if (!main.isLoading)
            {
                MAIN.GrdPlayerDat.Rows[0x38].Cells[0].Value = MAIN.NumCurMana.Value;
            }
        }

        public static void ChangeMaxMana(main MAIN)
        {
            if (!main.isLoading)
            {
                MAIN.GrdPlayerDat.Rows[0x39].Cells[0].Value = MAIN.NumMaxMana.Value;
            }
        }

        public static void ChangeHunger(main MAIN)
        {
            if (!main.isLoading)
            {
                MAIN.GrdPlayerDat.Rows[0x3A].Cells[0].Value = MAIN.NumHunger.Value;
            }
        }

        public static void ChangeFatigue(main MAIN)
        {
            if (!main.isLoading)
            {
                MAIN.GrdPlayerDat.Rows[0x3B].Cells[0].Value = MAIN.NumHunger.Value;
            }
        }

        public static void UpdateSkills(main MAIN)
        {
            if (!main.isLoading)
            {
                int j = 0;
                for (int i = 0x1f; i <= 0x35; i++)
                {
                    int cellvalue = 0;
                    if (!int.TryParse(MAIN.GrdSkills.Rows[j].Cells[1].Value.ToString() , out cellvalue))
                    {
                        MAIN.GrdSkills.Rows[j].Cells[1].Value = 0;
                        cellvalue = 0;
                    }
                    if (cellvalue>30)
                    {
                        MAIN.GrdSkills.Rows[j].Cells[1].Value = 30;
                    }
                    if (cellvalue < 0)
                    {
                        MAIN.GrdSkills.Rows[j].Cells[1].Value = 0;
                    }
                    MAIN.GrdPlayerDat.Rows[i].Cells[0].Value = MAIN.GrdSkills.Rows[j++].Cells[1].Value;
                }
            }
        }


        /// <summary>
        /// Get the list of values in the grid and store in a char array.
        /// </summary>
        /// <returns></returns>
        public static char[] GetValuesFromPDatGrid(main MAIN)
        {
            char[] buffer = new char[MAIN.GrdPlayerDat.Rows.Count];
            for (int i = 0; i <= buffer.GetUpperBound(0); i++)
            {
                int val;
                if (int.TryParse(MAIN.GrdPlayerDat.Rows[i].Cells[0].Value.ToString(), out val))
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



    }
}
