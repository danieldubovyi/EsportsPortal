using EsportsPortal.Models.References;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.References.Dto;
using MediatR;

namespace EsportsPortal.Services.References.Queries;
public record GetCountriesQuery() : IRequest<IReadOnlyCollection<CountryListItem>>;

internal class GetCountriesQueryHandler(IEntityRepository<Country> countryRepository)
    : IRequestHandler<GetCountriesQuery, IReadOnlyCollection<CountryListItem>>
{
    public async Task<IReadOnlyCollection<CountryListItem>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        return await countryRepository.GetProjectedListAsync(
            r => new CountryListItem(r.Id, r.Name, r.FlagFileName), cancellationToken);
    }
}
