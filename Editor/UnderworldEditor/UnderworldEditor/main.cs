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
        public main()
        {
            InitializeComponent();
            grdPlayerDat.RowHeadersWidth = 100;
        }

        private void btnLoadPDatUW1_Click(object sender, EventArgs e)
        {
            char[] buffer = playerdat.LoadPlayerDatUW1("c:\\games\\uw1\\save1\\player.dat");
            grdPlayerDat.Rows.Clear();
            txtCharName.Text = "";
            for (int i=0; i<=buffer.GetUpperBound(0);i++)
            {
                int rowId = grdPlayerDat.Rows.Add();
                DataGridViewRow row = grdPlayerDat.Rows[rowId];
                if ((i>=1) && (i<14))
                {//Player name
                    row.Cells[0].Value = (int)buffer[i];
                    txtCharName.Text = txtCharName.Text + buffer[i].ToString();
                }
                else
                {
                    row.Cells[0].Value = (int)buffer[i];
                }
                row.HeaderCell.Value = playerdat.UW1FieldName(i);
            }            
        }

        /// <summary>
        /// Write the info in the raw grid back to the player dat file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWritePDat_Click(object sender, EventArgs e)
        {
            char[] buffer = new char[grdPlayerDat.Rows.Count];
            for (int i=0; i<=buffer.GetUpperBound(0);i++)
            {
                int val;
                if (int.TryParse(grdPlayerDat.Rows[i].Cells[0].Value.ToString(), out val))
                {
                    val = val & 0xff;
                    buffer[i] = (char)val;
                }
                else
                {
                    buffer[i] = (char)0;
                }

            }
            playerdat.EncryptDecryptUW1(buffer, buffer[0]);
            Util.WriteStreamFile("c:\\games\\uw1\\save1\\test.dat", buffer);
        }
    }
}
