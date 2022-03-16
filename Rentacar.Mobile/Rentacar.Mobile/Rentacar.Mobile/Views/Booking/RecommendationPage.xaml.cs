using Rentacar.Mobile.ViewModels.Booking;
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
    public partial class RecommendationPage : ContentPage
    {
        public RecommendationPage()
        {
            InitializeComponent();
            BindingContext = new RecommendationsViewModel();
        }
    }
}