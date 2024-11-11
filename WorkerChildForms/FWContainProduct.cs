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
    public partial class FWContainProduct : Form
    {
        private string maLoaiSP;
        private readonly SanPhamDAO spDAO = new SanPhamDAO();
        private readonly PhuongThucTTDAO ptttDAO = new PhuongThucTTDAO();
        private readonly HoaDonDAO hdDAO = new HoaDonDAO();
        private readonly ChiTietDAO ctDAO = new ChiTietDAO();
        public FWContainProduct()
        {
            InitializeComponent();
        }
        public FWContainProduct(string maLoaiSP)
        {
            InitializeComponent();
            this.maLoaiSP = maLoaiSP;
        }

        List<PhuongThucTT> listPttt;
        private void FWContainProduct_Load(object sender, EventArgs e)
        {
            datetimeHoadon.Value = DateTime.Now;
            LoadSanPham();
            LoadDonHang();
            LoadPTTT();
            CapNhatNutHoaDon();
        }
        private void CapNhatNutHoaDon()
        {
            btnTaoMa.Enabled = string.IsNullOrEmpty(HoaDonDAO.MaHD);
            lblMaHD.Text = HoaDonDAO.MaHD ?? string.Empty;
        }

        private void LoadSanPham()
        {
            List<SanPham> products = spDAO.DSSanPham(maLoaiSP);
            foreach (SanPham product in products)
            {
                WProduct productControl = new WProduct(product) { Margin = new Padding(0, 0, 8, 8) };
                fLPanelSP.Controls.Add(productControl);
            }
        }
        private void LoadDonHang()
        {
            if (SanPhamDAO.listOrder != null)
            {
                foreach (SanPhamOrder order in SanPhamDAO.listOrder)
                {
                    WProductInOrder productOrderControl = new WProductInOrder(order) { Margin = new Padding() };
                    FLPanelOrder.Controls.Add(productOrderControl);
                }
            }
        }
        private void LoadPTTT()
        {
            var paymentMethods = ptttDAO.LayDSPhuongThuc();
            cbbPTTT.DataSource = paymentMethods;
            cbbPTTT.DisplayMember = "TenPTTT";
            cbbPTTT.ValueMember = "MaPTTT";
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Active.OpenChildForm(new WorkerChildForms.FWMenu(), ref Active.activeForm, FWorker.panelFill);
        }

        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            HoaDonDAO.MaHD = ctDAO.TaoMaHD();
            lblMaHD.Text = HoaDonDAO.MaHD;
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            try
            {
                decimal discount = Convert.ToDecimal(txtDiscount.Text);
                decimal subtotal = Convert.ToDecimal(lblTongTien.Text);
                decimal total = subtotal - discount;
                lblTotal.Text = total.ToString();

                string maPTTT = cbbPTTT.SelectedValue.ToString();
                string maNV = ShortTermVariables.BienDungChung.maNVND;
                var hd = new HoaDon(lblMaHD.Text, maNV, datetimeHoadon.Value, maPTTT, txtNote.Text, Convert.ToInt32(lblTotal.Text));
                hdDAO.ThemHoaDon(hd);

                foreach (var order in SanPhamDAO.listOrder)
                {
                    ChiTiet ct = new ChiTiet(lblMaHD.Text, order.MaSP, order.SoLuongOrder, order.Gia);
                    ctDAO.ThemChiTietHD(ct);
                }

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
                foreach (SanPhamOrder order in SanPhamDAO.listOrder)
                {
                    ChiTiet ct = new ChiTiet(lblMaHD.Text, order.MaSP, order.SoLuongOrder, order.Gia);
                    ctDAO.ThemChiTietHD(ct);
                }

                var listChiTiet = ctDAO.LoadCTHD(lblMaHD.Text);
                var listHoaDon = hdDAO.LoadHD(lblMaHD.Text);
                var paymentForm = new FWThanhToan(listChiTiet, listHoaDon);

                SanPhamDAO.listOrder.Clear();
                HoaDonDAO.MaHD = null;
                Active.OpenChildForm(new WorkerChildForms.FWMenu(), ref Active.activeForm, FWorker.panelFill);

                paymentForm.Show();
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
