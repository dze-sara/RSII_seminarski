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
    public partial class RegisterNowPage : ContentPage
    {
        public RegisterNowPage()
        {
            InitializeComponent();
            BindingContext = new RegisterNowViewModel();
        }
    }
}