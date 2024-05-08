using EsportsPortal.WebApi.Clients;
using Microsoft.AspNetCore.Components.Authorization;

namespace EsportsPortal.WebUi.Authentication;

public class AuthenticationService(
    UsersClient usersClient,
    ITokenStore tokenStore,
    AuthenticationStateProvider authenticationStateProvider,
    IUserThemeService userThemeService)
    : IAuthenticationService
{

    public async Task<AuthenticationResponse> RegisterAsync(string email, string password)
    {
        try
        {
            var request = new RegisterRequest { Email = email, Password = password };
            await usersClient.RegisterAsync(request);
        }
        catch (ApiException<HttpValidationProblemDetails> validationExeption)
        {
            return AuthenticationResponse.Failure(validationExeption.Result.Errors.SelectMany(x => x.Value).ToArray());
        }
        catch (ApiException apiException)
        {
            Console.WriteLine(apiException.Message);
            return AuthenticationResponse.Failure(["A server side error occurred. Please try again"]);
        }

        return AuthenticationResponse.Success();
    }

    public async Task<AuthenticationResponse> LoginAsync(string email, string password)
    {
        try
        {
            var request = new LoginRequest { Email = email, Password = password };
            var token = await usersClient.LoginAsync(request);
            await tokenStore.StoreTokensAsync(token.AccessToken, token.RefreshToken);
        }
        catch (ApiException apiException)
        {
            if (apiException.StatusCode == 401)
            {
                return AuthenticationResponse.Failure(["User with this credentials doesn't exist"]);
            }

            Console.WriteLine(apiException.Message);
            return AuthenticationResponse.Failure(["A server side error occurred. Please try again"]);
        }

        await authenticationStateProvider.GetAuthenticationStateAsync();
        await userThemeService.ApplayUserThemeSettingsAsync();
        return AuthenticationResponse.Success();
    }

    public async Task<AuthenticationResponse> LogoutAsync()
    {
        await tokenStore.ClearTokens();
        await authenticationStateProvider.GetAuthenticationStateAsync();
        await userThemeService.ResetThemeSettingsAsync();
        return AuthenticationResponse.Success();
    }
}
