using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Matches.Dto;
using MediatR;

namespace EsportsPortal.Services.Matches.Queries;
public record GetMatchesQuery(MatchFilter Filter) : IRequest<IReadOnlyCollection<MatchListItem>>;

internal class GetMatchesQueryHandler(IEntityRepository<Match> matchRepository)
    : IRequestHandler<GetMatchesQuery, IReadOnlyCollection<MatchListItem>>
{
    public async Task<IReadOnlyCollection<MatchListItem>> Handle(GetMatchesQuery request, CancellationToken cancellationToken)
    {
        return await matchRepository.GetProjectedListAsync(request.Filter.GetExpression(),
            m => new MatchListItem
            {
                Id = m.Id,
                DateTime = m.DateTime,
                MatchFormat = m.MatchFormat,
                Team1 = new MatchTeam
                {
                    Id = m.Team1Id,
                    Name = m.Team1!.Name,
                    LogoFileName = m.Team1!.LogoFileName,
                    Points = m.Result != null ? m.Result.Team1MapWins : null,
                    IsWinner = m.Result != null ? m.Result.WinnerTeamId == m.Team1Id : null
                },
                Team2 = new MatchTeam
                {
                    Id = m.Team2Id,
                    Name = m.Team2!.Name,
                    LogoFileName = m.Team2!.LogoFileName,
                    Points = m.Result != null ? m.Result.Team2MapWins : null,
                    IsWinner = m.Result != null ? m.Result.WinnerTeamId == m.Team2Id : null
                }
            }, cancellationToken);
    }
}
