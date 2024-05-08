namespace EsportsPortal.Services.Files;
internal class FileService : IFileService
{
    public async Task<byte[]?> GetFileAsync(string fileName, CancellationToken cancellationToken)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", fileName);
        if (!File.Exists(filePath))
        {
            return null;
        }

        return await File.ReadAllBytesAsync(filePath, cancellationToken);
    }

    public async Task CreateFileAsync(Stream file, string fileName, CancellationToken cancellationToken)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", fileName);
        if (File.Exists(filePath))
        {
            throw new ApplicationException($"File with name '{fileName}' already exists");
        }

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);
    }
}
