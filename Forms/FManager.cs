using DemoCSDL.ActiveInForms;
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
    public partial class FManager : Form
    {
        public FManager()
        {
            InitializeComponent();
        }
        private void FManager_Load(object sender, EventArgs e)
        {
            Active.OpenChildForm(new ManagerChildForms.FMDashboard(), ref Active.activeForm, panelFill);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            FLogin fLogin = new FLogin();
            fLogin.Show();
            this.Hide();
            this.Close();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Active.OpenChildForm(new ManagerChildForms.FMDashboard(), ref Active.activeForm, panelFill);
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Active.OpenChildForm(new ManagerChildForms.FMAddProduct(), ref Active.activeForm, panelFill);
        }
        private void btnStorage_Click(object sender, EventArgs e)
        {
            Active.OpenChildForm(new ManagerChildForms.FMWarehouse(), ref Active.activeForm, panelFill);
        }
        private void btnSideBar_Click(object sender, EventArgs e)
        {
            if (panelLeft.Visible == false)
            {
                panelLeft.Visible = true;
            }
            else
            {
                panelLeft.Visible = false;
            }
        }
        private void btnShift_Click(object sender, EventArgs e)
        {
            Active.OpenChildForm(new ManagerChildForms.FMShift(), ref Active.activeForm, panelFill);
        }

        private void btnMBill_Click(object sender, EventArgs e)
        {
            Active.OpenChildForm(new ManagerChildForms.FMBill(), ref Active.activeForm, panelFill);
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            Active.OpenChildForm(new ManagerChildForms.FMinformation(), ref Active.activeForm, panelFill);
        }
        private void btnPM_Click(object sender, EventArgs e)
        {
            Active.OpenChildForm(new ManagerChildForms.FMPersonnelManagement(), ref Active.activeForm, panelFill);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin fLogin = new FLogin();
            fLogin.ShowDialog();
            this.Close();
        }
    }
}
