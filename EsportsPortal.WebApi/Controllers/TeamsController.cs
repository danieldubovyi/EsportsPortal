using EsportsPortal.Models.Users;
using EsportsPortal.Services.Teams.Commands;
using EsportsPortal.Services.Teams.Dto;
using EsportsPortal.Services.Teams.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;
[Route("api/teams")]
[ApiController]
public class TeamsController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<TeamListItem>> GetTeams(CancellationToken cancellationToken)
    {
        var query = new GetTeamsQuery();
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{teamId:int}")]
    public async Task<TeamDetails> GetTeamDetails(int teamId, CancellationToken cancellationToken)
    {
        var query = new GetTeamDetailsQuery(teamId);
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{teamId:int}/players")]
    public async Task<IReadOnlyCollection<TeamPlayer>> GetTeamPlayers(int teamId, CancellationToken cancellationToken)
    {
        var query = new GetTeamPlayersQuery(teamId);
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{teamId:int}/coaches")]
    public async Task<IReadOnlyCollection<TeamCoach>> GetTeamCoaches(int teamId, CancellationToken cancellationToken)
    {
        var query = new GetTeamCoachesQuery(teamId);
        return await sender.Send(query, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = UserRole.Admin)]
    public async Task<int> CreateTeam(TeamCreateParams teamCreateParams, CancellationToken cancellationToken)
    {
        return await sender.Send(new CreateTeamCommand(teamCreateParams), cancellationToken);
    }

    [HttpPut("{teamId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateTeam(int teamId, TeamCreateParams teamUpdateParams, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateTeamCommand(teamId, teamUpdateParams), cancellationToken);
    }

    [HttpDelete("{teamId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task DeleteTeam(int teamId, CancellationToken cancellationToken)
    {
        await sender.Send(new DeleteTeamCommand(teamId), cancellationToken);
    }

    [HttpPut("{teamId:int}/logo")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateTeamLogo(int teamId, IFormFile file, CancellationToken cancellationToken)
    {
        using var stream = file.OpenReadStream();
        var uploadCommand = new UpdateTeamLogoCommand(teamId, stream, file.FileName);
        await sender.Send(uploadCommand, cancellationToken);
    }

    [HttpPut("{teamId:int}/players")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateTeamPlayers(int teamId, IReadOnlyCollection<int> playerIds, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateTeamPlayersCommand(teamId, playerIds), cancellationToken);
    }

    [HttpPut("{teamId:int}/coaches")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateTeamCoaches(int teamId, IReadOnlyCollection<int> coachIds, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateTeamCoachesCommand(teamId, coachIds), cancellationToken);
    }
}
