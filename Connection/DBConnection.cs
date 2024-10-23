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
        public string strCon = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=testDatabase;Integrated Security=True";
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


        public DataTable Load(string sqlStr, SqlParameter[] parameters = null)
        {
            DataTable dtData = new DataTable();
            try
            {
                OpenConnection();

                using (SqlCommand command = new SqlCommand(sqlStr, sqlCon))
                {
                    // Thêm tham số vào SqlCommand nếu có
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

    }
}

