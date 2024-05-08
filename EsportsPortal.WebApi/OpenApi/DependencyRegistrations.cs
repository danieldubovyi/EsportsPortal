using NSwag;

namespace EsportsPortal.WebApi.OpenApi;

internal static class DependencyRegistrations
{
    public static IServiceCollection AddOpenApiDocument(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddOpenApiDocument(
            options =>
            {
                options.Title = "Esports Portal";
                options.OperationProcessors.Add(new UsersOperationProcessor());
                options.AddSecurity("Bearer", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "Bearer",
                    Name = "Bearer",
                    In = OpenApiSecurityApiKeyLocation.Header
                });
                options.PostProcess = document =>
                {
                    document.Security.Add(new OpenApiSecurityRequirement { { "Bearer", Array.Empty<string>() } });
                };
            });

        return services;
    }
}
