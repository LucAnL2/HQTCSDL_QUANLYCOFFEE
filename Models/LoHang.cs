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
        private DateTime ngayHatHan;
        private DateTime ngayNhap;
        private string maNL;
        private int soLuong;
        private Decimal GiaTien;

        public LoHang()
        {
        }

        public string MaLH { get => maLH; set => maLH = value; }
        public DateTime NgayHatHan { get => ngayHatHan; set => ngayHatHan = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string MaNL { get => maNL; set => maNL = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal GiaTien1 { get => GiaTien; set => GiaTien = value; }
    }
}
