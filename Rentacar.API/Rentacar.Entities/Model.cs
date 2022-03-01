using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Entities
{
    public partial class Model
    {
        public Model()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModelDescription { get; set; }
        public string Year { get; set; }
        public short NoOfSeats { get; set; }
        public int MakeId { get; set; }
        public int VehicleTypeId { get; set; }

        public virtual Make Make { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
