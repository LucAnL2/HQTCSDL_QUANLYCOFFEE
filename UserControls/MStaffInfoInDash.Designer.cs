namespace DemoCSDL.UserControls
{
    partial class MStaffInfoInDash
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
            this.nameuc = new System.Windows.Forms.Label();
            this.iduc = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameuc
            // 
            this.nameuc.AutoSize = true;
            this.nameuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.nameuc.Location = new System.Drawing.Point(110, 33);
            this.nameuc.Name = "nameuc";
            this.nameuc.Size = new System.Drawing.Size(110, 22);
            this.nameuc.TabIndex = 6;
            this.nameuc.Text = "Eric Archer";
            // 
            // iduc
            // 
            this.iduc.AutoSize = true;
            this.iduc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iduc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.iduc.Location = new System.Drawing.Point(243, 33);
            this.iduc.Name = "iduc";
            this.iduc.Size = new System.Drawing.Size(107, 22);
            this.iduc.TabIndex = 6;
            this.iduc.Text = "ID: 238943";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::DemoCSDL.Properties.Resources.user;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(17, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(65, 65);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 5;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // MStaffInfoInDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.Controls.Add(this.iduc);
            this.Controls.Add(this.nameuc);
            this.Controls.Add(this.guna2PictureBox1);
            this.Name = "MStaffInfoInDash";
            this.Size = new System.Drawing.Size(362, 93);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label nameuc;
        private System.Windows.Forms.Label iduc;
    }
}
