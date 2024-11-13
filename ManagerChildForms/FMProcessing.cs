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
    public partial class FMProcessing : Form
    {
        NguyenLieuDAO nlDAO = new NguyenLieuDAO();
        SanPham sp;
        string maSp;
        CheBienDAO cbDAO = new CheBienDAO();
        List<NguyenLieu> listNL = new List<NguyenLieu>();
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
        private void FMProcessing_Load(object sender, EventArgs e)
        {
            LoadNguyenLieuSPDaCo();
        }

        private void LoadNguyenLieuSPDaCo()
        {
            listNL = nlDAO.LayNguyenLieuDaCo(maSp);
            foreach (NguyenLieu nl in listNL)
            {
                MIngredient ucNL = new MIngredient(nl) { Margin = new Padding(0, 0, 0, 1) };
                flowLPIngredient.Controls.Add(ucNL);
            }
        }

        private void btnThoatt_Click(object sender, EventArgs e)
        {
            this.Close();
            Active.OpenChildForm(new ManagerChildForms.FMIngredients(), ref Active.activeForm, FManager.panelFill);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            foreach (NguyenLieu nl in listNL)
            {
                CheBien ct = new CheBien(maSp, nl.MaNL, nl.SoLuongCB);
                bool kiemTra; 

                try
                {
                    cbDAO.SuaCheBien(ct, out kiemTra);

                    if (kiemTra)
                    {
                        MessageBox.Show("Sửa nguyên liệu của sản phẩm "+sp.TenSP+" thành công");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show("Có lỗi khi sửa nguyên liệu: " + nl.MaNL + "\n" + ex.Message);
                }
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (NguyenLieu nl in listNL)
            {
                if (nl.TamThoi == false)
                {
                    CheBien ct = new CheBien(maSp, nl.MaNL, nl.SoLuongCB);
                    cbDAO.XoaCheBien(ct);
                    MessageBox.Show("Xóa nguyên liệu cuả sản phẩm "+sp.TenSP + " thành công");
                    flowLPIngredient.Controls.Clear();
                    LoadNguyenLieuSPDaCo();
                }
            }
        }
    }
}
