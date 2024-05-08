using Microsoft.Extensions.DependencyInjection;

namespace EsportsPortal.Services.Files;
internal static class DependencyRegistrations
{
    public static IServiceCollection AddFileServices(this IServiceCollection services)
    {
        services.AddTransient<IFileService, FileService>();
        return services;
    }
}
