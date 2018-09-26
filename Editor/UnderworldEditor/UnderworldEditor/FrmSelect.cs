using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UnderworldEditor
{
    public partial class FrmSelect : Form
    {
        string apppath;

        public FrmSelect()
        {
            InitializeComponent();
        }


        private void FrmSelect_Load(object sender, EventArgs e)
        {
            apppath = Path.GetDirectoryName(Application.ExecutablePath);
            if (File.Exists(apppath + "\\previous.txt"))
            {
                BtnPrevious.Enabled = true;
                StreamReader sr = File.OpenText(apppath + "\\previous.txt");
                BtnPrevious.Text = sr.ReadLine();
                sr.Close();
               
            }
            else
            {
                BtnPrevious.Enabled = false;
            }
        }

        void WriteLastPath(string path)
        {
            StreamWriter sw = new StreamWriter(apppath + "\\previous.txt",false);
            sw.Write(path);
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result= openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = Path.GetDirectoryName(openFileDialog1.FileName);
                switch (Path.GetFileName(openFileDialog1.FileName).ToUpper())
                {
                    case "UW.EXE"://underworld 1
                        main.curgame = main.GAME_UW1;
                        main.basepath = path;
                        WriteLastPath(path);
                        this.Dispose();
                        break;
                    case "UW2.EXE"://underworld 2
                        main.curgame = main.GAME_UW2;
                        main.basepath = path;
                        WriteLastPath(path);
                        this.Dispose();
                        break;
                }
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (File.Exists(BtnPrevious.Text + "\\uw.exe"))
            {
                main.curgame = main.GAME_UW1;
                main.basepath = BtnPrevious.Text;
                this.Dispose();
            }
            if (File.Exists(BtnPrevious.Text + "\\uw2.exe"))
            {
                main.curgame = main.GAME_UW2;
                main.basepath = BtnPrevious.Text;
                this.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
