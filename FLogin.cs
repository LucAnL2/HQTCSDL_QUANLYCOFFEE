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
        private void FLogin_Load(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (unametb.Text == "")
            {
                MessageBox.Show("Please enter information");
            }
            else
            {
                ShortTermVariables.ShortTermVariables.unameEmp = unametb.Text;
                DataTable dt = new DataTable();
                NhanVienDAO dao = new NhanVienDAO();
                dt = dao.DisplayInfo(unametb.Text);
                if(dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    label1.Text = dr["MatKhau"].ToString();
                    if (passtb.Text == dr["MatKhau"].ToString())
                    {
                        ShortTermVariables.ShortTermVariables.idEmp = dr["MaNV"].ToString();
                        DataTable dt1 = new DataTable();
                        dt1=dao.getrole(ShortTermVariables.ShortTermVariables.idEmp);
                        if(dt1.Rows.Count > 0)
                        {
                            DataRow dr1 = dt1.NewRow();
                            if (dr1["MaCV"].ToString()=="1")
                            {
                                this.Hide();
                                FLoading fLoading = new FLoading();
                                fLoading.ShowDialog();
                                FManager fManager = new FManager();
                                fManager.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                                FLoading fLoading = new FLoading();
                                fLoading.ShowDialog();
                                FWorker fworker = new FWorker();
                                fworker.ShowDialog();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                       MessageBox.Show("Wrong Password please try again");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong information please try again");
                }
            }
              
            
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
