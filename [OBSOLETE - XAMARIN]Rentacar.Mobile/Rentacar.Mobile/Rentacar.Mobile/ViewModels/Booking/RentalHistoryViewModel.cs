using Rentacar.Dto;
using Rentacar.Dto.Response;
using Rentacar.Mobile.Views;
using Rentacar.Mobile.Views.Reviews;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class RentalHistoryViewModel : BaseViewModel
    {
        public ObservableCollection<BaseBookingDto> BookingItems { get; }
        public Command LoadItemsCommand { get; }
        public Command AddReviewTapped { get; }


        private void OnNavigatedTo(NavigationEventArgs e)
        {
            ExecuteLoadItemsCommand();
        }
        private void OnPageAppearing(object sender, Page e)
        {
            if(e is RentalHistoryPage)
            {
                ExecuteLoadItemsCommand();
            }
        }

        public RentalHistoryViewModel()
        {
            BookingItems = new ObservableCollection<BaseBookingDto>();

            Application.Current.PageAppearing += OnPageAppearing;

            ExecuteLoadItemsCommand();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddReviewTapped = new Command<BaseBookingDto>(OnAddReviewTapped);
        }

        public async void OnAddReviewTapped(BaseBookingDto bookingProp)
        {
            if(!bookingProp.CanAddReview)
            {
                return;
            }

            AddReviewPage.Booking = bookingProp;

            await Shell.Current.GoToAsync(nameof(AddReviewPage));
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await BookingService.GetBookingHistoryForUser(AuthenticationService.UserId);
                BookingItems.Clear();
                foreach (var item in items)
                {
                    BookingItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
