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
        //Tạo biến lưu đường dẫn kết nối với database
        private static string stringConnection = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=QUANLYCOFFEE;Integrated Security=True";
        SqlCommand sqlCommand;
        SqlDataReader dataReader;

        //Trả về đường dẫn kết nối với database
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }

        public DataTable Load(string sqlStr)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                    DataTable dtperson = new DataTable();
                    adapter.Fill(dtperson);
                    return dtperson;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return null;
        }
    }
}
