using Microsoft.Reporting.WinForms;
using Rentacar.Dto;
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
    public partial class BookingsReportForm : Form
    {
        List<BaseBookingDto> _bookingsList;
        BookingReportRequestDto _request;
        public BookingsReportForm(List<BaseBookingDto> bookingsList, BookingReportRequestDto request = null)
        {
            this._bookingsList = bookingsList;
            this._request = request == null ? new BookingReportRequestDto() : request;
            InitializeComponent();
        }

        private void BookingsReportForm_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("dsBookings", _bookingsList);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            var parameters = new ReportParameter[]{
                new ReportParameter("pFromDate", !string.IsNullOrEmpty(_request.FromDate.ToString()) ? _request.FromDate.ToString() : "All dates"),
                new ReportParameter("pToDate", !string.IsNullOrEmpty(_request.ToDate.ToString()) ? _request.ToDate.ToString() : "All dates"),
                new ReportParameter("pCreatedDate", DateTime.Now.ToString())
            };
            this.reportViewer1.LocalReport.SetParameters(parameters);
            //this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }
    }
}
