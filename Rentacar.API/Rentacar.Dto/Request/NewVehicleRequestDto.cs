using Rentacar.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Dto.Request
{
    public class NewVehicleRequest
    {
        public MakeBaseDto Make { get; set; }
        public ModelBaseDto Model { get; set; }
        public TransmissionTypeEnum Transmission { get; set; }
        public int NumberOfSeats { get; set; }
        public int PricePerDay { get; set; }
        //public string ImageUrl { get; set; }
        public int TypeId { get; set; }
    }
}
