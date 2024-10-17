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
            Active active = new Active();
            active.OpenChildForm(new ManagerChildForms.FMDashboard(), ref Active.activeForm, panelFill);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Active active = new Active();
            active.OpenChildForm(new ManagerChildForms.FMDashboard(), ref Active.activeForm, panelFill);
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Active active = new Active();
            active.OpenChildForm(new ManagerChildForms.FMAddProduct(), ref Active.activeForm, panelFill);
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

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
