using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Tournaments.Dto;
using MediatR;

namespace EsportsPortal.Services.Tournaments.Queries;
public record GetTournamentTeamsQuery(int TournametId) : IRequest<IReadOnlyCollection<TournamentTeamItem>>;

internal class GetTournamentTeamsQueryHandler(IEntityRepository<TournamentTeam> tournamentTemRepository)
    : IRequestHandler<GetTournamentTeamsQuery, IReadOnlyCollection<TournamentTeamItem>>
{
    public async Task<IReadOnlyCollection<TournamentTeamItem>> Handle(GetTournamentTeamsQuery request, CancellationToken cancellationToken)
    {
        return await tournamentTemRepository.GetProjectedListAsync(t => t.TournamentId == request.TournametId,
            t => new TournamentTeamItem
            {
                Id = t.TeamId,
                Name = t.Team!.Name,
                LogoFileName = t.Team.LogoFileName,
                RegionName = t.Team!.Region!.Name,
                RegionFlagFileName = t.Team.Region.FlagFileName,
                Place = t.Place,
                Prize = t.Prize
            }, cancellationToken);
    }
}
