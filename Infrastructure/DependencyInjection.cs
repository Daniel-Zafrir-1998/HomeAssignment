using Domain.Abstractions.DatabaseSeeder;
using Domain.Abstractions.Filters.ActorFilters;
using Domain.Abstractions.Repositories;
using Infrastructure.Context;
using Infrastructure.Repository;
using Infrastructure.Utils.Database;
using Infrastructure.Utils.Filters.ActorFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("SplititLocal"));

        services.AddTransient<IActorRepository, ActorRepository>();
        services.AddTransient<IDatabaseSeeder, IMDBDatabaseSeeder>();
        services.AddTransient<IActorFilter, ActorFilter>();

        return services;
    }
}

