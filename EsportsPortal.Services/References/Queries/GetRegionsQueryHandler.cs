using EsportsPortal.Models.References;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.References.Dto;
using MediatR;

namespace EsportsPortal.Services.References.Queries;
public record GetRegionsQuery() : IRequest<IReadOnlyCollection<RegionListItem>>;

internal class GetRegionsQueryHandler(IEntityRepository<Region> regionRepository)
    : IRequestHandler<GetRegionsQuery, IReadOnlyCollection<RegionListItem>>
{
    public async Task<IReadOnlyCollection<RegionListItem>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        return await regionRepository.GetProjectedListAsync(
            r => new RegionListItem(r.Id, r.Name, r.FlagFileName), cancellationToken);
    }
}
