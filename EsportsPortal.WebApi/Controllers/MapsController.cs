using EsportsPortal.Services.References.Dto;
using EsportsPortal.Services.References.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;

[Route("api/maps")]
[ApiController]
public class MapsController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<MapListItem>> GetMaps(CancellationToken cancellationToken)
    {
        return await sender.Send(new GetMapsQuery(), cancellationToken);
    }
}
