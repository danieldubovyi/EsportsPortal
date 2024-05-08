using EsportsPortal.Services.Files;
using EsportsPortal.Services.Matches.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EsportsPortal.Services;
public static class DependencyRegistrations
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(DependencyRegistrations).Assembly));
        services.AddFileServices();
        services.AddMatchServices();
        return services;
    }
}
