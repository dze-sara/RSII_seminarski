using Rentacar.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rentacar.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RentalDatePage : ContentPage
    {
        public RentalDatePage()
        {
            InitializeComponent();
            BindingContext = new RentalDateViewModel();
        }

        private async void OnUserButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("UserDetailsPage");
        }
    }
}