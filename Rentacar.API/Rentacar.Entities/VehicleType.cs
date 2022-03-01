using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Entities
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Models = new HashSet<Model>();
        }

        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
