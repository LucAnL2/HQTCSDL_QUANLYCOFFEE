using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCSDL.DAO;
using DemoCSDL.Models;
using DemoCSDL.UserControls;
using DemoCSDL.Connection;
using System.Windows.Forms.DataVisualization.Charting;

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMDashboard : Form
    {
        private NhanVienDAO nvDAO;
        List<NhanVien> ListNV = new List<NhanVien>();
        List<NhanVien> ListLN = new List<NhanVien>();
        DBConnection conn = new DBConnection();
        public FMDashboard()
        {
            InitializeComponent();
            nvDAO = new NhanVienDAO();
            ListNV = conn.GetNhanVienList();
            ListLN = conn.GetDoanhThuList();
        }

        private void FMDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                CapNhatTongLoiNhuan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
            }
            foreach (var nhanVien in ListNV)
            {
                MStaffInfoInDash md = new MStaffInfoInDash(nhanVien);
                pnlNhanVien.Controls.Add(md);

            }
            if (chart1.Series.Count > 0)
            {
                chart1.Series[0].Points.Clear(); // Xóa các điểm dữ liệu hiện có trong Series đầu tiên
            }
            else
            {
                Series series = new Series("Data");
                series.IsValueShownAsLabel = true;
                chart1.Series.Add(series);
            }

            int test = 0;

            // Thêm các điểm dữ liệu mới vào Series đầu tiên
            for (int i = 0; i < ListLN.Count; i++)
            {
                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = ListLN[i].HTen; // Đặt nhãn trục Y là tên
                test += ListLN[i].Tuoi;
                dataPoint.YValues = new double[] { ListLN[i].Tuoi }; // Giá trị trục X
                chart1.Series[0].Points.Add(dataPoint);
            }
        }
        private void CapNhatTongLoiNhuan()
        {
            try
            {
                decimal tongLoiNhuan = nvDAO.LayTongLoiNhuan();
                lblTongLoiNhuan.Text = tongLoiNhuan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tổng lợi nhuận: " + ex.Message);
            }
        }
        private void btnDTNgay_Click(object sender, EventArgs e)
        {
            CapNhatDoanhThuNgay();           
        }
        private void CapNhatDoanhThuNgay()
        {
            try
            {
                decimal doanhThuNgay = nvDAO.LayDoanhThuNgay(DateTime.Today);
                lblTongLoiNhuan.Text = doanhThuNgay.ToString();
                lblDoanhThu.Text = "Total Revenue";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật doanh thu ngày: " + ex.Message);
            }
        }

        private void btnDTThang_Click(object sender, EventArgs e)
        {
            try
            {
                int thangHienTai = DateTime.Now.Month - 1;
                int namHienTai = DateTime.Now.Year;
                string chuoiThangNam = $"{namHienTai}-{thangHienTai}";
                DataTable dt = nvDAO.LayLoiNhuanThangTruoc(chuoiThangNam);
                if (dt.Rows.Count > 0)
                {
                    lblTongLoiNhuan.Text = dt.Rows[0]["LoiNhuan"].ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu lợi nhuận cho tháng trước.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật doanh thu tháng: " + ex.Message);
            }
        }

        private void btnDTAll_Click(object sender, EventArgs e)
        {
            CapNhatTongLoiNhuan();
        }

        private void btnPhatLuong_Click(object sender, EventArgs e)
        {
            try
            {
                nvDAO.PhatLuong();
                int thangHienTai = DateTime.Now.Month;
                int namHienTai = DateTime.Now.Year;
                string chuoiThangNam = $"{namHienTai}-{thangHienTai}";
                nvDAO.ThemThongTinLoiNhuan(chuoiThangNam);
                FMDashboard_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message);
            }
        }
    }
}
