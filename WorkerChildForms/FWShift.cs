using DemoCSDL.DAO;
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

namespace DemoCSDL.WorkerChildForms
{
    public partial class FWShift : Form
    {
        private string MaNV = "NV1";
        CaLamViecDAO clvDAO = new CaLamViecDAO();
        DangKyDAO dkDAO = new DangKyDAO();
        List<CaLamViec> danhSachCa = new List<CaLamViec>();
        public FWShift()
        {
            InitializeComponent();
            gvStaffRegisterShift.DataSource = clvDAO.hienThiTheoBoLoc(MaNV);
            danhSachCa = clvDAO.layDanhSachMaCa();
            cbbMaca.DataSource = danhSachCa;
            cbbMaca.DisplayMember = "MaCa";
        }

        private void FWShift_Load(object sender, EventArgs e)
        {
            gvStaffRegisterShift.DataSource = clvDAO.hienThiTheoBoLoc(MaNV);
        }

        private void cbbMaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvStaffRegisterShift.DataSource = clvDAO.hienThiTheoMaNVVaMaCa(MaNV,cbbMaca.Text);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            gvStaffRegisterShift.DataSource = clvDAO.hienThiTheoBoLoc(MaNV);
        }

        private void btnViewSalary_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy(MaNV);
            MessageBox.Show(dkDAO.tinhLuong(dk).ToString());
        }
    }
}
