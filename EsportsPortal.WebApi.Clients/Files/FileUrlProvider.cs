using Microsoft.Extensions.Options;

namespace EsportsPortal.WebApi.Clients.Files;
internal class FileUrlProvider(IOptions<WebApiOptions> options) : IFileUrlProvider
{
    public string GetFileUrl(string fileName)
        => $"{options.Value.BaseAddress}api/Files/{fileName}";
}
