namespace Rentacar.Dto
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public string Content { get; set; }
        public short Score { get; set; }
        public int ModelId { get; set; }
        public int UserId { get; set; }
        public string AuthorName { get; set; }
        public int BookingId { get; set; }
    }
}
