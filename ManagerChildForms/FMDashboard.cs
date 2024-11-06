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
using DemoCSDL.UserControls;

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMDashboard : Form
    {
        private NhanVienDAO dao;
        public FMDashboard()
        {
            InitializeComponent();
            dao = new NhanVienDAO();
        }

        private void FMDashboard_Load(object sender, EventArgs e)
        {
            PopulateItems();
            UpdateTotalProfit();
        }
        private void PopulateItems()
        {
            pnlNhanVien.Controls.Clear();
            DataTable dt = dao.ThongTinNV();

            foreach (DataRow dr in dt.Rows)
            {
                var mStaff = new MStaffInfoInDash
                {
                    Nameuc = dr["HTen"].ToString(),
                    Iduc = dr["MaNV"].ToString()
                };
                pnlNhanVien.Controls.Add(mStaff);
            }
            lblSoNV.Text = dt.Rows.Count.ToString();
        }
        private void UpdateTotalProfit()
        {
            decimal totalProfit = dao.GetTotalProfit();
            totallb.Text = totalProfit.ToString();
        }
        private void btnDTNgay_Click(object sender, EventArgs e)
        {
            UpdateRevenueForToday();
        }
        private void UpdateRevenueForToday()
        {
            decimal todayRevenue = dao.GetRevenuePerDay(DateTime.Today);
            totallb.Text = todayRevenue.ToString();
            lblRevenue.Text = "Total Revenue";
        }

        private void btnDTThang_Click(object sender, EventArgs e)
        {
            int currentMonth = DateTime.Now.Month - 1;
            int currentYear = DateTime.Now.Year;
            string combinedString = $"{currentYear}-{currentMonth}";
            DataTable dt = dao.GetProfitFromLastMonth(combinedString);
            if (dt.Rows.Count > 0)
            {
                totallb.Text = dt.Rows[0]["LoiNhuan"].ToString();
            }
        }

        private void btnDTAll_Click(object sender, EventArgs e)
        {
            UpdateTotalProfit();
        }

        private void btnPhatLuong_Click(object sender, EventArgs e)
        {
            try
            {
                dao.PhatLuong();
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;
                string combinedString = $"{currentYear}-{currentMonth}";
                dao.AddProfitInfo(combinedString);
                FMDashboard_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }
    }
}
