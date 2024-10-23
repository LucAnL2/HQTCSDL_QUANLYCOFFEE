using DemoCSDL.Connection;
using DemoCSDL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DemoCSDL.DAO
{
    public class SanPhamDAO
    {
        DBConnection db = new DBConnection();
        public static List<SanPhamOrder> listOrder = new List<SanPhamOrder>();
        
        public DataTable LoadProduct()
        {
            string query = "select MaSP as [Mã SP], MaLoaiSP as [Mã loại SP], TenSP as [Tên SP], TinhTrang as [Tình trạng], Gia as [Giá bán], HinhAnh as [Hình ảnh], TenLoaiSP as [Tên loại SP] " +
                " from product_type";
            return db.Load(query);
        }

        public void DeleteProduct(SanPham sp)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaSP", sp.MaSP),
            };
            try
            {
                db.ExecuteNonQuery("DeleteProduct", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateProDuct(SanPham sp)
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
                db.ExecuteNonQuery("UpdateProduct", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public void AddProduct(SanPham sp)
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
                db.ExecuteNonQuery("AddProduct", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getDSSanPhamByString(string str)
        {
            string sql = "SELECT * FROM TimKiemSP(@searchString)";
             // Tạo tham số cho hàm
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@searchString", str)
            };

            // Gọi phương thức Load từ DBConnection, truyền câu lệnh và tham số
            DataTable table = db.Load(sql, parameters);
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
            DataTable dt = db.Load(sql, parameters);

            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham(
                    dr["MaSP"].ToString(),
                    dr["MaLoaiSP"].ToString(),
                    dr["TenSP"].ToString(),
                    dr["TinhTrang"].ToString(),
                    dr["HinhAnh"].ToString(),
                    Convert.ToDecimal(dr["Gia"])
                );
                listSP.Add(sp);
            }
            return listSP;
        }


    }
}
