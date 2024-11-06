using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Connection;
using DemoCSDL.Models;

namespace DemoCSDL.DAO
{
    public class NguyenLieuDAO
    {
        DBConnection dbConnection = new DBConnection();
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

        public void ThemNguyenLieu(NguyenLieu nl)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenNL", nl.TenNL),
                new SqlParameter("@Gia", nl.Gia),
                new SqlParameter("@SoLuong", nl.SoLuong),
            };
            try
            {
                dbConnection.ExecuteNonQuery("ThemNguyenLieu", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public void SuaNguyenLieu(NguyenLieu nl)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNL", nl.MaNL), // Mã nguyên liệu
                new SqlParameter("@TenNL", nl.TenNL),
                new SqlParameter("@Gia", nl.Gia),
                new SqlParameter("@SoLuong", nl.SoLuong),
            };

            try
            {
                dbConnection.ExecuteNonQuery("SuaNguyenLieu", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public void XoaNguyenLieu(string maNL)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaNL", maNL) // Mã nguyên liệu
            };

            try
            {
                dbConnection.ExecuteNonQuery("XoaNguyenLieu", parameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi tại đây nếu cần thiết
                throw new Exception("Lỗi khi xóa nguyên liệu: " + ex.Message);
            }
        }
    }
}
