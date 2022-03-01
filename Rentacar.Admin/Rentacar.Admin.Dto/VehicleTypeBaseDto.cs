namespace Rentacar.Dto
{
    public class VehicleTypeBaseDto
    {
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }

        public override string ToString()
        {
            return VehicleTypeName;
        }
    }
}
