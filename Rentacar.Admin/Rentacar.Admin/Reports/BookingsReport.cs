using Rentacar.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Rentacar.Admin.Reports
{
    public partial class BookingsReport : Form
    {
        private List<BaseBookingDto> _bookingsList;

        public BookingsReport(List<BaseBookingDto> bookingsList)
        {
            _bookingsList = bookingsList;
            InitializeComponent();
        }

        private void BookingsReport_Load(object sender, EventArgs e)
        {
            BindingList<BaseBookingDto> bookings = new BindingList<BaseBookingDto>(_bookingsList);

            BaseBookingDtoBindingSource.DataSource = bookings;
            this.reportViewer2.RefreshReport();

            //reportViewer1.
            this.reportViewer2.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
