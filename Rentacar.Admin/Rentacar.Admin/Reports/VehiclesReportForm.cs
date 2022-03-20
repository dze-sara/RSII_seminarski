using Microsoft.Reporting.WinForms;
using Rentacar.Admin.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rentacar.Admin.Reports
{
    public partial class VehiclesReportForm : Form
    {
        private List<VehiclesReportDataDto> _vehiclesListChart;
        private List<VehiclesReportDataTableDto> _vehiclesListTable;
        public VehiclesReportForm(List<VehiclesReportDataDto> vehiclesListChart, List<VehiclesReportDataTableDto> vehiclesListTable)
        {
            _vehiclesListChart = vehiclesListChart;
            _vehiclesListTable = vehiclesListTable;
            InitializeComponent();
        }

        private void VehiclesReportForm_Load(object sender, EventArgs e)
        {
            ReportDataSource rds1 = new ReportDataSource("dsVehicles", _vehiclesListChart);
            ReportDataSource rds2 = new ReportDataSource("dsVehiclesTable", _vehiclesListTable);
            var parameters = new ReportParameter[]
            {
                new ReportParameter("pCreatedDate", DateTime.Now.ToString())
            };
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.LocalReport.DataSources.Add(rds2);
            //this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }
    }
}
