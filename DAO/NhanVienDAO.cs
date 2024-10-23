using DemoCSDL.Connection;
using DemoCSDL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.DAO
{
    public class NhanVienDAO
    {
        DBConnection connect = new DBConnection();
        public List<NhanVien> layDanhSachMaMVDaDuocPhanCongCV()
        {
            string storeProcedure = "LayDanhSachMaNVDaDuocPhanCa";
            SqlParameter[] parameters = null;
            return connect.GetObjects<NhanVien>(storeProcedure,
                parameters,
                reader => new NhanVien
                {
                    MaNV = reader["MaNV"].ToString()
                }
            );
        }

        public List<NhanVien> layDanhSachMaMVCuaTatCaNV()
        {
            string storeProcedure = "LayDanhTatCaMaNV";
            SqlParameter[] parameters = null;
            return connect.GetObjects<NhanVien>(storeProcedure,
                parameters,
                reader => new NhanVien
                {
                    MaNV = reader["MaNV"].ToString()
                }
            );
        }
    }
}
