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
    public partial class FLoading : Form
    {
        private int _value = 0;
        public FLoading()
        {
            InitializeComponent();
        }
        private void FLoading_Load(object sender, EventArgs e)
        {
            timeLoading.Start();
        }

        private void timeLoading_Tick(object sender, EventArgs e)
        {
            if (LoadingBar.Value == 100)
            {
                timeLoading.Stop();
                this.Hide();
                this.Close();
            }
            LoadingBar.Value += 1;
            _value += 1;
            lblValue.Text = _value.ToString() + "%";
        }


    }
}
