using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Tournaments.Dto;
using MediatR;

namespace EsportsPortal.Services.Tournaments.Queries;
public record GetTournamentsQuery(TournamentFilter Filter) : IRequest<IReadOnlyCollection<TournamentListItem>>;

internal class GetTournamentsQueryHandler(IEntityRepository<Tournament> tournamentRepository)
    : IRequestHandler<GetTournamentsQuery, IReadOnlyCollection<TournamentListItem>>
{
    public async Task<IReadOnlyCollection<TournamentListItem>> Handle(GetTournamentsQuery request, CancellationToken cancellationToken)
    {
        return await tournamentRepository.GetProjectedListAsync(request.Filter.GetExpression(),
            t => new TournamentListItem
            {
                Id = t.Id,
                Name = t.Name,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                City = t.Location!.City,
                CountryName = t.Location!.Country!.Name,
                CountryFlagFileName = t.Location!.Country!.FlagFileName,
                LogoFileName = t.LogoFileName
            }, cancellationToken);
    }
}
