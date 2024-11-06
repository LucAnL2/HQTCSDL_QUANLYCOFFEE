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
    public partial class FMShift : Form
    {
        //Tạo các đối tượng DAO
        CaLamViecDAO clvDAO = new CaLamViecDAO();
        NhanVienDAO nvDAO = new NhanVienDAO();
        DangKyDAO dkDAO = new DangKyDAO();

        //Tạo list Model cần sử dụng
        List<CaLamViec> danhSachCa = new List<CaLamViec>();
        List<NhanVien> danhSachMaCaNVDaDuocPhanCongCV = new List<NhanVien>();
        List<NhanVien> danhSachNhanVien = new List<NhanVien>();
        List<CaLamViec> danhSachTatCaMaCa = new List<CaLamViec>();

        public FMShift()
        {
            InitializeComponent();
            danhSachCa = clvDAO.LayDanhSachMaCa();
            danhSachMaCaNVDaDuocPhanCongCV = nvDAO.LayDanhSachMaMVDaDuocPhanCongCV();
            danhSachNhanVien = nvDAO.LayDanhSachMaMVCuaTatCaNV();
            danhSachTatCaMaCa = clvDAO.LayDanhSachTatCaMaCa();
            resetTabPhanCong();
            resetControls();
        }

        //Thêm ca làm việc mới
        private void btnAddShift_Click(object sender, EventArgs e)
        {
            try
            {
                CaLamViec clv = new CaLamViec(txtShiftID.Text, dtpStartDay.Value, dtpStartTime.Value, dtpEndTime.Value);
                clvDAO.ThemCaLamViec(clv);
                MessageBox.Show("Ca làm việc được thêm thành công");
                gvContainShift.DataSource = clvDAO.HienThiCaLam();
                resetTabPhanCong();
                resetControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                resetControls();
            }
        }        
        private void btnEditShift_Click(object sender, EventArgs e)
        {
            try
            {
                CaLamViec clv = new CaLamViec(txtShiftID.Text, dtpStartDay.Value, dtpStartTime.Value, dtpEndTime.Value);
                clvDAO.SuaCaLamViec(clv);
                MessageBox.Show("Cập nhật thành công");
                gvContainShift.DataSource = clvDAO.HienThiCaLam();
                resetControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                resetControls();
            }
        }

        //Xóa ca làm việc
        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            try
            {
                CaLamViec clv = new CaLamViec(txtShiftID.Text, dtpStartDay.Value, dtpStartTime.Value, dtpEndTime.Value);
                clvDAO.XoaCaLamViec(clv);
                MessageBox.Show("Xóa thành công");
                gvContainShift.DataSource = clvDAO.HienThiCaLam();
                resetTabPhanCong();
                resetControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                resetControls();
            }
        }

        //Reset các đối tượng về trạng thái ban đầu
        private void resetControls()
        {
            txtShiftID.Text = "";
            dtpStartDay.Value = DateTime.Now;
            dtpStartDay.CustomFormat = "yyyy-MM-dd";
            dtpStartTime.Value = DateTime.Today.Add(new TimeSpan(0, 0, 0));
            dtpStartTime.CustomFormat = "HH-mm-ss";
            dtpStartTime.ShowUpDown = true;
            dtpEndTime.Value = DateTime.Today.Add(new TimeSpan(0, 0, 0));
            dtpEndTime.CustomFormat = "HH-mm-ss";
            dtpEndTime.ShowUpDown = true;
        }

        private void resetTabPhanCong()
        {
            danhSachMaCaNVDaDuocPhanCongCV = nvDAO.LayDanhSachMaMVDaDuocPhanCongCV();
            danhSachNhanVien = nvDAO.LayDanhSachMaMVCuaTatCaNV();
            danhSachTatCaMaCa = clvDAO.LayDanhSachTatCaMaCa();
            //Hiển thị danh sách ca làm việc đã tạo lên datagridviews
            gvContainShift.DataSource = clvDAO.HienThiCaLam();
            //Hiển thị danh sách ca làm đã được phân công cho nhân viên lên datagirdviews
            gvStaffRegisterShift.DataSource = clvDAO.HienThiCaLamDaDK();

            cbbMaca.DataSource = danhSachCa;
            cbbMaca.DisplayMember = "MaCa";
            cbbMaNV.DataSource = danhSachMaCaNVDaDuocPhanCongCV;
            cbbMaNV.DisplayMember = "MaNV";
            cbbMaNVDK.DataSource = danhSachNhanVien;
            cbbMaNVDK.DisplayMember = "MaNV";
            cbbMaCaDK.DataSource = danhSachTatCaMaCa;
            cbbMaCaDK.DisplayMember = "MaCa";
        }

        private void gvContainShift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = gvContainShift.Rows[e.RowIndex];
                    txtShiftID.Text = selectedRow.Cells["Mã ca"].Value?.ToString();
                    if (DateTime.TryParse(selectedRow.Cells["Ngày làm"].Value?.ToString(), out DateTime startDay))
                    {
                        dtpStartDay.Value = startDay;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu 'Ngày làm' không hợp lệ.");
                    }
                    if (TimeSpan.TryParse(selectedRow.Cells["Giờ bắt đầu"].Value?.ToString(), out TimeSpan startTime))
                    {
                        dtpStartTime.Value = DateTime.Today.Add(startTime);
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu 'Giờ bắt đầu' không hợp lệ.");
                    }
                    if (TimeSpan.TryParse(selectedRow.Cells["Giờ kết thúc"].Value?.ToString(), out TimeSpan endTime))
                    {
                        dtpEndTime.Value = DateTime.Today.Add(endTime);
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu 'Giờ kết thúc' không hợp lệ.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                DangKy dk = new DangKy(cbbMaNVDK.Text, cbbMaCaDK.Text);
                dkDAO.ThemDangKy(dk);
                MessageBox.Show("Ca làm việc được phân công thành công");
                gvStaffRegisterShift.DataSource = clvDAO.HienThiCaLamDaDK();
                resetTabPhanCong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            resetTabPhanCong();
        }

        private void cbbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvStaffRegisterShift.DataSource = clvDAO.HienThiTheoBoLoc(cbbMaNV.Text);
        }

        private void cbbMaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvStaffRegisterShift.DataSource = clvDAO.HienThiTheoBoLoc(cbbMaca.Text);
        }
    }
}
