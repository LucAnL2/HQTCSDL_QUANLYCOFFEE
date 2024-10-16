namespace DemoCSDL.Forms
{
    partial class FForgotPassword
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FForgotPassword));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTakePassword = new Guna.UI2.WinForms.Guna2Button();
            this.txtFPPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::DemoCSDL.Properties.Resources.Pic2;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Location = new System.Drawing.Point(333, -13);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(552, 665);
            this.guna2Panel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Edwardian Script ITC", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(153, 558);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 51);
            this.label5.TabIndex = 32;
            this.label5.Text = "The Coffee Land";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 29);
            this.label6.TabIndex = 25;
            this.label6.Text = "Forgot Password";
            // 
            // btnTakePassword
            // 
            this.btnTakePassword.BorderRadius = 10;
            this.btnTakePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.btnTakePassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakePassword.ForeColor = System.Drawing.Color.White;
            this.btnTakePassword.Location = new System.Drawing.Point(65, 461);
            this.btnTakePassword.Name = "btnTakePassword";
            this.btnTakePassword.Size = new System.Drawing.Size(198, 47);
            this.btnTakePassword.TabIndex = 26;
            this.btnTakePassword.Text = "Take Password";
            // 
            // txtFPPassword
            // 
            this.txtFPPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.txtFPPassword.BorderThickness = 3;
            this.txtFPPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFPPassword.DefaultText = "";
            this.txtFPPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.txtFPPassword.DisabledState.FillColor = System.Drawing.SystemColors.Control;
            this.txtFPPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.txtFPPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.txtFPPassword.Enabled = false;
            this.txtFPPassword.FillColor = System.Drawing.SystemColors.Control;
            this.txtFPPassword.FocusedState.BorderColor = System.Drawing.Color.Indigo;
            this.txtFPPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFPPassword.HoverState.BorderColor = System.Drawing.Color.Indigo;
            this.txtFPPassword.Location = new System.Drawing.Point(17, 370);
            this.txtFPPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFPPassword.Name = "txtFPPassword";
            this.txtFPPassword.PasswordChar = '\0';
            this.txtFPPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.txtFPPassword.PlaceholderText = "Password";
            this.txtFPPassword.ReadOnly = true;
            this.txtFPPassword.SelectedText = "";
            this.txtFPPassword.Size = new System.Drawing.Size(295, 48);
            this.txtFPPassword.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtFPPassword.TabIndex = 27;
            // 
            // txtFUsername
            // 
            this.txtFUsername.AutoRoundedCorners = true;
            this.txtFUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.txtFUsername.BorderRadius = 21;
            this.txtFUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFUsername.DefaultText = "";
            this.txtFUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.txtFUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFUsername.Location = new System.Drawing.Point(17, 274);
            this.txtFUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtFUsername.Name = "txtFUsername";
            this.txtFUsername.PasswordChar = '●';
            this.txtFUsername.PlaceholderText = "User name";
            this.txtFUsername.SelectedText = "";
            this.txtFUsername.Size = new System.Drawing.Size(295, 44);
            this.txtFUsername.TabIndex = 30;
            this.txtFUsername.TextOffset = new System.Drawing.Point(12, 0);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DemoCSDL.Properties.Resources.logo;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(79, 111);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(184, 146);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 31;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(41)))), ((int)(((byte)(33)))));
            this.btnClose.Location = new System.Drawing.Point(908, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.guna2Panel1;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // FForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 617);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.txtFUsername);
            this.Controls.Add(this.txtFPPassword);
            this.Controls.Add(this.btnTakePassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FForgotPassword";
            this.Load += new System.EventHandler(this.FForgotPassword_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btnTakePassword;
        private Guna.UI2.WinForms.Guna2TextBox txtFPPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtFUsername;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
    }
}