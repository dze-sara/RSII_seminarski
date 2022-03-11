using Rentacar.Dto;
using Rentacar.Dto.Response;
using Rentacar.Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rentacar.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleItemControl : ContentView
    {
        public VehicleBaseDto Vehicle { get; set; }

        public static BindableProperty VehicleProperty = BindableProperty.Create(
                    propertyName: nameof(Vehicle),
                    returnType: typeof(VehicleBaseDto),
                    declaringType: typeof(VehicleItemControl),
                    defaultValue: default(VehicleBaseDto),
                    defaultBindingMode: BindingMode.OneWay);

        //public bool IsRentable { get; set; }

        //public static BindableProperty IsRentableProperty = BindableProperty.Create(
        //            propertyName: nameof(IsRentable),
        //            returnType: typeof(bool),
        //            declaringType: typeof(VehicleItemControl),
        //            defaultValue: default(bool),
        //            defaultBindingMode: BindingMode.OneWay);

        public VehicleItemControl()
        {
            InitializeComponent();
        }



        public VehicleBaseDto VehicleProp
        {
            get { return (VehicleBaseDto)GetValue(VehicleProperty); }
            set 
            { 
                SetValue(VehicleProperty, value);
                OnPropertyChanged("VehicleProperty");
            }
        }

        private async void OnRentNowClicked(object sender, EventArgs e)
        {
            RentalDetailsPage.Vehicle = VehicleProp;

            await Shell.Current.GoToAsync(nameof(RentalDetailsPage));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}