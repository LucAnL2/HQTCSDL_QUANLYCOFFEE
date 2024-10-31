using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Connection;
using DemoCSDL.Models;

namespace DemoCSDL.DAO
{
    public class NguyenLieuDAO
    {
        public DataTable LayNguyenLieu()
        {
            try
            {
                DBConnection dbConnection = new DBConnection();
                DataTable dtData = dbConnection.Load("Select * from NguyenLieu");
                return dtData;
            }
            catch
            {
                throw;
            }
        }
    }
}
