using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class PhuongThucTT
    {
        private string maHD;
        private string maKH;
        private string phuongThuc;
        private DateTime ngayThanhToan;

        public PhuongThucTT()
        {
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string PhuongThuc { get => phuongThuc; set => phuongThuc = value; }
        public DateTime NgayThanhToan { get => ngayThanhToan; set => ngayThanhToan = value; }
    }
}
