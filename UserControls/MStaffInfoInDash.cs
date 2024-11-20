using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCSDL.Models;

namespace DemoCSDL.UserControls
{
    public partial class MStaffInfoInDash : UserControl
    {
        public MStaffInfoInDash(NhanVien nv)
        {
            InitializeComponent();
            txtname.Text = nv.HTen;
            txtid.Text = nv.MaNV;
         
        }
        private string name;
        private string id;

        #region properties
        public string Nameuc
        {
            get { return name; }
            set { name = value; txtname.Text = value; }
        }
        public string Iduc
        {
            get { return id; }
            set { id = value; txtid.Text = value; }
        }
        #endregion

        private void MStaffInfoInDash_Load(object sender, EventArgs e)
        {

        }
    }
}
