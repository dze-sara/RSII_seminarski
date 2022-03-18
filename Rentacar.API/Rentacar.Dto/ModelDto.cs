using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Dto
{
    public partial class ModelDto
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModelDescription { get; set; }
        public string Year { get; set; }
        public short NoOfSeats { get; set; }
        public int MakeId { get; set; }
        public int VehicleTypeId { get; set; }

        public MakeDto Make { get; set; }
        //public ICollection<VehicleDto> Vehicles { get; set; }
        public VehicleTypeDto VehicleType { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}
