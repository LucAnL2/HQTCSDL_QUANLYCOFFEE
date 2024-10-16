using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class DangKy
    {
        private string maNV;
        private string maCa;

        public DangKy()
        {
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string MaCa { get => maCa; set => maCa = value; }
    }
}
