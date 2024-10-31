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
        PhuongThucTTDAO ptttDAO = new PhuongThucTTDAO();
        HoaDonDAO hdDAO = new HoaDonDAO();
        ChiTietDAO ctDAO = new ChiTietDAO();
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

        List<PhuongThucTT> listPttt;
        private void FWMenu_Load(object sender, EventArgs e)
        {
            if (SanPhamDAO.listOrder != null)
            {
                foreach (SanPhamOrder i in SanPhamDAO.listOrder)
                {
                    WProductInOrder productOder = new WProductInOrder(i);
                    productOder.Margin = new Padding();
                    FLPanelOrder.Controls.Add(productOder);
                }
            }
            listPttt = ptttDAO.LayDSPhuongThuc();
            cbbPTTT.DataSource = listPttt;
            cbbPTTT.DisplayMember = "TenPTTT"; // Thuộc tính hiển thị
            cbbPTTT.ValueMember = "MaPTTT";

            if (HoaDonDAO.MaHD != null)
            {
                lblMaHD.Text = HoaDonDAO.MaHD;
                btnTaoMa.Enabled = false;
            }
            else
            {
                btnTaoMa.Enabled = true;
            }

        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SanPhamOrder spo in SanPhamDAO.listOrder)
                {
                    ChiTiet ct = new ChiTiet(lblMaHD.Text, spo.MaSP, spo.SoLuongOrder, spo.Gia);
                    ctDAO.ThemChiTietHD(ct);
                }
                List<ChiTiet> listChiTiet = ctDAO.LoadCTHD(lblMaHD.Text);
                List<HoaDon> listHoaDon = hdDAO.LoadHD(lblMaHD.Text);
                FWThanhToan fthanhtoan = new FWThanhToan(listChiTiet, listHoaDon);

                SanPhamDAO.listOrder.Clear();
                HoaDonDAO.MaHD = null;
                
                Active.OpenChildForm(new WorkerChildForms.FWMenu(), ref Active.activeForm, FWorker.panelFill);
               
                fthanhtoan.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            decimal tongOrder = hdDAO.TinhTienOrder(SanPhamDAO.listOrder);
            lblTongTien.Text = tongOrder.ToString();
        }
      
        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            HoaDonDAO.MaHD = ctDAO.TaoMaHD();
            lblMaHD.Text = HoaDonDAO.MaHD;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            decimal discount = Convert.ToDecimal(txtDiscount.Text);
            decimal subtotal = Convert.ToDecimal(lblTongTien.Text);
            decimal total = subtotal - discount;
            lblTotal.Text = total.ToString();

            try
            {
                string maPTTT = cbbPTTT.SelectedValue.ToString();
                string maNV = ShortTermVariables.ShortTermVariables.idEmp;
                HoaDon hd = new HoaDon(lblMaHD.Text, maNV, datetimeHoadon.Value, maPTTT, txtNote.Text, Convert.ToInt32(lblTotal.Text));
                hdDAO.ThemHoaDon(hd);
                MessageBox.Show("Thêm hóa đơn thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
