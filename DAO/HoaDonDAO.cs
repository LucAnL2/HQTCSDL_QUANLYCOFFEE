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
    public class HoaDonDAO
    {
        DBConnection db = new DBConnection();
        public static string MaHD = null;


        private List<SanPhamOrder> sanPhamDaTinh = new List<SanPhamOrder>();
        public decimal TinhTienOrder(List<SanPhamOrder> listSPO)
        {
            decimal tongOrder = 0;

            foreach (SanPhamOrder spo in listSPO)
            {
                if (!sanPhamDaTinh.Contains(spo)) // Kiểm tra xem sản phẩm đã được tính chưa
                {
                    tongOrder += spo.Gia * spo.SoLuongOrder;
                    sanPhamDaTinh.Add(spo); // Thêm sản phẩm vào danh sách đã tính
                }
            }
            sanPhamDaTinh.Clear();
            return tongOrder;
        }

        public void XoaHoaDonCu(int soNgay)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Songay", soNgay)
            };
            try
            {
                db.ExecuteNonQuery("XoaHoaDonCu", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public DataTable QuanLyHD(string maNV, DateTime ngayBD, DateTime ngayKT)
        {

            string sql = "EXEC HienThiHoaDonTheoDK @MaNV, @NgayBD, @NgayKT";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@NgayBD", ngayBD.Date),
                new SqlParameter("@NgayKT", ngayKT.Date)
            };
            DataTable dt = db.Load(sql, parameters);

            return dt;

        }

        public void ThemHoaDon(HoaDon hd)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHD", hd.MaHD),
                new SqlParameter("@MaNV", hd.MaNV),
                new SqlParameter("@ThoiGian", hd.ThoiGian),
                new SqlParameter("@MaPTTT", hd.MaPTTT),
                new SqlParameter("@GhiChu", hd.GhiChu),
                new SqlParameter("@TongTien", hd.TongTien)
            };
            try
            {
                db.ExecuteNonQuery("ThemHoaDon", parameters, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public List<HoaDon> LoadHD(string maHD)
        {
            List<HoaDon> listCT = new List<HoaDon>();

            string sql = "EXEC LayHoaDon @MaHD";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHD", maHD)
            };

            DataTable dt = db.Load(sql, parameters);

            foreach (DataRow dr in dt.Rows)
            {
                HoaDon ct = new HoaDon(
                    dr["MaHD"].ToString(),
                    dr["MaNV"].ToString(),
                    Convert.ToDateTime(dr["ThoiGian"]),
                    dr["MaPTTT"].ToString(),
                    dr["GhiChu"].ToString(),
                    Convert.ToDecimal(dr["TongTien"]));
                listCT.Add(ct);
            }
            return listCT;
        }
    }
}
