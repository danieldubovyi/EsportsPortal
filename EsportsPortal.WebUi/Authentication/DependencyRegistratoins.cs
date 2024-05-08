using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace EsportsPortal.WebUi.Authentication;

internal static class DependencyRegistratoins
{
    public static IServiceCollection AddUsersAuthentication(this IServiceCollection services)
    {
        services.AddBlazoredLocalStorage();
        services.AddOptions();
        services.AddAuthorizationCore();
        services.AddCascadingAuthenticationState();
        services.AddTransient<ITokenStore, LocalStorageTokenStore>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddScoped<AuthenticationStateProvider, BearerAuthStateProvider>();
        services.AddTransient<IUserThemeService, UserThemeService>();

        return services;
    }
}
