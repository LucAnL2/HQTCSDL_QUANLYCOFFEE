using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Models;
using DemoCSDL.Connection;

namespace DemoCSDL.DAO
{
    public class PhuongThucTTDAO
    {
        DBConnection dbConnection = new DBConnection();
        public List<PhuongThucTT> LayDSPhuongThuc()
        {
            List<PhuongThucTT> listpt = new List<PhuongThucTT>();

            string sql = "EXEC DSPhuongThucTT";
            DataTable dt = dbConnection.Load(sql);

            foreach (DataRow dr in dt.Rows)
            {
                PhuongThucTT pttt = new PhuongThucTT(
                    dr["MaPTTT"].ToString(),
                    dr["TenPTTT"].ToString());
                listpt.Add(pttt);
            }

            return listpt;
        }
    }
}
