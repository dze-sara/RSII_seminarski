using Rentacar.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rentacar.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilteredVehiclesPage : ContentPage
    {
        public FilteredVehiclesPage()
        {
            InitializeComponent();
            BindingContext = new FilteredVehiclesViewModel();
        }
    }
}