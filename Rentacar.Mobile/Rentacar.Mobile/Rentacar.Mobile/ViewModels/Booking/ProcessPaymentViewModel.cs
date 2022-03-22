using Rentacar.Dto;
using Rentacar.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels.Booking
{
    public class ProcessPaymentViewModel : BaseViewModel
    {
        private string _cardNumber;
        private string _expiryDate;
        private string _cvv;

        public string CardNumber
        {
            get => _cardNumber;
            set => SetProperty(ref _cardNumber, value);
        }

        public string ExpiryDate
        {
            get => _expiryDate;
            set => SetProperty(ref _expiryDate, value);
        }

        public string CVV
        {
            get => _cvv;
            set => SetProperty(ref _cvv, value);
        }


        public Command ConfirmPaymentCommand { get; set; }

        public ProcessPaymentViewModel()
        {
            ConfirmPaymentCommand = new Command(OnConfirmPaymentCommand);
        }

        public async void OnConfirmPaymentCommand(object sender)
        {
            BookingDto booking = new BookingDto()
            {
                StartDate = DataStore.BookingStartDate,
                EndDate = DataStore.BookingEndDate,
                TotalPrice = (decimal)(DataStore.BookingEndDate - DataStore.BookingStartDate).TotalHours * DataStore.Vehicle.RatePerDay,
                VehicleId = DataStore.Vehicle.VehicleId,
                UserId = AuthenticationService.UserId,
                CardInfo = new CardInfoDto()
                {
                    CVV = CVV,
                    CardNumber = CardNumber,
                    ExpiryDate = ExpiryDate,
                }
            };

            await BookingService.BookVehicle(booking);

            await Shell.Current.GoToAsync(nameof(RentalHistoryPage));
        }
    }
}
