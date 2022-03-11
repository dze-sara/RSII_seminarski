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

        public string StartDate { get => DataStore.BookingStartDate.ToString("MMM, dd yyyy");  }
        public string EndDate { get => DataStore.BookingEndDate.ToString("MMM, dd yyyy");  }

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
            
            ExecuteLoadItemsCommand();

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
            IsBusy = true;

            try
            {
                VehicleItems.Clear();
                DateTime startDate = DataStore.BookingStartDate;
                DateTime endDate = DataStore.BookingEndDate;
                var items = await VehicleService.FilterVehiclesByDateRange(startDate, endDate);
                foreach (var item in items)
                {
                    VehicleItems.Add(item);
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
    }
}
