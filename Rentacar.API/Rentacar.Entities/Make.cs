using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Entities
{
    public partial class Make
    {
        public Make()
        {
            Models = new HashSet<Model>();
        }

        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public string MakeDescription { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
