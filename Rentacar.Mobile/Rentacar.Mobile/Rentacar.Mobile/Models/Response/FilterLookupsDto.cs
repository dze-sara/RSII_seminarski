using System.Collections.Generic;

namespace Rentacar.Dto.Response
{
    public class FilterLookupsDto
    {
        public List<ModelBaseDto> Models { get; set; }
        public List<VehicleTypeBaseDto> VehicleTypes { get; set; }
        public List<MakeBaseDto> Makes { get; set; }
        public List<LocationDto> Locations { get; set; }
    }
}
