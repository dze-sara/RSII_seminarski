using System.Collections.Generic;



namespace Rentacar.Dto
{
    public partial class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserDto> Users { get; set; }
    }
}
