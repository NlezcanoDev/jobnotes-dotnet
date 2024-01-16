using Microsoft.Extensions.DependencyInjection;

namespace Job.Notes.Common;

public static class DependencyInjectionService
{
    public static IServiceCollection AddCommon(this IServiceCollection services)
    {
        // NOTE: register services for this project
        return services;
    }
}