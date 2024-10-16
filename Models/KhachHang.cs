using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class KhachHang
    {
        private string maKH;
        private string tenKH;
        private string sDT;

        public KhachHang()
        {
        }

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SDT { get => sDT; set => sDT = value; }
    }
}
