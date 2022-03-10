using Rentacar.Admin.Services;
using Rentacar.Dto;
using Rentacar.Dto.Request;
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

namespace Rentacar.Admin
{
    public partial class BookingDetails : Form
    {
        private BaseBookingDto _booking;
        private BaseUserDto _user;
        private VehicleBaseDto _vehicle;
        public BookingDetails()
        {
            InitializeComponent();
        }

        public BookingDetails(BaseBookingDto booking, BaseUserDto user, VehicleBaseDto vehicle)
        {
            InitializeComponent();

            this.userDetailsControlNonEditable1.User = user;
            userDetailsControlNonEditable1.RefreshData();

            this.vehicleDetailsControlNonEditable1.Vehicle = vehicle;
            vehicleDetailsControlNonEditable1.RefreshData();

            this.bookingDetailsControl1.Booking = booking;
            bookingDetailsControl1.RefreshData();


        }

    }
}
