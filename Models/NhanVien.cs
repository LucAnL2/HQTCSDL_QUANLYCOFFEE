using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class NhanVien
    {
        private string maNV;
        private string hTen;
        private int tuoi;
        private string dChi;
        private string gTinh;
        private string sDT;
        private DateTime nTuyenDung;
        private string taiKhoan;
        private string matKhau;
        private string maCV;

        public NhanVien()
        {
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string HTen { get => hTen; set => hTen = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string DChi { get => dChi; set => dChi = value; }
        public string GTinh { get => gTinh; set => gTinh = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public DateTime NTuyenDung { get => nTuyenDung; set => nTuyenDung = value; }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string MaCV { get => maCV; set => maCV = value; }

        public NhanVien(string manv, string hten, int tuoi, string dChi, string gTinh, string sDT, DateTime nTuyenDung, string taiKhoan, string matKhau, string maCV)
        {
            MaNV = manv;
            HTen = hten;
            Tuoi = tuoi;
            DChi = dChi;
            GTinh = gTinh;
            SDT = sDT;
            NTuyenDung = nTuyenDung;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            MaCV = maCV;
        }
    }
}
