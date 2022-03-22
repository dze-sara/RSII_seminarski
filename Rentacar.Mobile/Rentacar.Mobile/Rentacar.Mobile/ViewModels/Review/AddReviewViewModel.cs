using Rentacar.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels.Review
{
    public class AddReviewViewModel : BaseViewModel
    {
        public BaseBookingDto Booking { get; set; }
        
        public AddReviewViewModel(BaseBookingDto booking)
        {
            Booking = booking;
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private double score;
        private string description;

        private bool ValidateSave()
        {
            return score > 0 && score < 6
                && !String.IsNullOrWhiteSpace(description);
        }

        public double Score
        {
            get => score;
            set => SetProperty(ref score, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ReviewDto newReview = new ReviewDto()
            {
                BookingId = Booking.BookingId,
                Content = Description,
                Score = (short)Score
            };

            await ReviewService.AddReview(newReview);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

    }
}
