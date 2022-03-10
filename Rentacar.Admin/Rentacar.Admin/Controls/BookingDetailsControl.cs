using Rentacar.Dto;
using System.Windows.Forms;

namespace Rentacar.Admin.Controls
{
    public partial class BookingDetailsControl : UserControl
    {
        public BaseBookingDto Booking { get; set; }

        public BookingDetailsControl()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            textBoxBookingId.Text = Booking.BookingId.ToString();
            textBoxCreatedDate.Text = Booking.CreatedDate.ToString();
            textBoxEndDate.Text = Booking.EndDate.ToString();
            textBoxStartDate.Text = Booking.StartDate.ToString();
            textBoxUpdatedDate.Text = Booking.UpdatedDate.ToString();
        }
    }
}
