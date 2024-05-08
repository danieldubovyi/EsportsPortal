using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Teams.Dto;
using MediatR;

namespace EsportsPortal.Services.Teams.Queries;
public record GetTeamPlayersQuery(int TeamId) : IRequest<IReadOnlyCollection<TeamPlayer>>;

internal class GetTeamPlayersQueryHandler(IEntityRepository<Player> playerRepository)
    : IRequestHandler<GetTeamPlayersQuery, IReadOnlyCollection<TeamPlayer>>
{
    public async Task<IReadOnlyCollection<TeamPlayer>> Handle(GetTeamPlayersQuery request, CancellationToken cancellationToken)
    {
        return await playerRepository.GetProjectedListAsync(
            p => p.TeamId == request.TeamId,
            p => new TeamPlayer
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Nickname = p.Nickname,
                PhotoFileName = p.PhotoFileName,
            }, cancellationToken);
    }
}
