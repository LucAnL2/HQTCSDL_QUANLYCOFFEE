namespace DemoCSDL.UserControls
{
    partial class MIngredient
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
            this.UCCheckboxTenNL = new System.Windows.Forms.CheckBox();
            this.UCNumericNL = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.UClblSluongNL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.UCNumericNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UCCheckboxTenNL
            // 
            this.UCCheckboxTenNL.AutoSize = true;
            this.UCCheckboxTenNL.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UCCheckboxTenNL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.UCCheckboxTenNL.Location = new System.Drawing.Point(74, 22);
            this.UCCheckboxTenNL.Name = "UCCheckboxTenNL";
            this.UCCheckboxTenNL.Size = new System.Drawing.Size(119, 23);
            this.UCCheckboxTenNL.TabIndex = 0;
            this.UCCheckboxTenNL.Text = "Đường phèn";
            this.UCCheckboxTenNL.UseVisualStyleBackColor = true;
            this.UCCheckboxTenNL.CheckedChanged += new System.EventHandler(this.UCCheckboxTenNL_CheckedChanged);
            // 
            // UCNumericNL
            // 
            this.UCNumericNL.Location = new System.Drawing.Point(345, 32);
            this.UCNumericNL.Name = "UCNumericNL";
            this.UCNumericNL.Size = new System.Drawing.Size(55, 22);
            this.UCNumericNL.TabIndex = 3;
            this.UCNumericNL.ValueChanged += new System.EventHandler(this.UCNumericNL_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DemoCSDL.Properties.Resources.ingredients;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(217, 11);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(109, 17);
            this.guna2HtmlLabel1.TabIndex = 4;
            this.guna2HtmlLabel1.Text = "Số lượng còn lại:";
            // 
            // UClblSluongNL
            // 
            this.UClblSluongNL.BackColor = System.Drawing.Color.Transparent;
            this.UClblSluongNL.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UClblSluongNL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.UClblSluongNL.Location = new System.Drawing.Point(355, 11);
            this.UClblSluongNL.Name = "UClblSluongNL";
            this.UClblSluongNL.Size = new System.Drawing.Size(17, 17);
            this.UClblSluongNL.TabIndex = 5;
            this.UClblSluongNL.Text = "17";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(217, 37);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(122, 17);
            this.guna2HtmlLabel3.TabIndex = 6;
            this.guna2HtmlLabel3.Text = "Số lượng cần dùng:";
            // 
            // MIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.UClblSluongNL);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.UCNumericNL);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UCCheckboxTenNL);
            this.Name = "MIngredient";
            this.Size = new System.Drawing.Size(405, 69);
            this.Load += new System.EventHandler(this.MIngredient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UCNumericNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox UCCheckboxTenNL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown UCNumericNL;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel UClblSluongNL;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
    }
}
