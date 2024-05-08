using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using MediatR;

namespace EsportsPortal.Services.Players.Commands;
public record DeletePlayerCommand(int PlayerId) : IRequest;

internal class DeletePlayerCommandHandler(IEntityRepository<Player> playerRepository)
    : IRequestHandler<DeletePlayerCommand>
{
    public async Task Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
    {
        await playerRepository.DeleteAsync(request.PlayerId, cancellationToken);
    }
}
