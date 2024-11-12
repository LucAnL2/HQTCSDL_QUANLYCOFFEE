using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class CheBien
    {
        private string maSP;
        private string maNL;
        private int sLCanDung;

        public CheBien()
        {
        }
        public CheBien(string maSP, string maNL, int sLCanDung)
        {
            this.maSP = maSP;
            this.maNL = maNL;
            this.sLCanDung = sLCanDung;
        }

        public string MaSP { get => maSP; set => maSP = value; }
        public string MaNL { get => maNL; set => maNL = value; }
        public int SLCanDung { get => sLCanDung; set => sLCanDung = value; }
    }
}
