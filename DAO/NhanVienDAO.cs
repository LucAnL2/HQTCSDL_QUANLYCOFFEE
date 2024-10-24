using DemoCSDL.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DemoCSDL.DAO
{
    public class NhanVienDAO
    {
        private DBConnection conn;
       
        public void EditInfo(string id, string uname, string name, int age, string sex, string address, string phone, string pass)
        {
            conn = new DBConnection();
            
            try
            {
                conn.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "UpdateUserInfo";
                sqlcmd.Connection = conn.sqlCon;
                sqlcmd.Parameters.AddWithValue("@ID",id);
                sqlcmd.Parameters.AddWithValue("@HoTen",name);
                sqlcmd.Parameters.AddWithValue("@UserName", uname);
                sqlcmd.Parameters.AddWithValue("@Age", age);
                sqlcmd.Parameters.AddWithValue("@Gender", sex);
                sqlcmd.Parameters.AddWithValue("@Address",address);
                sqlcmd.Parameters.AddWithValue("@Phone",phone);
                sqlcmd.Parameters.AddWithValue("@Password",pass);
                int rowsAffected = sqlcmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin người dùng thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng với ID đã cho.");
                }
            }
            catch(Exception ex)  
            {
                MessageBox.Show("Error"+ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }
        public DataTable DisplayInfo(string username) 
        {
            conn = new DBConnection();
          
            DataTable dt = new DataTable();
            try
            {
                conn.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand("GetUserInfo", conn.sqlCon);
                sqlcmd.CommandType= CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return dt;
        }
        public DataTable getrole(string idemp)
        {
            conn = new DBConnection();
            
            DataTable dt = new DataTable();
            try
            {
                conn.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand("Getrole", conn.sqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@idemp", idemp);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return dt;
        }

        public DataTable StaffInfo_View()
        {
            string query = "Select * From View_StaffInfo";
            conn = new DBConnection();
            DataTable dt = new DataTable();
            
            try
            {
                conn.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand(query, conn.sqlCon);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.CloseConnection(); 
            }
            return dt;
        }

        public decimal GetRevenue(int month, int year)
        {
            conn = new DBConnection();
            conn.OpenConnection();
            decimal res = 0;
            try
            {
                string sqlQuery = "SELECT dbo.TongTienHoaDonTheoThang(@Thang, @Nam) AS TongDoanhThu";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery,conn.sqlCon);
                sqlcmd.Parameters.AddWithValue("@Thang", month);
                sqlcmd.Parameters.AddWithValue("@Nam", year);
                object result = sqlcmd.ExecuteScalar();
                res = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return res;
        }

        public decimal GetOutcome(int month, int year)
        {
            conn = new DBConnection();
            conn.OpenConnection();
            decimal res = 0;
            try
            {
                string sqlQuery = "SELECT dbo.TongTienNhapHangTheoThang(@Thang, @Nam) AS TongNhapHang";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, conn.sqlCon);
                sqlcmd.Parameters.AddWithValue("@Thang", month);
                sqlcmd.Parameters.AddWithValue("@Nam", year);
                object result = sqlcmd.ExecuteScalar();
                res = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return res;
        }
        public decimal GetRevenuePerDay(DateTime datet)
        {
            conn = new DBConnection();
            conn.OpenConnection();
            decimal res = 0;
            try
            {
                string sqlQuery = "SELECT dbo.TongTienHoaDonTheoNgay(@Ngay) AS TongTheoNgay";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, conn.sqlCon);
                sqlcmd.Parameters.AddWithValue("@Ngay", datet);
                object result = sqlcmd.ExecuteScalar();
                res = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return res;
        }
        public decimal GetTotalProfit()
        {
            conn = new DBConnection();
            conn.OpenConnection();
            decimal res = 0;
            try
            {
                string sqlQuery = "SELECT dbo.LayTongLoiNhuan() AS TongLN";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, conn.sqlCon);
                object result = sqlcmd.ExecuteScalar();
                res = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return res;

        }
        public DataTable GetProfittb(string datet)
        {
            conn = new DBConnection();

            DataTable dt = new DataTable();
            try
            {
                conn.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand("LayTongLoiNhuanTheoThangNam", conn.sqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@ThangNam", datet);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return dt;

        }
    }
}
