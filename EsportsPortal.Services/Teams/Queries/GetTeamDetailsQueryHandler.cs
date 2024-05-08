using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Teams.Dto;
using MediatR;

namespace EsportsPortal.Services.Teams.Queries;
public record GetTeamDetailsQuery(int TeamId) : IRequest<TeamDetails>;

internal class GetTeamDetailsQueryHandler(IEntityRepository<Team> teamRepository)
    : IRequestHandler<GetTeamDetailsQuery, TeamDetails>
{
    public async Task<TeamDetails> Handle(GetTeamDetailsQuery request, CancellationToken cancellationToken)
    {
        return await teamRepository.GetAsync(request.TeamId,
            t => new TeamDetails
            {
                Id = t.Id,
                Name = t.Name,
                LogoFileName = t.LogoFileName,
                Ranking = t.Ranking,
                RegionId = t.RegionId,
                RegionName = t.Region!.Name,
                RegionFlagFileName = t.Region.FlagFileName
            }, cancellationToken);
    }
}
