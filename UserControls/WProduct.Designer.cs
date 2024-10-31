namespace DemoCSDL.UserControls
{
    partial class WProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblWTinhtrang = new System.Windows.Forms.Label();
            this.lblWMa = new System.Windows.Forms.Label();
            this.lblWGia = new System.Windows.Forms.Label();
            this.lblWTen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picImageSP = new Guna.UI2.WinForms.Guna2PictureBox();
            this.NUpdownSL = new System.Windows.Forms.NumericUpDown();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImageSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpdownSL)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(190)))), ((int)(((byte)(165)))));
            this.guna2Panel1.Controls.Add(this.NUpdownSL);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.lblWTinhtrang);
            this.guna2Panel1.Controls.Add(this.lblWMa);
            this.guna2Panel1.Controls.Add(this.lblWGia);
            this.guna2Panel1.Controls.Add(this.lblWTen);
            this.guna2Panel1.Controls.Add(this.picImageSP);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(349, 193);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderThickness = 1;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.btnAdd.Location = new System.Drawing.Point(296, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnAdd.Size = new System.Drawing.Size(50, 54);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblWTinhtrang
            // 
            this.lblWTinhtrang.AutoSize = true;
            this.lblWTinhtrang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(190)))), ((int)(((byte)(165)))));
            this.lblWTinhtrang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWTinhtrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.lblWTinhtrang.Location = new System.Drawing.Point(160, 116);
            this.lblWTinhtrang.Name = "lblWTinhtrang";
            this.lblWTinhtrang.Size = new System.Drawing.Size(86, 19);
            this.lblWTinhtrang.TabIndex = 4;
            this.lblWTinhtrang.Text = "TinhTrang";
            // 
            // lblWMa
            // 
            this.lblWMa.AutoSize = true;
            this.lblWMa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(190)))), ((int)(((byte)(165)))));
            this.lblWMa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWMa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.lblWMa.Location = new System.Drawing.Point(161, 84);
            this.lblWMa.Name = "lblWMa";
            this.lblWMa.Size = new System.Drawing.Size(53, 19);
            this.lblWMa.TabIndex = 4;
            this.lblWMa.Text = "MaSP";
            // 
            // lblWGia
            // 
            this.lblWGia.AutoSize = true;
            this.lblWGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(190)))), ((int)(((byte)(165)))));
            this.lblWGia.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.lblWGia.Location = new System.Drawing.Point(161, 50);
            this.lblWGia.Name = "lblWGia";
            this.lblWGia.Size = new System.Drawing.Size(36, 19);
            this.lblWGia.TabIndex = 4;
            this.lblWGia.Text = "$30";
            // 
            // lblWTen
            // 
            this.lblWTen.AutoSize = true;
            this.lblWTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(190)))), ((int)(((byte)(165)))));
            this.lblWTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.lblWTen.Location = new System.Drawing.Point(160, 13);
            this.lblWTen.Name = "lblWTen";
            this.lblWTen.Size = new System.Drawing.Size(67, 23);
            this.lblWTen.TabIndex = 3;
            this.lblWTen.Text = "Cream";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(190)))), ((int)(((byte)(165)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(160, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "SL Order";
            // 
            // picImageSP
            // 
            this.picImageSP.Image = global::DemoCSDL.Properties.Resources.icecream;
            this.picImageSP.ImageRotate = 0F;
            this.picImageSP.Location = new System.Drawing.Point(3, 3);
            this.picImageSP.Name = "picImageSP";
            this.picImageSP.Size = new System.Drawing.Size(151, 178);
            this.picImageSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImageSP.TabIndex = 0;
            this.picImageSP.TabStop = false;
            // 
            // NUpdownSL
            // 
            this.NUpdownSL.Location = new System.Drawing.Point(270, 154);
            this.NUpdownSL.Name = "NUpdownSL";
            this.NUpdownSL.Size = new System.Drawing.Size(46, 22);
            this.NUpdownSL.TabIndex = 7;
            this.NUpdownSL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "WProduct";
            this.Size = new System.Drawing.Size(349, 193);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImageSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpdownSL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox picImageSP;
        private System.Windows.Forms.Label lblWTen;
        private System.Windows.Forms.Label lblWGia;
        private Guna.UI2.WinForms.Guna2CircleButton btnAdd;
        private System.Windows.Forms.Label lblWTinhtrang;
        private System.Windows.Forms.Label lblWMa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUpdownSL;
    }
}
