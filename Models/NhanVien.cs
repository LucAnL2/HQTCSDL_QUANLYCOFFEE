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
        private string taiKhoan;
        private string matKhau;
        private string maCV;
        private string eMail;

        public NhanVien()
        {

        }
        public NhanVien(string manv, string hten, string taikhoan, string matkhau, string email)
        {
            maNV = manv;
            hTen = hten;
            taiKhoan = taikhoan;
            matKhau = matkhau;
            eMail = email;
        }

        public NhanVien(string maNV, string hTen)
        {
            this.maNV = maNV;
            this.hTen = hTen;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string HTen { get => hTen; set => hTen = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string DChi { get => dChi; set => dChi = value; }
        public string GTinh { get => gTinh; set => gTinh = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string MaCV { get => maCV; set => maCV = value; }

        public string EMail { get => eMail; set => eMail = value; }
    }
}
