using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class HoaDon
    {
        private string maHD;
        private string maNV;
        private DateTime thoiGian;
        private string maPTTT;
        private string ghiChu;
        private decimal tongTien;

        public HoaDon(string maHD, string maNV, DateTime thoiGian, string maPTTT, string ghiChu, decimal tongTien)
        {
            this.maHD = maHD;
            this.maNV = maNV;
            this.thoiGian = thoiGian;
            this.maPTTT = maPTTT;
            this.ghiChu = ghiChu;
            this.tongTien = tongTien;
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime ThoiGian { get => thoiGian; set => thoiGian = value; }
        public string MaPTTT { get => maPTTT; set => maPTTT = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
    }
}
