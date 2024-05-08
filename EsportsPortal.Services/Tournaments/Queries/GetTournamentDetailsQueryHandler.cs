using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Tournaments.Dto;
using MediatR;

namespace EsportsPortal.Services.Tournaments.Queries;
public record GetTournamentDetailsQuery(int TournamentId) : IRequest<TournamentDetails>;

internal class GetTournamentDetailsQueryHandler(IEntityRepository<Tournament> tournamentRepository)
    : IRequestHandler<GetTournamentDetailsQuery, TournamentDetails>
{
    public async Task<TournamentDetails> Handle(GetTournamentDetailsQuery request, CancellationToken cancellationToken)
    {
        return await tournamentRepository.GetAsync(request.TournamentId,
            t => new TournamentDetails
            {
                Id = t.Id,
                Name = t.Name,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                PrizePool = t.PrizePool,
                LocationId = t.LocationId,
                City = t.Location!.City,
                CountryName = t.Location!.Country!.Name,
                CountryFlagFileName = t.Location!.Country!.FlagFileName,
                LogoFileName = t.LogoFileName
            }, cancellationToken);
    }
}
