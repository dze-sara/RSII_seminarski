using Rentacar.Mobile.Services;
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

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<BookingService>();
            DependencyService.Register<AuthenticationService>();
            DependencyService.Register<UserService>();

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
