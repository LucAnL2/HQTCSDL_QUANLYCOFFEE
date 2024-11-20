using DemoCSDL.DAO;
using DemoCSDL.Models;
using DemoCSDL.ShortTermVariables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL.Forms
{
    public partial class FRegister : Form
    {
        public FRegister()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin fLogin = new FLogin();
            fLogin.ShowDialog();   
            this.Close();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                BienDungChung.SetQuyenAdmin();
                NhanVienDAO nhanVienDAO = new NhanVienDAO();
                string maNV = nhanVienDAO.TaoMaNV();
                NhanVien nhanVien = new NhanVien(maNV, txtHTen.Text, txtTaiKhoan.Text, txtMatKhau.Text, txtEmail.Text);

                nhanVienDAO.ThemNhanVien(nhanVien);
                MessageBox.Show("Đăng ký thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký thất bại: " + ex.Message);
            }
        }
    }
}
