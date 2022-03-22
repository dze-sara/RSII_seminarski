using Rentacar.Mobile.Services;
using Rentacar.Mobile.Services.Implementations;
using Rentacar.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rentacar.Mobile
{
    public partial class App : Application
    {
        public static bool isLogged = false;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataStore>();
            DependencyService.Register<BookingService>();
            DependencyService.Register<AuthenticationService>();
            DependencyService.Register<VehicleService>();
            DependencyService.Register<UserService>();
            DependencyService.Register<ReviewService>();
            DependencyService.Register<FiltersService>();

            bool isLogged = false;
            if (isLogged)
            {
                MainPage = new AppShell("mainpage");
            }
            else
            {
                MainPage = new AppShell("loginpage");
            }
        }

        protected override async void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
