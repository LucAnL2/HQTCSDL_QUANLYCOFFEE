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
        public FMinformation()
        {
            InitializeComponent();
        }
        public int flag;

        private void ConfigureFieldsForPasswordChange()
        {
            savebtn.Visible = true;
            SetFieldsReadOnly(true);
            passtb.ReadOnly = false;
            passtb.Enabled = true;
        }

        private void ConfigureFieldsForInfoEdit()
        {
            savebtn.Visible = true;
            SetFieldsReadOnly(false);
            passtb.ReadOnly = true;
            passtb.Enabled = false;
        }

        private void SetFieldsReadOnly(bool isReadOnly)
        {
            nametb.ReadOnly = isReadOnly;
            agetb.ReadOnly = isReadOnly;
            sextb.ReadOnly = isReadOnly;
            unametb.ReadOnly = isReadOnly;
            phonetb.ReadOnly = isReadOnly;
            addresstb.ReadOnly = isReadOnly;
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dao = new NhanVienDAO();
                string id = idtb.Text;
                string name = nametb.Text;
                string uname = unametb.Text;
                string sex = sextb.Text;
                string addr = addresstb.Text;
                string phone = phonetb.Text;
                string pass = passtb.Text;
                int age = int.Parse(agetb.Text);

                dao.EditInfo(id, uname, name, age, sex, addr, phone, pass);
                SetFieldsReadOnly(true);
                savebtn.Visible = false;
                FMinformation_Load(sender, e);
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng cho tuổi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FMinformation_Load(object sender, EventArgs e)
        {
            LoadStaffInfo();
        }
        private void LoadStaffInfo()
        {
            var dao = new NhanVienDAO();
            string username = ShortTermVariables.ShortTermVariables.unameEmp;
            DataTable userInfo = dao.DisplayInfo(username);

            if (userInfo.Rows.Count > 0)
            {
                DataRow dr = userInfo.Rows[0];
                nametb.Text = dr["HTen"].ToString();
                unametb.Text = dr["TaiKhoan"].ToString();
                idtb.Text = dr["MaNV"].ToString();
                agetb.Text = dr["Tuoi"].ToString();
                sextb.Text = dr["GTinh"].ToString();
                phonetb.Text = dr["SDT"].ToString();
                passtb.Text = dr["MatKhau"].ToString();
                addresstb.Text = dr["DChi"].ToString();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!");
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            // Chuyển sang chế độ đổi mật khẩu
            flag = 1;
            ConfigureFieldsForPasswordChange();
        }

        private void btnSuaTT_Click(object sender, EventArgs e)
        {
            // Chuyển sang chế độ chỉnh sửa thông tin cá nhân
            flag = 2;
            ConfigureFieldsForInfoEdit();
        }
    } 
}
