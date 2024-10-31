using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Models;
using DemoCSDL.Connection;

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
                "HinhAnh as [Hình ảnh], TenLoaiSP as [Tên loại SP] from ChiTietSanPham";

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
                dbConnection.ExecuteNonQuery("XoaSanPham", parameters, CommandType.StoredProcedure);
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
                dbConnection.ExecuteNonQuery("CapNhatSanPham", parameters, CommandType.StoredProcedure);
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
                    new SqlParameter("@MaSP", sp.MaSP),
                    new SqlParameter("@MaLoaiSP", sp.MaLoaiSP),
                    new SqlParameter("@TenSP", sp.TenSP),
                    new SqlParameter("@TinhTrang", sp.TinhTrang),
                    new SqlParameter("@HinhAnh", sp.HinhAnh),
                    new SqlParameter("@Gia", sp.Gia)
            };
            try
            {
                dbConnection.ExecuteNonQuery("ThemSanPham", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public DataTable LayDSSanPhamBangChuoi(string str)
        {
            string sql = "SELECT * FROM TimKiemSP(@searchString)";
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
            string sql = "EXEC HienThiSP @MaLoaiSP";

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
    }
}
