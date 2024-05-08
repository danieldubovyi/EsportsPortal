using EsportsPortal.Models.Users;
using EsportsPortal.Services.Coaches.Commands;
using EsportsPortal.Services.Coaches.Dto;
using EsportsPortal.Services.Coaches.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;
[ApiController]
[Route("api/coaches")]
public class CoachesController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<CoachListItem>> GetCoaches([FromQuery]bool? notInTeam, CancellationToken cancellationToken)
    {
        var query = new GetCoachesQuery(notInTeam);
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{coachId:int}")]
    public async Task<CoachDetails> GetCoachDetails(int coachId, CancellationToken cancellationToken)
    {
        var query = new GetCoachDetailsQuery(coachId);
        return await sender.Send(query, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = UserRole.Admin)]
    public async Task<int> CreateCoach(CoachCreateParams coachCreateParams, CancellationToken cancellationToken)
    {
        return await sender.Send(new CreateCoachCommand(coachCreateParams), cancellationToken);
    }

    [HttpPut("{coachId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateCoach(int coachId, CoachCreateParams coachUpdateParams, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateCoachCommand(coachId, coachUpdateParams), cancellationToken);
    }

    [HttpDelete("{coachId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task DeleteCoach(int coachId, CancellationToken cancellationToken)
    {
        await sender.Send(new DeleteCoachCommand(coachId), cancellationToken);
    }

    [HttpPut("{coachId:int}/photo")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateCoachPhotoAsync(int coachId, IFormFile file, CancellationToken cancellationToken)
    {
        using var stream = file.OpenReadStream();
        var uploadCommand = new UpdateCoachPhotoCommand(coachId, stream, file.FileName);
        await sender.Send(uploadCommand, cancellationToken);
    }
}
