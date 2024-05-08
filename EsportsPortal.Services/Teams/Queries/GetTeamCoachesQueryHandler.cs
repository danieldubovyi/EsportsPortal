using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Teams.Dto;
using MediatR;

namespace EsportsPortal.Services.Teams.Queries;
public record GetTeamCoachesQuery(int TeamId) : IRequest<IReadOnlyCollection<TeamCoach>>;

internal class GetTeamCoachesQueryHandler(IEntityRepository<Coach> coachRepository)
    : IRequestHandler<GetTeamCoachesQuery, IReadOnlyCollection<TeamCoach>>
{
    public async Task<IReadOnlyCollection<TeamCoach>> Handle(GetTeamCoachesQuery request, CancellationToken cancellationToken)
    {
        return await coachRepository.GetProjectedListAsync(
            c => c.TeamId == request.TeamId,
            c => new TeamCoach
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Nickname = c.Nickname,
                PhotoFileName = c.PhotoFileName,
            }, cancellationToken);
    }
}
