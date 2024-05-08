using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using MediatR;

namespace EsportsPortal.Services.Teams.Commands;
public record UpdateTeamPlayersCommand(int TeamId, IReadOnlyCollection<int> PlayerIds) : IRequest;

internal class UpdateTeamPlayersCommandHandler(IEntityRepository<Player> playerRepository)
    : IRequestHandler<UpdateTeamPlayersCommand>
{
    public async Task Handle(UpdateTeamPlayersCommand request, CancellationToken cancellationToken)
    {
        var players = await playerRepository.GetListAsync(p => p.TeamId == request.TeamId || request.PlayerIds.Contains(p.Id),  cancellationToken);

        foreach (var player in players)
        {
            player.TeamId = request.PlayerIds.Contains(player.Id) ? request.TeamId : null;
        }

        await playerRepository.UpdateAsync(players, cancellationToken);
    }
}
