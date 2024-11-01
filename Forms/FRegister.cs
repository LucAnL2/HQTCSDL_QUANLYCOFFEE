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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NhanVienDAO dao = new NhanVienDAO();
            string manv = dao.GenerateMaNV();
            NhanVien nhanVien = new NhanVien(manv,fnametb.Text,unametb.Text,passtb.Text);
            dao.AddNewStaff(nhanVien);
        }
    }
}
