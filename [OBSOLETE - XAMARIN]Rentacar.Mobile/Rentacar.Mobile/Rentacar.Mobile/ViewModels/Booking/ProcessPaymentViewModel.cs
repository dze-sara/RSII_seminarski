using Rentacar.Dto;
using Rentacar.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
            Regex regex = new Regex("^[0-9]+$");

            if (string.IsNullOrWhiteSpace(CVV) || 
                string.IsNullOrWhiteSpace(CardNumber) || 
                string.IsNullOrWhiteSpace(ExpiryDate) || 
                !regex.Match(CVV).Success || 
                !regex.Match(CardNumber.Replace("-","")).Success ||
                !regex.Match(ExpiryDate.Replace("/", "")).Success)
            {
                await Shell.Current.DisplayAlert("Error", "Please check entered data", "OK");
                return;
            }

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

            var response = await BookingService.BookVehicle(booking);
            if(response != null)
            {
                await Shell.Current.DisplayAlert("Error", "Payment was not successfull, please check entered data", "OK");
            }
            else
            {
                await Shell.Current.Navigation.PopToRootAsync();
                await Shell.Current.GoToAsync(nameof(RentalHistoryPage));
            }
        }
    }
}
