using DemoCSDL.Connection;
using DemoCSDL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.DAO
{
    public class PhuongThucTTDAO
    {
        DBConnection db = new DBConnection();
        public List<PhuongThucTT> layDSPhuongThuc()
        {
            List<PhuongThucTT> listpt = new List<PhuongThucTT>();

            string sql = "EXEC DSPhuongThucTT";
            DataTable dt = db.Load(sql);

            foreach(DataRow dr in dt.Rows)
            {
                PhuongThucTT pttt = new PhuongThucTT(
                    dr["MaPTTT"].ToString(),
                    dr["TenPTTT"].ToString()
                    );
                listpt.Add( pttt );
            }

            return listpt;
        }
    }
}
