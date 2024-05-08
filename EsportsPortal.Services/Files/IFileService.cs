namespace EsportsPortal.Services.Files;
public interface IFileService
{
    Task CreateFileAsync(Stream file, string fileName, CancellationToken cancellationToken);

    Task<byte[]?> GetFileAsync(string fileName, CancellationToken cancellationToken);
}
