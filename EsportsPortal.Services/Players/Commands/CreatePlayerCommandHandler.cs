using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Players.Dto;
using MediatR;

namespace EsportsPortal.Services.Players.Commands;
public record CreatePlayerCommand(PlayerCreateParams CreateParams) : IRequest<int>;

internal class CreatePlayerCommandHandler(IEntityRepository<Player> playerRepository)
    : IRequestHandler<CreatePlayerCommand, int>
{
    public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Player
        {
            FirstName = request.CreateParams.FirstName,
            LastName = request.CreateParams.LastName,
            Nickname = request.CreateParams.Nickname,
            DateOfBirth = request.CreateParams.DateOfBirth,
            CountryId = request.CreateParams.CountryId,
            Rating = request.CreateParams.Rating,
            Role = request.CreateParams.Role,
            TeamId = request.CreateParams.TeamId
        };

        await playerRepository.CreateAsync(player, cancellationToken);

        return player.Id;
    }
}
