using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using MediatR;

namespace EsportsPortal.Services.Coaches.Commands;
public record DeleteCoachCommand(int CoachId) : IRequest;

internal class DeleteCoachCommandHandler(IEntityRepository<Coach> coachRepository)
    : IRequestHandler<DeleteCoachCommand>
{
    public async Task Handle(DeleteCoachCommand request, CancellationToken cancellationToken)
    {
        await coachRepository.DeleteAsync(request.CoachId, cancellationToken);
    }
}
