using EsportsPortal.Models.Users;
using EsportsPortal.Services.Matches.Commands;
using EsportsPortal.Services.Matches.Dto;
using EsportsPortal.Services.Matches.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;
[Route("api/matches")]
[ApiController]
public class MatchesController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<MatchListItem>> GetMatches([FromQuery] MatchFilter filter, CancellationToken cancellationToken)
    {
        var query = new GetMatchesQuery(filter);
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{matchId:int}")]
    public async Task<MatchDetails> GetMatchDetails(int matchId, CancellationToken cancellationToken)
    {
        var query = new GetMatchDetailsQuery(matchId);
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{matchId:int}/maps")]
    public async Task<IReadOnlyCollection<MatchMapItem>> GetMatchMaps(int matchId, CancellationToken cancellationToken)
    {
        var query = new GetMatchMapsQuery(matchId);
        return await sender.Send(query, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = UserRole.Admin)]
    public async Task<int> CreateMatch(MatchCreateParams matchCreateParams, CancellationToken cancellationToken)
    {
        return await sender.Send(new CreateMatchCommand(matchCreateParams), cancellationToken);
    }

    [HttpPut("{matchId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateMatch(int matchId, MatchCreateParams matchUpdateParams, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateMatchCommand(matchId, matchUpdateParams), cancellationToken);
    }

    [HttpDelete("{matchId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task DeleteMatch(int matchId, CancellationToken cancellationToken)
    {
        await sender.Send(new DeleteMatchCommand(matchId), cancellationToken);
    }

    [HttpPut("{matchId:int}/maps")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateMatchMaps(int matchId, IReadOnlyCollection<int> mapIds, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateMatchMapsCommand(matchId, mapIds), cancellationToken);
    }

    [HttpPut("{matchId:int}/results")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateMatchResults(int matchId, IReadOnlyCollection<MapResultParams> results, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateMatchResultsCommand(matchId, results), cancellationToken);
    }
}
