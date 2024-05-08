using EsportsPortal.Services.References.Dto;
using EsportsPortal.Services.References.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;

[Route("api/locations")]
[ApiController]
public class LocationsController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<LocationListItem>> GetLocations(CancellationToken cancellationToken)
    {
        return await sender.Send(new GetLocationsQuery(), cancellationToken);
    }
}
