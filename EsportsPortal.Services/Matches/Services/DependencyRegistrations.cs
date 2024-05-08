using Microsoft.Extensions.DependencyInjection;

namespace EsportsPortal.Services.Matches.Services;
internal static class DependencyRegistrations
{
    public static IServiceCollection AddMatchServices(this IServiceCollection services)
    {
        services.AddTransient<IMatchResultCalculationService, MatchResultCalculationService>();
        return services;
    }
}
