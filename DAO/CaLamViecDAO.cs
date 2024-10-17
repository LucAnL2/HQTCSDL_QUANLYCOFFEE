using DemoCSDL.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.DAO
{
    public class CaLamViecDAO
    {
        DBConnection connect = new DBConnection();
        public DataTable load()
        {
            string sqlStr = string.Format("SELECT Maca, NgayLam, GioBatDau, GioKetThuc FROM CaLamViec");
            return connect.Load(sqlStr);
        }
    }
}
