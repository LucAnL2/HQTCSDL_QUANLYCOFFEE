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

namespace DemoCSDL
{
    public partial class FWThanhToan : Form
    {
        ChiTietDAO ctd = new ChiTietDAO();
        List<ChiTiet> listct = new List<ChiTiet>();
        List<HoaDon> listhd = new List<HoaDon>();
        public FWThanhToan(List<ChiTiet> listct, List<HoaDon> listhd)
        {
            InitializeComponent();
            this.listct = listct;
            this.listhd = listhd;
        }
        public FWThanhToan()
        {
            InitializeComponent();
        }

        private void FWThanhToan_Load(object sender, EventArgs e)
        {
            rvCTHoaDon.LocalReport.ReportPath = "RCTHoaDon.rdlc";
            var source = new ReportDataSource("CTHoaDonDataSet", listct);
            var source1 = new ReportDataSource("HoaDonDataSet", listhd);
            rvCTHoaDon.LocalReport.DataSources.Clear();
            rvCTHoaDon.LocalReport.DataSources.Add(source);
            rvCTHoaDon.LocalReport.DataSources.Add(source1);
            this.rvCTHoaDon.RefreshReport();
        }
    }
}
