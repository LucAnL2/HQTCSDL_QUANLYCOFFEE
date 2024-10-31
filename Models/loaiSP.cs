using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class LoaiSP
    {
        private string maLoaiSP;
        private string tenLoaiSP;

        public LoaiSP(string maLoaiSP, string tenLoaiSP)
        {
            this.MaLoaiSP = maLoaiSP;
            this.TenLoaiSP = tenLoaiSP;
        }

        public string MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string TenLoaiSP { get => tenLoaiSP; set => tenLoaiSP = value; }
    }
}
