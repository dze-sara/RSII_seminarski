using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class RentalDateViewModel : BaseViewModel
    {
        public Command SearchCommand { get; }

        public RentalDateViewModel()
        {
            SearchCommand = new Command(OnSearchClicked);
        }

        private async void OnSearchClicked(object obj)
        {
            await Shell.Current.GoToAsync("FilteredVehiclesPage");
        }
    }
}
