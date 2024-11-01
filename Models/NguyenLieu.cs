using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class NguyenLieu
    {
        private string maNL;
        private string tenNL;
        private decimal gia;
        private int soLuong;

        public NguyenLieu(string maNL, string tenNL, decimal gia, int soLuong)
        {
            this.maNL = maNL;
            this.tenNL = tenNL;
            this.gia = gia;
            this.soLuong = soLuong;
        }

        public string MaNL { get => maNL; set => maNL = value; }
        public string TenNL { get => tenNL; set => tenNL = value; }
        public decimal Gia { get => gia; set => gia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
