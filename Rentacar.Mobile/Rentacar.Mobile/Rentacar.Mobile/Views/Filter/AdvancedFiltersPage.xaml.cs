using Rentacar.Dto.Request;
using Rentacar.Mobile.ViewModels.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rentacar.Mobile.Views.Filter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdvancedFiltersPage : ContentPage
    {
        private AdvancedFiltersViewModel _viewModel;

        public AdvancedFiltersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AdvancedFiltersViewModel();
        }
        
        public async void OnCloseFilters(object sender, EventArgs e)
        {
            if(maxPriceSlider.Value < minPriceSlider.Value)
            {
                await Shell.Current.DisplayAlert("Incorrect", "Invalid values for min and max price", "OK");
                return;
            }

            BookVehiclesRequest filters = new BookVehiclesRequest();
            if(sedanCb.IsChecked)
            {
                filters.VehicleTypes.Add("Sedan");
            }
            if (suvCb.IsChecked)
            {
                filters.VehicleTypes.Add("SUV");
            }
            if (sportscarCb.IsChecked)
            {
                filters.VehicleTypes.Add("Sports car");
            }
            if (smallcarCb.IsChecked)
            {
                filters.VehicleTypes.Add("Small car");
            }
            filters.MaxPrice = (int)maxPriceSlider.Value;
            filters.MinPrice = (int)minPriceSlider.Value;

            _viewModel.DataStore.Filter = filters;
            await Shell.Current.GoToAsync("..");
        }

        private void OnMinSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            minDisplayLabel.Text = String.Format("{0}", value);
        }

        private void OnMaxSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            maxDisplayLabel.Text = String.Format("{0}", value);
        }
    }
}