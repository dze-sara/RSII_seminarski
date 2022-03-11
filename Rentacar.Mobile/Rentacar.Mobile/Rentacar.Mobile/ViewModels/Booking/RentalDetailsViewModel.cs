using Rentacar.Dto;
using Rentacar.Dto.Response;
using Rentacar.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class RentalDetailsViewModel : BaseViewModel
    {
        public string StartDate { get => DataStore.BookingStartDate.ToString("MMM, dd yyyy"); }
        public string EndDate { get => DataStore.BookingEndDate.ToString("MMM, dd yyyy"); }

        public VehicleBaseDto Vehicle { get; set; }
        public Command ConfirmBookingCommand { get; set; }
        public RentalDetailsViewModel(VehicleBaseDto vehicleBaseDto)
        {
            Vehicle = vehicleBaseDto;
            ConfirmBookingCommand = new Command(OnConfirmBooking);
        }

        private async void OnConfirmBooking(object obj)
        {
            BookingDto booking = new BookingDto()
            {
                StartDate = DataStore.BookingStartDate,
                EndDate = DataStore.BookingEndDate,
                TotalPrice = (decimal)(DataStore.BookingEndDate - DataStore.BookingStartDate).TotalDays * Vehicle.RatePerDay,
                VehicleId = Vehicle.VehicleId,
                UserId = AuthenticationService.UserId
            };

            await BookingService.BookVehicle(booking);

            await Shell.Current.GoToAsync(nameof(RentalHistoryPage));
        }
    }
}
