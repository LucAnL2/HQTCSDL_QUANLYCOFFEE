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

namespace DemoCSDL.ManagerChildForms
{
    public partial class FMPersonnelManagement : Form
    {
        public FMPersonnelManagement()
        {
            InitializeComponent();
            LoadNhanVien();
        }

        public void LoadNhanVien()
        {
            try
            {
                NhanVienDAO nhanVienDAO = new NhanVienDAO();
                gvNhanVien.DataSource = nhanVienDAO.LayNhanVien();
                if (gvNhanVien.Columns.Contains("btnXoaNhanVien") == false)
                {
                    DataGridViewButtonColumn buttonColumnXN = new DataGridViewButtonColumn
                    {
                        Name = "btnXoaNhanVien",
                        HeaderText = "Xóa",
                        Text = "✗",
                        UseColumnTextForButtonValue = true,
                        Width = 50,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None

                    };
                    gvNhanVien.Columns.Add(buttonColumnXN);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void gvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NhanVienDAO dao = new NhanVienDAO();
            // Kiểm tra xem cột bấm vào có phải là btnXoaNhanVien không và không phải là hàng tiêu đề
            if (e.RowIndex >= 0 && gvNhanVien.Columns[e.ColumnIndex].Name == "btnXoaNhanVien")
            {
                // Lấy thông tin hàng cần xóa, ví dụ: ID nhân viên từ cột đầu tiên
                string idNhanVien = (gvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value).ToString();

                // Thực hiện hành động xóa: hiển thị xác nhận hoặc gọi hàm xóa từ cơ sở dữ liệu
                var xacNhanKQ = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo);
                if (xacNhanKQ == DialogResult.Yes)
                {
                    // Gọi hàm xóa trong cơ sở dữ liệu
                    dao.XoaNV(idNhanVien);

                    // Xóa hàng khỏi DataGridView
                    LoadNhanVien();
                }
            }
        }
    }
}
