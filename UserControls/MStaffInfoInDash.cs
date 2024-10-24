using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL.UserControls
{
    public partial class MStaffInfoInDash : UserControl
    {
        public MStaffInfoInDash()
        {
            InitializeComponent();
        }
        private string name;
        private string id;

        #region properties
        public string Nameuc
        {
            get { return name; }
            set { name = value; nameuc.Text = value; }
        }
        public string Iduc
        {
            get { return id; }
            set { id = value; iduc.Text = value; }
        }
        #endregion
    }
}
