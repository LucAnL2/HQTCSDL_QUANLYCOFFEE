using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class HoaDon
    {
        private string maHD;
        private string maNV;
        private string maKH;
        private string ghiChu;

        public HoaDon()
        {
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
