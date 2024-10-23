using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCSDL.Connection;
using DemoCSDL.Models;

namespace DemoCSDL.DAO
{
   
    public class ChiTietDAO
    {
        DBConnection db = new DBConnection();

        
        public string taoMaHD()
        {
            string maHD = null;

            try
            {
                // Gọi hàm GenerateMaHD để lấy mã HD mới
                string query = "SELECT dbo.TaoMaHD()"; // Câu lệnh gọi hàm
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
        

        public void themChiTietHD(ChiTiet ct)
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
                db.ExecuteNonQuery("themChiTietHD", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public List<ChiTiet> LoadCTHD(string maHD)
        {
            List<ChiTiet> listCT = new List<ChiTiet>();

            string sql = "EXEC layCTHoaDon @MaHD";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHD", maHD)
            };

            DataTable dt = db.Load(sql, parameters);

            foreach(DataRow dr in  dt.Rows ) 
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
