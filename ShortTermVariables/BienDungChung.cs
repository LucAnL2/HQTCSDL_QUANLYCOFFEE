using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCSDL.Connection;

namespace DemoCSDL.ShortTermVariables
{
    public class BienDungChung
    {
        public static DBConnection conn = new DBConnection();
        public static string taiKhoanND = null;
        public static string matkhauND = null;
        public static string maNVND = null;

        public static void SetQuyenAdmin()
        {
            taiKhoanND = "admin";
            matkhauND = "admin";
        }
    }
}
