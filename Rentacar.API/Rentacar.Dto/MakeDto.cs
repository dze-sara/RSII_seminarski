using System.Collections.Generic;

#nullable disable

namespace Rentacar.Dto
{
    public partial class MakeDto
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public string MakeDescription { get; set; }

        public ICollection<ModelDto> Models { get; set; }
    }
}
