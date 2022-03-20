using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Dto.Response
{
    public class VehiclesReportResponseDto
    {
        public VehicleBaseDto VehicleBase { get; set; }
        public List<BaseBookingDto> BookingsForVehicle { get; set; }
    }
}
