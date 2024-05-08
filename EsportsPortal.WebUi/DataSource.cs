using EsportsPortal.WebApi.Clients;

namespace EsportsPortal.WebUi;

internal class DataSource
{
    public async Task<ServiceResponse> RunAction(Func<Task> action)
    {
        try
        {
            await action();
            return ServiceResponse.Success();
        }
        catch (ApiException<HttpValidationProblemDetails> validationExeption)
        {
            return ServiceResponse.Failure(validationExeption.Result.Errors.SelectMany(x => x.Value).ToArray());
        }
        catch (ApiException apiException)
        {
            Console.WriteLine(apiException.Message);
            return ServiceResponse.Failure(["A server side error occurred. Please try again"]);
        }
    }

    public async Task<ServiceResponse<TResult>> RunAction<TResult>(Func<Task<TResult>> action)
    {
        try
        {
            var result = await action();
            return ServiceResponse<TResult>.Success(result);
        }
        catch (ApiException<HttpValidationProblemDetails> validationExeption)
        {
            return ServiceResponse<TResult>.Failure(validationExeption.Result.Errors.SelectMany(x => x.Value).ToArray());
        }
        catch (ApiException apiException)
        {
            Console.WriteLine(apiException.Message);
            return ServiceResponse<TResult>.Failure(["A server side error occurred. Please try again"]);
        }
    }
}

public class ServiceResponse
{
    public static ServiceResponse Success()
        => new(true, Array.Empty<string>());

    public static ServiceResponse Failure(IReadOnlyCollection<string> errors)
        => new(false, errors);

    protected ServiceResponse(bool success, IReadOnlyCollection<string> errors)
    {
        IsSuccessful = success;
        Errors = errors;
    }

    public bool IsSuccessful { get; }
    public IReadOnlyCollection<string> Errors { get; }
}

public class ServiceResponse<TResult> : ServiceResponse
{
    public static ServiceResponse<TResult> Success(TResult result)
        => new(result);

    new public static ServiceResponse<TResult> Failure(IReadOnlyCollection<string> errors)
        => new(errors);

    private ServiceResponse(TResult result)
        : base(true, Array.Empty<string>())
    {
        Result = result;
    }

    private ServiceResponse(IReadOnlyCollection<string> errors)
        : base(false, errors)
    {
        Result = default!;
    }

    public TResult Result { get; }
}
