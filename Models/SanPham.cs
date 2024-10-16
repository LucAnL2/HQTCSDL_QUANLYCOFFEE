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

        public SanPham()
        {
        }

        public string MaSP { get => maSP; set => maSP = value; }
        public string MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public Decimal Gia { get => gia; set => gia = value; }
    }
}
