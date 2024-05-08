using EsportsPortal.Models.References;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.References.Dto;
using MediatR;

namespace EsportsPortal.Services.References.Queries;
public record GetLocationsQuery() : IRequest<IReadOnlyCollection<LocationListItem>>;

internal class GetLocationsQueryHandler(IEntityRepository<Location> locationRepository)
    : IRequestHandler<GetLocationsQuery, IReadOnlyCollection<LocationListItem>>
{
    public async Task<IReadOnlyCollection<LocationListItem>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        return await locationRepository.GetProjectedListAsync(
            r => new LocationListItem(r.Id, r.City, r.CountryId, r.Country!.Name, r.Country!.FlagFileName), cancellationToken);
    }
}
