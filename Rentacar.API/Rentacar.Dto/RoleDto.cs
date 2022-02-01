using System.Collections.Generic;

#nullable disable

namespace Rentacar.Dto
{
    public partial class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserDto> Users { get; set; }
    }
}
