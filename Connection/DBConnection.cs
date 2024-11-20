using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCSDL.Models;
using DemoCSDL.ShortTermVariables;

namespace DemoCSDL.Connection
{
    public class DBConnection
    {
        public string strCon = @"Data Source=LAPTOP-3RJ8EVL2\THIENDB;Initial Catalog=QLQCFF;User ID="+BienDungChung.taiKhoanND+";Password="+BienDungChung.matkhauND+";Encrypt=False";
        public SqlConnection sqlCon = null;

        public void OpenConnection()
        {
            try
            {              
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
            }
            catch 
            {
                throw;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public void ExecuteNonQuery(string storeProcedure, SqlParameter[] parameters, CommandType commandType)
        {
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(storeProcedure, sqlCon))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable Load(string sqlStr, SqlParameter[] parameters = null)
        {
            DataTable dtData = new DataTable();
            try
            {
                OpenConnection();

                using (SqlCommand command = new SqlCommand(sqlStr, sqlCon))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dtData.Load(reader);
                    }
                }
            }
            catch 
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return dtData;
        }
        public object ExecuteScalar(string storeProcedure, SqlParameter[] parameters, CommandType commandType)
        {
            object result = null;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(storeProcedure, sqlCon))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    result = cmd.ExecuteScalar();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public decimal ExecuteScalarDecimal(string storeProcedure, SqlParameter[] parameters, CommandType commandType)
        {
            decimal result = 0;

            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(storeProcedure, sqlCon))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    var scalarResult = cmd.ExecuteScalar();
                    if (scalarResult != null)
                    {
                        result = Convert.ToDecimal(scalarResult); // Sử dụng Convert.ToDecimal cho giá trị lớn
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }

        public List<T> GetObjects<T>(string storeProcedure, SqlParameter[] parameters, Func<SqlDataReader, T> mapFunction)
        {
            List<T> result = new List<T>();

            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(storeProcedure, sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Ánh xạ từng bản ghi từ SqlDataReader sang đối tượng T
                            T item = mapFunction(reader);
                            result.Add(item);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }

        public List<NhanVien> GetNhanVienList()
        {
            List<NhanVien> nhanVienList = new List<NhanVien>();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();
                string query = "SELECT HTen, MaNV, SDT, Tuoi FROM NhanVien";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ten = reader.GetString(0);
                        string maNV = reader.GetString(1);  // Cột MaNV
                        string sdt = reader.IsDBNull(2) ? null : reader.GetString(1);  // Cột SDT, kiểm tra null


                        NhanVien nhanVien = new NhanVien(ten, maNV, sdt, 13);
                        nhanVienList.Add(nhanVien);
                    }
                }
            }

            return nhanVienList;
        }

        public List<NhanVien> GetDoanhThuList()
        {
            List<NhanVien> nhanVienList = new List<NhanVien>();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();
                string query = "SELECT ThangNam, LoiNhuan FROM TongLoiNhuan";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ten = reader.GetString(0);  // Cột MaNV
                        int tuoi = Convert.ToInt32(reader.GetDecimal(1));  // Cột SDT, kiểm tra null


                        NhanVien nhanVien = new NhanVien(ten, tuoi);
                        nhanVienList.Add(nhanVien);
                    }
                }
            }

            return nhanVienList;
        }
    }
}
