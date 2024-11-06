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

namespace DemoCSDL.DAO
{
    public class NhanVienDAO
    {
        DBConnection connect = new DBConnection();

        public List<NhanVien> LayDSNhanVien()
        {
            string sql = "EXEC LayDanhSachNV";

            List<NhanVien> listNV = new List<NhanVien>();

            NhanVien nv = new NhanVien("NV00", "Tất cả");
            listNV.Add(nv);
            DataTable dt = connect.Load(sql);
            foreach (DataRow dr in dt.Rows)
            {
                NhanVien nv1 = new NhanVien(
                        dr["MaNV"].ToString(),
                        dr["HTen"].ToString()
                    );
                listNV.Add(nv1);
            }
            return listNV;
        }
        public DataTable LayNhanVien()
        {
            try
            {
                DBConnection dbConnection = new DBConnection();
                DataTable dtData = dbConnection.Load("Select * from NhanVien");
                return dtData;
            }
            catch
            {
                throw;
            }
        }
        public List<NhanVien> LayDanhSachMaMVDaDuocPhanCongCV()
        {
            string storeProcedure = "LayDanhSachMaNVDaDuocPhanCa";
            SqlParameter[] parameters = null;
            return connect.GetObjects<NhanVien>(storeProcedure,
                parameters,
                reader => new NhanVien
                {
                    MaNV = reader["MaNV"].ToString()
                }
            );
        }

        public List<NhanVien> LayDanhSachMaMVCuaTatCaNV()
        {
            string storeProcedure = "LayDanhTatCaMaNV";
            SqlParameter[] parameters = null;
            return connect.GetObjects<NhanVien>(storeProcedure,
                parameters,
                reader => new NhanVien
                {
                    MaNV = reader["MaNV"].ToString()
                }
            );
        }

        public void EditInfo(string id, string uname, string name, int age, string sex, string address, string phone, string pass)
        {
            connect = new DBConnection();

            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@ID", id);
                sqlcmd.Parameters.AddWithValue("@HoTen", name);
                sqlcmd.Parameters.AddWithValue("@UserName", uname);
                sqlcmd.Parameters.AddWithValue("@Age", age);
                sqlcmd.Parameters.AddWithValue("@Gender", sex);
                sqlcmd.Parameters.AddWithValue("@Address", address);
                sqlcmd.Parameters.AddWithValue("@Phone", phone);
                sqlcmd.Parameters.AddWithValue("@Password", pass);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "CapNhatTTND";
                sqlcmd.Connection = connect.sqlCon;
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
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        public DataTable DisplayInfo(string username)
        {
            connect = new DBConnection();

            DataTable dt = new DataTable();
            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand("LayTTND", connect.sqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
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
                connect.CloseConnection();
            }
            return dt;
        }
        public DataTable getrole(string idemp)
        {
            connect = new DBConnection();

            DataTable dt = new DataTable();
            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand("LayVaiTro", connect.sqlCon);
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
                connect.CloseConnection();
            }
            return dt;
        }

        public DataTable ThongTinNV()
        {
            string query = "Select * From ViewThucHien";
            connect = new DBConnection();
            DataTable dt = new DataTable();

            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand(query, connect.sqlCon);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
            }
            catch 
            {
                throw;
            }
            finally
            {
                connect.CloseConnection();
            }
            return dt;
        }

        public decimal GetRevenue(int month, int year)
        {
            connect = new DBConnection();
            connect.OpenConnection();
            decimal res = 0;
            try
            {
                string sqlQuery = "SELECT dbo.TongTienHoaDonTheoThang(@Thang, @Nam) AS TongDoanhThu";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, connect.sqlCon);
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
                connect.CloseConnection();
            }
            return res;
        }

        public decimal GetOutcome(int month, int year)
        {
            connect = new DBConnection();
            connect.OpenConnection();
            decimal res = 0;
            try
            {
                string sqlQuery = "SELECT dbo.TongTienNhapHangTheoThang(@Thang, @Nam) AS TongNhapHang";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, connect.sqlCon);
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
                connect.CloseConnection();
            }
            return res;
        }
        public decimal GetRevenuePerDay(DateTime datet)
        {
            connect = new DBConnection();
            connect.OpenConnection();
            decimal res = 0;
            try
            {
                string sqlQuery = "SELECT dbo.TongTienHoaDonTheoNgay(@Ngay) AS TongTheoNgay";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, connect.sqlCon);
                sqlcmd.Parameters.AddWithValue("@Ngay", datet);
                object result = sqlcmd.ExecuteScalar();
                res = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
            }
            return res;
        }
        public decimal GetTotalProfit()
        {
            connect = new DBConnection();
            connect.OpenConnection();
            decimal res = 0;
            try
            {
                string sqlQuery = "SELECT dbo.LayTongLoiNhuan() AS TongLN";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, connect.sqlCon);
                object result = sqlcmd.ExecuteScalar();
                res = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
            catch 
            {
                throw;
            }
            finally
            {
                connect.CloseConnection();
            }
            return res;

        }

        public DataTable GetProfitFromLastMonth(string date)
        {
            connect = new DBConnection();

            DataTable dt = new DataTable();
            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand("LayLoiNhuanThangTruoc", connect.sqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@date", date);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
            }
            return dt;
        }

        public void AddProfitInfo(string daTe)
        {
            connect = new DBConnection();

            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ThemLoiNhuan";
                sqlcmd.Connection = connect.sqlCon;
                sqlcmd.Parameters.AddWithValue("@date", daTe);
                int rowsAffected = sqlcmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Save Successfully!");
                }
                else
                {
                    MessageBox.Show("Error ! Please Try Again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        public string GenerateMaNV()
        {
            connect = new DBConnection();
            connect.OpenConnection();
            string res = "";
            try
            {
                string sqlQuery = "SELECT dbo.TaoMaNV() AS TaoMaNV";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, connect.sqlCon);
                object result = sqlcmd.ExecuteScalar();
                res = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
            }
            return res;
        }
        public void AddNewStaff(NhanVien nv)
        {
            connect = new DBConnection();

            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ThemNVIEN";
                sqlcmd.Connection = connect.sqlCon;
                sqlcmd.Parameters.AddWithValue("@manv", nv.MaNV);
                sqlcmd.Parameters.AddWithValue("@hten", nv.HTen);
                sqlcmd.Parameters.AddWithValue("@uname", nv.TaiKhoan);
                sqlcmd.Parameters.AddWithValue("@pass", nv.MatKhau);
                int rowsAffected = sqlcmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Register Successfully!");
                }
                else
                {
                    MessageBox.Show("Error ! Please Try Again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        public void PhatLuong()
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            };
            try
            {
                connect.ExecuteNonQuery("PhatLuong", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
    }
}
