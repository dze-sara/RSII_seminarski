namespace Rentacar.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Content { get; set; }
        public short Score { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
