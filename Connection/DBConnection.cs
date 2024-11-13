using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL.Connection
{
    public class DBConnection
    {
        public string strCon = @"Data Source=LAPTOP-3RJ8EVL2\THIENDB;Initial Catalog=QLQCFF;User ID=sa;Password=@Daithien2004;Encrypt=False";
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
    }
}
