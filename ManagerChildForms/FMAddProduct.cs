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
        public FMAddProduct()
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged_1;
        }
        DBConnection db = new DBConnection();
        SanPhamDAO spd = new SanPhamDAO();
        LoaiSPDAO loaiSP = new LoaiSPDAO();

        List<loaiSP> listLSP;
        private void FMAddProduct_Load(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = false;
            listLSP = loaiSP.layDSProduct();
            cbbMaLoaiSP.DataSource = listLSP;
            cbbMaLoaiSP.DisplayMember = "TenLoaiSP"; // Thuộc tính hiển thị
            cbbMaLoaiSP.ValueMember = "MaLoaiSP";
            gvProduct.DataSource = spd.LoadProduct();

        }

        public void LoadImage(PictureBox picProduct, Guna2TextBox ImagePath)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false; // Only allow single file selection

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Image image = Image.FromFile(fileName);

                // Set the PictureBox and TextBox
                picProduct.SizeMode = PictureBoxSizeMode.Zoom;
                picProduct.Image = image; // Directly set the image
                ImagePath.Text = fileName; // Set the path of the image
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string tinhTrang = "Còn hàng";
            string maLoaiSP = cbbMaLoaiSP.SelectedValue.ToString();
            SanPham sp = new SanPham(txtMaSP.Text, maLoaiSP, txtTenSP.Text, tinhTrang, txtImagePath.Text, Decimal.Parse(txtGia.Text));
            spd.AddProduct(sp);
            FMAddProduct_Load(sender, e);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            LoadImage(picProduct, txtImagePath);
        }

        private void gvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
            try
            {
                if (e.RowIndex >= 0)
                {
                    txtMaSP.ReadOnly = true;
                    DataGridViewRow row = gvProduct.Rows[e.RowIndex];

                    txtMaSP.Text = row.Cells[0].Value.ToString();
                    string maLoaiSP = row.Cells[1].Value.ToString(); // Giả sử ô 1 chứa MaLoaiSP

                    // Gán tên loại sản phẩm vào ComboBox
                    var selectedItem = listLSP.FirstOrDefault(lsp => lsp.MaLoaiSP == maLoaiSP);
                    if (selectedItem != null)
                    {
                        cbbMaLoaiSP.SelectedValue = selectedItem.MaLoaiSP; // Gán giá trị tương ứng
                    }

                    txtTenSP.Text = row.Cells[2].Value.ToString();
                    txtGia.Text = row.Cells[4].Value.ToString();

                    string imagePath = row.Cells[5].Value.ToString();

                   
                    Image image = Image.FromFile(imagePath);
                    picProduct.SizeMode = PictureBoxSizeMode.Zoom;
                    picProduct.Image = image;
                    txtImagePath.Text = imagePath; // Gán đường dẫn vào TextBox
                   



                }
            }
            catch { }
         
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = false;
            SanPham sp = new SanPham(txtMaSP.Text);
            spd.DeleteProduct(sp);
            FMAddProduct_Load(sender, e);
            clear();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = false;
            string tinhTrang = "Còn hàng";
            string maLoaiSP = cbbMaLoaiSP.SelectedValue.ToString();
            SanPham sp = new SanPham(txtMaSP.Text, maLoaiSP, txtTenSP.Text, tinhTrang, txtImagePath.Text, Decimal.Parse(txtGia.Text));
            spd.UpdateProDuct(sp);
            FMAddProduct_Load(sender, e);

            clear();
        }


        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                gvProduct.DataSource = spd.LoadProduct();
                FMAddProduct_Load(sender, e);
            }
            else
            {
                string searchString = txtSearch.Text;
                DataTable productTable = spd.getDSSanPhamByString(searchString);
                gvProduct.DataSource = productTable;
               

            }
            
        }

        private void clear()
        {
            txtMaSP.Text = "";
            txtImagePath.Text = "";
            txtTenSP.Text = "";
            txtGia.Text = "";

            picProduct.Image = null;
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
