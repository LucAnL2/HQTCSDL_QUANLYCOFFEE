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
using DemoCSDL.ShortTermVariables;

namespace DemoCSDL.WorkerChildForms
{
    public partial class FWShift : Form
    {       
        CaLamViecDAO clvDAO = new CaLamViecDAO();
        DangKyDAO dkDAO = new DangKyDAO();
        List<CaLamViec> danhSachCa = new List<CaLamViec>();
        public FWShift()
        {
            InitializeComponent();
            gvStaffRegisterShift.DataSource = clvDAO.HienThiTheoBoLoc(BienDungChung.maNVND);
            danhSachCa = clvDAO.LayDanhSachMaCa();
            cbbMaca.DataSource = danhSachCa;
            cbbMaca.DisplayMember = "MaCa";
        }

        private void FWShift_Load(object sender, EventArgs e)
        {
            gvStaffRegisterShift.DataSource = clvDAO.HienThiTheoBoLoc(BienDungChung.maNVND);
        }

        private void cbbMaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvStaffRegisterShift.DataSource = clvDAO.HienThiTheoMaNVVaMaCa(BienDungChung.maNVND,cbbMaca.Text);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            gvStaffRegisterShift.DataSource = clvDAO.HienThiTheoBoLoc(BienDungChung.maNVND);
        }

        private void btnRutLuong_Click(object sender, EventArgs e)
        {
            dkDAO.RutLuong(BienDungChung.maNVND);
            MessageBox.Show("Rút lương thành công");
        }

        private void btnHienLuong_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy(BienDungChung.maNVND);
            MessageBox.Show(dkDAO.TinhLuong(dk).ToString());
        }
    }
}
