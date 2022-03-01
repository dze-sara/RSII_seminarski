namespace Rentacar.Dto
{
    public class MakeBaseDto
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public string MakeDescription { get; set; }

        public override string ToString()
        {
            return MakeName;
        }
    }
}
