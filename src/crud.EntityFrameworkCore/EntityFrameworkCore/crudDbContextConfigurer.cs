using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace crud.EntityFrameworkCore
{
    public static class crudDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<crudDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<crudDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
