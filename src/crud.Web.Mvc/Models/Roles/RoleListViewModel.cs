using System.Collections.Generic;
using crud.Roles.Dto;

namespace crud.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
