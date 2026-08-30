using AdsSqlApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdsSqlApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AdsDatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlDatabase")));

            // Repositories
            services.AddScoped<Repositories.IOperatorActionRepository, Repositories.OperatorActionRepository>();
            services.AddScoped<Repositories.IWellTestRepository, Repositories.WellTestRepository>();

            // Query handlers (CQRS)
            services.AddScoped<
                global::AdsSqlApi.Application.Abstractions.Cqrs.IQueryHandler<
                    global::AdsSqlApi.Application.Queries.GetOperatorActionsQuery,
                    System.Collections.Generic.IEnumerable<global::AdsSqlApi.Application.Dtos.OperatorActionDto>>,
                global::AdsSqlApi.Infrastructure.Handlers.GetOperatorActionsQueryHandler>();

            services.AddScoped<
                global::AdsSqlApi.Application.Abstractions.Cqrs.IQueryHandler<
                    global::AdsSqlApi.Application.Queries.GetWellTestsBetweenDateRangeExclusiveQuery,
                    System.Collections.Generic.IEnumerable<global::AdsSqlApi.Application.Dtos.WellTestDto>>,
                global::AdsSqlApi.Infrastructure.Handlers.GetWellTestsBetweenDateRangeExclusiveQueryHandler>();

            return services;
        }
    }
}
