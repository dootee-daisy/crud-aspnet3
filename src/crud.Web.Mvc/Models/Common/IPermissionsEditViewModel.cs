using System.Collections.Generic;
using crud.Roles.Dto;

namespace crud.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}