using System.Collections.Generic;

namespace Rentacar.Dto
{
    public partial class BrandDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

        public ICollection<MakeDto> Makes { get; set; }
    }
}
