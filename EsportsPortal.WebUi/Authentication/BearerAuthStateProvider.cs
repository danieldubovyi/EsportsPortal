using System.Net.Http.Headers;
using System.Security.Claims;
using EsportsPortal.WebApi.Clients;
using Microsoft.AspNetCore.Components.Authorization;

namespace EsportsPortal.WebUi.Authentication;

public class BearerAuthStateProvider(
    ITokenStore tokenStore,
    HttpClient httpClient,
    UsersClient usersClient)
    : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var accessToken = await tokenStore.GetAccessToken();
        var refreshToken = await tokenStore.GetRefreshToken();

        var identity = new ClaimsIdentity();
        httpClient.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrEmpty(accessToken))
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var userInfo = await usersClient.GetInfoAsync();
                identity = new ClaimsIdentity([
                    new Claim(ClaimTypes.Name, userInfo.Email!),
                    new Claim(ClaimTypes.Email, userInfo.Email!),
                    new Claim(ClaimTypes.Role, string.Join(',', userInfo.Roles))
                    ], "bearer");
            }
            catch(Exception ex)
            {
                await tokenStore.ClearTokens();
                Console.WriteLine(ex);
            }
        }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }
}
