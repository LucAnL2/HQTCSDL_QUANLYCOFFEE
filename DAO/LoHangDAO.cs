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
        public void ThemLoHang(LoHang lh)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ThemLoHang"))
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaLH", lh.MaLH);
                    cmd.Parameters.AddWithValue("@NgayHetHan", lh.NgayHetHan);
                    cmd.Parameters.AddWithValue("@NgayNhap", lh.NgayNhap);
                    cmd.Parameters.AddWithValue("@MaNL", lh.MaNL);
                    cmd.Parameters.AddWithValue("@SoLuong", lh.SoLuong);
                    cmd.Parameters.AddWithValue("@GiaTien", lh.GiaTien);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm Thành Công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }   
        }
    }
}
