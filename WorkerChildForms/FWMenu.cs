
using DemoCSDL.ActiveInForms;
using DemoCSDL.DAO;
using DemoCSDL.Forms;
using DemoCSDL.Models;
using DemoCSDL.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL.WorkerChildForms
{
    public partial class FWMenu : Form
    {
        private readonly PhuongThucTTDAO ptttDAO = new PhuongThucTTDAO();
        private readonly HoaDonDAO hdDAO = new HoaDonDAO();
        private readonly ChiTietDAO ctDAO = new ChiTietDAO();
        public FWMenu()
        {
            InitializeComponent();
        }
        string maLoaiSP;
        private void btnOpenCream_Click(object sender, EventArgs e)
        {
            maLoaiSP = "ML1";
            Active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
        }

        private void btnOpenCoffee_Click(object sender, EventArgs e)
        {
            maLoaiSP = "ML2";
            Active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
        }

        private void btnOpenBeverage_Click(object sender, EventArgs e)
        {
            maLoaiSP = "ML3";
            Active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
        }

        private void btnOpenCake_Click(object sender, EventArgs e)
        {
            maLoaiSP = "ML4";
            Active.OpenChildForm(new WorkerChildForms.FWContainProduct(maLoaiSP), ref Active.activeForm, FWorker.panelFill);
        }
        private void FWMenu_Load(object sender, EventArgs e)
        {
            datetimeHoadon.Value = DateTime.Now;
            LoadSanPhamDat();
            LoadPTTT();
            CapNhatNutDoanhThu();
        }
        private void CapNhatNutDoanhThu()
        {
            btnTaoMa.Enabled = string.IsNullOrEmpty(HoaDonDAO.MaHD);
            lblMaHD.Text = HoaDonDAO.MaHD ?? string.Empty;
        }
        private void LoadPTTT()
        {
            var listPttt = ptttDAO.LayDSPhuongThuc();
            cbbPTTT.DataSource = listPttt;
            cbbPTTT.DisplayMember = "TenPTTT";
            cbbPTTT.ValueMember = "MaPTTT";
        }

        private void LoadSanPhamDat()
        {
            if (SanPhamDAO.listOrder != null)
            {
                foreach (SanPhamOrder order in SanPhamDAO.listOrder)
                {
                    WProductInOrder productInOrder = new WProductInOrder(order) { Margin = new Padding() };
                    FLPanelOrder.Controls.Add(productInOrder);
                }
            }
        }
        private void TaoChiTietHoaDon()
        {
            foreach (SanPhamOrder order in SanPhamDAO.listOrder)
            {
                ChiTiet ct = new ChiTiet(lblMaHD.Text, order.MaSP, order.SoLuongOrder, order.Gia);
                ctDAO.ThemChiTietHD(ct);
            }
        }
      
        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            HoaDonDAO.MaHD = ctDAO.TaoMaHD();
            lblMaHD.Text = HoaDonDAO.MaHD;
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            decimal discount = Convert.ToDecimal(txtDiscount.Text);
            decimal subtotal = Convert.ToDecimal(lblTongTien.Text);
            decimal total = subtotal - discount;
            lblTotal.Text = total.ToString();

            try
            {
                string maPTTT = cbbPTTT.SelectedValue.ToString();
                string maNV = ShortTermVariables.BienDungChung.maNVND;
                HoaDon hd = new HoaDon(lblMaHD.Text, maNV, datetimeHoadon.Value, maPTTT, txtNote.Text, Convert.ToInt32(lblTotal.Text));
                hdDAO.ThemHoaDon(hd);
                MessageBox.Show("Thêm hóa đơn thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                TaoChiTietHoaDon();
                var listChiTiet = ctDAO.LoadCTHD(lblMaHD.Text);
                var listHoaDon = hdDAO.LoadHD(lblMaHD.Text);

                SanPhamDAO.listOrder.Clear();
                HoaDonDAO.MaHD = null;

                Active.OpenChildForm(new WorkerChildForms.FWMenu(), ref Active.activeForm, FWorker.panelFill);
                new FWThanhToan(listChiTiet, listHoaDon).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTong_Click(object sender, EventArgs e)
        {
            decimal tongOrder = hdDAO.TinhTienOrder(SanPhamDAO.listOrder);
            lblTongTien.Text = tongOrder.ToString();
        }
    }
}
