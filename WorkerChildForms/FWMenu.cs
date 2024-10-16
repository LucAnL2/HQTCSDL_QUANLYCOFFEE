using DemoCSDL.ActiveInForms;
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
    }
}
