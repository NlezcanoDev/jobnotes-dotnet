using Job.Notes.Application.Database;
using Job.Notes.Application.Database.Project.Repositories;
using Job.Notes.Application.Database.Security.Repositories;
using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Application.Database.User.Repositories;
using Job.Notes.Persistence.Database;
using Job.Notes.Persistence.Repositories.Read;
using Job.Notes.Persistence.Repositories.Write;
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

        #region ReadRepositories
        // Users
        services.AddTransient<IReadUserRepository, ReadUserRepository>();
        
        // Application
        services.AddTransient<IReadProjectRepository, ReadProjectRepository>();
        services.AddTransient<IReadSpaceRepository, ReadSpaceRepository>();
        
        // Security
        services.AddTransient<IReadSecurityRepository, ReadSecurityRepository>();
        #endregion

        #region WriteRepositories
        // Users
        services.AddTransient<IWriteUserRepository, WriteUserRepository>();
        
        // Application
        services.AddTransient<IWriteSpaceRepository, WriteSpaceRepository>();
        services.AddTransient<IWriteProjectRepository, WriteProjectRepository>();
        
        // Security
        services.AddTransient<IWriteSecurityRepository, WriteSecurityRepository>();
        #endregion

        return services;
    }
}