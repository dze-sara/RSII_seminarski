using System;
using System.Collections.Generic;

namespace Rentacar.Dto.Request
{
    public class BookVehiclesRequest
    {
        public BookVehiclesRequest()
        {
            VehicleTypes = new List<string>();
        }

        public int? TransmissionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public List<string> VehicleTypes { get; set; }

    }
}
