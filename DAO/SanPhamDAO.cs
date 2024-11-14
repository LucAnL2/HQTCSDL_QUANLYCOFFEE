using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Models;
using DemoCSDL.Connection;
using System.Windows.Forms;

namespace DemoCSDL.DAO
{
    public class SanPhamDAO
    {
        DBConnection dbConnection = new DBConnection();
        public static List<SanPhamOrder> listOrder = new List<SanPhamOrder>();

        public DataTable LaySanPham()
        {           
            try
            {
                string query = "Select MaSP as [Mã SP], MaLoaiSP as [Mã loại SP], " +
                "TenSP as [Tên SP], TinhTrang as [Tình trạng], Gia as [Giá bán], " +
                "HinhAnh as [Hình ảnh], TenLoaiSP as [Tên loại SP] from VIEW_ChiTietSanPham";

                DataTable dtData = dbConnection.Load(query);
                return dtData;
            }
            catch
            {
                throw;
            }
        }
       
        public void XoaSanPham(SanPham sp)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaSP", sp.MaSP),
            };
            try
            {
                dbConnection.ExecuteNonQuery("PROC_XoaSanPham", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public void CapNhatSanPham(SanPham sp)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaSP", sp.MaSP),
                    new SqlParameter("@MaLoaiSP", sp.MaLoaiSP),
                    new SqlParameter("@TenSP", sp.TenSP),
                    new SqlParameter("@TinhTrang", sp.TinhTrang),
                    new SqlParameter("@HinhAnh", sp.HinhAnh),
                    new SqlParameter("@Gia", sp.Gia)
            };
            try
            {
                dbConnection.ExecuteNonQuery("PROC_CapNhatSanPham", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public void ThemSanPham(SanPham sp)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaLoaiSP", sp.MaLoaiSP),
                    new SqlParameter("@TenSP", sp.TenSP),
                    new SqlParameter("@TinhTrang", sp.TinhTrang),
                    new SqlParameter("@HinhAnh", sp.HinhAnh),
                    new SqlParameter("@Gia", sp.Gia)
            };
            try
            {
                dbConnection.ExecuteNonQuery("PROC_ThemSanPham", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public bool CheckNguyenLieu(string maSP, int sLHienTai, int soLuongOrder)
        {
            bool isEnough = false; // Mặc định là không đủ

            // Tạo tham số cho stored procedure
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", maSP),
                new SqlParameter("@SoLuong", soLuongOrder),
                new SqlParameter("@CurrentSoLuong", sLHienTai)
            };

            try
            {
                // Gọi stored procedure và nhận kết quả từ ExecuteScalar
                object result = dbConnection.ExecuteScalar("PROC_CheckNguyenLieu", parameters, CommandType.StoredProcedure);

                // Kiểm tra kết quả
                if (result != null)
                {
                    isEnough = Convert.ToInt32(result) == 1; // Kết quả từ procedure
                }
            }
            catch
            {
                throw;
            }

            return isEnough; // Trả về kết quả kiểm tra
        }
        public DataTable LayDSSanPhamBangChuoi(string str)
        {
            string sql = "SELECT * FROM FUNC_TimKiemSP(@searchString)";
            // Tạo tham số cho hàm
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@searchString", str)
            };

            // Gọi phương thức Load từ DBConnection, truyền câu lệnh và tham số
            DataTable table = dbConnection.Load(sql, parameters);
            return table;
        }

        public List<SanPham> DSSanPham(string maLoaiSP)
        {
            List<SanPham> listSP = new List<SanPham>();

            // Thay đổi câu lệnh SQL để sử dụng tham số
            string sql = "EXEC PROC_HienThiSP @MaLoaiSP";

            // Tạo tham số
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLoaiSP", maLoaiSP)
            };

            // Gọi phương thức Load với tham số
            DataTable dt = dbConnection.Load(sql, parameters);

            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham(
                    dr["MaSP"].ToString(),
                    dr["MaLoaiSP"].ToString(),
                    dr["TenSP"].ToString(),
                    dr["TinhTrang"].ToString(),
                    Convert.ToDecimal(dr["Gia"]),
                    dr["HinhAnh"].ToString()
                );
                listSP.Add(sp);
            }
            return listSP;
        }
        public string LayMaSPMoi()
        {
            try
            {
                string query = "SELECT dbo.FUNC_TaoMaSP()";

                object result = dbConnection.ExecuteScalar(query, null, CommandType.Text);

                return result != null ? result.ToString() : null;
            }
            catch
            {
                throw;
            }
        }
        public string LayTenSP(string maSP)
        {
            try
            {
                string query = "SELECT dbo.FUNC_LayTenSP(@MaSP)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSP", maSP)
                };

                object result = dbConnection.ExecuteScalar(query, parameters, CommandType.Text);

                return result != null ? result.ToString() : string.Empty; 
            }
            catch 
            {
                throw;
            }
        }

    }
}
