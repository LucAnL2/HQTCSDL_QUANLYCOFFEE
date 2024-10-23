using DemoCSDL.ActiveInForms;
using DemoCSDL.DAO;
using DemoCSDL.Forms;
using DemoCSDL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL.UserControls
{
    public partial class WProductInOrder : UserControl
    {
        SanPhamOrder spo = new SanPhamOrder();
        public WProductInOrder(SanPhamOrder spo)
        {

            InitializeComponent();
            this.spo = spo;
            lblWOrderTen.Text = spo.TenSP;
            lblWOrderGia.Text = spo.Gia.ToString();
            string image = spo.HinhAnh;
            picWOrderImage.Image = Image.FromFile(image);
            lblOrderSL.Text = spo.SoLuongOrder.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLoaibo_Click(object sender, EventArgs e)
        {
            for (int i = SanPhamDAO.listOrder.Count - 1; i >= 0; i--)
            {
                SanPhamOrder sp1 = SanPhamDAO.listOrder[i];
                if (spo == sp1)
                {
                    SanPhamDAO.listOrder.RemoveAt(i);
                }
            }
            if (spo.MaLoaiSP == "ML1")
            {
                string maLoaiSP = "ML1";
                Active active = new Active();
                active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
            }
            else if (spo.MaLoaiSP == "ML2")
            {

                string maLoaiSP = "ML2";
                Active active = new Active();
                active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
            }
            else if (spo.MaLoaiSP == "ML3")
            {
                string maLoaiSP = "ML3";
                Active active = new Active();
                active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
            }
            else
            {
                string maLoaiSP = "ML4";
                Active active = new Active();
                active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
            }
        }
    }
}
