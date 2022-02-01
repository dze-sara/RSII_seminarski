using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Dto
{
    public partial class MakeDto
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public string MakeDescription { get; set; }
        public string Year { get; set; }
        public short NoOfSeats { get; set; }
        public int BrandId { get; set; }

        public BrandDto Brand { get; set; }
        public ICollection<VehicleDto> Vehicles { get; set; }
    }
}
