using System.Collections.Generic;
using crud.Roles.Dto;

namespace crud.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
