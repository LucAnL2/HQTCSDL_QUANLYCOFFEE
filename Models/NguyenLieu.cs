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
        private DateTime gia;
        private int soLuong;

        public NguyenLieu()
        {
        }

        public string MaNL { get => maNL; set => maNL = value; }
        public string TenNL { get => tenNL; set => tenNL = value; }
        public DateTime Gia { get => gia; set => gia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
