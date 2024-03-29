using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using crud.Configuration;
using crud.Web;

namespace crud.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class crudDbContextFactory : IDesignTimeDbContextFactory<crudDbContext>
    {
        public crudDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<crudDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            crudDbContextConfigurer.Configure(builder, configuration.GetConnectionString(crudConsts.ConnectionStringName));

            return new crudDbContext(builder.Options);
        }
    }
}
