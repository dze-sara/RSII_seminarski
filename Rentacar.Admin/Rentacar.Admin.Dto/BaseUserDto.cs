using System;

namespace Rentacar.Dto
{
    public class BaseUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Role { get; set; }
    }
}
