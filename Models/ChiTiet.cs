using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class ChiTiet
    {
        private string maHD;
        private string maSP;
        private int soLuong;
        private decimal tongTien;
        private decimal donGia;

        public ChiTiet()
        {
        }

        public ChiTiet(string maHD, string maSP, int soLuong, decimal donGia)
        {
            this.maHD = maHD;
            this.maSP = maSP;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }
        public ChiTiet(string maHD, string maSP, int soLuong, decimal tongTien, decimal donGia)
        {
            this.maHD = maHD;
            this.maSP = maSP;
            this.soLuong = soLuong;
            this.tongTien = tongTien;
            this.donGia = donGia;
            
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
    }
}
