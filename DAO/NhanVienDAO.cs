using DemoCSDL.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
