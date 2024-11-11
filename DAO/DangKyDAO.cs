using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DemoCSDL.Models;
using DemoCSDL.Connection;

namespace DemoCSDL.DAO
{
    public class DangKyDAO
    {
        DBConnection connect = new DBConnection();
        public void ThemDangKy(DangKy dk)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaNV", dk.MaNV),
                    new SqlParameter("@Maca", dk.MaCa)
            };
            try
            {
                connect.ExecuteNonQuery("PROC_ThemDangKi", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public void RutLuong()
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            };
            try
            {
                connect.ExecuteNonQuery("PROC_RutLuong", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public decimal TinhLuong(DangKy dk)
        {
            decimal luong = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaNV", dk.MaNV)
            };
            try
            {
                luong = connect.ExecuteScalarDecimal("SELECT dbo.FUNC_TinhLuong(@MaNV)", parameters, CommandType.Text);
            }
            catch
            {
                throw;
            }
            return luong;
        }
    }
}
