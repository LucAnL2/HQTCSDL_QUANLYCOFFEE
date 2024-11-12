using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Models;
using DemoCSDL.Connection;
using System.Data;
using System.Windows.Forms;
using System.CodeDom;

namespace DemoCSDL.DAO
{
    public class CheBienDAO
    {
        DBConnection dbConnection = new DBConnection();
        public void ThemCheBien(CheBien ct)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", ct.MaSP),
                new SqlParameter("@MaNL", ct.MaNL),
                new SqlParameter("@SLCanDung", ct.SLCanDung)
            };
            try
            {
                dbConnection.ExecuteNonQuery("PROC_ThemCheBien", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

        }

        public void SuaCheBien(CheBien ct, out bool kiemTra)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", ct.MaSP),
                new SqlParameter("@MaNL", ct.MaNL),
                new SqlParameter("@SLCanDung", ct.SLCanDung),
                new SqlParameter("@KiemTra", SqlDbType.Bit) { Direction = ParameterDirection.Output }  // Thêm tham số OUTPUT
            };

            try
            {
                // Thực thi thủ tục và nhận giá trị OUTPUT
                dbConnection.ExecuteNonQuery("PROC_SuaCheBien", parameters, CommandType.StoredProcedure);

                // Lấy giá trị của @KiemTra sau khi thực thi thủ tục
                kiemTra = (bool)parameters.FirstOrDefault(p => p.ParameterName == "@KiemTra").Value;
            }
            catch
            {
                throw;
            }
        }

        public void XoaCheBien(CheBien ct)
        {
           SqlParameter[] parameters = new SqlParameter[]
           {
                new SqlParameter("@MaSP", ct.MaSP),
                new SqlParameter("@MaNL", ct.MaNL),
           };
            try
            {
                dbConnection.ExecuteNonQuery("PROC_XoaCheBien", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

        }

        public DataTable LayCheBien()
        {
            DataTable result = new DataTable();
            try
            {
                string storedProcedureName = "PROC_LayCheBien";
                result = dbConnection.Load(storedProcedureName);
            }
            catch
            {
                throw;
            }
            return result;
        }
        public DataTable LayDSCheBienBangChuoi(string str)
        {
            string sql = "SELECT * FROM FUNC_TimKiemCheBien(@searchString)";
            // Tạo tham số cho hàm
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@searchString", str)
            };

            // Gọi phương thức Load từ DBConnection, truyền câu lệnh và tham số
            DataTable table = dbConnection.Load(sql, parameters);
            return table;
        }

        public string LayTenSP(string maSP)
        {
            string tenSP = string.Empty;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", maSP)
            };

            try
            {
                // Gọi stored procedure để lấy tên sản phẩm
                object result = dbConnection.ExecuteScalar("PROC_LayTenSP", parameters, CommandType.StoredProcedure);

                // Kiểm tra nếu result là null trước khi chuyển đổi sang string
                if (result != null)
                {
                    tenSP = result.ToString();
                }
                else
                {
                    tenSP = "Không tìm thấy sản phẩm"; // hoặc thông báo lỗi khác
                }
            }
            catch 
            {
                throw;
            }

            return tenSP;
        }


    }
}
