using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCSDL.DAO;
using DemoCSDL.UserControls;

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMShift : Form
    {
        CaLamViecDAO clv = new CaLamViecDAO();
        //MStaffRegisterShift msr = new MStaffRegisterShift();
        public FMShift()
        {
            InitializeComponent();
            //this.Controls.Add(this.msr);
            //msr.Show();
            gvContainShift.DataSource = clv.load();
        }

        private void FMShift_Load(object sender, EventArgs e)
        {

        }
    }
}
