namespace EsportsPortal.WebUi.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> RegisterAsync(string email, string password);

    Task<AuthenticationResponse> LoginAsync(string email, string password);

    Task<AuthenticationResponse> LogoutAsync();
}
