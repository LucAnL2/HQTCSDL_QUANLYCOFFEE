namespace DemoCSDL.UserControls
{
    partial class WProductInOrder
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
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblOrderSL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoaibo = new Guna.UI2.WinForms.Guna2Button();
            this.picWOrderImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblWOrderGia = new System.Windows.Forms.Label();
            this.lblWOrderTen = new System.Windows.Forms.Label();
            this.guna2Panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWOrderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(155)))), ((int)(((byte)(128)))));
            this.guna2Panel9.BorderRadius = 10;
            this.guna2Panel9.BorderThickness = 3;
            this.guna2Panel9.Controls.Add(this.lblOrderSL);
            this.guna2Panel9.Controls.Add(this.label1);
            this.guna2Panel9.Controls.Add(this.btnLoaibo);
            this.guna2Panel9.Controls.Add(this.picWOrderImage);
            this.guna2Panel9.Controls.Add(this.lblWOrderGia);
            this.guna2Panel9.Controls.Add(this.lblWOrderTen);
            this.guna2Panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.guna2Panel9.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.Size = new System.Drawing.Size(254, 65);
            this.guna2Panel9.TabIndex = 1;
            // 
            // lblOrderSL
            // 
            this.lblOrderSL.AutoSize = true;
            this.lblOrderSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.lblOrderSL.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderSL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.lblOrderSL.Location = new System.Drawing.Point(204, 36);
            this.lblOrderSL.Name = "lblOrderSL";
            this.lblOrderSL.Size = new System.Drawing.Size(14, 15);
            this.lblOrderSL.TabIndex = 10;
            this.lblOrderSL.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(178, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "SL:";
            // 
            // btnLoaibo
            // 
            this.btnLoaibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.btnLoaibo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoaibo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoaibo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoaibo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoaibo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.btnLoaibo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnLoaibo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoaibo.Image = global::DemoCSDL.Properties.Resources.minus;
            this.btnLoaibo.Location = new System.Drawing.Point(216, 11);
            this.btnLoaibo.Name = "btnLoaibo";
            this.btnLoaibo.Size = new System.Drawing.Size(25, 22);
            this.btnLoaibo.TabIndex = 8;
            this.btnLoaibo.Click += new System.EventHandler(this.btnLoaibo_Click);
            // 
            // picWOrderImage
            // 
            this.picWOrderImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.picWOrderImage.BackColor = System.Drawing.Color.Transparent;
            this.picWOrderImage.Image = global::DemoCSDL.Properties.Resources.icecream;
            this.picWOrderImage.ImageRotate = 0F;
            this.picWOrderImage.Location = new System.Drawing.Point(12, 11);
            this.picWOrderImage.Name = "picWOrderImage";
            this.picWOrderImage.Size = new System.Drawing.Size(60, 41);
            this.picWOrderImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWOrderImage.TabIndex = 6;
            this.picWOrderImage.TabStop = false;
            this.picWOrderImage.UseTransparentBackground = true;
            // 
            // lblWOrderGia
            // 
            this.lblWOrderGia.AutoSize = true;
            this.lblWOrderGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.lblWOrderGia.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWOrderGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.lblWOrderGia.Location = new System.Drawing.Point(83, 36);
            this.lblWOrderGia.Name = "lblWOrderGia";
            this.lblWOrderGia.Size = new System.Drawing.Size(59, 15);
            this.lblWOrderGia.TabIndex = 2;
            this.lblWOrderGia.Text = "20000.00";
            // 
            // lblWOrderTen
            // 
            this.lblWOrderTen.AutoSize = true;
            this.lblWOrderTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.lblWOrderTen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWOrderTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.lblWOrderTen.Location = new System.Drawing.Point(83, 11);
            this.lblWOrderTen.Name = "lblWOrderTen";
            this.lblWOrderTen.Size = new System.Drawing.Size(98, 19);
            this.lblWOrderTen.TabIndex = 2;
            this.lblWOrderTen.Text = "Cà phê chồn";
            // 
            // WProductInOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel9);
            this.Name = "WProductInOrder";
            this.Size = new System.Drawing.Size(254, 65);
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWOrderImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private Guna.UI2.WinForms.Guna2PictureBox picWOrderImage;
        private System.Windows.Forms.Label lblWOrderGia;
        private System.Windows.Forms.Label lblWOrderTen;
        private Guna.UI2.WinForms.Guna2Button btnLoaibo;
        private System.Windows.Forms.Label lblOrderSL;
        private System.Windows.Forms.Label label1;
    }
}
