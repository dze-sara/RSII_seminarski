using Rentacar.Dto.Response;
using Rentacar.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels.Booking
{
    public class RecommendationsViewModel : BaseViewModel
    {
        public ObservableCollection<VehicleBaseDto> VehicleItems { get; }
        public Command LoadItemsCommand { get; }
        private VehicleBaseDto _selectedItem;

        public string StartDate { get => DataStore.BookingStartDate.ToString("MMM, dd yyyy"); }
        public string EndDate { get => DataStore.BookingEndDate.ToString("MMM, dd yyyy"); }

        public RecommendationsViewModel()
        {
            Title = "Browse";
            VehicleItems = new ObservableCollection<VehicleBaseDto>();

            //ExecuteLoadItemsCommand();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                VehicleItems.Clear();
                DateTime startDate = DataStore.BookingStartDate;
                DateTime endDate = DataStore.BookingEndDate;
                var items = await VehicleService.GetRecommendedVehicles(AuthenticationService.UserId);
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
