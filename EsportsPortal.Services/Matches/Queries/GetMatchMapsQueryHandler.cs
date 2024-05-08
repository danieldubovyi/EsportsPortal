using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Matches.Dto;
using MediatR;

namespace EsportsPortal.Services.Matches.Queries;
public record GetMatchMapsQuery(int MatchId) : IRequest<IReadOnlyCollection<MatchMapItem>>;

internal class GetMatchMapsQueryHandler(IEntityRepository<MatchMap> matchMapRepository)
    : IRequestHandler<GetMatchMapsQuery, IReadOnlyCollection<MatchMapItem>>
{
    public async Task<IReadOnlyCollection<MatchMapItem>> Handle(GetMatchMapsQuery request, CancellationToken cancellationToken)
    {
        return await matchMapRepository.GetProjectedListAsync(m => m.MatchId == request.MatchId,
            m => new MatchMapItem
            {
                Id = m.MapId,
                Name = m.Map!.Name,
                ImageFileName = m.Map!.ImageFileName,
                Team1 = new MatchTeam
                {
                    Id = m.Match!.Team1Id,
                    Name = m.Match!.Team1!.Name,
                    LogoFileName = m.Match!.Team1!.LogoFileName,
                    Points = m.Result != null ? m.Result.Team1RoundWins : null,
                    IsWinner = m.Result != null ? m.Result.WinnerTeamId == m.Match.Team1Id : null
                },
                Team2 = new MatchTeam
                {
                    Id = m.Match!.Team2Id,
                    Name = m.Match!.Team2!.Name,
                    LogoFileName = m.Match!.Team2!.LogoFileName,
                    Points = m.Result != null ? m.Result.Team2RoundWins : null,
                    IsWinner = m.Result != null ? m.Result.WinnerTeamId == m.Match.Team2Id : null
                }
            }, cancellationToken);
    }
}
