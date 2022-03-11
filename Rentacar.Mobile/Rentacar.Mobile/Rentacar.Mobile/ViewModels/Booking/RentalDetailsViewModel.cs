using Rentacar.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar.Mobile.ViewModels
{
    public class RentalDetailsViewModel : BaseViewModel
    {
        public VehicleBaseDto Vehicle { get; set; }
        public RentalDetailsViewModel(VehicleBaseDto vehicleBaseDto)
        {
            Vehicle = vehicleBaseDto;
        }
    }
}
