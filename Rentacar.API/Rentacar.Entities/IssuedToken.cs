using System;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.Entities
{
    public class IssuedToken
    {
        [Key]
        public int TokenId { get; set; }
        public string TokenValue { get; set; }
        public DateTime IssuedOn { get; set; }
        public int ValidFor { get; set; }
        public int UserId { get; set; }
    }
}
