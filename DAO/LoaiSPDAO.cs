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
            List<loaiSP> list = new List<loaiSP>();

            string sql = "EXEC DSLoaiSanPham";


            DataTable dt = db.Load(sql);

            foreach (DataRow dr in dt.Rows)
            {
                loaiSP lsp = new loaiSP(
                    dr["MaLoaiSP"].ToString(),
                    dr["TenLoaiSP"].ToString()
                );
                list.Add(lsp);

            }
            return list;

        }
    }
}
