using Rentacar.Dto;
using Rentacar.Dto.Response;
using Rentacar.Mobile.Views;
using Rentacar.Mobile.Views.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class RentalDetailsViewModel : BaseViewModel
    {
        public string StartDate { get => DataStore.BookingStartDate.ToString("MMM, dd yyyy"); }
        public string EndDate { get => DataStore.BookingEndDate.ToString("MMM, dd yyyy"); }

        public VehicleBaseDto Vehicle { get; set; }
        public Command ConfirmBookingCommand { get; set; }
        public Command LoadReviewsCommand { get; set; }
        public ObservableCollection<ReviewDto> ReviewItems { get; }

        public RentalDetailsViewModel(VehicleBaseDto vehicleBaseDto)
        {
            Vehicle = vehicleBaseDto;
            ReviewItems = new ObservableCollection<ReviewDto>();
            ConfirmBookingCommand = new Command(OnConfirmBooking);

            ExecuteLoadItemsCommand();
            LoadReviewsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if(IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            { 
                DateTime startDate = DataStore.BookingStartDate;
                DateTime endDate = DataStore.BookingEndDate;
                var items = await ReviewService.GetReviewsByModelId(Vehicle.ModelId);
                ReviewItems.Clear();
                foreach (var item in items)
                {
                    ReviewItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnConfirmBooking(object obj)
        {
            DataStore.Vehicle = this.Vehicle;
            await Shell.Current.GoToAsync(nameof(ProcessPaymentPage));
        }
    }
}
