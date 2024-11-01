using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSDL.Models
{
    public class SanPhamOrder : SanPham
    {
        private int soLuongOrder;

        public int SoLuongOrder { get => soLuongOrder; set => soLuongOrder = value; }

        public SanPhamOrder(string maSP, string maLoaiSP, string tenSP, string tinhTrang, string hinhAnh, decimal gia, int soLuongOrder)
            : base(maSP, maLoaiSP, tenSP, tinhTrang, gia, hinhAnh)
        {
            this.SoLuongOrder = soLuongOrder;
        }
        public SanPhamOrder() { }
    }
}
