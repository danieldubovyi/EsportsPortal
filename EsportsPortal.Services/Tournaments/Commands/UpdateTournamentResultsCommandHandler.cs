using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Tournaments.Dto;
using MediatR;

namespace EsportsPortal.Services.Tournaments.Commands;
public record UpdateTournamentResultsCommand(int TournamentId, IReadOnlyCollection<TeamResultParams> Results) : IRequest;

internal class UpdateTournamentResultsCommandHandler(IEntityRepository<TournamentTeam> tournamentTeamRepository)
    : IRequestHandler<UpdateTournamentResultsCommand>
{
    public async Task Handle(UpdateTournamentResultsCommand request, CancellationToken cancellationToken)
    {
        var teams = await tournamentTeamRepository.GetListAsync(t => t.TournamentId == request.TournamentId, cancellationToken);

        foreach (var team in teams)
        {
            var result = request.Results.FirstOrDefault(r => r.TeamId == team.TeamId);
            team.Place = result?.Place;
            team.Prize = result?.Prize;
        }

        await tournamentTeamRepository.UpdateAsync(teams, cancellationToken);
    }
}
