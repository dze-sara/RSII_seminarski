using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Entities
{
    public partial class Make
    {
        public Make()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public string MakeDescription { get; set; }
        public string Year { get; set; }
        public short NoOfSeats { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
