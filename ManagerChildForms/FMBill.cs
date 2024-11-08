using DemoCSDL.DAO;
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

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMBill : Form
    {
        public FMBill()
        {
            InitializeComponent();
        }
        NhanVienDAO nvd = new NhanVienDAO();
        HoaDonDAO hdd = new HoaDonDAO();
        ChiTietDAO ctd = new ChiTietDAO();
        private void FMBill_Load(object sender, EventArgs e)
        {
            dateTimeBegin.Value = DateTime.Now;
            dateTimeEnd.Value = DateTime.Now;
            cmbNhanVien.DataSource = nvd.LayDSNhanVien();
            cmbNhanVien.DisplayMember = "HTen";
            cmbNhanVien.ValueMember = "MaNV";
            gvDSHoaDon.DataSource = hdd.QuanLyHD(cmbNhanVien.SelectedValue.ToString(), dateTimeBegin.Value.Date, dateTimeEnd.Value.Date); 
        }
        

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string maNV = cmbNhanVien.SelectedValue.ToString();
            gvDSHoaDon.DataSource = hdd.QuanLyHD(maNV, dateTimeBegin.Value, dateTimeEnd.Value);
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (txtSoNgay.Text == "")
            {
                MessageBox.Show("Vui lòng nhập vào số ngày bạn muốn giữ lại hóa đơn");
            }
            else
            {
                int soNgay = Convert.ToInt32(txtSoNgay.Text);
                hdd.XoaHoaDonCu(soNgay);
                MessageBox.Show("Xóa hóa đơn thành công");
                gvDSHoaDon.DataSource = hdd.QuanLyHD("NV00", dateTimeBegin.Value.Date, dateTimeEnd.Value.Date);
            }
        }

        private void gvDSHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnChitietHD_Click(object sender, EventArgs e)
        {
            gvChiTietHD.DataSource = ctd.QLChiTietHD(txtMaHD.Text); 
        }

        private void gvDSHoaDon_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = gvDSHoaDon.Rows[e.RowIndex];

                    txtMaHD.Text = row.Cells[0].Value.ToString();
                }
            }
            catch { }
        }
    }
}
