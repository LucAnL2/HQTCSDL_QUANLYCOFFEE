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
        private void FLogin_Load(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLoading fLoading = new FLoading();
            fLoading.ShowDialog();
            this.Close();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            FForgotPassword fForgotPassword = new FForgotPassword();
            fForgotPassword.ShowDialog();
            this.Close();
        }
    }
}
