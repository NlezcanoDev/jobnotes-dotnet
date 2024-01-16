using Job.Notes.Application.Interfaces;
using Job.Notes.Persistence.Database;
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
        
        return services;
    }
}