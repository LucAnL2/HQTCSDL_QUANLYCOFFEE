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
        //MStaffInfoInDash mStaffInfoInDash = new MStaffInfoInDash();
        public FMDashboard()
        {
            InitializeComponent();
            //this.Controls.Add(this.mStaffInfoInDash);
            //mStaffInfoInDash.Show();
        }

        private void FMDashboard_Load(object sender, EventArgs e)
        {
            populateItems();
            NhanVienDAO dao = new NhanVienDAO();
            //lay du lieu tu bang tong cac dot loi nhuan roi dua vao totallb
            decimal rs = dao.GetTotalProfit();
            totallb.Text = rs.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NhanVienDAO dao = new NhanVienDAO();
            DateTime today = DateTime.Today;
            //goi function tinh doanh thu trong hom nay
            decimal rs = dao.GetRevenuePerDay(today);
            totallb.Text = rs.ToString();
        }
        private void populateItems()
        {
            NhanVienDAO dao = new NhanVienDAO();
            flowLayoutPanel1.Controls.Clear();
            DataTable dt = new DataTable();
            dt = dao.StaffInfo_View();
            MStaffInfoInDash[] mStaffs = new MStaffInfoInDash[dt.Rows.Count];
            for (int i =0;i< mStaffs.Length; i++)
            {
                DataRow dr = dt.Rows[i];
                mStaffs[i] = new MStaffInfoInDash();
                mStaffs[i].Nameuc = dr["HTen"].ToString();
                mStaffs[i].Iduc = dr["MaNV"].ToString();
                if(flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(mStaffs[i]);
            }
            label3.Text = dt.Rows.Count.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            NhanVienDAO dao = new NhanVienDAO();
            DataTable dt = new DataTable();
            //goi function tinh tong tien hoa don trong 1 thang + tong tien lo hang trong 1 thang - tong luong nhan vien rtong 1 thang roi luu vao bang tong loi nhuan
            /*int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            decimal rs = dao.GetOutcome(currentMonth, currentYear); //tong tien nhap hang
            decimal rs1 = dao.GetRevenue(currentMonth, currentYear); //tong tien hoa don 
            // luong nhan vien rs2 = ....
            decimal finalres = rs1 - rs;*/
            DateTime currentDate = DateTime.Now; // Lấy ngày và giờ hiện tại
            DateTime previousMonthDate = currentDate.AddMonths(-1); // Lấy tháng trước
            int previousMonth = previousMonthDate.Month; // Tháng trước
            int currentYear = DateTime.Now.Year;
            string result = $"{previousMonth}-{currentDate}";
            dt=dao.GetProfittb(result);
            DataRow dr = dt.Rows[0];
            totallb.Text = dr["LoiNhuan"].ToString() ;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            NhanVienDAO dao = new NhanVienDAO();
            decimal rs = dao.GetTotalProfit();
            totallb.Text = rs.ToString();
        }
    }
}
