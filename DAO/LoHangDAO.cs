using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Connection;
using System.Data;
using DemoCSDL.Models;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DemoCSDL.DAO
{
    public class LoHangDAO
    {
        DBConnection dbConnection = new DBConnection();
        public void ThemLoHang(LoHang lh)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNL", lh.MaNL),
                new SqlParameter("@NgayNhap", lh.NgayNhap),
                new SqlParameter("@SoLuong", lh.SoLuong),
                new SqlParameter("@DonGia", lh.DonGia),
            };
            try
            {
                dbConnection.ExecuteNonQuery("ThemLoHang", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public DataTable LayLoHang()
        {
            try
            {
                DataTable dtData = dbConnection.Load("Select * from LoHang");
                return dtData;
            }
            catch
            {
                throw;
            }
        }
    }
}
