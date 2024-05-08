namespace EsportsPortal.WebUi.Authentication;

public class AuthenticationResponse
{
    public static AuthenticationResponse Success()
        => new(true, Array.Empty<string>());

    public static AuthenticationResponse Failure(IReadOnlyCollection<string> errors)
        => new(false, errors);

    private AuthenticationResponse(bool success, IReadOnlyCollection<string> errors)
    {
        IsSuccessful = success;
        Errors = errors;
    }

    public bool IsSuccessful { get; }
    public IReadOnlyCollection<string> Errors { get; }
}
