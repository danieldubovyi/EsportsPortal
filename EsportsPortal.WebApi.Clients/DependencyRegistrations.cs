using EsportsPortal.WebApi.Clients.Files;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EsportsPortal.WebApi.Clients;
public static class DependencyRegistrations
{
    public static IServiceCollection AddApiClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<WebApiOptions>(configuration.GetSection(WebApiOptions.SectionName));
        services.AddTransient<IFileUrlProvider, FileUrlProvider>();

        services.AddScoped(sp =>
        {
            var options = sp.GetRequiredService<IOptions<WebApiOptions>>();
            return new HttpClient { BaseAddress = new Uri(options.Value.BaseAddress) };
        });

        var clientTypes = typeof(DependencyRegistrations).Assembly.GetTypes()
            .Where(t => t.IsClass && typeof(IApiClient).IsAssignableFrom(t))
            .ToArray();

        foreach (var clientType in clientTypes)
        {
            services.AddTransient(clientType);
        }

        return services;
    }
}
