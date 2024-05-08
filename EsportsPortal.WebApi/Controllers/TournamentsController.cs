using EsportsPortal.Models.Users;
using EsportsPortal.Services.Matches.Dto;
using EsportsPortal.Services.Matches.Queries;
using EsportsPortal.Services.Tournaments.Commands;
using EsportsPortal.Services.Tournaments.Dto;
using EsportsPortal.Services.Tournaments.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;
[Route("api/tournaments")]
[ApiController]
public class TournamentsController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<TournamentListItem>> GetTournaments([FromQuery]TournamentFilter filter, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetTournamentsQuery(filter), cancellationToken);
    }

    [HttpGet("{tournamentId:int}")]
    public async Task<TournamentDetails> GetTournamentDetails(int tournamentId, CancellationToken cancellationToken)
    {
        var query = new GetTournamentDetailsQuery(tournamentId);
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{tournamentId:int}/teams")]
    public async Task<IReadOnlyCollection<TournamentTeamItem>> GetTournamentTeams(int tournamentId, CancellationToken cancellationToken)
    {
        var query = new GetTournamentTeamsQuery(tournamentId);
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{tournamentId:int}/matches")]
    public async Task<IReadOnlyCollection<MatchListItem>> GetTournamentMatches(int tournamentId, CancellationToken cancellationToken)
    {
        var query = new GetMatchesQuery(new MatchFilter { TournamentId = tournamentId });
        return await sender.Send(query, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = UserRole.Admin)]
    public async Task<int> CreateTournament(TournamentCreateParams tournamentCreateParams, CancellationToken cancellationToken)
    {
        return await sender.Send(new CreateTournamentCommand(tournamentCreateParams), cancellationToken);
    }

    [HttpPut("{tournamentId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateTournament(int tournamentId, TournamentCreateParams tournamentUpdateParams, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateTournamentCommand(tournamentId, tournamentUpdateParams), cancellationToken);
    }

    [HttpDelete("{tournamentId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task DeleteTournament(int tournamentId, CancellationToken cancellationToken)
    {
        await sender.Send(new DeleteTournamentCommand(tournamentId), cancellationToken);
    }

    [HttpPut("{tournamentId:int}/logo")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateTournamentLogo(int tournamentId, IFormFile file, CancellationToken cancellationToken)
    {
        using var stream = file.OpenReadStream();
        var uploadCommand = new UpdateTournamentLogoCommand(tournamentId, stream, file.FileName);
        await sender.Send(uploadCommand, cancellationToken);
    }

    [HttpPut("{tournamentId:int}/teams")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateTournamentTeams(int tournamentId, IReadOnlyCollection<int> teamIds, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateTournamentTeamsCommand(tournamentId, teamIds), cancellationToken);
    }

    [HttpPut("{tournamentId:int}/results")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateTournamentResults(int tournamentId, IReadOnlyCollection<TeamResultParams> results, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateTournamentResultsCommand(tournamentId, results), cancellationToken);
    }
}
