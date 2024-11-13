using DemoCSDL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMinformation : Form
    {
        NhanVienDAO nvDAO = new NhanVienDAO();
        public FMinformation()
        {
            InitializeComponent();
        }
        public int flag;

        private void CapNhatTruongDoiMK()
        {
            btnLuu.Visible = true;
            GanTruongReadOnly(true);
            txtMatKhau.ReadOnly = false;
            txtMatKhau.Enabled = true;
        }

        private void CapNhatTruongChinhSua()
        {
            btnLuu.Visible = true;
            GanTruongReadOnly(false);
            txtMatKhau.ReadOnly = true;
            txtMatKhau.Enabled = false;
        }

        private void GanTruongReadOnly(bool isReadOnly)
        {
            txtHTen.ReadOnly = isReadOnly;
            txtTuoi.ReadOnly = isReadOnly;
            txtGioiTinh.ReadOnly = isReadOnly;
            txtTaiKhoan.ReadOnly = isReadOnly;
            txtSDT.ReadOnly = isReadOnly;
            txtDiaChi.ReadOnly = isReadOnly;
            txtEmail.ReadOnly = isReadOnly; 
        }

        private void FMinformation_Load(object sender, EventArgs e)
        {
            CapNhatTTNV();
        }
        private void CapNhatTTNV()
        {
            try
            {
                string taiKhoan = ShortTermVariables.BienDungChung.taiKhoanND;
                DataTable thongTinND = nvDAO.HienThiThongTin(taiKhoan);

                if (thongTinND.Rows.Count > 0)
                {
                    DataRow dr = thongTinND.Rows[0];
                    txtHTen.Text = dr["HTen"].ToString();
                    txtTaiKhoan.Text = dr["TaiKhoan"].ToString();
                    txtID.Text = dr["MaNV"].ToString();
                    txtTuoi.Text = dr["Tuoi"].ToString();
                    txtGioiTinh.Text = dr["GTinh"].ToString();
                    txtSDT.Text = dr["SDT"].ToString();
                    txtMatKhau.Text = dr["MatKhau"].ToString();
                    txtDiaChi.Text = dr["DChi"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi " + ex.Message);
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            // Chuyển sang chế độ đổi mật khẩu
            flag = 1;
            CapNhatTruongDoiMK();
        }

        private void btnSuaTT_Click(object sender, EventArgs e)
        {
            // Chuyển sang chế độ chỉnh sửa thông tin cá nhân
            flag = 2;
            CapNhatTruongChinhSua();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text;
                string name = txtHTen.Text;
                string uname = txtTaiKhoan.Text;
                string sex = txtGioiTinh.Text;
                string addr = txtDiaChi.Text;
                string phone = txtSDT.Text;
                string pass = txtMatKhau.Text;
                int age = int.Parse(txtTuoi.Text);
                string email = txtEmail.Text;

                nvDAO.ChinhSuaThongTin(id, uname, name, age, sex, addr, phone, pass, email);
                GanTruongReadOnly(true);
                btnLuu.Visible = false;
                MessageBox.Show("Lưu thành công!");
                FMinformation_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi " + ex.Message);
            }
        }
    } 
}
