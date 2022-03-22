﻿using Rentacar.Dto;
using Rentacar.Dto.Response;
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


        public RentalHistoryViewModel()
        {
            BookingItems = new ObservableCollection<BaseBookingDto>();

            ExecuteLoadItemsCommand();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddReviewTapped = new Command<BaseBookingDto>(OnAddReviewTapped);
        }

        public async void OnAddReviewTapped(BaseBookingDto bookingProp)
        {
            AddReviewPage.Booking = bookingProp;

            await Shell.Current.GoToAsync(nameof(AddReviewPage));
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                BookingItems.Clear();
                var items = await BookingService.GetBookingHistoryForUser(AuthenticationService.UserId);
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
