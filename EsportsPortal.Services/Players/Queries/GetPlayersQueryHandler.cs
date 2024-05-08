using System.Linq.Expressions;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Players.Dto;
using MediatR;

namespace EsportsPortal.Services.Players.Queries;
public record GetPlayersQuery(bool? NotInTeam) : IRequest<IReadOnlyCollection<PlayerListItem>>;

internal class GetPlayersQueryHandler(
    IEntityRepository<Player> playerRepository)
    : IRequestHandler<GetPlayersQuery, IReadOnlyCollection<PlayerListItem>>
{
    public async Task<IReadOnlyCollection<PlayerListItem>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        var filter = GetFilter(request);

        return await playerRepository.GetProjectedListAsync(filter,
            p => new PlayerListItem
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Nickname = p.Nickname,
                PhotoFileName = p.PhotoFileName,
                Rating = p.Rating,
                TeamName = p.Team!.Name,
                TeamLogoFileName = p.Team!.LogoFileName
            }, cancellationToken);
    }

    private static Expression<Func<Player, bool>>? GetFilter(GetPlayersQuery query)
    {
        List<Expression<Func<Player, bool>>> expressions = [];

        if (query.NotInTeam.HasValue)
        {
            if (query.NotInTeam.Value)
            {
                expressions.Add(p => p.TeamId == null);
            }
            else
            {
                expressions.Add(p => p.TeamId != null);
            }
        }

        return expressions.ToAndExpression();
    }
}
