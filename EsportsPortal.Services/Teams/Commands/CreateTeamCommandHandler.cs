using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Teams.Dto;
using MediatR;

namespace EsportsPortal.Services.Teams.Commands;
public record CreateTeamCommand(TeamCreateParams CreateParams) : IRequest<int>;

internal class CreateTeamCommandHandler(IEntityRepository<Team> teamsRepository)
    : IRequestHandler<CreateTeamCommand, int>
{
    public async Task<int> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team
        {
            Name = request.CreateParams.Name,
            RegionId = request.CreateParams.RegionId,
            Ranking = request.CreateParams.Ranking
        };

        await teamsRepository.CreateAsync(team, cancellationToken);

        return team.Id;
    }
}
