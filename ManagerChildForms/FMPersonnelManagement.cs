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
    }
}
