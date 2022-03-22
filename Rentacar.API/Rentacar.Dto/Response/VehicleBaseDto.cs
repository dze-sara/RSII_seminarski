using Rentacar.Dto.Enums;

namespace Rentacar.Dto.Response
{
    public class VehicleBaseDto
    {
        public int VehicleId { get; set; }
        public decimal RatePerDay { get; set; }
        public bool IsActive { get; set; }
        public TransmissionTypeEnum TransmissionType { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string VehicleType { get; set; }
        public int NumberOfSeats { get; set; }
        public string ImageUrl { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
