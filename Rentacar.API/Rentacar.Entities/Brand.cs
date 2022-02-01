using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Makes = new HashSet<Make>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

        public virtual ICollection<Make> Makes { get; set; }
    }
}
