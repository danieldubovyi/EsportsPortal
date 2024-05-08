using EsportsPortal.Services.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace EsportsPortal.WebApi.Controllers;
[Route("api/files")]
[ApiController]
public class FilesController(IFileService fileService)
    : ControllerBase
{
    [HttpGet("{fileName}")]
    [ProducesResponseType<FileResult>(200)]
    public async Task<IActionResult> DownloadFile(string fileName, CancellationToken cancellationToken)
    {
        var fileContent = await fileService.GetFileAsync(fileName, cancellationToken);
        if (fileContent == null)
        {
            return NotFound();
        }

        var fileExtensionContentTypeProvider = new FileExtensionContentTypeProvider();
        if (!fileExtensionContentTypeProvider.TryGetContentType(fileName, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        return File(fileContent, contentType, fileName);
    }
}
