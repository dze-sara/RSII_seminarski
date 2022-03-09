using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Dto.Request
{
    public class BookingRequestDto
    {
        public int? BookingId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EndTime { get; set; }
        public int? UserId { get; set; }
        public int? VehicleId { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string VehicleType { get; set; }
    }
}
