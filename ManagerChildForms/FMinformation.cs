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
       

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //pass
            flag = 1;
            savebtn.Visible = true;
            nametb.ReadOnly = true;
            nametb.Enabled = false;
            agetb.ReadOnly = true;
            agetb.Enabled = false;
            sextb.ReadOnly = true;
            sextb.Enabled = false;
            unametb.ReadOnly = true;
            unametb.Enabled = false;
            phonetb.ReadOnly = true;
            phonetb.Enabled = false;
            addresstb.ReadOnly = true;
            addresstb.Enabled = false;
            passtb.ReadOnly = false;
            passtb.Enabled = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //info
            flag = 2;
            savebtn.Visible = true;
            nametb.ReadOnly = false;
            nametb.Enabled = true;
            agetb.ReadOnly = false;
            agetb.Enabled = true;
            sextb.ReadOnly = false;
            sextb.Enabled = true;
            unametb.ReadOnly = false;
            unametb.Enabled = true;
            phonetb.ReadOnly = false;
            phonetb.Enabled = true;
            addresstb.ReadOnly = false;
            addresstb.Enabled = true;
            passtb.ReadOnly = true;
            passtb.Enabled = false;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (flag == 2)
            {
                string id = idtb.Text;
                string name = nametb.Text;
                string uname = unametb.Text;
                string sex = sextb.Text;
                string addr = addresstb.Text;
                string phone = phonetb.Text;
                string pass = passtb.Text;
                int age = int.Parse(agetb.Text);
                NhanVienDAO dao = new NhanVienDAO();
                dao.EditInfo(id, uname, name, age, sex, addr, phone, pass);
                nametb.ReadOnly = true;
                nametb.Enabled = false;
                agetb.ReadOnly = true;
                agetb.Enabled = false;
                sextb.ReadOnly = true;
                sextb.Enabled = false;
                unametb.ReadOnly = true;
                unametb.Enabled = false;
                phonetb.ReadOnly = true;
                phonetb.Enabled = false;
                addresstb.ReadOnly = true;
                addresstb.Enabled = false;
                savebtn.Visible = false;
                FMinformation_Load(sender, e);
            }
            else if (flag == 1)
            {
                string id = idtb.Text;
                string name = nametb.Text;
                string uname = unametb.Text;
                string sex = sextb.Text;
                string addr = addresstb.Text;
                string phone = phonetb.Text;
                string pass = passtb.Text;
                int age = int.Parse(agetb.Text);
                NhanVienDAO dao = new NhanVienDAO();
                dao.EditInfo(id, uname, name, age, sex, addr, phone, pass);
                passtb.ReadOnly = true;
                passtb.Enabled = false;
                savebtn.Visible = false;
                FMinformation_Load(sender, e);
            }
        }

        private void FMinformation_Load(object sender, EventArgs e)
        {
            string unem = ShortTermVariables.ShortTermVariables.unameEmp;
            NhanVienDAO dao = new NhanVienDAO();
            DataTable dt = dao.DisplayInfo(unem);
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
               
            }
            else
            {
                // Xử lý nếu không có dữ liệu  
                MessageBox.Show("Không có dữ liệu để hiển thị!");
            }
        }
    }

   
}
