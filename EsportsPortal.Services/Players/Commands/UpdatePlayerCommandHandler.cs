using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Players.Dto;
using MediatR;

namespace EsportsPortal.Services.Players.Commands;
public record UpdatePlayerCommand(int PlayerId, PlayerCreateParams UpdateParams) : IRequest;

internal class UpdatePlayerCommandHandler(IEntityRepository<Player> playerRepository)
    : IRequestHandler<UpdatePlayerCommand>
{
    public async Task Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = await playerRepository.GetAsync(request.PlayerId, cancellationToken);
        player.FirstName = request.UpdateParams.FirstName;
        player.LastName = request.UpdateParams.LastName;
        player.Nickname = request.UpdateParams.Nickname;
        player.DateOfBirth = request.UpdateParams.DateOfBirth;
        player.Rating = request.UpdateParams.Rating;
        player.Role = request.UpdateParams.Role;
        player.CountryId = request.UpdateParams.CountryId;
        player.TeamId = request.UpdateParams.TeamId;

        await playerRepository.UpdateAsync(player, cancellationToken);
    }
}
