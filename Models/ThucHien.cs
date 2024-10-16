using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class ThucHien
    {
        private string maNV;
        private string maCV;

        public ThucHien()
        {
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string MaCV { get => maCV; set => maCV = value; }
    }
}
