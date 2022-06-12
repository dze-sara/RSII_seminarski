using System;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.Entities
{
    public class PaymentInfo
    {
        [Key]
        public int PaymentInfoId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string PaymentIntentId { get; set; }
        public long PaymentAmount { get; set; }
        public string Currency { get; set; }
        public string InvoiceId { get; set; }
        public string PaymentMethodId { get; set; }
    }
}
