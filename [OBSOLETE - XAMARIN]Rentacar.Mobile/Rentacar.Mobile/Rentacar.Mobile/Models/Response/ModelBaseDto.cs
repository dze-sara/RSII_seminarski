namespace Rentacar.Dto
{
    public class ModelBaseDto
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModelDescription { get; set; }
        public string Year { get; set; }
        public short NoOfSeats { get; set; }
        public int MakeId { get; set; }
    }
}
