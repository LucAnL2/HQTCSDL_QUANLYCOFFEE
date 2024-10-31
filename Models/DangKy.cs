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

        public DangKy() { }

        public DangKy(string maNV)
        {
            this.maNV = maNV;
        }

        public DangKy(string maNV, string maCa)
        {
            this.maNV = maNV;
            this.maCa = maCa;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string MaCa { get => maCa; set => maCa = value; }
    }
}
