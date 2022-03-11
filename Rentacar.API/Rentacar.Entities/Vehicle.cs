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
        public short TransmissionType { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
