using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class SanPham
    {
        private string maSP;
        private string maLoaiSP;
        private string tenSP;
        private string tinhTrang;
        private Decimal gia;
        private string hinhAnh;

        public SanPham() { }

        public SanPham(string maSP)
        {
            this.maSP = maSP;
        }

        public SanPham(string maSP, string maLoaiSP, string tenSP, string tinhTrang, decimal gia, string hinhAnh)
        {
            this.maSP = maSP;
            this.maLoaiSP = maLoaiSP;
            this.tenSP = tenSP;
            this.tinhTrang = tinhTrang;
            this.gia = gia;
            this.hinhAnh = hinhAnh;
        }

        public string MaSP { get => maSP; set => maSP = value; }
        public string MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public Decimal Gia { get => gia; set => gia = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
    }
}
