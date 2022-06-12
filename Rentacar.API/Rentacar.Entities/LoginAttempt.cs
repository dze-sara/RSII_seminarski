using System;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.Entities
{
    public class LoginAttempt
    {
        [Key]
        public int LoginAttemptId { get; set; }
        public int? UserId { get; set; }
        public DateTime AttemptedOn { get; set; }
        public int Status { get; set; }
        public string Username { get; set; }
    }
}
