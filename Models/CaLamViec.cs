using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class CaLamViec
    {
        private string maCa;
        private DateTime ngayLam;
        private DateTime gioBatDau;
        private DateTime gioKetThuc;
        public CaLamViec(string maCa, DateTime ngayLam, DateTime gioBatDau, DateTime gioKetThuc)
        {
            MaCa = maCa;
            NgayLam = ngayLam;
            GioBatDau = gioBatDau;
            GioKetThuc = gioKetThuc;
        }

        public CaLamViec() { }

        public string MaCa { get => maCa; set => maCa = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
        public DateTime GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public DateTime GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
    }
}
