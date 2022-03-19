using System;

namespace Rentacar.Dto
{
    public class BaseBookingDto
    {
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserId { get; set; }
        public string BookedBy { get; set; }
        public int VehicleId { get; set; }
        public string VehicleModel { get; set; }
        public decimal? TotalPrice { get; set; }
        public string ImageUrl { get; set; }

    }
}
