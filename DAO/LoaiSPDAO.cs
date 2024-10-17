using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Connection;
using DemoCSDL.Models;
using DemoCSDL.UserControls;

namespace DemoCSDL.DAO
{
    public class LoaiSPDAO
    {
        DBConnection db = new DBConnection();


        public List<loaiSP> layDSProduct()
        {
            db.OpenConnection();
            List<loaiSP> listSP = new List<loaiSP>();
            string query = "SELECT MaLoaiSP, TenLoaiSP FROM LoaiSP";
            using (SqlCommand command = new SqlCommand(query, db.sqlCon))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loaiSP sp = new loaiSP();
                        sp.MaLoaiSP = reader.GetString(0);
                        sp.TenLoaiSP = reader.GetString(1);
                        listSP.Add(sp);
                    }
                }
            }
            return listSP;  
        }
    }
}
