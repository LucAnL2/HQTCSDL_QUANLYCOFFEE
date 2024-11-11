using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Models;
using System.Windows.Forms;
using System.Web.UI.WebControls.WebParts;
using DemoCSDL.Connection;

namespace DemoCSDL.DAO
{
    public class ChiTietDAO
    {
        DBConnection db = new DBConnection();
        public string TaoMaHD()
        {
            string maHD = null;
            try
            {
                // Gọi hàm GenerateMaHD để lấy mã HD mới
                string query = "SELECT dbo.FUNC_TaoMaHD()"; // Câu lệnh gọi hàm
                object result = db.ExecuteScalar(query, null, CommandType.Text); // Gọi phương thức ExecuteScalar

                // Kiểm tra kết quả và chuyển đổi thành string
                if (result != null)
                {
                    maHD = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return maHD; // Trả về mã HD mới
        }
        public DataTable QLChiTietHD(string maHD)
        {
            string sql = "EXEC PROC_QLChiTietHD @MaHD";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@MaHD", maHD)
            };

            DataTable dt = db.Load(sql, parameter);
            return dt;

        }
        public void ThemChiTietHD(ChiTiet ct)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHD", ct.MaHD),
                new SqlParameter("@MaSP", ct.MaSP),
                new SqlParameter("@SoLuong", ct.SoLuong),
                new SqlParameter("@DonGia", ct.DonGia)
            };
            try
            {
                db.ExecuteNonQuery("PROC_ThemChiTietHD", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public List<ChiTiet> LoadCTHD(string maHD)
        {
            List<ChiTiet> listCT = new List<ChiTiet>();

            string sql = "EXEC PROC_LayCTHoaDon @MaHD";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHD", maHD)
            };

            DataTable dt = db.Load(sql, parameters);

            foreach (DataRow dr in dt.Rows)
            {
                ChiTiet ct = new ChiTiet(
                    dr["MaHD"].ToString(),
                    dr["MaSP"].ToString(),
                    Convert.ToInt32(dr["SoLuong"]),
                    Convert.ToDecimal(dr["TongTien"]),
                    Convert.ToDecimal(dr["DonGia"])
                    );
                listCT.Add(ct);
            }
            return listCT;
        }
    }
}
