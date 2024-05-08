namespace EsportsPortal.WebUi.Authentication;

public interface ITokenStore
{
    Task StoreTokensAsync(string accessToken, string refreshToken);

    Task ClearTokens();

    Task<string?> GetAccessToken();

    Task<string?> GetRefreshToken();
}
