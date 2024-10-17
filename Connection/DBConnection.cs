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

