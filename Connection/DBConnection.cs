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
        private string strCon = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=QUANLYCOFFEE;Integrated Security=True";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        public decimal ExecuteScalar(string storeProcedure, SqlParameter[] parameters, CommandType commandType)
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


        public DataTable Load(string sqlStr)
        {
            DataTable dtData = new DataTable();
            try
            {
                OpenConnection();

                using (SqlCommand command = new SqlCommand(sqlStr, sqlCon))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dtData.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dtData;
        }
    }
}
