using DemoCSDL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Connection;

namespace DemoCSDL.DAO
{
    public class DangKyDAO
    {
        DBConnection connect = new DBConnection();
        public void themDangKy(DangKy dk)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaNV", dk.MaNV),
                    new SqlParameter("@Maca", dk.MaCa)
            };
            try
            {
                connect.ExecuteNonQuery("ThemDangKi", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public void rutLuong()
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            };
            try
            {
                connect.ExecuteNonQuery("RutLuong", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public decimal tinhLuong(DangKy dk)
        {
            decimal luong = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaNV", dk.MaNV)
            };
            try
            {
                luong = connect.ExecuteScalar("SELECT dbo.TinhLuong(@MaNV)", parameters, CommandType.Text);
            }
            catch
            {
                throw;
            }
            return luong;
        }
    }
}
