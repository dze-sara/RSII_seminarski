using System.Collections.Generic;



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
