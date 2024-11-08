using DemoCSDL.Connection;
using DemoCSDL.DAO;
using DemoCSDL.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMAddProduct : Form
    {
        private readonly SanPhamDAO spDAO = new SanPhamDAO();
        private readonly LoaiSPDAO loaiSPDAO = new LoaiSPDAO();
        private string fileName = "";
        private List<LoaiSP> listLSP;
        public FMAddProduct()
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;
        }
        private void FMAddProduct_Load(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = false;
            LoadProductCategories();
            LoadProducts();
        }
        private void LoadProductCategories()
        {
            listLSP = loaiSPDAO.LayDSProduct();
            cbbMaLoaiSP.DataSource = listLSP;
            cbbMaLoaiSP.DisplayMember = "TenLoaiSP";
            cbbMaLoaiSP.ValueMember = "MaLoaiSP";
        }
        private void LoadProducts()
        {
            gvProduct.DataSource = spDAO.LaySanPham();
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var sp = CreateProductFromInputs();
                spDAO.ThemSanPham(sp);
                LoadProducts();
                MessageBox.Show("Thêm sản phẩm thành công");
                FMProcessing form = new FMProcessing(sp);
                form.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private SanPham CreateProductFromInputs()
        {
            string maLoaiSP = cbbMaLoaiSP.SelectedValue.ToString();
            return new SanPham(txtMaSP.Text, maLoaiSP, txtTenSP.Text, "Còn hàng", decimal.Parse(txtGia.Text), fileName);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            picProduct.Image = ThaoTacAnh.ThemMotAnh(ref fileName);
        }

        private void LoadProductToInputs(DataGridViewRow row)
        {
            txtMaSP.Text = row.Cells[0].Value.ToString();
            string maLoaiSP = row.Cells[1].Value.ToString();

            // Gán tên loại sản phẩm vào ComboBox
            var selectedItem = listLSP.FirstOrDefault(lsp => lsp.MaLoaiSP == maLoaiSP);
            if (selectedItem != null)
            {
                cbbMaLoaiSP.SelectedValue = selectedItem.MaLoaiSP;
            }

            txtTenSP.Text = row.Cells[2].Value.ToString();
            txtGia.Text = row.Cells[4].Value.ToString();
            picProduct.Image = ThaoTacAnh.LayAnh(row.Cells[5].Value.ToString());
            fileName = row.Cells[5].Value.ToString();
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaSP.ReadOnly = false;
                var sp = new SanPham(txtMaSP.Text);
                spDAO.XoaSanPham(sp);
                LoadProducts();
                ClearInputs();
                MessageBox.Show("Xóa sản phẩm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaSP.ReadOnly = false;
                var sp = CreateProductFromInputs();
                spDAO.CapNhatSanPham(sp);
                LoadProducts();
                ClearInputs();
                MessageBox.Show("Sửa sản phẩm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearInputs()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGia.Clear();
            txtMaSP.ReadOnly = false;
            picProduct.Image = null;
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadProducts();
            }
            else
            {
                string searchString = txtSearch.Text;
                gvProduct.DataSource = spDAO.LayDSSanPhamBangChuoi(searchString);
            }
        }

        private void gvProduct_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                txtMaSP.ReadOnly = true;
                var row = gvProduct.Rows[e.RowIndex];
                LoadProductToInputs(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
