using EsportsPortal.Services.References.Dto;
using EsportsPortal.Services.References.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;

[Route("api/in-game-roles")]
[ApiController]
public class InGameRolesController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<InGameRoleListItem>> GetInGameRolesAsync(CancellationToken cancellationToken)
    {
        return await sender.Send(new GetInGameRolesQuery(), cancellationToken);
    }
}
