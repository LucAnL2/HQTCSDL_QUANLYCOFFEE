using DemoCSDL.ActiveInForms;
using DemoCSDL.Forms;
using DemoCSDL.UserControls;
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
    public partial class FWContainProduct : Form
    {
        //WProduct wProduct = new WProduct();
        public FWContainProduct()
        {
            InitializeComponent();
            //this.Controls.Add(wProduct);

        }

        private void FWContainProduct_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Active active = new Active();
            active.OpenChildForm(new WorkerChildForms.FWMenu(), ref Active.activeForm, FWorker.panelFill);
        }
    }
}
