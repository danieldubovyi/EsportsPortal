using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Coaches.Dto;
using MediatR;

namespace EsportsPortal.Services.Coaches.Commands;
public record UpdateCoachCommand(int CoachId, CoachCreateParams UpdateParams) : IRequest;

internal class UpdateCoachCommandHandler(IEntityRepository<Coach> coachRepository)
    : IRequestHandler<UpdateCoachCommand>
{
    public async Task Handle(UpdateCoachCommand request, CancellationToken cancellationToken)
    {
        var coach = await coachRepository.GetAsync(request.CoachId, cancellationToken);
        coach.FirstName = request.UpdateParams.FirstName;
        coach.LastName = request.UpdateParams.LastName;
        coach.Nickname = request.UpdateParams.Nickname;
        coach.DateOfBirth = request.UpdateParams.DateOfBirth;
        coach.CountryId = request.UpdateParams.CountryId;
        coach.TeamId = request.UpdateParams.TeamId;

        await coachRepository.UpdateAsync(coach, cancellationToken);
    }
}
