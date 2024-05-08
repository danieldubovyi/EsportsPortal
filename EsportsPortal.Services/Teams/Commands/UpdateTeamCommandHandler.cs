using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Teams.Dto;
using MediatR;

namespace EsportsPortal.Services.Teams.Commands;
public record UpdateTeamCommand(int TeamId, TeamCreateParams UpdateParams) : IRequest;

internal class UpdateTeamCommandHandler(IEntityRepository<Team> teamRepository)
    : IRequestHandler<UpdateTeamCommand>
{
    public async Task Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetAsync(request.TeamId, cancellationToken);
        team.Name = request.UpdateParams.Name;
        team.RegionId = request.UpdateParams.RegionId;
        team.Ranking = request.UpdateParams.Ranking;

        await teamRepository.UpdateAsync(team, cancellationToken);
    }
}
