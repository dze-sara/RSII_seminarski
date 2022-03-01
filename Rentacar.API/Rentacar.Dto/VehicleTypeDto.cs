using System.Collections.Generic;

#nullable disable

namespace Rentacar.Dto
{
    public partial class VehicleTypeDto
    {
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }

        public ICollection<ModelDto> Models { get; set; }
    }
}
