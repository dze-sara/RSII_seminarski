using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Admin.Dto
{
    public class VehiclesReportDataTableDto
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public double TotalHoursBooked { get; set; }
        public double TotalPrice { get; set; }
    }
}
