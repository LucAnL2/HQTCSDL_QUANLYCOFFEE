using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCSDL.Connection;
using DemoCSDL.DAO;
using DemoCSDL.Models;

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMWarehouse : Form
    {
        public FMWarehouse()
        {
            InitializeComponent();
        }

        private void FMWarehouse_Load(object sender, EventArgs e)
        {
            LoadNguyenLieu();
            LoadLoHang();
        }
        // Xu li datagridview
        private void gvNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                string maNL = gvNguyenLieu.Rows[e.RowIndex].Cells[0].Value.ToString();
                string donGia = gvNguyenLieu.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtMaNL.Text = maNL;
                txtDonGia.Text = donGia;
            }
        }

        // Lay du lieu
        public void LoadNguyenLieu()
        {
            try
            {
                NguyenLieuDAO nguyenLieuDAO = new NguyenLieuDAO();
                gvNguyenLieu.DataSource = nguyenLieuDAO.LayNguyenLieu();
                gvDSNguyenLieu.DataSource = nguyenLieuDAO.LayNguyenLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        public void LoadLoHang()
        {
            try
            {
                LoHangDAO loHangDAO = new LoHangDAO();
                gvLoHang.DataSource = loHangDAO.LayLoHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        // Chuc nang
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            try
            {
                LoHang lh = new LoHang(
                    txtMaNL.Text,
                    DateTime.Now,
                    Convert.ToInt32(txtSoluong.Text),
                    Convert.ToDecimal(txtDonGia.Text)
                );
                LoHangDAO lhDAO = new LoHangDAO();
                lhDAO.ThemLoHang(lh);
                LoadLoHang();
                LoadNguyenLieu();
                MessageBox.Show("Thêm lô hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoluong.Text != "")
                txtTongTien.Text = Convert.ToString(Convert.ToInt32(txtSoluong.Text) * Convert.ToInt32(txtDonGia.Text));
            else
                txtTongTien.Text = "0";
        }

        private void txtThemNhuyenLieu_Click(object sender, EventArgs e)
        {
            try
            {
                NguyenLieu lh = new NguyenLieu(
                    txtMaNguyenLieu.Text,
                    txtTenNguyenLieu.Text,
                    Convert.ToInt32(txtGia.Text),
                    0
                );
                NguyenLieuDAO nlDAO = new NguyenLieuDAO();
                nlDAO.ThemNguyenLieu(lh);
                LoadLoHang();
                LoadNguyenLieu();
                MessageBox.Show("Thêm nguyên liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void gvDSNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maNL = gvDSNguyenLieu.Rows[e.RowIndex].Cells[0].Value.ToString();
                string tenNL = gvDSNguyenLieu.Rows[e.RowIndex].Cells[1].Value.ToString();
                string donGia = gvDSNguyenLieu.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtMaNguyenLieu.Text = maNL;
                txtTenNguyenLieu.Text = tenNL;
                txtGia.Text = donGia;
            }
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            try
            {
                NguyenLieu lh = new NguyenLieu(
                    txtMaNguyenLieu.Text,
                    txtTenNguyenLieu.Text,
                    Convert.ToDecimal(txtGia.Text),
                    0
                );

                NguyenLieuDAO nlDAO = new NguyenLieuDAO();
                nlDAO.SuaNguyenLieu(lh); // Gọi phương thức sửa

                LoadLoHang();
                LoadNguyenLieu();
                MessageBox.Show("Sửa nguyên liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            try
            {
                string maNguyenLieu = txtMaNguyenLieu.Text;

                NguyenLieuDAO nlDAO = new NguyenLieuDAO();
                nlDAO.XoaNguyenLieu(maNguyenLieu);

                LoadLoHang();
                LoadNguyenLieu();
                MessageBox.Show("Xóa nguyên liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
