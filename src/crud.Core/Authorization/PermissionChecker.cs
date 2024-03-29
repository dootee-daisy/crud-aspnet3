using Abp.Authorization;
using crud.Authorization.Roles;
using crud.Authorization.Users;

namespace crud.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
