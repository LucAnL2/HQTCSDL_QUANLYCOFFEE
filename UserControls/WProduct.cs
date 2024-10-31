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
    public partial class WProduct : UserControl
    {
        SanPhamOrder spo = new SanPhamOrder();
        SanPham sp;
        public WProduct(SanPham sp)
        {  
            InitializeComponent();
            this.sp = sp;
            lblWTen.Text = sp.TenSP;
            lblWGia.Text = sp.Gia.ToString();
            lblWMa.Text = sp.MaSP;
            lblWTinhtrang.Text = sp.TinhTrang;
            string image = sp.HinhAnh;
            picImageSP.Image = Image.FromFile(image);       
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NUpdownSL.Value == 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng khách đã Order");
                HienThiManHinh(sp.MaLoaiSP);
            }
            else{
                spo.MaSP = sp.MaSP;
                spo.MaLoaiSP = sp.MaLoaiSP;
                spo.TenSP = sp.TenSP;
                spo.TinhTrang = sp.TinhTrang;
                spo.Gia = sp.Gia;
                spo.HinhAnh = sp.HinhAnh;
                spo.SoLuongOrder = Convert.ToInt32(NUpdownSL.Value);
                SanPhamDAO.listOrder.Add(spo);
                HienThiManHinh(spo.MaLoaiSP);
            }                             
        }

        public void HienThiManHinh(string MaLoaiSP)
        {
            if (MaLoaiSP == "ML1")
            {
                string maLoaiSP = "ML1";
                Active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
            }
            else if (MaLoaiSP == "ML2")
            {
                string maLoaiSP = "ML2";
                Active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
            }
            else if (MaLoaiSP == "ML3")
            {
                string maLoaiSP = "ML3";
                Active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
            }
            else
            {
                string maLoaiSP = "ML4";
                Active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
            }
        }
    }
}
