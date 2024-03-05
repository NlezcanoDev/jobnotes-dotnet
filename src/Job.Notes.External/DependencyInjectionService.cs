using Job.Notes.External.Jwt.GetTokenJwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Job.Notes.External;

public static class DependencyInjectionService
{
    public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSingleton<IGetTokenJwtModel, GetTokenJwtService>();
        return services;
    }
}