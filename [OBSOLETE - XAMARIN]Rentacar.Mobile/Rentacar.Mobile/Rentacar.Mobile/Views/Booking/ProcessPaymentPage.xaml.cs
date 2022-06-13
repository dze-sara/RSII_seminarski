using Rentacar.Mobile.ViewModels.Booking;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rentacar.Mobile.Views.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcessPaymentPage : ContentPage
    {
        public ProcessPaymentPage()
        {
            InitializeComponent();
            BindingContext = new ProcessPaymentViewModel();
        }
    }
}