using Rentacar.Dto;
using Rentacar.Mobile.ViewModels.Review;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rentacar.Mobile.Views.Reviews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReviewPage : ContentPage
    {
        public static BaseBookingDto Booking { get; set; }
        public ReviewDto Review { get; set; }
        public static int ReviewValue { get; set; }

        public AddReviewPage()
        {
            BindingContext = new AddReviewViewModel(Booking);

            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            ReviewValue = (int)Math.Round(value);
            scoreSlider.Value = ReviewValue;
            displayLabel.Text = String.Format("{0}", value);
        }
    }
}