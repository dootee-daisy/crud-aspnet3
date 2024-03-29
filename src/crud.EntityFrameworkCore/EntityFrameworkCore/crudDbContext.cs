using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using crud.Authorization.Roles;
using crud.Authorization.Users;
using crud.MultiTenancy;
using crud.KhachHangs;

namespace crud.EntityFrameworkCore
{
    public class crudDbContext : AbpZeroDbContext<Tenant, Role, User, crudDbContext>
    {
        /* Define a DbSet for each entity of the application */
        DbSet<KhachHang> KhachHangs { get; set; }
        public crudDbContext(DbContextOptions<crudDbContext> options)
            : base(options)
        {
        }
    }
}
