using DemoCSDL.DAO;
using DemoCSDL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Runtime.CompilerServices;

namespace DemoCSDL
{
    public partial class FWThanhToan : Form
    {
        ChiTietDAO ctd = new ChiTietDAO();
        List<ChiTiet> listct = new List<ChiTiet>();
        List<HoaDon> listhd = new List<HoaDon>();
        List<SanPhamOrder> listspod = new List<SanPhamOrder>();
        public FWThanhToan(List<ChiTiet> listct, List<HoaDon> listhd, List<SanPhamOrder> listspod)
        {
            InitializeComponent();
            this.listct = listct;
            this.listhd = listhd;
            this.listspod = listspod;
        }
        public FWThanhToan()
        {
            InitializeComponent();
        }

        private void FWThanhToan_Load(object sender, EventArgs e)
        {
            rvCTHoaDon.LocalReport.ReportPath = "RCTHoaDon.rdlc";
            var source = new ReportDataSource("CTHoaDonDataset", listct);
            var source1 = new ReportDataSource("HoaDonDataset", listhd);
            var source2 = new ReportDataSource("SanPhamDataset", listspod);
            rvCTHoaDon.LocalReport.DataSources.Clear();
            rvCTHoaDon.LocalReport.DataSources.Add(source);
            rvCTHoaDon.LocalReport.DataSources.Add(source1);
            rvCTHoaDon.LocalReport.DataSources.Add(source2);
            this.rvCTHoaDon.RefreshReport();
        }
    }
}
