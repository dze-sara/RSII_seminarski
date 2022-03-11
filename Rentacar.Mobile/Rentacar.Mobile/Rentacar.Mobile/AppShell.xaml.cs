using Rentacar.Mobile.Views;
using Xamarin.Forms;

namespace Rentacar.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();

            Shell shell = new Shell();
            shell.CurrentItem = new LoginPage();
        }

        public AppShell(string currentItem)
        {

            InitializeComponent();
            RegisterRoutes();
            Shell shell = new Shell();

            switch (currentItem)
            {
                case "login":
                    shell.CurrentItem = new LoginPage();
                    break;

                case "mainpage":
                    shell.CurrentItem = new RentalDatePage();
                    break;
            }
        }

        public void RegisterRoutes()
        {
            // Examples
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            // Authentication
            Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
            Routing.RegisterRoute(nameof(RegisterNowPage), typeof(RegisterNowPage));

            // Filter
            Routing.RegisterRoute(nameof(FilteredVehiclesPage), typeof(FilteredVehiclesPage));
            Routing.RegisterRoute(nameof(EditFiltersPage), typeof(EditFiltersPage));

            // User
            Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));

            // Booking
            Routing.RegisterRoute(nameof(RentalDetailsPage), typeof(RentalDetailsPage));
            Routing.RegisterRoute(nameof(RentalHistoryPage), typeof(RentalHistoryPage));
        }

        
    }
}
