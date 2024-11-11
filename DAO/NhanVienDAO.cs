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
            string sql = "EXEC PROC_LayDanhSachNV";

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
            string storeProcedure = "PROC_LayDanhSachMaNVDaDuocPhanCa";
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
            string storeProcedure = "PROC_LayDanhTatCaMaNV";
            SqlParameter[] parameters = null;
            return connect.GetObjects<NhanVien>(storeProcedure,
                parameters,
                reader => new NhanVien
                {
                    MaNV = reader["MaNV"].ToString()
                }
            );
        }

        public void ChinhSuaThongTin(string id, string uname, string name, int age, string sex, string address, string phone, string pass)
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
                sqlcmd.CommandText = "PROC_CapNhatTTND";
                sqlcmd.Connection = connect.sqlCon;

                int soDongBiAnhHuong = sqlcmd.ExecuteNonQuery();
                if (soDongBiAnhHuong <= 0)
                {
                    throw new Exception("Vui lòng thử lại.");
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        public DataTable HienThiThongTin(string username)
        {
            connect = new DBConnection();

            DataTable dt = new DataTable();
            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand("PROC_LayTTND", connect.sqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@username", username);
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
        public DataTable LayVaiTro(string idemp)
        {
            connect = new DBConnection();

            DataTable dt = new DataTable();
            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand("PROC_LayVaiTro", connect.sqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@idemp", idemp);
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
        public decimal LayDoanhThuNgay(DateTime datetime)
        {
            connect = new DBConnection();
            decimal res = 0;
            try
            {
                connect.OpenConnection();
                string sqlQuery = "SELECT dbo.FUNC_TongTienHoaDonTheoNgay(@Ngay) AS TongTheoNgay";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, connect.sqlCon);
                sqlcmd.Parameters.AddWithValue("@Ngay", datetime);
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
        public decimal LayTongLoiNhuan()
        {
            connect = new DBConnection();
            decimal res = 0;
            try
            {
                connect.OpenConnection();
                string sqlQuery = "SELECT dbo.FUNC_LayTongLoiNhuan()";
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

        public DataTable LayLoiNhuanThangTruoc(string date)
        {
            connect = new DBConnection();
                
            DataTable dt = new DataTable();
            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand("PROC_LayLoiNhuanThangTruoc", connect.sqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@date", date);
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

        public void ThemThongTinLoiNhuan(string daTe)
        {
            connect = new DBConnection();

            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "PROC_ThemLoiNhuan";
                sqlcmd.Connection = connect.sqlCon;
                sqlcmd.Parameters.AddWithValue("@date", daTe);

                int soDongBiAnhHuong = sqlcmd.ExecuteNonQuery();
                if (soDongBiAnhHuong <= 0)
                {
                    throw new Exception("Vui lòng thử lại.");
                }
            }
            catch 
            {
                throw;
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        public string TaoMaNV()
        {
            connect = new DBConnection();
            string ketQua = "";

            try
            {
                connect.OpenConnection();
                string sqlQuery = "SELECT dbo.FUNC_TaoMaNV()";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, connect.sqlCon);
                object ketQuaTruyVan = sqlcmd.ExecuteScalar();
                ketQua = ketQuaTruyVan.ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                connect.CloseConnection();
            }

            return ketQua;
        }
        public void ThemNhanVien(NhanVien nv)
        {
            connect = new DBConnection();

            try
            {
                connect.OpenConnection();
                using (SqlCommand sqlcmd = new SqlCommand())
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "PROC_ThemNVIEN";
                    sqlcmd.Connection = connect.sqlCon;
                    sqlcmd.Parameters.AddWithValue("@manv", nv.MaNV);
                    sqlcmd.Parameters.AddWithValue("@hten", nv.HTen);
                    sqlcmd.Parameters.AddWithValue("@uname", nv.TaiKhoan);
                    sqlcmd.Parameters.AddWithValue("@pass", nv.MatKhau);

                    int soDongBiAnhHuong = sqlcmd.ExecuteNonQuery();
                    if (soDongBiAnhHuong <= 0)
                    {
                        throw new Exception("Vui lòng thử lại.");
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        public void PhatLuong()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            try
            {
                connect.ExecuteNonQuery("PROC_PhatLuong", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public void XoaNV(string manv)
        {
            connect = new DBConnection();

            try
            {
                connect.OpenConnection();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "PROC_XoaNV";
                sqlcmd.Connection = connect.sqlCon;
                sqlcmd.Parameters.AddWithValue("@Manv", manv);

                int soDongBiAnhHuong = sqlcmd.ExecuteNonQuery();
                if (soDongBiAnhHuong <= 0)
                {
                    throw new Exception("Vui lòng thử lại.");
                }
            }
            catch 
            {
                throw;
            }
            finally
            {
                connect.CloseConnection();
            }
        }
    }
}
