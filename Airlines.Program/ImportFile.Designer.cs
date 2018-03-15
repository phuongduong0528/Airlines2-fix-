namespace Airlines.Program
{
    partial class ImportFile
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
            this.chooseBtn = new System.Windows.Forms.Button();
            this.filepathTxb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.importBtn = new System.Windows.Forms.Button();
            this.failLbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.successLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseBtn
            // 
            this.chooseBtn.Font = new System.Drawing.Font("Tw Cen MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseBtn.Location = new System.Drawing.Point(12, 31);
            this.chooseBtn.Name = "chooseBtn";
            this.chooseBtn.Size = new System.Drawing.Size(75, 28);
            this.chooseBtn.TabIndex = 0;
            this.chooseBtn.Text = "File";
            this.chooseBtn.UseVisualStyleBackColor = true;
            this.chooseBtn.Click += new System.EventHandler(this.chooseBtn_Click);
            // 
            // filepathTxb
            // 
            this.filepathTxb.Font = new System.Drawing.Font("Tw Cen MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filepathTxb.Location = new System.Drawing.Point(85, 32);
            this.filepathTxb.Name = "filepathTxb";
            this.filepathTxb.Size = new System.Drawing.Size(317, 26);
            this.filepathTxb.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.successLbl);
            this.groupBox1.Controls.Add(this.failLbl);
            this.groupBox1.Font = new System.Drawing.Font("Tw Cen MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 153);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // importBtn
            // 
            this.importBtn.Enabled = false;
            this.importBtn.Font = new System.Drawing.Font("Tw Cen MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Location = new System.Drawing.Point(409, 27);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(92, 36);
            this.importBtn.TabIndex = 0;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // failLbl
            // 
            this.failLbl.AutoSize = true;
            this.failLbl.Location = new System.Drawing.Point(6, 71);
            this.failLbl.Name = "failLbl";
            this.failLbl.Size = new System.Drawing.Size(31, 20);
            this.failLbl.TabIndex = 0;
            this.failLbl.Text = "Fail";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CSV files|*.csv";
            // 
            // successLbl
            // 
            this.successLbl.AutoSize = true;
            this.successLbl.Location = new System.Drawing.Point(6, 32);
            this.successLbl.Name = "successLbl";
            this.successLbl.Size = new System.Drawing.Size(60, 20);
            this.successLbl.TabIndex = 1;
            this.successLbl.Text = "Success";
            // 
            // ImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 242);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.filepathTxb);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.chooseBtn);
            this.Name = "ImportFile";
            this.Text = "ImportFile";
            this.Load += new System.EventHandler(this.ImportFile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseBtn;
        private System.Windows.Forms.TextBox filepathTxb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Label failLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label successLbl;
    }
}