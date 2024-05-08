using EsportsPortal.Services.Search.Commands;
using EsportsPortal.Services.Search.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;
[Route("api/search")]
[ApiController]
public class SearchController(ISender sender)
    : ControllerBase
{
    public async Task<IReadOnlyCollection<SearchResult>> Search(string searchTerm, CancellationToken cancellationToken)
    {
        return await sender.Send(new SearchCommand(searchTerm), cancellationToken);
    }
}
