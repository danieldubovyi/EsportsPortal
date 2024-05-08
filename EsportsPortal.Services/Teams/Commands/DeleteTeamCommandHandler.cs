using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using MediatR;

namespace EsportsPortal.Services.Teams.Commands;
public record DeleteTeamCommand(int TeamId) : IRequest;

internal class DeleteTeamCommandHandler(IEntityRepository<Team> teamsRepository)
    : IRequestHandler<DeleteTeamCommand>
{
    public async Task Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        await teamsRepository.DeleteAsync(request.TeamId, cancellationToken);
    }
}
