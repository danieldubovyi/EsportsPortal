using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Teams.Dto;
using MediatR;

namespace EsportsPortal.Services.Teams.Queries;

public record GetTeamsQuery : IRequest<IReadOnlyCollection<TeamListItem>>;

internal class GetTeamsQueryHandler(IEntityRepository<Team> teamRepository)
    : IRequestHandler<GetTeamsQuery, IReadOnlyCollection<TeamListItem>>
{
    public async Task<IReadOnlyCollection<TeamListItem>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
    {
        return await teamRepository.GetProjectedListAsync(
            t => new TeamListItem
            {
                Id = t.Id,
                Name = t.Name,
                LogoFileName = t.LogoFileName,
                Ranking = t.Ranking,
                RegionName = t.Region!.Name,
                RegionFlagFileName = t.Region.FlagFileName
            }, cancellationToken);
    }
}
