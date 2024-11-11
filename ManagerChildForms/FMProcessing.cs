using DemoCSDL.DAO;
using DemoCSDL.Models;
using DemoCSDL.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMProcessing : Form
    {
        NguyenLieuDAO nld = new NguyenLieuDAO();
        SanPham sp;
        string maSp;
        CheBienDAO ctd = new CheBienDAO();
        List<NguyenLieu> listNL;
        public FMProcessing(SanPham sp)
        {
            InitializeComponent();
            this.sp = sp;
            maSp = sp.MaSP;
            lblTenSP.Text = sp.TenSP;

        }
        public FMProcessing()
        {
            InitializeComponent();

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FMProcessing_Load(object sender, EventArgs e)
        {
            LoadNguyeLieuSP();
        }

        private void LoadNguyeLieuSP()
        {
            listNL = nld.LayNguyenLieuSP();
            foreach (NguyenLieu nguyenlieu in listNL)
            {
                MIngredient ucNL = new MIngredient(nguyenlieu) { Margin = new Padding(0, 0, 0, 1) };
                flowLPIngredient.Controls.Add(ucNL);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string maNL;
                int soLuongCB;
                foreach (NguyenLieu nl in listNL)
                {
                    if (nl.TamThoi == true)
                    {
                        maNL = nl.MaNL;
                        soLuongCB = nl.SoLuongCB;
                        CheBien ct = new CheBien(maSp, maNL, soLuongCB);
                        ctd.ThemCheBien(ct);

                    }
                }
                MessageBox.Show("Thêm nguyên liệu cho sản phẩm thành công");
            }
            catch (SqlException ex)
            {
                // Hiển thị thông báo lỗi từ trigger ra màn hình
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
