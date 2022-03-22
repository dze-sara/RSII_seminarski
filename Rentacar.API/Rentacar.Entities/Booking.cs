using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Entities
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool ReviewAdded { get; set; }

        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
