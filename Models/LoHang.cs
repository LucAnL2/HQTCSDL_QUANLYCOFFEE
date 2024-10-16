using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class LoHang
    {
        private string maLH;
        private DateTime ngayHetHan;
        private DateTime ngayNhap;
        private string maNL;
        private int soLuong;
        private Decimal giaTien;

        public LoHang(string maLH, DateTime ngayHetHan, DateTime ngayNhap, string maNL, int soLuong, decimal giaTien)
        {
            this.maLH = maLH;
            this.ngayHetHan = ngayHetHan;
            this.ngayNhap = ngayNhap;
            this.maNL = maNL;
            this.soLuong = soLuong;
            this.giaTien = giaTien;
        }

        public string MaLH { get => maLH; set => maLH = value; }
        public DateTime NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string MaNL { get => maNL; set => maNL = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal GiaTien { get => giaTien; set => giaTien = value; }
    }
}
