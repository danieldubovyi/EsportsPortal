using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Coaches.Dto;
using MediatR;

namespace EsportsPortal.Services.Coaches.Commands;
public record CreateCoachCommand(CoachCreateParams CreateParams) : IRequest<int>;

internal class CreateCoachCommandHandler(IEntityRepository<Coach> coachRepository)
    : IRequestHandler<CreateCoachCommand, int>
{
    public async Task<int> Handle(CreateCoachCommand request, CancellationToken cancellationToken)
    {
        var coach = new Coach
        {
            FirstName = request.CreateParams.FirstName,
            LastName = request.CreateParams.LastName,
            Nickname = request.CreateParams.Nickname,
            DateOfBirth = request.CreateParams.DateOfBirth,
            CountryId = request.CreateParams.CountryId,
            TeamId = request.CreateParams.TeamId
        };

        await coachRepository.CreateAsync(coach, cancellationToken);

        return coach.Id;
    }
}
