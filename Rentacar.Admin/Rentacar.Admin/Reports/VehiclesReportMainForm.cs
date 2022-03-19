using Microsoft.Reporting.WinForms;
using Rentacar.Dto.Response;
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

    public partial class VehiclesReportMainForm : Form
    {
        private List<VehicleBaseDto> _vehiclesList;
        public VehiclesReportMainForm(List<VehicleBaseDto> vehiclesList)
        {
            _vehiclesList = vehiclesList;
            InitializeComponent();
        }

        private void VehiclesReportMainForm_Load(object sender, EventArgs e)
        {
            ReportDataSource rds1 = new ReportDataSource("dsVehicleBase", _vehiclesList);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            var parameters = new ReportParameter[]
            {
                new ReportParameter("pCreatedDate", DateTime.Now.ToString())
            };
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }
    }
}
