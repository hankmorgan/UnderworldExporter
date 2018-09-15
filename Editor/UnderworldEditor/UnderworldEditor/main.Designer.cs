namespace UnderworldEditor
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Helm");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Chest");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Gloves");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Leggings");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Boots");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("TopRightShoulder");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("TopLeftShoulder");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("RightHand");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("LeftHand");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("LeftRing");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("BackPack0");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("BackPack1");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("BackPack2");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("BackPack3");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("BackPack4");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("BackPack5");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("BackPack6");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("BackPack7");
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TreeInventory = new System.Windows.Forms.TreeView();
            this.NumEXP = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnWritePDatUW2 = new System.Windows.Forms.Button();
            this.BtnLoadPDatUW2 = new System.Windows.Forms.Button();
            this.TxtCharName = new System.Windows.Forms.TextBox();
            this.BtnWritePDatUW1 = new System.Windows.Forms.Button();
            this.GrdPlayerDat = new System.Windows.Forms.DataGridView();
            this.PDatValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnLoadPDatUW1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumEXP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPlayerDat)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(927, 474);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.NumEXP);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.BtnWritePDatUW2);
            this.tabPage1.Controls.Add(this.BtnLoadPDatUW2);
            this.tabPage1.Controls.Add(this.TxtCharName);
            this.tabPage1.Controls.Add(this.BtnWritePDatUW1);
            this.tabPage1.Controls.Add(this.GrdPlayerDat);
            this.tabPage1.Controls.Add(this.BtnLoadPDatUW1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(919, 445);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "UW PlayerDat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(517, 46);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(399, 393);
            this.tabControl2.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TreeInventory);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(391, 364);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Inventory";
            // 
            // TreeInventory
            // 
            this.TreeInventory.Location = new System.Drawing.Point(7, 3);
            this.TreeInventory.Name = "TreeInventory";
            treeNode1.Name = "Helml";
            treeNode1.Text = "Helm";
            treeNode2.Name = "Chest";
            treeNode2.Text = "Chest";
            treeNode3.Name = "Gloves";
            treeNode3.Text = "Gloves";
            treeNode4.Name = "Leggings";
            treeNode4.Text = "Leggings";
            treeNode5.Name = "Boots";
            treeNode5.Text = "Boots";
            treeNode6.Name = "TopRightShoulder";
            treeNode6.Text = "TopRightShoulder";
            treeNode7.Name = "TopLeftShoulder";
            treeNode7.Text = "TopLeftShoulder";
            treeNode8.Name = "RightHand";
            treeNode8.Text = "RightHand";
            treeNode9.Name = "LeftHand";
            treeNode9.Text = "LeftHand";
            treeNode10.Name = "RightRing";
            treeNode10.Text = "LeftRing";
            treeNode11.Name = "BackPack0";
            treeNode11.Text = "BackPack0";
            treeNode12.Name = "BackPack1";
            treeNode12.Text = "BackPack1";
            treeNode13.Name = "BackPack2";
            treeNode13.Text = "BackPack2";
            treeNode14.Name = "BackPack3";
            treeNode14.Text = "BackPack3";
            treeNode15.Name = "BackPack4";
            treeNode15.Text = "BackPack4";
            treeNode16.Name = "BackPack5";
            treeNode16.Text = "BackPack5";
            treeNode17.Name = "BackPack6";
            treeNode17.Text = "BackPack6";
            treeNode18.Name = "BackPack7";
            treeNode18.Text = "BackPack7";
            this.TreeInventory.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            this.TreeInventory.Size = new System.Drawing.Size(208, 355);
            this.TreeInventory.TabIndex = 0;
            this.TreeInventory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeInventory_AfterSelect);
            // 
            // NumEXP
            // 
            this.NumEXP.Location = new System.Drawing.Point(780, 7);
            this.NumEXP.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.NumEXP.Name = "NumEXP";
            this.NumEXP.Size = new System.Drawing.Size(120, 22);
            this.NumEXP.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(742, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Exp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name";
            // 
            // BtnWritePDatUW2
            // 
            this.BtnWritePDatUW2.Location = new System.Drawing.Point(6, 351);
            this.BtnWritePDatUW2.Name = "BtnWritePDatUW2";
            this.BtnWritePDatUW2.Size = new System.Drawing.Size(90, 34);
            this.BtnWritePDatUW2.TabIndex = 6;
            this.BtnWritePDatUW2.Text = "WritePDat";
            this.BtnWritePDatUW2.UseVisualStyleBackColor = true;
            this.BtnWritePDatUW2.Click += new System.EventHandler(this.btnWritePDatUW2_Click);
            // 
            // BtnLoadPDatUW2
            // 
            this.BtnLoadPDatUW2.Location = new System.Drawing.Point(6, 311);
            this.BtnLoadPDatUW2.Name = "BtnLoadPDatUW2";
            this.BtnLoadPDatUW2.Size = new System.Drawing.Size(90, 34);
            this.BtnLoadPDatUW2.TabIndex = 5;
            this.BtnLoadPDatUW2.Text = "LoadPDat";
            this.BtnLoadPDatUW2.UseVisualStyleBackColor = true;
            this.BtnLoadPDatUW2.Click += new System.EventHandler(this.btnLoadPDatUW2_Click);
            // 
            // TxtCharName
            // 
            this.TxtCharName.Location = new System.Drawing.Point(565, 6);
            this.TxtCharName.MaxLength = 13;
            this.TxtCharName.Name = "TxtCharName";
            this.TxtCharName.Size = new System.Drawing.Size(160, 22);
            this.TxtCharName.TabIndex = 4;
            this.TxtCharName.TextChanged += new System.EventHandler(this.txtCharName_TextChanged);
            // 
            // BtnWritePDatUW1
            // 
            this.BtnWritePDatUW1.Location = new System.Drawing.Point(6, 46);
            this.BtnWritePDatUW1.Name = "BtnWritePDatUW1";
            this.BtnWritePDatUW1.Size = new System.Drawing.Size(90, 34);
            this.BtnWritePDatUW1.TabIndex = 3;
            this.BtnWritePDatUW1.Text = "WritePDat";
            this.BtnWritePDatUW1.UseVisualStyleBackColor = true;
            this.BtnWritePDatUW1.Click += new System.EventHandler(this.btnWritePDatUW1_Click);
            // 
            // GrdPlayerDat
            // 
            this.GrdPlayerDat.AllowUserToAddRows = false;
            this.GrdPlayerDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdPlayerDat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PDatValue,
            this.Commands});
            this.GrdPlayerDat.Location = new System.Drawing.Point(102, 3);
            this.GrdPlayerDat.Name = "GrdPlayerDat";
            this.GrdPlayerDat.RowTemplate.Height = 24;
            this.GrdPlayerDat.Size = new System.Drawing.Size(395, 436);
            this.GrdPlayerDat.TabIndex = 2;
            this.GrdPlayerDat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPlayerDat_CellContentClick);
            this.GrdPlayerDat.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdPlayerDat_CellValueChanged);
            // 
            // PDatValue
            // 
            this.PDatValue.HeaderText = "Value";
            this.PDatValue.Name = "PDatValue";
            this.PDatValue.Width = 200;
            // 
            // Commands
            // 
            this.Commands.HeaderText = "Commands";
            this.Commands.Name = "Commands";
            // 
            // BtnLoadPDatUW1
            // 
            this.BtnLoadPDatUW1.Location = new System.Drawing.Point(6, 6);
            this.BtnLoadPDatUW1.Name = "BtnLoadPDatUW1";
            this.BtnLoadPDatUW1.Size = new System.Drawing.Size(90, 34);
            this.BtnLoadPDatUW1.TabIndex = 1;
            this.BtnLoadPDatUW1.Text = "LoadPDat";
            this.BtnLoadPDatUW1.UseVisualStyleBackColor = true;
            this.BtnLoadPDatUW1.Click += new System.EventHandler(this.btnLoadPDatUW1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 498);
            this.Controls.Add(this.tabControl1);
            this.Name = "main";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumEXP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPlayerDat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView GrdPlayerDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDatValue;
        private System.Windows.Forms.Button BtnLoadPDatUW1;
        private System.Windows.Forms.Button BtnWritePDatUW1;
        private System.Windows.Forms.TextBox TxtCharName;
        private System.Windows.Forms.Button BtnWritePDatUW2;
        private System.Windows.Forms.Button BtnLoadPDatUW2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commands;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumEXP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView TreeInventory;
    }
}

