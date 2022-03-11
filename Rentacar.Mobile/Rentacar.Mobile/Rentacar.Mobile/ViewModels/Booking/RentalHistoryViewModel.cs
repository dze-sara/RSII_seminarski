using Rentacar.Dto.Response;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class RentalHistoryViewModel : BaseViewModel
    {
        public ObservableCollection<VehicleBaseDto> VehicleItems { get; }
        public Command LoadItemsCommand { get; }

        public RentalHistoryViewModel()
        {
            VehicleItems = new ObservableCollection<VehicleBaseDto>();

            VehicleItems = new ObservableCollection<VehicleBaseDto>()
            {
                new VehicleBaseDto() { VehicleId = 1, VehicleType = "small car", Make = "Volvo", Model = "V40", IsActive = true, NumberOfSeats = 5, RatePerDay = 50 },
                new VehicleBaseDto() { VehicleId = 2, VehicleType = "small car", Make = "VW", Model = "Polo", IsActive = true, NumberOfSeats = 5, RatePerDay = 30 }
            };

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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
