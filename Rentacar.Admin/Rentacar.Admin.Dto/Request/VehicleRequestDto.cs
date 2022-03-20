namespace Rentacar.Dto.Request
{
    public class VehicleRequestDto
    {
        public int? VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? Transmission { get; set; }
        public string VehicleType { get; set; }
        public int? NumberOfSeats { get; set; }
    }
}
