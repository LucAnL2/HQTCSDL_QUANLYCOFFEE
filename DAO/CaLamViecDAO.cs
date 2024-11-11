using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCSDL.Models;
using DemoCSDL.Connection;

namespace DemoCSDL.DAO
{
    public class CaLamViecDAO
    {
        DBConnection connect = new DBConnection();
        public DataTable HienThiCaLam()
        {
            string query = "select Maca as [Mã ca], NgayLam as [Ngày làm], GioBatDau as [Giờ bắt đầu], GioKetThuc as [Giờ kết thúc] from DSCaLamViec";
            return connect.Load(query);
        }

        public DataTable HienThiCaLamDaDK()
        {
            string query = "select Maca as [Mã ca], NgayLam as [Ngày làm], GioBatDau as [Giờ bắt đầu], GioKetThuc as [Giờ kết thúc], MaNV as [Mã nhân viên], HTen as [Họ tên NV] from ThongTinNhanVienCaLamViec";
            return connect.Load(query);
        }

        public DataTable HienThiTheoBoLoc(string filter)
        {
            string query = string.Format("select Maca as [Mã ca], NgayLam as [Ngày làm], GioBatDau as [Giờ bắt đầu], GioKetThuc as [Giờ kết thúc], MaNV as [Mã nhân viên], HTen as [Họ tên NV] from ThongTinNhanVienCaLamViec" + " where MaNV = N'{0}' or MaCa = N'{0}'", filter);
            return connect.Load(query);
        }

        public DataTable HienThiTheoMaNVVaMaCa(string MaNV, string MaCa)
        {
            string query = string.Format("select Maca as [Mã ca], NgayLam as [Ngày làm], GioBatDau as [Giờ bắt đầu], GioKetThuc as [Giờ kết thúc], MaNV as [Mã nhân viên], HTen as [Họ tên NV] from ThongTinNhanVienCaLamViec" + " where MaNV = N'{0}' and MaCa = N'{1}'", MaNV, MaCa);
            return connect.Load(query);
        }

        public void ThemCaLamViec(CaLamViec clv)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@Maca", clv.MaCa),
                    new SqlParameter("@NgayLam", clv.NgayLam),
                    new SqlParameter("@GioBatDau", clv.GioBatDau.TimeOfDay),
                    new SqlParameter("@GioKetThuc", clv.GioKetThuc.TimeOfDay)
            };
            try
            {
                connect.ExecuteNonQuery("PROC_ThemCaLamViec", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public void SuaCaLamViec(CaLamViec clv)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@Maca", clv.MaCa),
                    new SqlParameter("@NgayLam", clv.NgayLam),
                    new SqlParameter("@GioBatDau", clv.GioBatDau.TimeOfDay),
                    new SqlParameter("@GioKetThuc", clv.GioKetThuc.TimeOfDay)
            };
            try
            {
                connect.ExecuteNonQuery("PROC_SuaCaLamViec", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public void XoaCaLamViec(CaLamViec clv)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@Maca", clv.MaCa)
            };
            try
            {
                connect.ExecuteNonQuery("PROC_XoaCaLamViec", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public List<CaLamViec> LayDanhSachMaCa()
        {
            string storeProcedure = "PROC_LayDanhSachMaCaDaCoNguoiLam";
            SqlParameter[] parameters = null;
            return connect.GetObjects<CaLamViec>(storeProcedure,
                parameters,
                reader => new CaLamViec
                {
                    MaCa = reader["MaCa"].ToString(),
                    NgayLam = Convert.ToDateTime(reader["NgayLam"])
                }
            );
        }

        public List<CaLamViec> LayDanhSachTatCaMaCa()
        {
            string storeProcedure = "PROC_LayDanhTatCaMaCa";
            SqlParameter[] parameters = null;
            return connect.GetObjects<CaLamViec>(storeProcedure,
                parameters,
                reader => new CaLamViec
                {
                    MaCa = reader["MaCa"].ToString()
                }
            );
        }
    }
}
