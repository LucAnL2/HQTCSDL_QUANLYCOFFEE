using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class HoaDon
    {
        private string maHD;
        private string maNV;
        private DateTime thoiGian;
        private string maPTTT;
        private string ghiChu;
        private decimal tongTien;

        public HoaDon()
        {
        }

        public HoaDon(string maHD, string maNV, DateTime thoiGian, string maPTTT, string ghiChu, decimal tongTien)
        {
            this.maHD = maHD;
            this.maNV = maNV;
            this.thoiGian = thoiGian;
            this.maPTTT = maPTTT;
            this.ghiChu = ghiChu;
            this.tongTien = tongTien;
        }

        public string MaHD {  get { return maHD; } set {  maHD = value; } }
        public string MaNV {  get { return maNV; } set { maNV = value; } }
        public DateTime ThoiGian {  get { return thoiGian; } set { thoiGian = value; } }
        public string MaPTTT {  get { return maPTTT; } set { maPTTT = value; } }
        public string GhiChu { get {  return ghiChu; } set {  ghiChu = value; } }
        public decimal TongTien { get {  return tongTien; } set {  tongTien = value; } }
    }
}
