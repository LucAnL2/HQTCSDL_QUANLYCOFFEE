using DemoCSDL.ActiveInForms;
using DemoCSDL.DAO;
using DemoCSDL.Forms;
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
    public partial class FMNProcessing : Form
    {
        NguyenLieuDAO nlDAO = new NguyenLieuDAO();
        SanPham sp;
        string maSp;
        CheBienDAO ctDAO = new CheBienDAO();
        List<NguyenLieu> listNL;
        public FMNProcessing(SanPham sp)
        {
            InitializeComponent();
            this.sp = sp;
            maSp = sp.MaSP;
            lblTenSP.Text = sp.TenSP;

        }
        public FMNProcessing()
        {
            InitializeComponent();

        }

        private void FMNProcessing_Load(object sender, EventArgs e)
        {
            LoadNguyeLieuSP();
        }

        private void LoadNguyeLieuSP()
        {
            listNL = nlDAO.LayNguyenLieuSP(maSp);
            foreach (NguyenLieu nguyenlieu in listNL)
            {
                MIngredient ucNL = new MIngredient(nguyenlieu) { Margin = new Padding(0, 0, 0, 1) };
                flowLPNguyenLieu.Controls.Add(ucNL);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
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
                        ctDAO.ThemCheBien(ct);

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
            Active.OpenChildForm(new ManagerChildForms.FMIngredients(), ref Active.activeForm, FManager.panelFill);
        }
    } 
}
