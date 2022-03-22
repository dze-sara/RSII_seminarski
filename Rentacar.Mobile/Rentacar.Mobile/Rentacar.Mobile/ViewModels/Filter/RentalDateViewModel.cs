using Rentacar.Dto.Response;
using Rentacar.Mobile.Services;
using System;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class RentalDateViewModel : BaseViewModel
    {
        private DateTime _startDate = DateTime.Now.Date;
        private DateTime _endDate = DateTime.Now.Date.AddDays(1);
        private DateTime _startTime = DateTime.Now.Date;
        private DateTime _endTime = DateTime.Now.Date.AddDays(1);
        private double _minPrice;
        private double _maxPrice;

        public FilterLookupsDto FilterLookups { get; set; }
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

        public double MinPrice
        {
            get => _minPrice;
            set => SetProperty(ref _minPrice, value);
        }

        public double MaxPrice
        {
            get => _maxPrice;
            set => SetProperty(ref _maxPrice, value);
        }


        public Command SearchCommand { get; }
        public Command AdvancedFiltersCommand { get; }

        public RentalDateViewModel()
        {
            SearchCommand = new Command(OnSearchClicked);
            AdvancedFiltersCommand = new Command(OnAdvancedFiltersClicked);

            GetFilters();
        }
        private async void GetFilters()
        {
            FilterLookups = await FiltersService.GetFilterLookups();
        }

        private async void OnAdvancedFiltersClicked(object obj)
        {
            await Shell.Current.GoToAsync("AdvancedFiltersPage");
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
