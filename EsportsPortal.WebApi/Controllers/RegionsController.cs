using EsportsPortal.Services.References.Dto;
using EsportsPortal.Services.References.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;
[Route("api/regions")]
[ApiController]
public class RegionsController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<RegionListItem>> GetRegions(CancellationToken cancellationToken)
    {
        return await sender.Send(new GetRegionsQuery(), cancellationToken);
    }
}
