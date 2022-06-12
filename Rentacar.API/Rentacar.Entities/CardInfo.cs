using System.ComponentModel.DataAnnotations;

namespace Rentacar.Entities
{
    public class CardInfo
    {
        [Key]
        public int CardInfoId { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
    }
}
