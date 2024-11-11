using DemoCSDL.DAO;
using DemoCSDL.Models;
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
    public partial class MIngredient : UserControl
    {
        NguyenLieu nl;
        public MIngredient(NguyenLieu nl)
        {
            InitializeComponent();
            this.nl = nl;
            UCCheckboxTenNL.Text = nl.TenNL;
            UClblSluongNL.Text = nl.SoLuong.ToString();
        }


        private void MIngredient_Load(object sender, EventArgs e)
        {

        }

        private void UCCheckboxTenNL_CheckedChanged(object sender, EventArgs e)
        {
            if( UCCheckboxTenNL.Checked == true)
            {
               if(nl.TamThoi == false)
                {
                    nl.TamThoi = true;
                }
            }
            else
            {
                if(nl.TamThoi == true)
                {
                    nl.TamThoi = false;
                }
            }
        }

        private void UCNumericNL_ValueChanged(object sender, EventArgs e)
        {
            nl.SoLuongCB = Convert.ToInt32(UCNumericNL.Value);
        }
    }
}
