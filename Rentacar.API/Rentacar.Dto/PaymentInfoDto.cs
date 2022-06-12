using System;

namespace Rentacar.Dto
{
    public class PaymentInfoDto
    {
        public int PaymentInfoId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string PaymentIntentId { get; set; }
        public long PaymentAmount { get; set; }
        public string Currency { get; set; }
        public string InvoiceId { get; set; }
        public string PaymentMethodId { get; set; }
    }
}
