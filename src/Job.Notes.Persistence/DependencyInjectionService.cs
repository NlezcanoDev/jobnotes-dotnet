using Job.Notes.Application.Database;
using Job.Notes.Application.Database.Space.Repository;
using Job.Notes.Application.Repositories;
using Job.Notes.Persistence.Database;
using Job.Notes.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Job.Notes.Persistence;

public static class DependencyInjectionService
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseService>(opt =>
            opt.UseSqlServer(configuration["SQLConnectionString"]));

        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddScoped<ISpaceRepository, SpaceRepository>();

        return services;
    }
}