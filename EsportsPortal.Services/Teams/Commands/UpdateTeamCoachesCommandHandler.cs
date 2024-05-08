using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using MediatR;

namespace EsportsPortal.Services.Teams.Commands;
public record UpdateTeamCoachesCommand(int TeamId, IReadOnlyCollection<int> CoachIds) : IRequest;

internal class UpdateTeamCoachesCommandHandler(IEntityRepository<Coach> coachRepository)
    : IRequestHandler<UpdateTeamCoachesCommand>
{
    public async Task Handle(UpdateTeamCoachesCommand request, CancellationToken cancellationToken)
    {
        var coaches = await coachRepository.GetListAsync(c => c.TeamId == request.TeamId || request.CoachIds.Contains(c.Id),  cancellationToken);

        foreach (var coach in coaches)
        {
            coach.TeamId = request.CoachIds.Contains(coach.Id) ? request.TeamId : null;
        }

        await coachRepository.UpdateAsync(coaches, cancellationToken);
    }
}
