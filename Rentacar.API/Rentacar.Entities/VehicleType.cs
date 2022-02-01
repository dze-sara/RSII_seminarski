using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Entities
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
