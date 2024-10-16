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
        private string sLCanDung;

        public CheBien()
        {
        }

        public string MaSP { get => maSP; set => maSP = value; }
        public string MaNL { get => maNL; set => maNL = value; }
        public string SLCanDung { get => sLCanDung; set => sLCanDung = value; }
    }
}
