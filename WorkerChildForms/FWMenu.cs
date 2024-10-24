using DemoCSDL.ActiveInForms;
using DemoCSDL.DAO;
using DemoCSDL.Forms;
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
    public partial class FWMenu : Form
    {
        public FWMenu()
        {
            InitializeComponent();
        }

        private void btnOpenCream_Click(object sender, EventArgs e)
        {
            Active active = new Active();
            active.OpenChildForm(new WorkerChildForms.FWContainProduct(), ref Active.activeForm, FWorker.panelFill);
        }

        private void FWMenu_Load(object sender, EventArgs e)
        {
            NhanVienDAO dAO = new NhanVienDAO();
            DataTable dt = new DataTable();
            dt=dAO.DisplayInfo(ShortTermVariables.ShortTermVariables.idEmp);
            DataRow dr = dt.Rows[0];
            settingbtn.Text = dr["TaiKhoan"].ToString();
        }
    }
}
