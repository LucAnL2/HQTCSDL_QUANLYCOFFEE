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
using DemoCSDL.Models;
using DemoCSDL.UserControls;

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMIngredients : Form
    {
        CheBienDAO cbDAO = new CheBienDAO();
        public FMIngredients()
        {
            InitializeComponent();
        }
        private void LoadCB()
        {
            gvCheBien.DataSource = cbDAO.LayCheBien();
        }

        public void FMIngredients_Load(object sender, EventArgs e)
        {
            LoadCB();
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadCB();
            }
            else
            {
                string searchString = txtSearch.Text;
                gvCheBien.DataSource = cbDAO.LayDSCheBienBangChuoi(searchString);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham sp = new SanPham(txtMaSP.Text, txtTenSP.Text);
                FMProcessing form = new FMProcessing(sp);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi " + ex.Message);
            }
        }

        private void gvCheBien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                txtMaSP.ReadOnly = true;
                var row = gvCheBien.Rows[e.RowIndex];
                LoadSanPhamVaoForm(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadSanPhamVaoForm(DataGridViewRow row)
        {
            txtMaSP.Text = row.Cells[0].Value.ToString();
            txtTenSP.Text = cbDAO.LayTenSP(row.Cells[0].Value.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham(txtMaSP.Text, txtTenSP.Text);
            FMNProcessing form = new FMNProcessing(sp);
            form.Show();
        }

        private void btnXemNL_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham(txtMaSP.Text, txtTenSP.Text);
            FMProcessing form = new FMProcessing(sp);
            form.Show();
        }
    }
}
