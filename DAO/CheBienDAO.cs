using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Connection;
using DemoCSDL.Models;

namespace DemoCSDL.DAO
{
    public class CheBienDAO
    {
        DBConnection dbConnection = new DBConnection();
        public void ThemCheBien(CheBien ct)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", ct.MaSP),
                new SqlParameter("@MaNL", ct.MaNL),
                new SqlParameter("@SLCanDung", ct.SLCanDung)
            };
            try
            {
                dbConnection.ExecuteNonQuery("PROC_ThemCheBien", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

        }
    }
}
