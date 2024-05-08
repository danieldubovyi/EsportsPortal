using Blazored.LocalStorage;

namespace EsportsPortal.WebUi.Authentication;

public class LocalStorageTokenStore(ILocalStorageService localStorage)
    : ITokenStore
{
    const string AccessTokenKey = "accessToken";
    const string RefreshTokenKey = "refreshToken";

    public async Task StoreTokensAsync(string accessToken, string refreshToken)
    {
        await localStorage.SetItemAsync(AccessTokenKey, accessToken);
        await localStorage.SetItemAsync(RefreshTokenKey, refreshToken);
    }

    public async Task ClearTokens()
    {
        await localStorage.RemoveItemAsync(AccessTokenKey);
        await localStorage.RemoveItemAsync(RefreshTokenKey);
    }

    public async Task<string?> GetAccessToken()
    {
        var token = await localStorage.GetItemAsStringAsync(AccessTokenKey);
        return token?.Trim('"');
    }

    public async Task<string?> GetRefreshToken()
    {
        var token = await localStorage.GetItemAsStringAsync(RefreshTokenKey);
        return token?.Trim('"');
    }
}
