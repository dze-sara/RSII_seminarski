using Rentacar.Mobile.Services;
using System;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class RentalDateViewModel : BaseViewModel
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private DateTime _startTime;
        private DateTime _endTime;
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public DateTime StartTime
        {
            get => _startTime;
            set => SetProperty(ref _startTime, value);
        }

        public DateTime EndTime
        {
            get => _endTime;
            set => SetProperty(ref _endTime, value);
        }


        public Command SearchCommand { get; }

        public RentalDateViewModel()
        {
            SearchCommand = new Command(OnSearchClicked);
        }

        private async void OnSearchClicked(object obj)
        {
            DataStore.BookingStartDate = StartDate;
            DataStore.BookingStartDate.AddHours(StartTime.Hour);
            DataStore.BookingStartDate.AddMinutes(StartTime.Minute);

            DataStore.BookingEndDate = EndDate;
            DataStore.BookingEndDate.AddHours(EndTime.Hour);
            DataStore.BookingEndDate.AddMinutes(EndTime.Minute);
            await Shell.Current.GoToAsync("FilteredVehiclesPage");
        }
    }
}
