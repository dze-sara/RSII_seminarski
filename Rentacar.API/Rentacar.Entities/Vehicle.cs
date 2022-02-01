using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Entities
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Bookings = new HashSet<Booking>();
        }

        public int VehicleId { get; set; }
        public decimal RatePerDay { get; set; }
        public bool IsActive { get; set; }
        public int VehicleTypeId { get; set; }
        public short TransmissionType { get; set; }
        public int MakeId { get; set; }

        public virtual Make Make { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
