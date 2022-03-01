using Rentacar.Dto.Enums;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Dto
{
    public partial class VehicleDto
    {
        public int VehicleId { get; set; }
        public decimal RatePerDay { get; set; }
        public bool IsActive { get; set; }
        public TransmissionTypeEnum TransmissionType { get; set; }
        public int ModelId { get; set; }

        public ModelDto Model { get; set; }
        public LocationDto Location { get; set; }
        public ICollection<BookingDto> Bookings { get; set; }
    }
}
