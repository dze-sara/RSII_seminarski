using System;
using System.Collections.Generic;

#nullable disable

namespace Rentacar.Dto
{
    public partial class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? RoleId { get; set; }
        public string Token { get; set; } 

        public RoleDto Role { get; set; }
        public ICollection<BookingDto> Bookings { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}
