using DemoCSDL.Connection;
using DemoCSDL.ManagerChildForms;
using DemoCSDL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;

namespace DemoCSDL.DAO
{
    public class CaLamViecDAO
    {
        DBConnection connect = new DBConnection();
        public DataTable hienThiCaLam()
        {
            string query = "select Maca as [Mã ca], NgayLam as [Ngày làm], GioBatDau as [Giờ bắt đầu], GioKetThuc as [Giờ kết thúc] from v_CaLamViec";
            return connect.Load(query);
        }

        public DataTable hienThiCaLamDaDK()
        {
            string query = "select Maca as [Mã ca], NgayLam as [Ngày làm], GioBatDau as [Giờ bắt đầu], GioKetThuc as [Giờ kết thúc], MaNV as [Mã nhân viên], HTen as [Họ tên NV] from v_ThongTinNhanVien_CaLamViec";
            return connect.Load(query);
        }

        public DataTable hienThiTheoBoLoc(string filter)
        {
            string query = string.Format("select Maca as [Mã ca], NgayLam as [Ngày làm], GioBatDau as [Giờ bắt đầu], GioKetThuc as [Giờ kết thúc], MaNV as [Mã nhân viên], HTen as [Họ tên NV] from v_ThongTinNhanVien_CaLamViec" + " where MaNV = N'{0}' or MaCa = N'{0}'", filter);
            return connect.Load(query);
        }

        public DataTable hienThiTheoMaNVVaMaCa(string MaNV, string MaCa)
        {
            string query = string.Format("select Maca as [Mã ca], NgayLam as [Ngày làm], GioBatDau as [Giờ bắt đầu], GioKetThuc as [Giờ kết thúc], MaNV as [Mã nhân viên], HTen as [Họ tên NV] from v_ThongTinNhanVien_CaLamViec" + " where MaNV = N'{0}' and MaCa = N'{1}'", MaNV, MaCa);
            return connect.Load(query);
        }

        public void themCaLamViec(CaLamViec clv)
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
                connect.ExecuteNonQuery("ThemCaLamViec", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public void suaCaLamViec(CaLamViec clv) 
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
                connect.ExecuteNonQuery("SuaCaLamViec", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public void xoaCaLamViec(CaLamViec clv)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@Maca", clv.MaCa)
            };
            try
            {
                connect.ExecuteNonQuery("XoaCaLamViec", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public List<CaLamViec> layDanhSachMaCa()
        {
            string storeProcedure = "LayDanhSachMaCaDaCoNguoiLam";
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

        public List<CaLamViec> layDanhSachTatCaMaCa()
        {
            string storeProcedure = "LayDanhTatCaMaCa";
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
