using DemoCSDL.DAO;
using DemoCSDL.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUname.Text))
                {
                    MessageBox.Show("Vui lòng nhập tài khoản");
                    return;
                }

                if (string.IsNullOrEmpty(txtPass.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu");
                    return;
                }

                NhanVienDAO nhanVienDAO = new NhanVienDAO();
                DataTable duLieu = nhanVienDAO.HienThiThongTin(txtUname.Text);

                if (txtPass.Text != duLieu.Rows[0]["MatKhau"].ToString())
                {
                    MessageBox.Show("Sai mật khẩu, vui lòng thử lại.");
                    return;
                }

                ShortTermVariables.BienDungChung.taiKhoanND = duLieu.Rows[0]["TaiKhoan"].ToString();
                ShortTermVariables.BienDungChung.maNVND = duLieu.Rows[0]["MaNV"].ToString();
                DataTable bangVaiTro = nhanVienDAO.LayVaiTro(ShortTermVariables.BienDungChung.maNVND);

                string maVaiTro = bangVaiTro.Rows[0]["MaCV"].ToString();
                MoFormPhuHop(maVaiTro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message);
            }

        }
        private void MoFormPhuHop(string maVaiTro)
        {
            this.Hide();
            using (FLoading formLoading = new FLoading())
            {
                formLoading.ShowDialog();
            }
            if (maVaiTro == "CV1")
            {
                using (FWorker formCongNhan = new FWorker())
                {
                    formCongNhan.ShowDialog();
                }
            }
            else if (maVaiTro == "CV2")
            {
                using (FManager formQuanLy = new FManager())
                {
                    formQuanLy.ShowDialog();
                }
            }
            this.Close();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRegister fDangKy = new FRegister();
            fDangKy.ShowDialog();
            this.Close();
        }
    }
}
