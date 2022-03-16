using System;
using System.Collections.Generic;

namespace Rentacar.Dto
{
    public partial class BookingDto
    {
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public decimal? TotalPrice { get; set; }
        //public UserDto User { get; set; }
        //public VehicleDto Vehicle { get; set; }
    }
}
