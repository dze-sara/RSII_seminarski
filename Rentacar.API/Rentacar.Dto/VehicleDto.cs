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
        public int VehicleTypeId { get; set; }
        public TransmissionTypeEnum TransmissionType { get; set; }
        public int MakeId { get; set; }

        public MakeDto Make { get; set; }
        public VehicleTypeDto VehicleType { get; set; }
        public ICollection<BookingDto> Bookings { get; set; }
    }
}
