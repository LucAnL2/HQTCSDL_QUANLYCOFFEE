using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class loaiSP
    {
        private string maLoaiSP;
        private string tenLoaiSP;

        public loaiSP()
        {
        }

        public string MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string TenLoaiSP { get => tenLoaiSP; set => tenLoaiSP = value; }
    }
}
