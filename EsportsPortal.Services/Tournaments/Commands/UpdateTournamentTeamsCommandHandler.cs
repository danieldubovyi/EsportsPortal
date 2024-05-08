using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using MediatR;

namespace EsportsPortal.Services.Tournaments.Commands;
public record UpdateTournamentTeamsCommand(int TournamentId, IReadOnlyCollection<int> TeamIds) : IRequest;

internal class UpdateTournamentTeamsCommandHandler(IEntityRepository<TournamentTeam> tournamentTeamRepository)
    : IRequestHandler<UpdateTournamentTeamsCommand>
{
    public async Task Handle(UpdateTournamentTeamsCommand request, CancellationToken cancellationToken)
    {
        var teams = await tournamentTeamRepository.GetListAsync(p => p.TournamentId == request.TournamentId, cancellationToken);

        var teamsToDelete = teams
            .Where(t => !request.TeamIds.Contains(t.TeamId))
            .ToArray();
        var teamsToCreate = request.TeamIds
            .Except(teams.Select(t => t.TeamId))
            .Select(teamId => new TournamentTeam { TournamentId = request.TournamentId, TeamId = teamId})
            .ToArray();

        await tournamentTeamRepository.MergeAsync(teamsToCreate, Array.Empty<TournamentTeam>(), teamsToDelete, cancellationToken);
    }
}
