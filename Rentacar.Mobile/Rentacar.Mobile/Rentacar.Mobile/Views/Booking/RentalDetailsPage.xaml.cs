using Rentacar.Dto;
using Rentacar.Dto.Response;
using Rentacar.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rentacar.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RentalDetailsPage : ContentPage
    {
        public static VehicleBaseDto Vehicle { get; set; }
        public RentalDetailsPage()
        {
            BindingContext = new RentalDetailsViewModel(Vehicle);
            InitializeComponent();
        }

        public RentalDetailsPage(VehicleBaseDto vehicleBaseDto)
        {
            Vehicle = vehicleBaseDto;
            BindingContext = new RentalDetailsViewModel(Vehicle);
            InitializeComponent();
        }

        private async void OnConfirmBooking(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(RentalHistoryPage));
        }
    }
}