using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AdsSqlApi.Infrastructure.Persistence;

public sealed class AdsDatabaseContextFactory : IDesignTimeDbContextFactory<AdsDatabaseContext>
{
    public AdsDatabaseContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

        var config = builder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<AdsDatabaseContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("SqlDatabase"));

        return new AdsDatabaseContext(optionsBuilder.Options);
    }
}
