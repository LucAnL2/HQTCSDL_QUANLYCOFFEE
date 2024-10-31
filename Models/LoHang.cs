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
        private DateTime ngayNhap;
        private string maNL;
        private int soLuong;
        private decimal donGia;
        private decimal tongTien;

        public LoHang(string maNL, DateTime ngayNhap, int soLuong, decimal donGia)
        {
            this.ngayNhap = ngayNhap;
            this.maNL = maNL;
            this.soLuong = soLuong;
            this.DonGia = donGia;
        }

        public string MaLH { get => maLH; set => maLH = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string MaNL { get => maNL; set => maNL = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
    }
}
