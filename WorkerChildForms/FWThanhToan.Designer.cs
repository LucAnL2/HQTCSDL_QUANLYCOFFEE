﻿namespace DemoCSDL
{
    partial class FWThanhToan
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
            this.rvCTHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvCTHoaDon
            // 
            this.rvCTHoaDon.Location = new System.Drawing.Point(2, 3);
            this.rvCTHoaDon.Name = "rvCTHoaDon";
            this.rvCTHoaDon.ServerReport.BearerToken = null;
            this.rvCTHoaDon.Size = new System.Drawing.Size(1045, 539);
            this.rvCTHoaDon.TabIndex = 0;
            // 
            // FWThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 544);
            this.Controls.Add(this.rvCTHoaDon);
            this.Name = "FWThanhToan";
            this.Load += new System.EventHandler(this.FWThanhToan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvCTHoaDon;
    }
}