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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnWritePDatUW2 = new System.Windows.Forms.Button();
            this.btnLoadPDatUW2 = new System.Windows.Forms.Button();
            this.txtCharName = new System.Windows.Forms.TextBox();
            this.btnWritePDatUW1 = new System.Windows.Forms.Button();
            this.grdPlayerDat = new System.Windows.Forms.DataGridView();
            this.PDatValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadPDatUW1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayerDat)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(781, 426);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnWritePDatUW2);
            this.tabPage1.Controls.Add(this.btnLoadPDatUW2);
            this.tabPage1.Controls.Add(this.txtCharName);
            this.tabPage1.Controls.Add(this.btnWritePDatUW1);
            this.tabPage1.Controls.Add(this.grdPlayerDat);
            this.tabPage1.Controls.Add(this.btnLoadPDatUW1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(773, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "UW PlayerDat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnWritePDatUW2
            // 
            this.btnWritePDatUW2.Location = new System.Drawing.Point(6, 351);
            this.btnWritePDatUW2.Name = "btnWritePDatUW2";
            this.btnWritePDatUW2.Size = new System.Drawing.Size(90, 34);
            this.btnWritePDatUW2.TabIndex = 6;
            this.btnWritePDatUW2.Text = "WritePDat";
            this.btnWritePDatUW2.UseVisualStyleBackColor = true;
            this.btnWritePDatUW2.Click += new System.EventHandler(this.btnWritePDatUW2_Click);
            // 
            // btnLoadPDatUW2
            // 
            this.btnLoadPDatUW2.Location = new System.Drawing.Point(6, 311);
            this.btnLoadPDatUW2.Name = "btnLoadPDatUW2";
            this.btnLoadPDatUW2.Size = new System.Drawing.Size(90, 34);
            this.btnLoadPDatUW2.TabIndex = 5;
            this.btnLoadPDatUW2.Text = "LoadPDat";
            this.btnLoadPDatUW2.UseVisualStyleBackColor = true;
            this.btnLoadPDatUW2.Click += new System.EventHandler(this.btnLoadPDatUW2_Click);
            // 
            // txtCharName
            // 
            this.txtCharName.Location = new System.Drawing.Point(531, 4);
            this.txtCharName.Name = "txtCharName";
            this.txtCharName.Size = new System.Drawing.Size(160, 22);
            this.txtCharName.TabIndex = 4;
            // 
            // btnWritePDatUW1
            // 
            this.btnWritePDatUW1.Location = new System.Drawing.Point(6, 46);
            this.btnWritePDatUW1.Name = "btnWritePDatUW1";
            this.btnWritePDatUW1.Size = new System.Drawing.Size(90, 34);
            this.btnWritePDatUW1.TabIndex = 3;
            this.btnWritePDatUW1.Text = "WritePDat";
            this.btnWritePDatUW1.UseVisualStyleBackColor = true;
            this.btnWritePDatUW1.Click += new System.EventHandler(this.btnWritePDat_Click);
            // 
            // grdPlayerDat
            // 
            this.grdPlayerDat.AllowUserToAddRows = false;
            this.grdPlayerDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPlayerDat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PDatValue});
            this.grdPlayerDat.Location = new System.Drawing.Point(102, 3);
            this.grdPlayerDat.Name = "grdPlayerDat";
            this.grdPlayerDat.RowTemplate.Height = 24;
            this.grdPlayerDat.Size = new System.Drawing.Size(395, 391);
            this.grdPlayerDat.TabIndex = 2;
            // 
            // PDatValue
            // 
            this.PDatValue.HeaderText = "Value";
            this.PDatValue.Name = "PDatValue";
            this.PDatValue.Width = 200;
            // 
            // btnLoadPDatUW1
            // 
            this.btnLoadPDatUW1.Location = new System.Drawing.Point(6, 6);
            this.btnLoadPDatUW1.Name = "btnLoadPDatUW1";
            this.btnLoadPDatUW1.Size = new System.Drawing.Size(90, 34);
            this.btnLoadPDatUW1.TabIndex = 1;
            this.btnLoadPDatUW1.Text = "LoadPDat";
            this.btnLoadPDatUW1.UseVisualStyleBackColor = true;
            this.btnLoadPDatUW1.Click += new System.EventHandler(this.btnLoadPDatUW1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "main";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayerDat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grdPlayerDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDatValue;
        private System.Windows.Forms.Button btnLoadPDatUW1;
        private System.Windows.Forms.Button btnWritePDatUW1;
        private System.Windows.Forms.TextBox txtCharName;
        private System.Windows.Forms.Button btnWritePDatUW2;
        private System.Windows.Forms.Button btnLoadPDatUW2;
    }
}

