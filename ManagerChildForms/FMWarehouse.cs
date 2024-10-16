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
            // TODO: This line of code loads data into the 'qLCFFDataSet.NguyenLieu' table. You can move, or remove it, as needed.
            this.nguyenLieuTableAdapter.Fill(this.qLCFFDataSet.NguyenLieu);
            AddColumn();
        }

        public void AddColumn()
        {
            DataGridViewButtonColumn dBC = new DataGridViewButtonColumn();
            dBC.HeaderText = "Nhập Hàng";
            dBC.Text = "Nhập Hàng";
            dBC.UseColumnTextForButtonValue = true;
            gvNhapHang.Columns.Add(dBC);
        }

        private void gvNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                string maNL = gvNhapHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMaNL.Text = maNL;
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            LoHang lh = new LoHang(txtMalohang.Text, dtNgayHetHan.Value, dtNgayNhap.Value, txtMaNL.Text, Convert.ToInt32(txtSoluong.Text),
                Convert.ToDecimal(txtGiatien.Text));
            LoHangDAO lhDAO = new LoHangDAO();
            lhDAO.ThemLoHang(lh);
            
        }
    }
}
