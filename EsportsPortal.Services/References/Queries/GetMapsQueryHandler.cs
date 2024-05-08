using EsportsPortal.Models.References;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.References.Dto;
using MediatR;

namespace EsportsPortal.Services.References.Queries;
public record GetMapsQuery() : IRequest<IReadOnlyCollection<MapListItem>>;

internal class GetMapsQueryHandler(IEntityRepository<Map> mapRepository)
    : IRequestHandler<GetMapsQuery, IReadOnlyCollection<MapListItem>>
{
    public async Task<IReadOnlyCollection<MapListItem>> Handle(GetMapsQuery request, CancellationToken cancellationToken)
    {
        return await mapRepository.GetProjectedListAsync(
            r => new MapListItem(r.Id, r.Name, r.ImageFileName), cancellationToken);
    }
}
