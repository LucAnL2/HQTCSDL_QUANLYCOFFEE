using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Connection;

namespace DemoCSDL.DAO
{
    public class LoaiSPDAO
    {
        DBConnection connect = new DBConnection();
        public DataTable load()
        {
                string sqlStr = string.Format("SELECT MaLoaiSP, TenLoaiSP");
                return connect.Load(sqlStr);
        }
    }
}
