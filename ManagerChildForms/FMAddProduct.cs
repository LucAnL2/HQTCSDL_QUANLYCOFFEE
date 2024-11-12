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
            LoadLoaiSP();
            LoadSP();
        }
        private void LoadLoaiSP()
        {
            listLSP = loaiSPDAO.LayDSSanPham();
            cbbMaLoaiSP.DataSource = listLSP;
            cbbMaLoaiSP.DisplayMember = "TenLoaiSP";
            cbbMaLoaiSP.ValueMember = "MaLoaiSP";
        }
        private void LoadSP()
        {
            gvProduct.DataSource = spDAO.LaySanPham();
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var sp = TaoSPTuInput();
                spDAO.ThemSanPham(sp);
                LoadSP();
                MessageBox.Show("Thêm sản phẩm thành công");
                FMNProcessing form = new FMNProcessing(sp);
                form.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private SanPham TaoSPTuInput()
        {
            string maLoaiSP = cbbMaLoaiSP.SelectedValue.ToString();
            return new SanPham(txtMaSP.Text, maLoaiSP, txtTenSP.Text, "Còn hàng", decimal.Parse(txtGia.Text), fileName);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            picProduct.Image = ThaoTacAnh.ThemMotAnh(ref fileName);
        }

        private void gvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            try
            {
                txtMaSP.ReadOnly = true;
                var row = gvProduct.Rows[e.RowIndex];
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
            string maLoaiSP = row.Cells[1].Value.ToString();

            // Gán tên loại sản phẩm vào ComboBox
            var itemDuocChon = listLSP.FirstOrDefault(lsp => lsp.MaLoaiSP == maLoaiSP);
            if (itemDuocChon != null)
            {
                cbbMaLoaiSP.SelectedValue = itemDuocChon.MaLoaiSP;
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
                LoadSP();
                XoaThongTin();
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
                var sp = TaoSPTuInput();
                spDAO.CapNhatSanPham(sp);
                LoadSP();
                XoaThongTin();
                MessageBox.Show("Sửa sản phẩm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void XoaThongTin()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGia.Clear();
            txtMaSP.ReadOnly = false;
            picProduct.Image = null;
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            XoaThongTin();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadSP();
            }
            else
            {
                string searchString = txtSearch.Text;
                gvProduct.DataSource = spDAO.LayDSSanPhamBangChuoi(searchString);
            }
        }

        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = spDAO.TaoMaSP();
        }
    }
}
