using Rentacar.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Dto.Response
{
    public class VehicleBaseDto
    {
        public int VehicleId { get; set; }
        public decimal RatePerDay { get; set; }
        public bool IsActive { get; set; }
        public TransmissionTypeEnum TransmissionType { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string VehicleType { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
