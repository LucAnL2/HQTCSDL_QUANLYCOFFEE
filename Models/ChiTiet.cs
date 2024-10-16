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
        private Decimal tongTien;
        private string donGia;

        public ChiTiet()
        {
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public string DonGia { get => donGia; set => donGia = value; }
    }
}
