using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class PhuongThucTT
    {
        private string maPTTT;
        private string tenPTTT;
        public PhuongThucTT(string maPTTT, string tenPTTT)
        {
            this.maPTTT = maPTTT;
            this.tenPTTT = tenPTTT;
        }
        public string MaPTTT { get => maPTTT; set => maPTTT = value; }
        public string TenPTTT { get => tenPTTT; set => tenPTTT = value; }
    }
}
