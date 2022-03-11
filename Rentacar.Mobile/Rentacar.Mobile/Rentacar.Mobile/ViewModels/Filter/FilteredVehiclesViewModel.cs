using Rentacar.Dto.Response;
using Rentacar.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class FilteredVehiclesViewModel : BaseViewModel
    {
        public ObservableCollection<VehicleBaseDto> VehicleItems { get; }
        public Command LoadItemsCommand { get; }
        public Command RentNowTapped { get; }
        private VehicleBaseDto _selectedItem;

        public VehicleBaseDto SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnRentNowClicked(value);
            }
        }

        public FilteredVehiclesViewModel()
        {
            Title = "Browse";
            VehicleItems = new ObservableCollection<VehicleBaseDto>();

            VehicleItems =  new ObservableCollection<VehicleBaseDto>()
            {
                new VehicleBaseDto() { VehicleId = 1, VehicleType = "small car", Make = "Volvo", Model = "V40", IsActive = true, NumberOfSeats = 5, RatePerDay = 50 },
                new VehicleBaseDto() { VehicleId = 2, VehicleType = "small car", Make = "VW", Model = "Polo", IsActive = true, NumberOfSeats = 5, RatePerDay = 30 }
            };

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            RentNowTapped = new Command<VehicleBaseDto>(OnRentNowClicked);
        }

        public async void OnRentNowClicked(VehicleBaseDto vehicleProp)
        {
            RentalDetailsPage.Vehicle = vehicleProp;

            await Shell.Current.GoToAsync(nameof(RentalDetailsPage));
        }

        async Task ExecuteLoadItemsCommand()
        {
            //IsBusy = true;

            //try
            //{
            //    VehicleItems.Clear();
            //    var items = await BookingService.FilterBookings(null);
            //    foreach (var item in items)
            //    {
            //        VehicleItems.Add(item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
            //finally
            //{
            //    IsBusy = false;
            //}
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
