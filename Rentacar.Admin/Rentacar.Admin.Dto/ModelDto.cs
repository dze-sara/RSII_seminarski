using System.Collections.Generic;

namespace Rentacar.Dto
{
    public partial class ModelDto
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModelDescription { get; set; }
        public string Year { get; set; }
        public short NoOfSeats { get; set; }
        public int MakeId { get; set; }

        public MakeDto Make { get; set; }
        public VehicleTypeDto VehicleType { get; set; }
        public ICollection<VehicleDto> Vehicles { get; set; }

        public override string ToString()
        {
            return ModelName;
        }
    }
}
