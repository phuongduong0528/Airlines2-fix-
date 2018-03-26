namespace Airlines.Program
{
    partial class MainForm
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
            this.scheduleDgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descChkbx = new System.Windows.Forms.CheckBox();
            this.flightTxb = new System.Windows.Forms.TextBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.outboundTxb = new System.Windows.Forms.TextBox();
            this.sortCbx = new System.Windows.Forms.ComboBox();
            this.toCbx = new System.Windows.Forms.ComboBox();
            this.fromCbx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.reloadBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleDgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduleDgv
            // 
            this.scheduleDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleDgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.scheduleDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleDgv.Location = new System.Drawing.Point(12, 124);
            this.scheduleDgv.Name = "scheduleDgv";
            this.scheduleDgv.Size = new System.Drawing.Size(776, 314);
            this.scheduleDgv.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.descChkbx);
            this.groupBox1.Controls.Add(this.flightTxb);
            this.groupBox1.Controls.Add(this.applyBtn);
            this.groupBox1.Controls.Add(this.outboundTxb);
            this.groupBox1.Controls.Add(this.sortCbx);
            this.groupBox1.Controls.Add(this.toCbx);
            this.groupBox1.Controls.Add(this.fromCbx);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // descChkbx
            // 
            this.descChkbx.AutoSize = true;
            this.descChkbx.Location = new System.Drawing.Point(556, 71);
            this.descChkbx.Name = "descChkbx";
            this.descChkbx.Size = new System.Drawing.Size(110, 24);
            this.descChkbx.TabIndex = 3;
            this.descChkbx.Text = "Descending";
            this.descChkbx.UseVisualStyleBackColor = true;
            // 
            // flightTxb
            // 
            this.flightTxb.Location = new System.Drawing.Point(331, 68);
            this.flightTxb.Name = "flightTxb";
            this.flightTxb.Size = new System.Drawing.Size(150, 26);
            this.flightTxb.TabIndex = 2;
            // 
            // applyBtn
            // 
            this.applyBtn.Enabled = false;
            this.applyBtn.Location = new System.Drawing.Point(666, 64);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(104, 34);
            this.applyBtn.TabIndex = 2;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // outboundTxb
            // 
            this.outboundTxb.Location = new System.Drawing.Point(93, 68);
            this.outboundTxb.Name = "outboundTxb";
            this.outboundTxb.Size = new System.Drawing.Size(150, 26);
            this.outboundTxb.TabIndex = 2;
            // 
            // sortCbx
            // 
            this.sortCbx.FormattingEnabled = true;
            this.sortCbx.Items.AddRange(new object[] {
            "Date-Time",
            "Date",
            "Time",
            "Price"});
            this.sortCbx.Location = new System.Drawing.Point(620, 23);
            this.sortCbx.Name = "sortCbx";
            this.sortCbx.Size = new System.Drawing.Size(150, 28);
            this.sortCbx.TabIndex = 1;
            // 
            // toCbx
            // 
            this.toCbx.Enabled = false;
            this.toCbx.FormattingEnabled = true;
            this.toCbx.Location = new System.Drawing.Point(331, 23);
            this.toCbx.Name = "toCbx";
            this.toCbx.Size = new System.Drawing.Size(150, 28);
            this.toCbx.TabIndex = 1;
            // 
            // fromCbx
            // 
            this.fromCbx.Enabled = false;
            this.fromCbx.FormattingEnabled = true;
            this.fromCbx.Location = new System.Drawing.Point(93, 23);
            this.fromCbx.Name = "fromCbx";
            this.fromCbx.Size = new System.Drawing.Size(150, 28);
            this.fromCbx.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(552, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sort by";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Flight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Outbound";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.Location = new System.Drawing.Point(12, 444);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(127, 34);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel flight";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editBtn.Location = new System.Drawing.Point(145, 444);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(127, 34);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Edit flight";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadBtn.Location = new System.Drawing.Point(590, 444);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(96, 34);
            this.reloadBtn.TabIndex = 2;
            this.reloadBtn.Text = "Reload";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importBtn.Location = new System.Drawing.Point(692, 444);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(96, 34);
            this.importBtn.TabIndex = 2;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.ForeColor = System.Drawing.Color.Red;
            this.statusLbl.Location = new System.Drawing.Point(339, 451);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(79, 20);
            this.statusLbl.TabIndex = 3;
            this.statusLbl.Text = "Loading...";
            this.statusLbl.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scheduleDgv);
            this.Font = new System.Drawing.Font("Tw Cen MT", 13F);
            this.Name = "MainForm";
            this.Text = "AMONIC Airlines";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleDgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView scheduleDgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox flightTxb;
        private System.Windows.Forms.TextBox outboundTxb;
        private System.Windows.Forms.ComboBox sortCbx;
        private System.Windows.Forms.ComboBox toCbx;
        private System.Windows.Forms.ComboBox fromCbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.CheckBox descChkbx;
        private System.Windows.Forms.Label statusLbl;
    }
}

