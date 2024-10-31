using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Connection;
using DemoCSDL.Models;

namespace DemoCSDL.DAO
{
    public class LoaiSPDAO
    {
        DBConnection db = new DBConnection();
        public List<LoaiSP> LayDSProduct()
        {
            List<LoaiSP> list = new List<LoaiSP>();
            string sql = "EXEC DSLoaiSanPham";
            DataTable dt = db.Load(sql);

            foreach (DataRow dr in dt.Rows)
            {
                LoaiSP lsp = new LoaiSP(
                    dr["MaLoaiSP"].ToString(),
                    dr["TenLoaiSP"].ToString()
                );
                list.Add(lsp);
            }
            return list;

        }
    }
}
