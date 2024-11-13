
using DemoCSDL.DAO;
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

namespace DemoCSDL.WorkerChildForms
{
    public partial class FWinformation : Form
    {
        private int flag;

        public FWinformation()
        {
            InitializeComponent();
        }
        private void FWinformation_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfo();
        }

        private void LoadEmployeeInfo()
        {
            string username = ShortTermVariables.BienDungChung.taiKhoanND;
            NhanVienDAO dao = new NhanVienDAO();
            DataTable dt = dao.HienThiThongTin(username);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                nametb.Text = dr["HTen"].ToString();
                unametb.Text = dr["TaiKhoan"].ToString();
                idtb.Text = dr["MaNV"].ToString();
                agetb.Text = dr["Tuoi"].ToString();
                sextb.Text = dr["GTinh"].ToString();
                phonetb.Text = dr["SDT"].ToString();
                passtb.Text = dr["MatKhau"].ToString();
                addresstb.Text = dr["DChi"].ToString();
                txtemail.Text = dr["Email"].ToString();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!");
            }
        }

        private void ConfigureFieldsForInfoEdit()
        {
            savebtn.Visible = true;
            SetFieldsReadOnly(false);
            passtb.ReadOnly = true;
            passtb.Enabled = false;
        }

        private void ConfigureFieldsForPasswordChange()
        {
            savebtn.Visible = true;
            SetFieldsReadOnly(true);
            passtb.ReadOnly = false;
            passtb.Enabled = true;
        }

        private void SetFieldsReadOnly(bool isReadOnly)
        {
            nametb.ReadOnly = isReadOnly;
            agetb.ReadOnly = isReadOnly;
            sextb.ReadOnly = isReadOnly;
            unametb.ReadOnly = isReadOnly;
            phonetb.ReadOnly = isReadOnly;
            addresstb.ReadOnly = isReadOnly;
            txtemail.ReadOnly = isReadOnly;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = idtb.Text;
                string name = nametb.Text;
                string uname = unametb.Text;
                string sex = sextb.Text;
                string addr = addresstb.Text;
                string phone = phonetb.Text;
                string pass = passtb.Text;
                string email = txtemail.Text;
                int age;

                // Kiểm tra định dạng tuổi
                if (!int.TryParse(agetb.Text, out age))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng cho tuổi.");
                    return;
                }

                NhanVienDAO dao = new NhanVienDAO();
                dao.ChinhSuaThongTin(id, uname, name, age, sex, addr, phone, pass, email);

                // Cập nhật trạng thái sau khi lưu
                SetFieldsReadOnly(true);
                savebtn.Visible = false;
                MessageBox.Show("Lưu thành công!");
                FWinformation_Load(sender, e);
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
            ConfigureFieldsForPasswordChange();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            // Chuyển sang chế độ chỉnh sửa thông tin
            flag = 2;
            ConfigureFieldsForInfoEdit();
        }

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rút tiền thành công!");
        }
    }
}
